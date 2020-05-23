using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public static class MapDumpHelper
    {
        public static bool ImportToLayerAcreSingle(FieldItemLayer layer, int acreIndex, string acre, int layerIndex)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Field Item Layer (*.nhl)|*.nhl|All files (*.*)|*.*",
                FileName = $"{acre}-{layerIndex}.nhl",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return false;

            var path = ofd.FileName;
            var fi = new FileInfo(path);

            int expect = layer.GridTileCount * Item.SIZE;
            if (fi.Length != expect)
            {
                WinFormsUtil.Error(string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expect));
                return false;
            }

            var data = File.ReadAllBytes(path);
            layer.ImportAcre(acreIndex, data);
            return true;
        }

        public static bool ImportToLayerAcreAll(FieldItemLayer layer)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Field Item Layer (*.nhl)|*.nhl|All files (*.*)|*.*",
                FileName = "acres.nhl",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return false;

            var path = ofd.FileName;
            var fi = new FileInfo(path);

            int expect = layer.MaxTileCount * Item.SIZE;
            if (fi.Length != expect)
            {
                WinFormsUtil.Error(string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expect));
                return false;
            }

            var data = File.ReadAllBytes(path);
            layer.ImportAll(data);
            return true;
        }

        public static void DumpLayerAcreSingle(FieldItemLayer layer, int acreIndex, string acre, int layerIndex)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Field Item Layer (*.nhl)|*.nhl|All files (*.*)|*.*",
                FileName = $"{acre}-{layerIndex}.nhl",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var path = sfd.FileName;
            var data = layer.DumpAcre(acreIndex);
            File.WriteAllBytes(path, data);
        }

        public static void DumpLayerAcreAll(FieldItemLayer layer)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Field Item Layer (*.nhl)|*.nhl|All files (*.*)|*.*",
                FileName = "acres.nhl",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var path = sfd.FileName;
            var data = layer.DumpAll();
            File.WriteAllBytes(path, data);
        }

        public static bool ImportTerrainAcre(TerrainLayer m, int acreIndex, string acre)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Terrain (*.nht)|*.nht|All files (*.*)|*.*",
                FileName = $"{acre}.nht",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return false;

            var path = ofd.FileName;
            var fi = new FileInfo(path);

            int expect = m.GridTileCount * TerrainTile.SIZE;
            if (fi.Length != expect)
            {
                WinFormsUtil.Error(string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expect));
                return false;
            }

            var data = File.ReadAllBytes(path);
            m.ImportAcre(acreIndex, data);
            return true;
        }

        public static bool ImportTerrainAll(TerrainLayer m)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Terrain (*.nht)|*.nht|All files (*.*)|*.*",
                FileName = "terrainAcres.nht",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return false;

            var path = ofd.FileName;
            var fi = new FileInfo(path);

            int expect = m.MaxTileCount * TerrainTile.SIZE;
            if (fi.Length != expect)
            {
                WinFormsUtil.Error(string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expect));
                return false;
            }

            var data = File.ReadAllBytes(path);
            m.ImportAll(data);
            return true;
        }

        public static void DumpTerrainAcre(TerrainLayer m, int acreIndex, string acre)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Terrain (*.nht)|*.nht|All files (*.*)|*.*",
                FileName = $"{acre}.nht",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var path = sfd.FileName;
            var data = m.DumpAcre(acreIndex);
            File.WriteAllBytes(path, data);
        }

        public static void DumpTerrainAll(TerrainLayer m)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Terrain (*.nht)|*.nht|All files (*.*)|*.*",
                FileName = "terrainAcres.nht",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var path = sfd.FileName;
            var data = m.DumpAll();
            File.WriteAllBytes(path, data);
        }

        public static void DumpBuildings(IReadOnlyList<Building> buildings)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Building List (*.nhb)|*.nhb|All files (*.*)|*.*",
                FileName = "buildings.nhb",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var path = sfd.FileName;
            byte[] data = Building.SetArray(buildings);
            File.WriteAllBytes(path, data);
        }

        public static bool ImportBuildings(IReadOnlyList<Building> buildings)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Building List (*.nhb)|*.nhb|All files (*.*)|*.*",
                FileName = "buildings.nhb",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return false;

            var path = ofd.FileName;
            var fi = new FileInfo(path);

            const int expect = Building.SIZE * MainSaveOffsets.BuildingCount; // 46
            const int oldSize = Building.SIZE * 40;
            if (fi.Length != expect && fi.Length != oldSize)
            {
                WinFormsUtil.Error(string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expect));
                return false;
            }

            var data = File.ReadAllBytes(path);
            var arr = Building.GetArray(data);
            for (int i = 0; i < arr.Length; i++)
                buildings[i].CopyFrom(arr[i]);
            return true;
        }

        public static bool DumpMapAcresAll(byte[] data)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Acres (*.nha)|*.nha|All files (*.*)|*.*",
                FileName = "acres.nha",
            };

            if (sfd.ShowDialog() != DialogResult.OK)
                return false;

            File.WriteAllBytes(sfd.FileName, data);
            return true;
        }

        public static bool ImportMapAcresAll(byte[] data)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Acres (*.nha)|*.nha|All files (*.*)|*.*",
                FileName = "acres.nha",
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return false;

            var path = ofd.FileName;
            var original = data;
            var modified = File.ReadAllBytes(path);
            if (original.Length != modified.Length)
            {
                WinFormsUtil.Error(string.Format(MessageStrings.MsgDataSizeMismatchImport, modified.Length, original.Length), path);
                return false;
            }

            modified.CopyTo(data, 0);
            return true;
        }
    }
}
