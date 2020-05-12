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

        private static void Dump(this VillagerHouse h, string path, Villager v)
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
        public static void Dump(this IEnumerable<Villager> villagers, string path)
        {
            foreach (var v in villagers)
                v.Dump(path);
        }

        private static void Dump(this Villager v, string path)
        {
            var name = GameInfo.Strings.GetVillager(v.InternalName);
            var dest = Path.Combine(path, $"{name}.nhv");
            File.WriteAllBytes(dest, v.Data);
        }

        /// <summary>
        /// Dumps all designs to the requested <see cref="path"/>.
        /// </summary>
        /// <param name="sav">Save Data to dump from</param>
        /// <param name="path">Path to dump to</param>
        public static void DumpDesigns(this MainSave sav, string path)
        {
            for (int i = 0; i < MainSaveOffsets.PatternCount; i++)
                sav.GetDesign(i).Dump(path);
        }

        /// <summary>
        /// Dumps all designs to the requested <see cref="path"/>.
        /// </summary>
        /// <param name="patterns">Patterns to dump</param>
        /// <param name="path">Path to dump to</param>
        public static void Dump(this IEnumerable<DesignPattern> patterns, string path)
        {
            foreach (var dp in patterns)
                dp.Dump(path);
        }

        private static void Dump(this DesignPattern dp, string path)
        {
            var name = dp.DesignName;
            var fn = StringUtil.CleanFileName($"{name}.nhd");
            var dest = Path.Combine(path, fn);
            File.WriteAllBytes(dest, dp.Data);
        }

        /// <summary>
        /// Dumps all designs to the requested <see cref="path"/>.
        /// </summary>
        /// <param name="sav">Save Data to dump from</param>
        /// <param name="path">Path to dump to</param>
        public static void DumpDesignsPRO(this MainSave sav, string path)
        {
            for (int i = 0; i < MainSaveOffsets.PatternCount; i++)
                sav.GetDesignPRO(i).Dump(path);
        }

        /// <summary>
        /// Dumps all designs to the requested <see cref="path"/>.
        /// </summary>
        /// <param name="patterns">Patterns to dump</param>
        /// <param name="path">Path to dump to</param>
        public static void Dump(this IEnumerable<DesignPatternPRO> patterns, string path)
        {
            foreach (var dp in patterns)
                dp.Dump(path);
        }

        private static void Dump(this DesignPatternPRO dp, string path)
        {
            var name = dp.DesignName;
            var fn = StringUtil.CleanFileName($"{name}.nhpd");
            var dest = Path.Combine(path, fn);
            File.WriteAllBytes(dest, dp.Data);
        }
    }
}
