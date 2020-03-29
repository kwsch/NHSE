using System.IO;

namespace NHSE.Core
{
    /// <summary>
    /// Logic for loading decrypted game files.
    /// </summary>
    /// <seealso cref="GameFileDumper"/>
    public static class GameFileLoader
    {
        /// <summary>
        /// Loads a copy of the <see cref="sav"/>'s files in their decrypted state from the requested <see cref="path"/>.
        /// </summary>
        /// <param name="sav">Save Data to load</param>
        /// <param name="path">Path to load from</param>
        public static void Load(this HorizonSave sav, string path)
        {
            sav.Main.Load(path);
            foreach (var p in sav.Players)
            {
                var dir = Path.Combine(path, p.DirectoryName);
                p.Load(dir);
            }
        }

        /// <summary>
        /// Loads a copy of the <see cref="player"/>'s files in their decrypted state from the requested <see cref="path"/>.
        /// </summary>
        /// <param name="player">Save Data to load</param>
        /// <param name="path">Path to load from</param>
        public static void Load(this Player player, string path)
        {
            foreach (var pair in player)
                pair.Load(path);
        }

        /// <summary>
        /// Loads the <see cref="pair"/>'s files in their decrypted state from the requested <see cref="path"/>.
        /// </summary>
        /// <param name="pair">Save Data to load</param>
        /// <param name="path">Path to load from</param>
        public static void Load(this EncryptedFilePair pair, string path)
        {
            Load(path, pair.Data, pair.NameData);
        }

        private static void Load(string path, byte[] data, string name)
        {
            if (!Directory.Exists(path))
                return;

            var file = Path.Combine(path, name);
            if (!File.Exists(file))
                return;

            var import = File.ReadAllBytes(file);
            if (data.Length != import.Length)
                return;

            import.CopyTo(data, 0);
        }
    }
}