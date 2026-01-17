using System;

namespace NHSE.Core;

/// <summary>
/// Abstraction for reading and writing save files from different storage backends (folder, ZIP archive, etc.).
/// </summary>
public interface ISaveFileProvider
{
    /// <summary>
    /// Reads all bytes from the specified file path relative to the root.
    /// </summary>
    /// <param name="relativePath">Relative path to the file (e.g., "main.dat" or "Villager0/personal.dat").</param>
    /// <returns>Byte array containing the file contents.</returns>
    byte[] ReadFile(string relativePath);

    /// <summary>
    /// Writes all bytes to the specified file path relative to the root.
    /// </summary>
    /// <param name="relativePath">Relative path to the file.</param>
    /// <param name="data">Byte data to write.</param>
    void WriteFile(string relativePath, ReadOnlySpan<byte> data);

    /// <summary>
    /// Checks if a file exists at the specified relative path.
    /// </summary>
    /// <param name="relativePath">Relative path to the file.</param>
    /// <returns>True if the file exists; otherwise false.</returns>
    bool FileExists(string relativePath);

    /// <summary>
    /// Gets all subdirectory names matching the specified pattern relative to the root.
    /// </summary>
    /// <param name="searchPattern">Search pattern (e.g., "Villager*").</param>
    /// <returns>Array of matching directory names (not full paths).</returns>
    string[] GetDirectories(string searchPattern);

    /// <summary>
    /// Creates a child provider scoped to the specified subdirectory.
    /// </summary>
    /// <param name="subdirectory">Subdirectory name to scope to.</param>
    /// <returns>A new provider rooted at the subdirectory.</returns>
    ISaveFileProvider GetSubdirectoryProvider(string subdirectory);

    /// <summary>
    /// Flushes any pending writes to the underlying storage.
    /// For folder providers, this may be a no-op. For ZIP providers, this rebuilds and saves the archive.
    /// </summary>
    void Flush();
}
