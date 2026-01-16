using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace NHSE.Core;

/// <summary>
/// Provides file access from a ZIP archive. Loads contents into memory and rebuilds the archive on Flush.
/// </summary>
public sealed class ZipSaveFileProvider : ISaveFileProvider
{
    private string ZipPath { get; }
    private string BasePath { get; } = string.Empty;
    private Dictionary<string, byte[]> Files { get; } = [];
    private ZipSaveFileProvider? Root { get; }

    /// <summary>
    /// Creates a provider from a ZIP file path. The ZIP contents are loaded into memory.
    /// </summary>
    /// <param name="zipPath">Absolute path to the ZIP file.</param>
    public ZipSaveFileProvider(string zipPath)
    {
        ZipPath = zipPath;
        using var archive = ZipFile.OpenRead(ZipPath);
        LoadFromZip(archive);
    }

    private ZipSaveFileProvider(ZipSaveFileProvider root, string basePath)
    {
        ZipPath = root.ZipPath;
        BasePath = basePath;
        Files = root.Files;
        Root = root;
    }

    private void LoadFromZip(ZipArchive archive)
    {
        foreach (var entry in archive.Entries)
        {
            if (string.IsNullOrEmpty(entry.Name))
                continue; // Skip directory entries

            using var stream = entry.Open();
            using var ms = new MemoryStream((int)entry.Length);
            stream.CopyTo(ms);
            var key = NormalizePath(entry.FullName);
            Files[key] = ms.ToArray();
        }
    }

    private string GetFullKey(string relativePath)
    {
        var combined = string.IsNullOrEmpty(BasePath) ? relativePath : $"{BasePath}/{relativePath}";
        return NormalizePath(combined);
    }

    private static string NormalizePath(string path)
    {
        return path.Replace('\\', '/').TrimStart('/');
    }

    public byte[] ReadFile(string relativePath)
    {
        var key = GetFullKey(relativePath);
        if (!Files.TryGetValue(key, out var data))
            throw new FileNotFoundException($"File not found in ZIP: {key}");
        return data;
    }

    public void WriteFile(string relativePath, ReadOnlySpan<byte> data)
    {
        var key = GetFullKey(relativePath);
        Files[key] = data.ToArray();
    }

    public bool FileExists(string relativePath)
    {
        var key = GetFullKey(relativePath);
        return Files.ContainsKey(key);
    }

    public string[] GetDirectories(string searchPattern)
    {
        var prefix = string.IsNullOrEmpty(BasePath) ? string.Empty : BasePath + "/";
        var pattern = searchPattern.Replace("*", string.Empty);

        var directories = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var key in Files.Keys)
        {
            if (!key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                continue;

            var remainder = key[prefix.Length..];
            var slashIndex = remainder.IndexOf('/');
            if (slashIndex <= 0)
                continue;

            var dirName = remainder[..slashIndex];
            if (dirName.Contains(pattern, StringComparison.OrdinalIgnoreCase))
                directories.Add(dirName);
        }

        return [.. directories.Order()];
    }

    public ISaveFileProvider GetSubdirectoryProvider(string subdirectory)
    {
        var newBase = string.IsNullOrEmpty(BasePath) ? subdirectory : $"{BasePath}/{subdirectory}";
        var rootProvider = Root ?? this;
        return new ZipSaveFileProvider(rootProvider, NormalizePath(newBase));
    }

    public void Flush()
    {
        // Only the root provider can flush
        if (Root is not null)
        {
            Root.Flush();
            return;
        }

        // Write to a temporary file first, then replace the original
        var tempPath = ZipPath + ".tmp";
        try
        {
            using (var stream = new FileStream(tempPath, FileMode.Create, FileAccess.Write))
            using (var archive = new ZipArchive(stream, ZipArchiveMode.Create))
            {
                foreach (var (key, data) in Files.OrderBy(x => x.Key))
                {
                    var entry = archive.CreateEntry(key, CompressionLevel.Optimal);
                    using var entryStream = entry.Open();
                    entryStream.Write(data);
                }
            }

            // Replace original with temp
            File.Delete(ZipPath);
            File.Move(tempPath, ZipPath);
        }
        catch
        {
            // Clean up temp file on failure
            if (File.Exists(tempPath))
                File.Delete(tempPath);
            throw;
        }
    }
}
