using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms;

public static class MapDumpHelper
{
    private const int DesignDumpSizeAbove31 = 0x6C00;
    private const int DesignDumpSizeBelow31 = 0x5400;

    public static bool ImportToLayerAcreSingle(LayerFieldItem layerField, string acre, int layerIndex, int relX, int relY)
    {
        var name = GetBaseFileName(acre, "acre");
        using var ofd = new OpenFileDialog();
        ofd.Filter = "New Horizons Field Item Layer (*.nhl)|*.nhl|All files (*.*)|*.*";
        ofd.FileName = $"{name}-{layerIndex}.nhl";
        if (ofd.ShowDialog() != DialogResult.OK)
            return false;

        var path = ofd.FileName;
        var fi = new FileInfo(path);

        int expect = layerField.TileInfo.ViewCount * Item.SIZE;
        if (fi.Length != expect)
        {
            WinFormsUtil.Error(string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expect));
            return false;
        }

        var data = File.ReadAllBytes(path);
        var importedCount = layerField.ImportAcre(data, relX, relY);
        return true;
    }

    private static string GetBaseFileName(string initialName, string fallback)
    {
        var result = StringUtil.CleanFileName(initialName);
        if (string.IsNullOrEmpty(result))
            return fallback;
        return result;
    }

    public static bool ImportToLayerAcreAll(LayerFieldItem layerField)
    {
        using var ofd = new OpenFileDialog();
        ofd.Filter = "New Horizons Field Item Layer (*.nhl)|*.nhl|All files (*.*)|*.*";
        ofd.FileName = "acres.nhl";
        if (ofd.ShowDialog() != DialogResult.OK)
            return false;

        var path = ofd.FileName;
        var fi = new FileInfo(path);
        var expect = layerField.TileInfo.TotalCount * Item.SIZE;
        if (fi.Length != expect && !FieldItemUpgrade.IsUpdateNeeded(fi.Length, expect))
        {
            WinFormsUtil.Error(string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expect));
            return false;
        }

        var data = File.ReadAllBytes(path);
        FieldItemUpgrade.DetectUpdate(ref data, expect);
        layerField.ImportAll(data);
        return true;
    }

    public static void DumpLayerAcreSingle(LayerFieldItem layerField, string acre, int layerIndex, int relX, int relY)
    {
        var name = GetBaseFileName(acre, "acre");
        using var sfd = new SaveFileDialog();
        sfd.Filter = "New Horizons Field Item Layer (*.nhl)|*.nhl|All files (*.*)|*.*";
        sfd.FileName = $"{name}-{layerIndex}.nhl";
        if (sfd.ShowDialog() != DialogResult.OK)
            return;

        var path = sfd.FileName;
        var data = layerField.DumpAcre(relX, relY);
        File.WriteAllBytes(path, data);
    }

    public static void DumpLayerAcreAll(LayerFieldItem layerField)
    {
        using var sfd = new SaveFileDialog();
        sfd.Filter = "New Horizons Field Item Layer (*.nhl)|*.nhl|All files (*.*)|*.*";
        sfd.FileName = "acres.nhl";
        if (sfd.ShowDialog() != DialogResult.OK)
            return;

        var path = sfd.FileName;
        var data = layerField.DumpAll();
        File.WriteAllBytes(path, data);
    }

    public static bool ImportTerrainAcre(LayerTerrain m, string acre, int relX, int relY)
    {
        var name = GetBaseFileName(acre, "acre");
        using var ofd = new OpenFileDialog();
        ofd.Filter = "New Horizons Terrain (*.nht)|*.nht|All files (*.*)|*.*";
        ofd.FileName = $"{name}.nht";
        if (ofd.ShowDialog() != DialogResult.OK)
            return false;

        var path = ofd.FileName;
        var fi = new FileInfo(path);

        int expect = m.TileInfo.ViewCount * TerrainTile.SIZE;
        if (fi.Length != expect)
        {
            WinFormsUtil.Error(string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expect));
            return false;
        }

        var data = File.ReadAllBytes(path);
        int importedCount = m.ImportAcre(data, relX, relY);
        return true;
    }

    public static bool ImportTerrainAll(LayerTerrain m)
    {
        using var ofd = new OpenFileDialog();
        ofd.Filter = "New Horizons Terrain (*.nht)|*.nht|All files (*.*)|*.*";
        ofd.FileName = "terrainAcres.nht";
        if (ofd.ShowDialog() != DialogResult.OK)
            return false;

        var path = ofd.FileName;
        var fi = new FileInfo(path);

        int expect = m.TileInfo.TotalCount * TerrainTile.SIZE;
        if (fi.Length != expect)
        {
            WinFormsUtil.Error(string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expect));
            return false;
        }

        var data = File.ReadAllBytes(path);
        m.ImportAll(data);
        return true;
    }

    public static void DumpTerrainAcre(LayerTerrain m, string acre, int relX, int relY)
    {
        var name = GetBaseFileName(acre, "terrainAcre");
        using var sfd = new SaveFileDialog();
        sfd.Filter = "New Horizons Terrain (*.nht)|*.nht|All files (*.*)|*.*";
        sfd.FileName = $"{name}.nht";
        if (sfd.ShowDialog() != DialogResult.OK)
            return;

        var path = sfd.FileName;
        var data = m.DumpAcre(relX, relY);
        File.WriteAllBytes(path, data);
    }

    public static void DumpTerrainAll(LayerTerrain m)
    {
        using var sfd = new SaveFileDialog();
        sfd.Filter = "New Horizons Terrain (*.nht)|*.nht|All files (*.*)|*.*";
        sfd.FileName = "terrainAcres.nht";
        if (sfd.ShowDialog() != DialogResult.OK)
            return;

        var path = sfd.FileName;
        var data = m.DumpAll();
        File.WriteAllBytes(path, data);
    }

    public static void DumpBuildings(IReadOnlyList<Building> buildings)
    {
        using var sfd = new SaveFileDialog();
        sfd.Filter = "New Horizons Building List (*.nhb)|*.nhb|All files (*.*)|*.*";
        sfd.FileName = "buildings.nhb";
        if (sfd.ShowDialog() != DialogResult.OK)
            return;

        var path = sfd.FileName;
        byte[] data = Building.SetArray(buildings);
        File.WriteAllBytes(path, data);
    }

    public static bool ImportBuildings(IReadOnlyList<Building> buildings)
    {
        using var ofd = new OpenFileDialog();
        ofd.Filter = "New Horizons Building List (*.nhb)|*.nhb|All files (*.*)|*.*";
        ofd.FileName = "buildings.nhb";
        if (ofd.ShowDialog() != DialogResult.OK)
            return false;

        var path = ofd.FileName;
        var fi = new FileInfo(path);

        const int expect = Building.SIZE * MainSaveOffsets.BuildingCount; // 46
        const int oldSize = Building.SIZE * 40;
        if (fi.Length is not (expect or oldSize))
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

    public static bool DumpMapAcresAll(ReadOnlySpan<byte> data)
    {
        using var sfd = new SaveFileDialog();
        sfd.Filter = "New Horizons Acres (*.nha)|*.nha|All files (*.*)|*.*";
        sfd.FileName = "acres.nha";

        if (sfd.ShowDialog() != DialogResult.OK)
            return false;

        File.WriteAllBytes(sfd.FileName, data);
        return true;
    }

    public static bool ImportMapAcresAll(Span<byte> data)
    {
        using var ofd = new OpenFileDialog();
        ofd.Filter = "New Horizons Acres (*.nha)|*.nha|All files (*.*)|*.*";
        ofd.FileName = "acres.nha";

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

        modified.CopyTo(data);
        return true;
    }

    public static bool DumpLayerAllFlag(ILayerFieldItemFlag layer, uint layerIndex)
    {
        using var sfd = new SaveFileDialog();
        sfd.Filter = "New Horizons Field Item Layer Flags (*.nhlf)|*.nhl|All files (*.*)|*.*";
        sfd.FileName = $"flags-{layerIndex}.nhlf";

        if (sfd.ShowDialog() != DialogResult.OK)
            return false;

        var data = layer.ExistingData;
        File.WriteAllBytes(sfd.FileName, data);
        return true;
    }

    public static bool ImportToLayerAllFlag(ILayerFieldItemFlag layer, uint layerIndex)
    {
        using var ofd = new OpenFileDialog();
        ofd.Filter = "New Horizons Field Item Layer Flags (*.nhlf)|*.nhl|All files (*.*)|*.*";
        ofd.FileName = $"flags-{layerIndex}.nhlf";
        if (ofd.ShowDialog() != DialogResult.OK)
            return false;

        var path = ofd.FileName;
        var fi = new FileInfo(path);

        var exist = layer.ExistingData;
        var expect = exist.Length;
        if (fi.Length != expect && !FieldItemUpgrade.IsUpdateNeeded(fi.Length, expect))
        {
            WinFormsUtil.Error(string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expect));
            return false;
        }

        var data = File.ReadAllBytes(path);
        FieldItemUpgrade.DetectUpdate(ref data, expect);
        layer.Import(data);
        return true;
    }

    public static bool ImportMapDesigns(MainSave sav, Tuple<int, int> size)
    {
        using var ofd = new OpenFileDialog();
        ofd.Filter = "nhmd file (*.nhmd)|*.nhmd";
        ofd.FileName = "Island MyDesignMap.nhmd";
        if (ofd.ShowDialog() != DialogResult.OK)
            return false;

        string path = ofd.FileName;

        var tiles = File.ReadAllBytes(path);

        var rel = size;

        if (rel.Item1 == 9)
        {
            if (tiles.Length == DesignDumpSizeAbove31)
            {
                tiles.CopyTo(sav.MapDesignTileData(rel.Item1, rel.Item2).Span);
            }
            else if (tiles.Length == DesignDumpSizeBelow31)
            {
                byte[] padBytes = BitConverter.GetBytes(MainSave.MapDesignNone);
                int len = (DesignDumpSizeAbove31 - DesignDumpSizeBelow31) / 2;

                tiles = ArrayUtil.PadLeft(tiles, tiles.Length + len, padBytes);
                tiles = ArrayUtil.PadRight(tiles, tiles.Length + len, padBytes);

                using var sfd = new SaveFileDialog();
                sfd.Filter = "nhmd file (*.nhmd)|*.nhmd";
                sfd.FileName = "Island MyDesignMap.nhmd";
                if (sfd.ShowDialog() != DialogResult.OK)
                    return false;

                string path2 = sfd.FileName;

                File.WriteAllBytes(path2, tiles);

                tiles.CopyTo(sav.MapDesignTileData(rel.Item1, rel.Item2).Span);
            }
            // account for previous dumps that included extra data after the tile data (oops)
            // this can be removed in the future once enough time has passed that everyone has
            // re-dumped with the fixed version, but for now it prevents data loss
            else if (tiles.Length > DesignDumpSizeAbove31)
            {
                Span<byte> trimTiles = tiles.AsSpan().Slice(0, DesignDumpSizeAbove31);
                tiles = trimTiles.ToArray();
                var msg1 = MessageStrings.MsgDataSizeMismatchImport;
                var msg2 = MessageStrings.MsgDataTrimmedWarning;
                WinFormsUtil.Alert(string.Format(msg1, tiles.Length, DesignDumpSizeAbove31) + " " + msg2);

                using var sfd = new SaveFileDialog();
                sfd.Filter = "nhmd file (*.nhmd)|*.nhmd";
                sfd.FileName = "Island MyDesignMap.nhmd";
                if (sfd.ShowDialog() != DialogResult.OK)
                    return false;

                string path2 = sfd.FileName;

                File.WriteAllBytes(path2, tiles);

                tiles.CopyTo(sav.MapDesignTileData(rel.Item1, rel.Item2).Span);
            }
            else
            {
                var msg = MessageStrings.MsgDataSizeMismatchImport;
                WinFormsUtil.Error(string.Format(msg, tiles.Length, DesignDumpSizeAbove31));
                return false;
            }
        }
        else
        {
            if (tiles.Length == DesignDumpSizeBelow31)
            {
                tiles.CopyTo(sav.MapDesignTileData(rel.Item1, rel.Item2).Span);
            }
            else if (tiles.Length == DesignDumpSizeAbove31)
            {
                int trimAmount = (DesignDumpSizeAbove31 - DesignDumpSizeBelow31) / 2;
                int newLength = tiles.Length - (2 * trimAmount);

                tiles = tiles.AsSpan(trimAmount, newLength).ToArray();

                tiles.CopyTo(sav.MapDesignTileData(rel.Item1, rel.Item2).Span);
            }
            else
            {
                var msg = MessageStrings.MsgDataSizeMismatchImport;
                WinFormsUtil.Error(string.Format(msg, tiles.Length, DesignDumpSizeBelow31));
                return false;
            }
        }

        return true;
    }
    public static bool DumpMapDesigns(MainSave sav, Tuple<int, int> size)
    {
        using var sfd = new SaveFileDialog();
        sfd.Filter = "nhmd file (*.nhmd)|*.nhmd";
        sfd.FileName = "Island MyDesignMap.nhmd";
        if (sfd.ShowDialog() != DialogResult.OK)
            return false;

        string path = sfd.FileName;

        var tiles = sav.MapDesignTileData(size.Item1, size.Item2).Span;

        File.WriteAllBytes(path, tiles);

        return true;
    }
}