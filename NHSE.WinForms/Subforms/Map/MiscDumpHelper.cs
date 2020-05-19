using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public static class MiscDumpHelper
    {
        public static void DumpVillagerMemoryPlayer(Villager v, GSaveMemory memory)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Villager Player Memory (*.nhvpm)|*.nhvpm|All files (*.*)|*.*",
                FileName = $"{v.InternalName}.nhvpm",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var data = memory.Data;
            File.WriteAllBytes(sfd.FileName, data);
        }

        public static bool LoadVillagerMemoryPlayer(Villager v, GSaveMemory[] memories, int index)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Villager Player Memory (*.nhvpm)|*.nhvpm|All files (*.*)|*.*",
                FileName = $"{v.InternalName}.nhvpm",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return false;

            var file = ofd.FileName;
            var fi = new FileInfo(file);
            const int expectLength = GSaveMemory.SIZE;
            if (fi.Length != expectLength)
            {
                WinFormsUtil.Error(MessageStrings.MsgCanceling, string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expectLength));
                return false;
            }

            var data = File.ReadAllBytes(file);
            var memory = new GSaveMemory(data);
            var old = memories[index];

            if (!memory.IsOriginatedFrom(old))
            {
                string msg = string.Format(MessageStrings.MsgDataDidNotOriginateFromHost_0, old.PlayerName);
                var result = WinFormsUtil.Prompt(MessageBoxButtons.YesNoCancel, msg, MessageStrings.MsgAskUpdateValues);
                if (result == DialogResult.Cancel)
                    return false;
                if (result == DialogResult.Yes)
                    memory.ChangeOrigins(old, memory.Data);
            }

            memories[index] = memory;
            return true;
        }

        public static void DumpMuseum(Museum museum)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Museum (*.nhm)|*.nhm|All files (*.*)|*.*",
                FileName = "museum.nhm",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var data = museum.Data;
            File.WriteAllBytes(sfd.FileName, data);
        }

        public static bool LoadMuseum(Museum museum)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Museum (*.nhm)|*.nhm|All files (*.*)|*.*",
                FileName = "museum.nhm",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return false;

            var file = ofd.FileName;
            var fi = new FileInfo(file);
            const int expectLength = Museum.SIZE;
            if (fi.Length != expectLength)
            {
                WinFormsUtil.Error(MessageStrings.MsgCanceling, string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expectLength));
                return false;
            }

            var data = File.ReadAllBytes(file);
            data.CopyTo(museum.Data);
            return true;
        }

        public static void DumpHouse(IReadOnlyList<Player> players, IReadOnlyList<PlayerHouse> houses, int index, bool dumpAll)
        {
            if (dumpAll)
                DumpAllPlayerHouses(houses, players);
            else
                DumpPlayerHouse(players, houses, index);
        }

        private static void DumpPlayerHouse(IReadOnlyList<Player> players, IReadOnlyList<PlayerHouse> houses, int index)
        {
            var house = houses[index];
            var name = PlayerHouseEditor.GetHouseSummary(players, house, index);
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Player House (*.nhph)|*.nhph|All files (*.*)|*.*",
                FileName = $"{name}.nhph",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var data = house.Data;
            File.WriteAllBytes(sfd.FileName, data);
        }

        private static void DumpAllPlayerHouses(IReadOnlyList<PlayerHouse> houses, IReadOnlyList<Player> players)
        {
            using var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() != DialogResult.OK)
                return;

            var dir = Path.GetDirectoryName(fbd.SelectedPath);
            if (dir == null || !Directory.Exists(dir))
                return;
            houses.DumpPlayerHouses(players, fbd.SelectedPath);
        }

        public static bool LoadHouse(IReadOnlyList<Player> players, PlayerHouse[] houses, int index)
        {
            var name = PlayerHouseEditor.GetHouseSummary(players, houses[index], index);
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Player House (*.nhph)|*.nhph|All files (*.*)|*.*",
                FileName = $"{name}.nhph",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return false;

            var file = ofd.FileName;
            var fi = new FileInfo(file);
            const int expectLength = PlayerHouse.SIZE;
            if (fi.Length != expectLength)
            {
                WinFormsUtil.Error(MessageStrings.MsgCanceling, string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expectLength));
                return false;
            }

            var data = File.ReadAllBytes(file);
            var h = new PlayerHouse(data);
            var current = houses[index];
            h.NPC1 = current.NPC1;
            houses[index] = h;
            return true;
        }

        public static void DumpRoom(PlayerRoom room, int index)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Player House Room (*.nhpr)|*.nhpr|All files (*.*)|*.*",
                FileName = $"Room {index + 1}.nhpr",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var data = room.Data;
            File.WriteAllBytes(sfd.FileName, data);
        }

        public static bool LoadRoom(PlayerRoom room, int index)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Player House Room (*.nhpr)|*.nhpr|All files (*.*)|*.*",
                FileName = $"Room {index + 1}.nhpr",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return false;

            var file = ofd.FileName;
            var fi = new FileInfo(file);
            const int expectLength = PlayerRoom.SIZE;
            if (fi.Length != expectLength)
            {
                WinFormsUtil.Error(MessageStrings.MsgCanceling, string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expectLength));
                return false;
            }

            var data = File.ReadAllBytes(file);
            data.CopyTo(room.Data, 0);
            return true;
        }

        public static void DumpFlags(byte[] data, string name)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Flag List (*.nhfl)|*.nhfl|All files (*.*)|*.*",
                FileName = $"{name}.nhfl",
            };
            if (sfd.ShowDialog() == DialogResult.OK)
                File.WriteAllBytes(sfd.FileName, data);
        }

        public static byte[] LoadFlags(int size, string name)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Flag List (*.nhfl)|*.nhfl|All files (*.*)|*.*",
                FileName = $"{name}.nhfl",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return System.Array.Empty<byte>();

            var file = ofd.FileName;
            var fi = new FileInfo(file);
            int expectLength = size;
            if (fi.Length != expectLength)
            {
                WinFormsUtil.Error(MessageStrings.MsgCanceling, string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expectLength));
                return System.Array.Empty<byte>();
            }

            return File.ReadAllBytes(file);
        }
    }
}
