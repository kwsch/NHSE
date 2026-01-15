using System;
using System.Collections.Generic;
using System.IO;
using static System.Buffers.Binary.BinaryPrimitives;

namespace NHSE.Core;

/// <summary>
/// Utility to scan save file parts for their hashed regions.
/// </summary>
/// <remarks>
/// Uses the same bruteforce approach as https://github.com/3096/effective-guacamole/blob/3bc30c4584cde0ebc526c1bfec3394ea1df1d475/generate_hash_sections/main.cpp
/// Data files are {gap, hash+(hashed-data)}[] where gap is up to 0x110 bytes of non-hashed data.
/// The gap is 0, 0x10, 0x100, or 0x110, but we'll check for % 0x10 increments.
/// Run this static method by feeding in your savedata folder path, and it will output to console.
///
/// ```csharp
/// const string folder = @"E:\acnh\matt30";
/// EffectiveGuacamole.DumpHashes(folder);
/// ```
/// </remarks>
public static class EffectiveGuacamole
{
    /// <summary>
    /// Writes out detected hash offsets and lengths for all files in the given folder.
    /// </summary>
    /// <param name="folder">Save folder to scan.</param>
    /// <param name="saveDecrypted">Whether to save decrypted files.</param>
    public static void DumpHashes(string folder, bool saveDecrypted = false)
    {
        // Scan for all .dat files
        var files = Directory.EnumerateFiles(folder, "*.dat", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            var name = Path.GetFileNameWithoutExtension(file);
            if (name.EndsWith("Header"))
                continue;

            var parent = Path.GetDirectoryName(file)!;
            DumpHashes(parent, name, saveDecrypted);
        }
    }

    public static void DumpHashes(string folder, string file, bool saveDecrypted = false)
    {
        // Ensure header exists for decryption
        var hdr = Path.Combine(folder, $"{file}Header.dat");
        if (!File.Exists(hdr))
            return;

        // Decrypt file
        var dat = Path.Combine(folder, $"{file}.dat");
        var hd = File.ReadAllBytes(hdr);
        var md = File.ReadAllBytes(dat);
        Encryption.Decrypt(hd, md);

        if (saveDecrypted)
        {
            var outPath = Path.Combine(folder, $"{file}.dec");
            File.WriteAllBytes(outPath, md);
        }

        // Brute-force scan for hashes
        var hashes = ScanHashes(md);

        // Output results
        Console.WriteLine(dat);
        foreach (var hash in hashes)
            Console.WriteLine($"(0x{hash.HashOffset:x6}, 0x{hash.HashLength:x6}),");
        Console.WriteLine();
    }

    public static List<(int HashOffset, int HashLength)> ScanHashes(ReadOnlySpan<byte> data)
    {
        var results = new List<(int HashOffset, int HashLength)>();
        if (TryPopulate(data, results, 0x100))
            return results;
        return [];
    }

    private static bool TryPopulate(ReadOnlySpan<byte> data, List<(int HashOffset, int HashLength)> results, int offset)
    {
        results.Clear();
        var gap = 0;
        while (true)
        {
            if (offset + 4 >= data.Length)
                break; // end

            var hash = ReadUInt32LittleEndian(data[offset..]);
            var possible = data[(offset + 4)..];

            var length = Murmur3.GetLength(possible, hash);
            if (length == -1)
            {
                if (gap >= 0x110) // max gap
                    throw new Exception("Max gap exceeded.");
                offset += 0x10;
                gap += 0x10;
                continue;
            }

            results.Add((offset, length));
            offset += 4 + length;
            gap = 0;
        }
        return results.Count != 0 && offset == data.Length;
    }
}