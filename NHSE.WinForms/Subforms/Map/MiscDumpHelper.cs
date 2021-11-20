using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public static class MiscDumpHelper
    {
        public static void DumpVillagerMemoryPlayer(IVillager v, GSaveMemory memory)
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

        public static bool LoadVillagerMemoryPlayer(IVillager v, GSaveMemory[] memories, int index)
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

        public static void DumpHouse(IReadOnlyList<Player> players, IReadOnlyList<IPlayerHouse> houses, int index, bool dumpAll)
        {
            if (dumpAll)
                DumpAllPlayerHouses(houses, players);
            else
                DumpPlayerHouse(players, houses, index);
        }

        private static void DumpPlayerHouse(IReadOnlyList<Player> players, IReadOnlyList<IPlayerHouse> houses, int index)
        {
            var house = houses[index];
            var name = PlayerHouseEditor.GetHouseSummary(players, house, index);
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Player House (*.nhph)|*.nhph|" +
                         "New Horizons Player House (*.nhph2)|*.nhph2|" +
                         "All files (*.*)|*.*",
                FileName = $"{name}.{house.Extension}",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var data = house.Write();
            File.WriteAllBytes(sfd.FileName, data);
        }

        private static void DumpAllPlayerHouses(IReadOnlyList<IPlayerHouse> houses, IReadOnlyList<Player> players)
        {
            using var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() != DialogResult.OK)
                return;

            var dir = Path.GetDirectoryName(fbd.SelectedPath);
            if (dir == null || !Directory.Exists(dir))
                return;
            houses.DumpPlayerHouses(players, fbd.SelectedPath);
        }

        public static bool LoadHouse(MainSaveOffsets offsets, IReadOnlyList<Player> players, IPlayerHouse[] houses, int index)
        {
            var h = houses[index];
            var name = PlayerHouseEditor.GetHouseSummary(players, houses[index], index);
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Player House (*.nhph)|*.nhph|" +
                         "New Horizons Player House (*.nhph2)|*.nhph2|" +
                         "All files (*.*)|*.*",
                FileName = $"{name}.{h.Extension}",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return false;

            var path = ofd.FileName;
            var expectLength = offsets.PlayerHouseSize;
            var fi = new FileInfo(path);
            if (!VillagerHouseConverter.IsCompatible((int)fi.Length, expectLength))
            {
                WinFormsUtil.Error(string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expectLength), path);
                return false;
            }

            var data = File.ReadAllBytes(ofd.FileName);
            data = PlayerHouseConverter.GetCompatible(data, expectLength);
            if (fi.Length != expectLength)
            {
                WinFormsUtil.Error(MessageStrings.MsgCanceling, string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expectLength), path);
                return false;
            }

            h = offsets.ReadPlayerHouse(data);
            var current = houses[index];
            h.NPC1 = current.NPC1;
            houses[index] = h;
            return true;
        }

        public static void DumpRoom(IPlayerRoom room, int index)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Player House Room (*.nhpr)|*.nhph|" +
                         "New Horizons Player House Room (*.nhpr2)|*.nhpr2|" +
                         "All files (*.*)|*.*",
                FileName = $"Room {index + 1}.{room.Extension}",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var data = room.Write();
            File.WriteAllBytes(sfd.FileName, data);
        }

        public static bool LoadRoom(MainSaveOffsets offsets, IPlayerRoom room, int index)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Player House Room (*.nhpr)|*.nhpr|All files (*.*)|*.*",
                FileName = $"Room {index + 1}.nhpr",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return false;

            var path = ofd.FileName;
            var expectLength = offsets.PlayerRoomSize;
            var fi = new FileInfo(path);
            if (!PlayerRoomConverter.IsCompatible((int)fi.Length, expectLength))
            {
                WinFormsUtil.Error(string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expectLength), path);
                return false;
            }

            var data = File.ReadAllBytes(ofd.FileName);
            data = PlayerRoomConverter.GetCompatible(data, offsets.PlayerRoomSize);
            if (fi.Length != expectLength)
            {
                WinFormsUtil.Error(MessageStrings.MsgCanceling, string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expectLength), path);
                return false;
            }

            room = offsets.ReadPlayerRoom(data);
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
