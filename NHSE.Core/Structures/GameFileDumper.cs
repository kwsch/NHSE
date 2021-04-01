using System;
using System.Collections.Generic;
using System.IO;

namespace NHSE.Core
{
    /// <summary>
    /// Logic for dumping decrypted game files.
    /// </summary>
    /// <seealso cref="GameFileLoader"/>
    public static class GameFileDumper
    {
        /// <summary>
        /// Dumps a copy of the <see cref="sav"/>'s files in their decrypted state to the requested <see cref="path"/>.
        /// </summary>
        /// <param name="sav">Save Data to dump</param>
        /// <param name="path">Path to dump to</param>
        public static void Dump(this HorizonSave sav, string path)
        {
            sav.Main.Dump(path);
            foreach (var p in sav.Players)
            {
                var dir = Path.Combine(path, p.DirectoryName);
                p.Dump(dir);
            }
        }

        /// <summary>
        /// Dumps a copy of the <see cref="player"/>'s files in their decrypted state to the requested <see cref="path"/>.
        /// </summary>
        /// <param name="player">Save Data to dump</param>
        /// <param name="path">Path to dump to</param>
        public static void Dump(this Player player, string path)
        {
            foreach (var pair in player)
                pair.Dump(path);
        }

        /// <summary>
        /// Dumps a copy of the <see cref="pair"/>'s files in their decrypted state to the requested <see cref="path"/>.
        /// </summary>
        /// <param name="pair">Save Data to dump</param>
        /// <param name="path">Path to dump to</param>
        public static void Dump(this EncryptedFilePair pair, string path)
        {
            Dump(path, pair.Data, pair.NameData);
        }

        private static void Dump(string path, byte[] data, string name)
        {
            Directory.CreateDirectory(path);
            var file = Path.Combine(path, name);
            File.WriteAllBytes(file, data);
        }

        /// <summary>
        /// Dumps all villager houses to the requested <see cref="path"/>.
        /// </summary>
        /// <param name="houses"></param>
        /// <param name="players"></param>
        /// <param name="path">Path to dump to</param>
        public static void DumpPlayerHouses(this IReadOnlyList<PlayerHouse> houses, IReadOnlyList<Player> players, string path)
        {
            for (int i = 0; i < houses.Count; i++)
            {
                var filename = i < players.Count ? players[i].Personal.PlayerName : $"House {i}";
                houses[i].Dump(filename, path);
            }
        }

        /// <summary>
        /// Dumps all villager houses to the requested <see cref="path"/>.
        /// </summary>
        /// <param name="sav">Save Data to dump from</param>
        /// <param name="path">Path to dump to</param>
        public static void DumpPlayerHouses(this HorizonSave sav, string path)
        {
            var count = Math.Min(sav.Players.Length, MainSaveOffsets.PlayerCount);
            for (int i = 0; i < count; i++)
            {
                var p = sav.Players[i];
                var h = sav.Main.GetPlayerHouse(i);
                h.Dump(path, p.Personal);
            }
        }

        private static void Dump(this PlayerHouse h, string path, IVillagerOrigin p) => h.Dump(p.PlayerName, path);

        private static void Dump(this PlayerHouse h, string player, string path)
        {
            var dest = Path.Combine(path, $"{player}.nhph");
            var data = h.Data;
            File.WriteAllBytes(dest, data);
        }

        /// <summary>
        /// Dumps all villager houses to the requested <see cref="path"/>.
        /// </summary>
        /// <param name="sav">Save Data to dump from</param>
        /// <param name="path">Path to dump to</param>
        public static void DumpVillagerHouses(this MainSave sav, string path)
        {
            for (int i = 0; i < MainSaveOffsets.VillagerCount; i++)
            {
                var v = sav.GetVillager(i);
                var h = sav.GetVillagerHouse(i);
                h.Dump(path, v);
            }
        }

        private static void Dump(this VillagerHouse h, string path, IVillager v)
        {
            var name = GameInfo.Strings.GetVillager(v.InternalName);
            var dest = Path.Combine(path, $"{name}.nhvh");
            var data = h.Data;
            File.WriteAllBytes(dest, data);
        }

        /// <summary>
        /// Dumps all villagers to the requested <see cref="path"/>.
        /// </summary>
        /// <param name="villagers">Data to dump from</param>
        /// <param name="path">Path to dump to</param>
        public static void Dump(this IEnumerable<IVillager> villagers, string path)
        {
            foreach (var v in villagers)
                v.Dump(path);
        }

        private static void Dump(this IVillager v, string path)
        {
            var name = GameInfo.Strings.GetVillager(v.InternalName);
            var dest = Path.Combine(path, $"{name}.{v.Extension}");
            File.WriteAllBytes(dest, v.Write());
        }

