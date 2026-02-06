using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms;

public static class MapDumpHelper
{
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
}