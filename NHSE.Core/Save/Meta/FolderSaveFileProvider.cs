using System;
using System.IO;

namespace NHSE.Core;

/// <summary>
/// Provides file access from a filesystem folder.
/// </summary>
/// <remarks>
/// Creates a provider rooted at the specified folder path.
/// </remarks>
/// <param name="rootPath">Absolute path to the save folder.</param>
public sealed class FolderSaveFileProvider(string rootPath) : ISaveFileProvider
{
    public byte[] ReadFile(string relativePath)
    {
        var fullPath = Path.Combine(rootPath, relativePath);
        return File.ReadAllBytes(fullPath);
    }

    public void WriteFile(string relativePath, ReadOnlySpan<byte> data)
    {
        var fullPath = Path.Combine(rootPath, relativePath);
        File.WriteAllBytes(fullPath, data);
    }

    public bool FileExists(string relativePath)
    {
        var fullPath = Path.Combine(rootPath, relativePath);
        return File.Exists(fullPath);
    }

    public string[] GetDirectories(string searchPattern)
    {
        var dirs = Directory.GetDirectories(rootPath, searchPattern, SearchOption.TopDirectoryOnly);
        var result = new string[dirs.Length];
        for (int i = 0; i < dirs.Length; i++)
            result[i] = new DirectoryInfo(dirs[i]).Name;
        return result;
    }

    public ISaveFileProvider GetSubdirectoryProvider(string subdirectory)
    {
        var subPath = Path.Combine(rootPath, subdirectory);
        return new FolderSaveFileProvider(subPath);
    }

    public void Flush()
    {
        // No-op for folder provider; writes are immediate.
    }
}