        /// <summary>
        /// Dumps all designs to the requested <see cref="path"/>.
        /// </summary>
        /// <param name="sav">Save Data to dump from</param>
        /// <param name="path">Path to dump to</param>
        public static void DumpDesigns(this MainSave sav, string path)
        {
            for (int i = 0; i < sav.Offsets.PatternCount; i++)
            {
                var dp = sav.GetDesign(i);
                dp.Dump(path, i);
            }
        }

        /// <summary>
        /// Dumps all designs to the requested <see cref="path"/>.
        /// </summary>
        /// <param name="patterns">Patterns to dump</param>
        /// <param name="path">Path to dump to</param>
        public static void Dump(this IReadOnlyList<DesignPattern> patterns, string path)
        {
            for (var index = 0; index < patterns.Count; index++)
            {
                var dp = patterns[index];
                dp.Dump(path, index);
            }
        }

        private static void Dump(this DesignPattern dp, string path, int index)
        {
            // Dump without index
            var name = dp.DesignName;
            var fn = StringUtil.CleanFileName($"{name}.nhd");
            var dest = Path.Combine(path, fn);
            File.WriteAllBytes(dest, dp.Data);

            // Dump with index
            fn = StringUtil.CleanFileName($"{index:00} - {name}.nhd");
            dest = Path.Combine(path, fn);
            File.WriteAllBytes(dest, dp.Data);
        }

        /// <summary>
        /// Loads all designs from the requested <see cref="path"/>.
        /// </summary>
        /// <param name="patterns">Patterns to load</param>
        /// <param name="path">Path to load from</param>
        public static void Load(this DesignPattern[] patterns, string path)
        {
            if (patterns.Length == 0)
                return;

            var files = Directory.GetFiles(path, "*.nhd", SearchOption.TopDirectoryOnly);
            int ctr = 0;
            foreach (var f in files)
            {
                var fi = new FileInfo(f);
                if (fi.Length != DesignPattern.SIZE)
                    continue;

                var data = File.ReadAllBytes(f);
                var p = new DesignPattern(data);
                p.ChangeOrigins(patterns[ctr], data);
                patterns[ctr] = p;
                if (++ctr >= patterns.Length)
                    break;
            }
        }

        /// <summary>
        /// Dumps all designs to the requested <see cref="path"/>.
        /// </summary>
        /// <param name="sav">Save Data to dump from</param>
        /// <param name="path">Path to dump to</param>
        public static void DumpDesignsPRO(this MainSave sav, string path)
        {
            for (int i = 0; i < sav.Offsets.PatternCount; i++)
            {
                var dp = sav.GetDesignPRO(i);
                dp.Dump(path, i);
            }
        }

        /// <summary>
        /// Dumps all designs to the requested <see cref="path"/>.
        /// </summary>
        /// <param name="patterns">Patterns to dump</param>
        /// <param name="path">Path to dump to</param>
        public static void Dump(this IReadOnlyList<DesignPatternPRO> patterns, string path)
        {
            for (var index = 0; index < patterns.Count; index++)
            {
                var dp = patterns[index];
                dp.Dump(path, index);
            }
        }

        /// <summary>
        /// Loads all designs from the requested <see cref="path"/>.
        /// </summary>
        /// <param name="patterns">Patterns to load</param>
        /// <param name="path">Path to load from</param>
        public static void Load(this DesignPatternPRO[] patterns, string path)
        {
            if (patterns.Length == 0)
                return;

            var files = Directory.GetFiles(path, "*.nhpd", SearchOption.TopDirectoryOnly);
            int ctr = 0;
            foreach (var f in files)
            {
                var fi = new FileInfo(f);
                if (fi.Length != DesignPatternPRO.SIZE)
                    continue;

                var data = File.ReadAllBytes(f);
                var p = new DesignPatternPRO(data);
                p.ChangeOrigins(patterns[ctr], data);
                patterns[ctr] = p;
                if (++ctr >= patterns.Length)
                    break;
            }
        }

        private static void Dump(this DesignPatternPRO dp, string path, int index)
        {
            // Dump without index
            var name = dp.DesignName;
            var fn = StringUtil.CleanFileName($"{name}.nhpd");
            var dest = Path.Combine(path, fn);
            File.WriteAllBytes(dest, dp.Data);

            // Dump with index
            fn = StringUtil.CleanFileName($"{index:00} - {name}.nhpd");
            dest = Path.Combine(path, fn);
            File.WriteAllBytes(dest, dp.Data);
        }
    }
}
