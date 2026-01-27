using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Sprites;
using NHSE.WinForms.Subforms.Map;

namespace NHSE.WinForms;

public sealed partial class FieldItemEditor : Form, IItemLayerEditor
{
    private readonly MainSave SAV;
    private readonly MapEditor Editor;
    private readonly MapRenderer Renderer;

    private MapViewState View => Editor.Mutator.View;
    private MapTileManager Map => Editor.Mutator.Manager;

    private bool Loading;
    private int SelectedBuildingIndex;

    /// <summary> Cached current hover X coordinate within the acre. </summary>
    private int HoverX;
    /// <summary> Cached current hover Y coordinate within the acre. </summary>
    private int HoverY;

    private int DragX = -1;
    private int DragY = -1;
    private bool IsDragOperationActive;

    private bool IsMenuHasActivate = true;

    public ItemEditor ItemProvider => ItemEdit;

    /// <summary>
    /// Layer to spawn items into.
    /// </summary>
    public LayerItem Spawn => CurrentLayer;

    public LayerFieldItem CurrentLayer => Editor.Mutator.CurrentLayer;

    private TerrainBrushEditor? tbeForm;

    public FieldItemEditor(MainSave sav)
    {
        InitializeComponent();
        this.TranslateInterface(GameInfo.CurrentLanguage);

        // Read the expected scale from the control.
        var scale = (PB_Viewport.Width - 2) / LayerFieldItem.TilesPerAcreDim; // 1px border
        SAV = sav;
        Editor = MapEditor.FromSaveFile(sav);
        Editor.MapScale = 1;
        Editor.ViewScale = scale;
        Renderer = new MapRenderer(Editor);

        Loading = true;

        LoadComboBoxes();
        LoadBuildings(sav);
        ReloadMapBackground();
        LoadEditors();

        // Set initial states
        CB_Acre.SelectedIndex = 0;
        CB_MapAcre.SelectedIndex = 0;
        LB_Items.SelectedIndex = 0; // triggers a draw

        Loading = false;
    }

    private void LoadComboBoxes()
    {
        // Snap viewport to acre
        foreach (var acre in AcreCoordinate.Exterior)
            CB_Acre.Items.Add(acre.Name);

        // Select acre type for current
        foreach (var acre in AcreCoordinate.Exterior)
            CB_MapAcre.Items.Add(acre.Name);

        CB_MapAcreSelect.DisplayMember = nameof(ComboItem.Text);
        CB_MapAcreSelect.ValueMember = nameof(ComboItem.Value);
        CB_MapAcreSelect.DataSource = ComboItemUtil.GetArray<OutsideAcre>();

        NUD_MapAcreTemplateOutside.Value = SAV.OutsideFieldTemplateUniqueId;
        NUD_MapAcreTemplateField.Value = SAV.MainFieldParamUniqueID;
    }

    private void LoadBuildings(MainSave sav)
    {
        NUD_PlazaX.Value = sav.EventPlazaLeftUpX;
        NUD_PlazaY.Value = sav.EventPlazaLeftUpZ;

        foreach (var obj in Editor.Mutator.Manager.LayerBuildings.Buildings)
            LB_Items.Items.Add(obj.ToString());
    }

    private void LoadEditors()
    {
        var data = GameInfo.Strings.ItemDataSource.ToList();
        var field = FieldItemList.Items.Select(z => z.Value).ToList();
        data.Add(field, GameInfo.Strings.InternalNameTranslation);
        ItemEdit.Initialize(data, true);
        PG_TerrainTile.SelectedObject = new TerrainTile();
    }

    private int ExteriorAcreIndex => CB_Acre.SelectedIndex;

    private void ChangeAcre(object sender, EventArgs e)
    {
        if (Loading)
            return;
        ChangeViewToAcre(ExteriorAcreIndex);
        CB_MapAcre.Text = CB_Acre.Text;
    }

    private void ChangeViewToAcre(int acre)
    {
        View.SetViewToAcre(acre);
        LoadItemGridAcre();
    }

    private void LoadItemGridAcre()
    {
        ReloadItems();
        ReloadViewportBackground();
        UpdateArrowVisibility();
    }

    private int GetItemTransparency() => ((int)(0xFF * TR_Transparency.Value / 100d) << 24) | 0x00FF_FFFF;

    private void ReloadMapBackground()
    {
        var img = Renderer.UpdateMapTerrain(SelectedBuildingIndex);
        SetMapBackgroundImage(img);
    }

    private void ReloadMapItemGrid() => SetMapForegroundImage(Renderer.UpdateMapItemsReticle(GetItemTransparency()));

    private void SetMapBackgroundImage(Bitmap img)
    {
        PB_Map.BackgroundImage = img;
        PB_Map.Invalidate(); // background image reassigning to same img doesn't redraw; force it
    }

    private void SetMapForegroundImage(Bitmap img)
    {
        PB_Map.Image = img;
    }

    private void ReloadViewportBackground()
    {
        var tbuild = (byte)TR_BuildingTransparency.Value;
        var tterrain = (byte)TR_Terrain.Value;
        var img = Renderer.UpdateViewportTerrain(L_Coordinates.Font, tbuild, tterrain, SelectedBuildingIndex);
        PB_Viewport.BackgroundImage = img;
        PB_Viewport.Invalidate(); // background image reassigning to same img doesn't redraw; force it
    }

    private void ReloadViewportItems() => PB_Viewport.Image = Renderer.UpdateViewportItems(GetItemTransparency());

    public void ReloadItems()
    {
        ReloadViewportItems();
        ReloadMapItemGrid();
    }

    private void ReloadBuildingsTerrain()
    {
        ReloadViewportBackground();
        ReloadMapBackground();
    }

    private void UpdateArrowVisibility()
    {
        B_Up.Enabled = View.CanUp;
        B_Down.Enabled = View.CanDown;
        B_Left.Enabled = View.CanLeft;
        B_Right.Enabled = View.CanRight;
    }

    private void ViewportMouseClick(object sender, MouseEventArgs e)
    {
        if (IsDragOperationActive)
        {
            ResetDrag();
            return;
        }

        if (RB_Item.Checked)
            OmniTile(e);
        else if (RB_Terrain.Checked)
            OmniTileTerrain(e);
    }

    private void ResetDrag()
    {
        DragX = -1;
        DragY = -1;
        IsDragOperationActive = false;
    }

    private void OmniTile(MouseEventArgs e)
    {
        if (!GetTile(e, CurrentLayer, out var tile))
            return;
        OmniTile(tile.Tile, tile.RelativeX, tile.RelativeY);
    }

    private void OmniTileTerrain(MouseEventArgs e)
    {
        if (!GetTile(e, Editor.Mutator.Manager.LayerTerrain, out var meta))
            return;

        var tile = meta.Tile;
        var relX = meta.RelativeX;
        var relY = meta.RelativeY;

        if (tbeForm?.IsBrushSelected != true)
        {
            OmniTileTerrain(tile);
            return;
        }

        if (tbeForm.Slider_thickness.Value <= 1)
        {
            SetTile(tile);
            return;
        }

        List<TerrainTile> selectedTiles = [];
        int radius = tbeForm.Slider_thickness.Value;
        int threshold = (radius * radius) / 2;
        for (int i = -radius; i < radius; i++)
        {
            for (int j = -radius; j < radius; j++)
            {
                if ((i * i) + (j * j) < threshold)
                    selectedTiles.Add(Editor.Terrain.GetTile(relX + i, relY + j));
            }
        }

        SetTiles(selectedTiles);
    }

    private void OmniTile(Item tile, int relX, int relY)
    {
        switch (ModifierKeys)
        {
            default:
                ViewTile(tile, relX, relY);
                return;

            case Keys.Alt | Keys.Control:
            case Keys.Alt | Keys.Control | Keys.Shift:
                ReplaceTile(tile, relX, relY);
                return;

            case Keys.Shift:
                SetTile(tile, relX, relY);
                return;

            case Keys.Alt:
                DeleteTile(tile, relX, relY);
                return;
        }
    }

    private void OmniTileTerrain(TerrainTile tile)
    {
        switch (ModifierKeys)
        {
            default:
                ViewTile(tile);
                return;

            case Keys.Shift | Keys.Control:
                RotateTile(tile);
                return;

            case Keys.Shift:
                SetTile(tile);
                return;

            case Keys.Alt:
                DeleteTile(tile);
                return;
        }
    }

    private sealed record TileCheck<T>(T Tile, int AbsoluteX, int AbsoluteY, int RelativeX, int RelativeY);

    private bool GetTile(MouseEventArgs e, LayerFieldItem layerField, [NotNullWhen(true)] out TileCheck<Item>? item)
    {
        UpdateHoveredCoordinates(e);
        var (absX, absY) = GetAbsoluteCoordinatesHover();
        return GetTile(layerField, absX, absY, out item);
    }

    private (int X, int Y) GetAbsoluteCoordinatesHover()
    {
        var absX = View.X + HoverX;
        var absY = View.Y + HoverY;
        return (absX, absY);
    }

    private (int X, int Y) GetAbsoluteCoordinatesHoverTerrain()
    {
        // Terrain tiles are 16x16, but the view caters to 32x32 for field items.
        var absX = (View.X + HoverX) / 2;
        var absY = (View.Y + HoverY) / 2;
        return (absX, absY);
    }

    private (int X, int Y) GetViewCoordinates(MouseEventArgs e)
    {
        var x = e.X / Editor.ViewScale;
        var y = e.Y / Editor.ViewScale;
        return (x, y);
    }

    private bool GetTile(LayerFieldItem layerField, int absX, int absY, [NotNullWhen(true)] out TileCheck<Item>? item)
    {
        var cfg = Editor.Mutator.Manager.ConfigItems;
        var (relX, relY) = cfg.GetCoordinatesRelative(absX, absY);
        if (!cfg.IsCoordinateValidRelative(relX, relY))
        {
            item = null;
            return false;
        }

        var tile = layerField.GetTile(relX, relY);
        item = new TileCheck<Item>(tile, absX, absY, relX, relY);
        return true;
    }

    private bool GetTile(MouseEventArgs e, LayerTerrain layerField, [NotNullWhen(true)] out TileCheck<TerrainTile>? item)
    {
        UpdateHoveredCoordinates(e);
        var (absX, absY) = GetAbsoluteCoordinatesHoverTerrain();
        return GetTile(layerField, absX, absY, out item);
    }

    private bool GetTile(LayerTerrain layerField, int absX, int absY, [NotNullWhen(true)] out TileCheck<TerrainTile>? item)
    {
        var cfg = Editor.Mutator.Manager.ConfigItems;
        var (relX, relY) = cfg.GetCoordinatesRelative(absX, absY);
        if (!cfg.IsCoordinateValidRelative(relX, relY))
        {
            item = null;
            return false;
        }

        var tile = layerField.GetTile(relX, relY);
        item = new TileCheck<TerrainTile>(tile, absX, absY, relX, relY);
        return true;
    }

    private void UpdateHoveredCoordinates(MouseEventArgs e)
    {
        (HoverX, HoverY) = GetViewCoordinates(e);

        // Mouse event may fire with a slightly too large x/y; clamp just in case.
        HoverX &= 0x1F;
        HoverY &= 0x1F;
    }

    private void ViewportMouseDown(object sender, MouseEventArgs e) => ResetDrag();

    private void ViewportMouseMove(object sender, MouseEventArgs e)
    {
        var l = CurrentLayer;
        if (e.Button == MouseButtons.Left && CHK_MoveOnDrag.Checked)
        {
            MoveDrag(e);
            return;
        }
        if (e.Button == MouseButtons.Left && tbeForm?.IsBrushSelected == true)
        {
            OmniTileTerrain(e);
        }

        // Update hover tooltip if it is a different tile
        // Can't compare coordinates if redirection of extension tiles hijacks to return the root tile.
        // Just check the (root) tile returns for each.
        // Two different extension tiles can redirect to the same root tile, can skip updating in that case.
        if (!GetTile(l, View.X + HoverX, View.Y + HoverY, out var old))
            return;

        var oldTile = old.Tile;
        if (!GetTile(e, l, out var dest))
            return;

        var tile = dest.Tile;
        var x = dest.RelativeX;
        var y = dest.RelativeY;
        if (ReferenceEquals(tile, oldTile))
            return; // same tile, no change

        // Regenerate tooltip text
        var str = GameInfo.Strings;
        var name = str.GetItemName(tile);
        var flagLayer = NUD_Layer.Value == 0 ? Map.LayerItemFlag0 : Map.LayerItemFlag1;
        var isActive = flagLayer.GetIsActive(x, y);
        if (isActive)
            name = $"{name} [Active]";
        TT_Hover.SetToolTip(PB_Viewport, name);
        SetCoordinateText(x, y);
    }

    private void MoveDrag(MouseEventArgs e)
    {
        var (viewX, viewY) = GetViewCoordinates(e);

        if (DragX == -1)
        {
            DragX = viewX;
            DragY = viewY;
            return;
        }

        var dX = DragX - viewX;
        var dY = DragY - viewY;

        if (ModifierKeys == Keys.Control) // move in larger steps
        {
            dX *= 2;
            dY *= 2;
        }

        if ((dX & 1) == 1)
            dX ^= 1;
        if ((dY & 1) == 1)
            dY ^= 1;

        // Ensure movement is significant enough
        var aX = Math.Abs(dX);
        var aY = Math.Abs(dY);
        if (aX < 2 && aY < 2)
            return;

        DragX = viewX;
        DragY = viewY;
        if (!View.DragView(dX, dY))
            return;

        IsDragOperationActive = true;
        LoadItemGridAcre();
    }

    private void ViewTile(Item tile, int relX, int relY)
    {
        if (CHK_RedirectExtensionLoad.Checked && tile.IsExtension)
        {
            var l = CurrentLayer;
            relX -= tile.ExtensionX;
            relY -= tile.ExtensionY;
            l.TileInfo.ClampInside(ref relX, ref relY);
            var redirectTile = l.GetTile(relX, relY);

            if (redirectTile.IsRoot && redirectTile.ItemId == tile.ExtensionItemId)
                tile = redirectTile;
        }

        ViewTile(tile);
    }

    private void ViewTile(Item tile)
    {
        ItemEdit.LoadItem(tile);
        TC_Editor.SelectedTab = Tab_Item;
    }

    private void ViewTile(TerrainTile tile)
    {
        var pgt = (TerrainTile)PG_TerrainTile.SelectedObject!;
        pgt.CopyFrom(tile);
        PG_TerrainTile.SelectedObject = pgt;
        TC_Editor.SelectedTab = Tab_Terrain;
    }

    private void SetTile(Item tile, int relX, int relY)
    {
        var l = CurrentLayer;
        var pgt = new Item();
        ItemEdit.SetItem(pgt);

        if (pgt.IsFieldItem && CHK_FieldItemSnap.Checked)
        {
            // coordinates must be even (not odd-half)
            relX &= 0xFFFE;
            relY &= 0xFFFE;
            tile = l.GetTile(relX, relY);
        }

        var permission = l.IsOccupied(pgt, relX, relY);
        switch (permission)
        {
            case PlacedItemPermission.OutOfBounds:
            case PlacedItemPermission.Collision when CHK_NoOverwrite.Checked:
                System.Media.SystemSounds.Asterisk.Play();
                return;
        }

        // Clean up original placed data
        if (tile.IsRoot && CHK_AutoExtension.Checked)
            l.DeleteExtensionTiles(tile, relX, relY);

        // Set new placed data
        if (pgt.IsRoot && CHK_AutoExtension.Checked)
            l.SetExtensionTiles(pgt, relX, relY);
        tile.CopyFrom(pgt);

        ReloadItems();
    }

    private void ReplaceTile(Item tile, int relX, int relY)
    {
        var l = CurrentLayer;
        var pgt = new Item();
        ItemEdit.SetItem(pgt);

        if (pgt.IsFieldItem && CHK_FieldItemSnap.Checked)
        {
            // coordinates must be even (not odd-half)
            relX &= 0xFFFE;
            relY &= 0xFFFE;
            tile = l.GetTile(relX, relY);
        }

        var permission = l.IsOccupied(pgt, relX, relY);
        switch (permission)
        {
            case PlacedItemPermission.OutOfBounds:
                System.Media.SystemSounds.Asterisk.Play();
                return;
        }

        bool wholeMap = (ModifierKeys & Keys.Shift) != 0;
        var copy = new Item(tile.RawValue);
        var count = Editor.Mutator.ReplaceFieldItems(copy, pgt, wholeMap);
        if (count == 0)
        {
            WinFormsUtil.Alert(MessageStrings.MsgFieldItemModifyNone);
            return;
        }
        LoadItemGridAcre();
        WinFormsUtil.Alert(string.Format(MessageStrings.MsgFieldItemModifyCount, count));
    }

    private void RotateTile(TerrainTile tile)
    {
        bool wasRotated = tile.TryRotate();
        if (!wasRotated)
        {
            System.Media.SystemSounds.Asterisk.Play();
            return;
        }
        ReloadBuildingsTerrain();
    }

    private void SetTile(TerrainTile tile)
    {
        var pgt = (TerrainTile)PG_TerrainTile.SelectedObject!;

        // Apply randomization if enabled
        if (tbeForm?.RandomizeVariation == true)
        {
            switch (pgt.UnitModel)
            {
                case TerrainUnitModel.Cliff5B:
                case TerrainUnitModel.River5B:
                    Random rand = new();
                    pgt.Variation = (ushort)rand.Next(4);
                    break;
            }
        }

        tile.CopyFrom(pgt);
        ReloadBuildingsTerrain();
    }

    private void SetTiles(IEnumerable<TerrainTile> tiles)
    {
        var pgt = (TerrainTile)PG_TerrainTile.SelectedObject!;

        foreach (var tile in tiles)
            tile.CopyFrom(pgt);
        ReloadBuildingsTerrain();
    }

    private void DeleteTile(Item tile, int relX, int relY)
    {
        if (CHK_AutoExtension.Checked)
        {
            var layer = CurrentLayer;
            if (!tile.IsRoot)
            {
                relX -= tile.ExtensionX;
                relY -= tile.ExtensionY;
                tile = layer.GetTile(relX, relY);
            }
            layer.DeleteExtensionTiles(tile, relX, relY);
        }

        tile.Delete();
        ReloadItems();
    }

    private void DeleteTile(TerrainTile tile)
    {
        tile.Clear();
        ReloadBuildingsTerrain();
    }

    private void B_Cancel_Click(object sender, EventArgs e) => Close();

    private void B_Save_Click(object sender, EventArgs e)
    {
        var set = Map.FieldItems;
        var unsupported = set.GetUnsupportedTiles();
        if (unsupported.Count != 0)
        {
            var err = MessageStrings.MsgFieldItemUnsupportedLayer2Tile;
            var ask = MessageStrings.MsgAskContinue;
            var prompt = WinFormsUtil.Prompt(MessageBoxButtons.YesNo, err, ask);
            if (prompt != DialogResult.Yes)
                return;
        }

        Map.SetManager(SAV);
        SAV.OutsideFieldTemplateUniqueId = (ushort)NUD_MapAcreTemplateOutside.Value;
        SAV.MainFieldParamUniqueID = (ushort)NUD_MapAcreTemplateField.Value;
        Close();
    }

    private void Menu_View_Click(object sender, EventArgs e)
    {
        if (RB_Item.Checked)
        {
            var (absX, absY) = GetAbsoluteCoordinatesHover();
            var cfg = Editor.Mutator.Manager.ConfigItems;
            var (relX, relY) = cfg.GetCoordinatesRelative(absX, absY);
            if (!cfg.IsCoordinateValidRelative(relX, relY))
            {
                System.Media.SystemSounds.Asterisk.Play();
                return;
            }

            var tile = CurrentLayer.GetTile(relX, relY);
            ViewTile(tile, relX, relY);
        }
        else if (RB_Terrain.Checked)
        {
            var (absX, absY) = GetAbsoluteCoordinatesHoverTerrain();
            var cfg = Editor.Mutator.Manager.ConfigTerrain;
            var (relX, relY) = cfg.GetCoordinatesRelative(absX, absY);
            if (!cfg.IsCoordinateValidRelative(relX, relY))
            {
                System.Media.SystemSounds.Asterisk.Play();
                return;
            }

            var tile = Editor.Terrain.GetTile(relX, relY);
            ViewTile(tile);
        }
    }

    private void Menu_Set_Click(object sender, EventArgs e)
    {
        if (RB_Item.Checked)
        {
            var (absX, absY) = GetAbsoluteCoordinatesHover();
            var cfg = Editor.Mutator.Manager.ConfigItems;
            var (relX, relY) = cfg.GetCoordinatesRelative(absX, absY);
            if (!cfg.IsCoordinateValidRelative(relX, relY))
            {
                System.Media.SystemSounds.Asterisk.Play();
                return;
            }

            var tile = CurrentLayer.GetTile(relX, relY);
            SetTile(tile, relX, relY);
        }
        else if (RB_Terrain.Checked)
        {
            var (absX, absY) = GetAbsoluteCoordinatesHoverTerrain();
            var cfg = Editor.Mutator.Manager.ConfigTerrain;
            var (relX, relY) = cfg.GetCoordinatesRelative(absX, absY);
            if (!cfg.IsCoordinateValidRelative(relX, relY))
            {
                System.Media.SystemSounds.Asterisk.Play();
                return;
            }

            var tile = Editor.Terrain.GetTile(relX, relY);
            SetTile(tile);
        }
    }

    private void Menu_Reset_Click(object sender, EventArgs e)
    {
        if (RB_Item.Checked)
        {
            var (absX, absY) = GetAbsoluteCoordinatesHover();
            var cfg = Editor.Mutator.Manager.ConfigItems;
            var (relX, relY) = cfg.GetCoordinatesRelative(absX, absY);
            if (!cfg.IsCoordinateValidRelative(relX, relY))
            {
                System.Media.SystemSounds.Asterisk.Play();
                return;
            }

            var tile = CurrentLayer.GetTile(relX, relY);
            DeleteTile(tile, relX, relY);
        }
        else if (RB_Terrain.Checked)
        {
            var (absX, absY) = GetAbsoluteCoordinatesHoverTerrain();
            var cfg = Editor.Mutator.Manager.ConfigTerrain;
            var (relX, relY) = cfg.GetCoordinatesRelative(absX, absY);
            if (!cfg.IsCoordinateValidRelative(relX, relY))
            {
                System.Media.SystemSounds.Asterisk.Play();
                return;
            }

            var tile = Editor.Terrain.GetTile(relX, relY);
            DeleteTile(tile);
        }
    }

    private void CM_Click_Opening(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (!RB_Item.Checked) // not in Item edit mode, therefore no "Activate Flag" menu
        {
            if (IsMenuHasActivate)
                CM_Click.Items.Remove(Menu_Activate);
            IsMenuHasActivate = false;
            return;
        }

        var (absX, absY) = GetAbsoluteCoordinatesHover();
        var cfg = Editor.Mutator.Manager.ConfigItems;
        var (relX, relY) = cfg.GetCoordinatesRelative(absX, absY);
        if (!cfg.IsCoordinateValidRelative(relX, relY))
            return;

        var flagLayer = NUD_Layer.Value == 0 ? Map.LayerItemFlag0 : Map.LayerItemFlag1;
        var isActive = flagLayer.GetIsActive(relX, relY);
        Menu_Activate.Text = isActive ? "Inactivate" : "Activate";
        CM_Click.Items.Add(Menu_Activate);
        IsMenuHasActivate = true;
    }

    private void Menu_Activate_Click(object sender, EventArgs e)
    {
        if (!RB_Item.Checked) // not in Item edit mode, therefore no "Activate Flag" menu
            return;

        var (absX, absY) = GetAbsoluteCoordinatesHover();
        var cfg = Editor.Mutator.Manager.ConfigItems;
        var (relX, relY) = cfg.GetCoordinatesRelative(absX, absY);
        if (!cfg.IsCoordinateValidRelative(relX, relY))
            return;

        var flagLayer = NUD_Layer.Value == 0 ? Map.LayerItemFlag0 : Map.LayerItemFlag1;
        var isActive = flagLayer.GetIsActive(relX, relY);
        flagLayer.SetIsActive(relX, relY, !isActive);
    }

    private void B_Up_Click(object sender, EventArgs e)
    {
        if (ModifierKeys == Keys.Shift)
            CB_Acre.SelectedIndex = Math.Max(0, CB_Acre.SelectedIndex - Editor.Items.Layer0.TileInfo.Columns);
        else if (View.ArrowUp())
            LoadItemGridAcre();
    }

    private void B_Left_Click(object sender, EventArgs e)
    {
        if (ModifierKeys == Keys.Shift)
            CB_Acre.SelectedIndex = Math.Max(0, CB_Acre.SelectedIndex - 1);
        else if (View.ArrowLeft())
            LoadItemGridAcre();
    }

    private void B_Right_Click(object sender, EventArgs e)
    {
        if (ModifierKeys == Keys.Shift)
            CB_Acre.SelectedIndex = Math.Min(CB_Acre.SelectedIndex + 1, CB_Acre.Items.Count - 1);
        else if (View.ArrowRight())
            LoadItemGridAcre();
    }

    private void B_Down_Click(object sender, EventArgs e)
    {
        if (ModifierKeys == Keys.Shift)
            CB_Acre.SelectedIndex = Math.Min(CB_Acre.SelectedIndex + Editor.Items.Layer0.TileInfo.Columns, CB_Acre.Items.Count - 1);
        else if (View.ArrowDown())
            LoadItemGridAcre();
    }

    private void B_DumpAcreItem_Click(object sender, EventArgs e)
    {
        var (relX, relY) = Editor.Mutator.Manager.ConfigItems.GetCoordinatesRelative(View.X, View.Y);
        MapDumpHelper.DumpLayerAcreSingle(CurrentLayer, $"{View.X:000}-{View.Y:000}", (int)NUD_Layer.Value, relX, relY);
    }

    private void B_DumpAllAcres_Click(object sender, EventArgs e) => MapDumpHelper.DumpLayerAcreAll(CurrentLayer);

    private void B_ImportAcreItem_Click(object sender, EventArgs e)
    {
        var (relX, relY) = Editor.Mutator.Manager.ConfigItems.GetCoordinatesRelative(View.X, View.Y);
        var layer = CurrentLayer;
        if (!MapDumpHelper.ImportToLayerAcreSingle(layer, $"{View.X:000}-{View.Y:000}", (int)NUD_Layer.Value, relX, relY))
            return;
        ChangeViewToAcre(ExteriorAcreIndex);
        System.Media.SystemSounds.Asterisk.Play();
    }

    private void B_ImportAllAcres_Click(object sender, EventArgs e)
    {
        if (!MapDumpHelper.ImportToLayerAcreAll(CurrentLayer))
            return;
        ChangeViewToAcre(ExteriorAcreIndex);
        System.Media.SystemSounds.Asterisk.Play();
    }

    private void B_DumpAllAcresFlag_Click(object sender, EventArgs e)
        => MapDumpHelper.DumpLayerAllFlag(Editor.Mutator.CurrentLayerFlags, Editor.Mutator.ItemLayerIndex);

    private void B_ImportAllAcresFlag_Click(object sender, EventArgs e)
    {
        var layer = Editor.Mutator.CurrentLayerFlags;
        var index = Editor.Mutator.ItemLayerIndex;
        if (!MapDumpHelper.ImportToLayerAllFlag(layer, index))
            return;
        ChangeViewToAcre(ExteriorAcreIndex);
        System.Media.SystemSounds.Asterisk.Play();
    }

    private void B_DumpBuildings_Click(object sender, EventArgs e) => MapDumpHelper.DumpBuildings(Editor.Buildings.Buildings);

    private void B_ImportBuildings_Click(object sender, EventArgs e)
    {
        if (!MapDumpHelper.ImportBuildings(Editor.Buildings.Buildings))
            return;

        for (int i = 0; i < Editor.Buildings.Count; i++)
            LB_Items.Items[i] = Editor.Buildings[i].ToString();
        LB_Items.SelectedIndex = 0;
        System.Media.SystemSounds.Asterisk.Play();
        ReloadBuildingsTerrain();
    }

    private void B_DumpTerrainAcre_Click(object sender, EventArgs e)
    {
        var (relX, relY) = Editor.Mutator.Manager.ConfigTerrain.GetCoordinatesRelative(View.X / 2, View.Y / 2);
        MapDumpHelper.DumpTerrainAcre(Editor.Terrain, $"{View.X:000}-{View.Y:000}", relX, relY);
    }

    private void B_DumpTerrainAll_Click(object sender, EventArgs e) => MapDumpHelper.DumpTerrainAll(Editor.Terrain);

    private void B_ImportTerrainAcre_Click(object sender, EventArgs e)
    {
        var (relX, relY) = Editor.Mutator.Manager.ConfigTerrain.GetCoordinatesRelative(View.X / 2, View.Y / 2);
        if (!MapDumpHelper.ImportTerrainAcre(Editor.Terrain, $"{View.X:000}-{View.Y:000}", relX, relY))
            return;
        ChangeViewToAcre(ExteriorAcreIndex);
        System.Media.SystemSounds.Asterisk.Play();
    }

    private void B_ImportTerrainAll_Click(object sender, EventArgs e)
    {
        if (!MapDumpHelper.ImportTerrainAll(Editor.Terrain))
            return;
        ChangeViewToAcre(ExteriorAcreIndex);
        System.Media.SystemSounds.Asterisk.Play();
    }

    private void Menu_SavePNG_Click(object sender, EventArgs e)
    {
        if (!WinFormsUtil.TryGetUnderlying<PictureBox>(sender, out var pb) || pb.Image is null)
        {
            WinFormsUtil.Alert(MessageStrings.MsgNoPictureLoaded);
            return;
        }

        CM_Picture.Close(ToolStripDropDownCloseReason.CloseCalled);

        const string name = "map";
        using var sfd = new SaveFileDialog();
        sfd.Filter = "png file (*.png)|*.png|All files (*.*)|*.*";
        sfd.FileName = $"{name}.png";
        if (sfd.ShowDialog() != DialogResult.OK)
            return;

        if (!Menu_SavePNGTerrain.Checked)
        {
            PB_Map.Image!.Save(sfd.FileName, ImageFormat.Png);
        }
        else if (!Menu_SavePNGItems.Checked)
        {
            PB_Map.BackgroundImage!.Save(sfd.FileName, ImageFormat.Png);
        }
        else
        {
            var img = (Bitmap)PB_Map.BackgroundImage!.Clone();
            using var gfx = Graphics.FromImage(img);
            gfx.DrawImage(PB_Map.Image!, new Point(0, 0));
            img.Save(sfd.FileName, ImageFormat.Png);
        }
    }

    private void CM_Picture_Closing(object sender, ToolStripDropDownClosingEventArgs e)
    {
        if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked && sender != Menu_SavePNG)
            e.Cancel = true;
    }

    private void PB_Map_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left)
            return;
        ClickMapAt(e);
    }

    private void ClickMapAt(MouseEventArgs e)
    {
        var (absX, absY) = Editor.GetMapCoordinates(e.X, e.Y, CHK_SnapToAcre.Checked ? MapViewCoordinateRequest.SnapAcre : MapViewCoordinateRequest.Centered);

        // Truncate to root-node coordinates. The map is only 1px per tile, and nobody is wanting to click on extension-tiles.
        absX &= 0xFFFE;
        absY &= 0xFFFE;

        if (View.SetViewTo(absX, absY))
            LoadItemGridAcre();
    }

    private void PB_Map_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            ClickMapAt(e);
        }
        else if (e.Button == MouseButtons.None)
        {
            var (absX, absY) = Editor.GetCursorCoordinates(e.X, e.Y);
            SetCoordinateText(absX, absY);
        }
    }

    private void SetCoordinateText(int absX, int absY) => L_Coordinates.Text = $"({absX:000},{absY:000}) = (0x{absX:X2},0x{absY:X2})";

    private void NUD_Layer_ValueChanged(object sender, EventArgs e)
    {
        View.ItemLayerIndex = (int)NUD_Layer.Value - 1;
        LoadItemGridAcre();
    }

    private void Remove(ToolStripItem sender, Func<int, int, int, int, int> removal)
    {
        var isModifyEntireMap = (ModifierKeys & Keys.Shift) != 0;
        var message = string.Format(MessageStrings.MsgFieldItemRemoveAsk, sender.Text);
        var question = WinFormsUtil.Prompt(MessageBoxButtons.YesNo, message);
        if (question != DialogResult.Yes)
            return;

        var count = Editor.Mutator.ModifyFieldItems(removal, isModifyEntireMap);
        if (count == 0)
        {
            WinFormsUtil.Alert(MessageStrings.MsgFieldItemRemoveNone);
            return;
        }
        LoadItemGridAcre();
        WinFormsUtil.Alert(string.Format(MessageStrings.MsgFieldItemRemoveCount, count));
    }

    private void Modify(ToolStripItem sender, Func<int, int, int, int, int> action)
    {
        var isModifyEntireMap = (ModifierKeys & Keys.Shift) != 0;
        var message = string.Format(MessageStrings.MsgFieldItemModifyAsk, sender.Text);
        var question = WinFormsUtil.Prompt(MessageBoxButtons.YesNo, message);
        if (question != DialogResult.Yes)
            return;

        var count = Editor.Mutator.ModifyFieldItems(action, isModifyEntireMap);
        if (count == 0)
        {
            WinFormsUtil.Alert(MessageStrings.MsgFieldItemModifyNone);
            return;
        }
        LoadItemGridAcre();
        WinFormsUtil.Alert(string.Format(MessageStrings.MsgFieldItemModifyCount, count));
    }

    private void B_RemoveEditor_Click(object sender, EventArgs e)
    {
        var item = ItemEdit.LoadFieldsToNewItem();
        var lambda = new Func<int, int, int, int, int>((min, max, x, y)
            => CurrentLayer.RemoveAllLike(min, max, x, y, item));
        Remove(B_RemoveEditor, lambda);
    }

    private void B_WaterFlowers_Click(object sender, EventArgs e)
    {
        var all = (ModifierKeys & Keys.Control) != 0;
        var lambda = new Func<int, int, int, int, int>((xmin, ymin, width, height)
            => CurrentLayer.WaterAllFlowers(xmin, ymin, width, height, all));
        Modify(B_WaterFlowers, lambda);
    }


    private void B_RemoveAllWeeds_Click(object sender, EventArgs e) => Remove(B_RemoveAllWeeds, CurrentLayer.RemoveAllWeeds);
    private void B_RemoveAllTrees_Click(object sender, EventArgs e) => Remove(B_RemoveAllTrees, CurrentLayer.RemoveAllTrees);
    private void B_FillHoles_Click(object sender, EventArgs e) => Remove(B_FillHoles, CurrentLayer.RemoveAllHoles);
    private void B_RemovePlants_Click(object sender, EventArgs e) => Remove(B_RemovePlants, CurrentLayer.RemoveAllPlants);
    private void B_RemoveFences_Click(object sender, EventArgs e) => Remove(B_RemoveFences, CurrentLayer.RemoveAllFences);
    private void B_RemoveObjects_Click(object sender, EventArgs e) => Remove(B_RemoveObjects, CurrentLayer.RemoveAllObjects);
    private void B_RemoveAll_Click(object sender, EventArgs e) => Remove(B_RemoveAll, CurrentLayer.RemoveAll);
    private void B_RemovePlacedItems_Click(object sender, EventArgs e) => Remove(B_RemovePlacedItems, CurrentLayer.RemoveAllPlacedItems);
    private void B_RemoveShells_Click(object sender, EventArgs e) => Remove(B_RemoveShells, CurrentLayer.RemoveAllShells);
    private void B_RemoveBranches_Click(object sender, EventArgs e) => Remove(B_RemoveBranches, CurrentLayer.RemoveAllBranches);
    private void B_RemoveFlowers_Click(object sender, EventArgs e) => Remove(B_RemoveFlowers, CurrentLayer.RemoveAllFlowers);
    private void B_RemoveBushes_Click(object sender, EventArgs e) => Remove(B_RemoveBushes, CurrentLayer.RemoveAllBushes);

    private static void ShowContextMenuBelow(ToolStripDropDown c, Control n) => c.Show(n.PointToScreen(new Point(0, n.Height)));

    private void B_RemoveItemDropDown_Click(object sender, EventArgs e) => ShowContextMenuBelow(CM_Remove, B_RemoveItemDropDown);
    private void B_DumpLoadField_Click(object sender, EventArgs e) => ShowContextMenuBelow(CM_DLField, B_DumpLoadField);
    private void B_DumpLoadTerrain_Click(object sender, EventArgs e) => ShowContextMenuBelow(CM_DLTerrain, B_DumpLoadTerrain);
    private void B_DumpLoadBuildings_Click(object sender, EventArgs e) => ShowContextMenuBelow(CM_DLBuilding, B_DumpLoadBuildings);
    private void B_ModifyAllTerrain_Click(object sender, EventArgs e) => ShowContextMenuBelow(CM_Terrain, B_ModifyAllTerrain);
    private void B_DumpLoadAcres_Click(object sender, EventArgs e) => ShowContextMenuBelow(CM_DLMapAcres, B_DumpLoadAcres);
    private void TR_Transparency_Scroll(object sender, EventArgs e) => ReloadItems();
    private void TR_BuildingTransparency_Scroll(object sender, EventArgs e) => ReloadBuildingsTerrain();
    private void TR_Terrain_Scroll(object sender, EventArgs e) => ReloadBuildingsTerrain();

    #region Buildings

    private void B_Help_Click(object sender, EventArgs e)
    {
        using var form = new BuildingHelp();
        form.ShowDialog();
    }

    private void NUD_PlazaX_ValueChanged(object sender, EventArgs e)
    {
        if (Loading)
            return;
        Map.Plaza.X = (uint)NUD_PlazaX.Value;
        ReloadBuildingsTerrain();
    }

    private void NUD_PlazaY_ValueChanged(object sender, EventArgs e)
    {
        if (Loading)
            return;
        Map.Plaza.Z = (uint)NUD_PlazaY.Value;
        ReloadBuildingsTerrain();
    }

    private void LB_Items_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (LB_Items.SelectedIndex < 0)
            return;
        LoadBuildingIndex(LB_Items.SelectedIndex);

        // View location snap has changed the view. Reload everything
        LoadItemGridAcre();
        ReloadMapBackground();
    }

    private void LoadBuildingIndex(int index)
    {
        Loading = true;
        SelectedBuildingIndex = index;
        var b = Editor.Buildings[index];
        NUD_BuildingType.Value = (int)b.BuildingType;
        NUD_X.Value = b.X;
        NUD_Y.Value = b.Y;
        NUD_Angle.Value = b.Angle;
        NUD_Bit.Value = b.Bit;
        NUD_Type.Value = b.Type;
        NUD_TypeArg.Value = b.TypeArg;
        NUD_UniqueID.Value = b.UniqueID;
        Loading = false;

        // Jump the view to see the building
        // -16 to put it in the center of the view
        const int shift = 16;
        var x = (b.X - shift) & 0xFFFE;
        var y = (b.Y - shift) & 0xFFFE;
        View.SetViewTo(x, y);
    }

    private void NUD_BuildingType_ValueChanged(object sender, EventArgs e)
    {
        if (Loading || sender is not NumericUpDown n)
            return;

        var b = Editor.Buildings[SelectedBuildingIndex];
        if (sender == NUD_BuildingType)
            b.BuildingType = (BuildingType)n.Value;
        else if (sender == NUD_X)
            b.X = (ushort)n.Value;
        else if (sender == NUD_Y)
            b.Y = (ushort)n.Value;
        else if (sender == NUD_Angle)
            b.Angle = (byte)n.Value;
        else if (sender == NUD_Bit)
            b.Bit = (sbyte)n.Value;
        else if (sender == NUD_Type)
            b.Type = (ushort)n.Value;
        else if (sender == NUD_TypeArg)
            b.TypeArg = (byte)n.Value;
        else if (sender == NUD_UniqueID)
            b.UniqueID = (ushort)n.Value;

        LB_Items.Items[SelectedBuildingIndex] = Editor.Buildings[SelectedBuildingIndex].ToString();
        ReloadBuildingsTerrain();
    }

    #endregion Buildings

    #region Acres

    private void CB_MapAcre_SelectedIndexChanged(object sender, EventArgs e)
    {
        var acre = Editor.Terrain.BaseAcres.Span[CB_MapAcre.SelectedIndex * 2];
        CB_MapAcreSelect.SelectedValue = (int)acre;

        // Jump view if available
        if (CB_Acre.Items.OfType<string>().Any(z => z == CB_MapAcre.Text))
            CB_Acre.Text = CB_MapAcre.Text;
    }

    private void CB_MapAcreSelect_SelectedValueChanged(object sender, EventArgs e)
    {
        if (Loading)
            return;

        var index = CB_MapAcre.SelectedIndex;
        var value = WinFormsUtil.GetIndex(CB_MapAcreSelect);

        // u16[], but values are at most u8 each.
        var span = Editor.Terrain.GetBaseAcreSpan(index);
        var oldValue = span[0];
        if (value == oldValue)
            return;

        System.Buffers.Binary.BinaryPrimitives.WriteUInt16LittleEndian(span, (ushort)value);
        ReloadBuildingsTerrain();
    }

    private void B_DumpMapAcres_Click(object sender, EventArgs e)
    {
        if (!MapDumpHelper.DumpMapAcresAll(Editor.Terrain.BaseAcres.Span))
            return;
        ReloadBuildingsTerrain();
        System.Media.SystemSounds.Asterisk.Play();
    }

    private void B_ImportMapAcres_Click(object sender, EventArgs e)
    {
        if (!MapDumpHelper.ImportMapAcresAll(Editor.Terrain.BaseAcres.Span))
            return;
        ReloadBuildingsTerrain();
        System.Media.SystemSounds.Asterisk.Play();
    }

    #endregion Acres

    private void B_ZeroElevation_Click(object sender, EventArgs e)
    {
        if (DialogResult.Yes != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, MessageStrings.MsgTerrainSetElevation0))
            return;
        foreach (var t in Editor.Terrain.Tiles)
            t.Elevation = 0;
        ReloadBuildingsTerrain();
        System.Media.SystemSounds.Asterisk.Play();
    }

    private void B_SetAllTerrain_Click(object sender, EventArgs e)
    {
        if (DialogResult.Yes != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, MessageStrings.MsgTerrainSetAll))
            return;

        var pgt = (TerrainTile)PG_TerrainTile.SelectedObject!;
        bool interiorOnly = DialogResult.Yes == WinFormsUtil.Prompt(MessageBoxButtons.YesNo, MessageStrings.MsgTerrainSetAllSkipExterior);
        Editor.Terrain.SetAll(pgt, interiorOnly);

        ReloadBuildingsTerrain();
        System.Media.SystemSounds.Asterisk.Play();
    }

    private void B_SetAllRoadTiles_Click(object sender, EventArgs e)
    {
        if (DialogResult.Yes != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, MessageStrings.MsgTerrainSetAll))
            return;

        var pgt = (TerrainTile)PG_TerrainTile.SelectedObject!;
        bool interiorOnly = DialogResult.Yes == WinFormsUtil.Prompt(MessageBoxButtons.YesNo, MessageStrings.MsgTerrainSetAllSkipExterior);
        Editor.Terrain.SetAllRoad(pgt, interiorOnly);

        ReloadBuildingsTerrain();
        System.Media.SystemSounds.Asterisk.Play();
    }

    private void B_ClearPlacedDesigns_Click(object sender, EventArgs e)
    {
        SAV.ClearDesignTiles();
        System.Media.SystemSounds.Asterisk.Play();
    }

    private void B_ExportPlacedDesigns_Click(object sender, EventArgs e)
    {
        using var sfd = new SaveFileDialog();
        sfd.Filter = "nhmd file (*.nhmd)|*.nhmd";
        sfd.FileName = "Island MyDesignMap.nhmd";
        if (sfd.ShowDialog() != DialogResult.OK)
            return;

        string path = sfd.FileName;
        var tiles = SAV.MapDesignTileData.Span;
        File.WriteAllBytes(path, tiles);
        System.Media.SystemSounds.Asterisk.Play();
    }

    private void B_ImportPlacedDesigns_Click(object sender, EventArgs e)
    {
        using var ofd = new OpenFileDialog();
        ofd.Filter = "nhmd file (*.nhmd)|*.nhmd";
        ofd.FileName = "Island MyDesignMap.nhmd";
        if (ofd.ShowDialog() != DialogResult.OK)
            return;

        string path = ofd.FileName;
        var tiles = File.ReadAllBytes(path);
        tiles.CopyTo(SAV.MapDesignTileData.Span);
        System.Media.SystemSounds.Asterisk.Play();
    }

    private void Menu_Spawn_Click(object sender, EventArgs e) => new BulkSpawn(this, View.X, View.Y).ShowDialog();

    private void Menu_Bulk_Click(object sender, EventArgs e)
    {
        var editor = new BatchEditor(Spawn.Tiles, ItemEdit.SetItem(new Item()));
        editor.ShowDialog();
        Spawn.ClearDanglingExtensions(0, 0, Spawn.TileInfo.TotalWidth, Spawn.TileInfo.TotalHeight);
        LoadItemGridAcre();
    }

    private void B_TerrainBrush_Click(object sender, EventArgs e)
    {
        tbeForm = new TerrainBrushEditor(PG_TerrainTile, this);
        tbeForm.Show();
    }

    private void FieldItemEditor_FormClosed(object sender, FormClosedEventArgs e)
    {
        tbeForm?.Close();
    }
}

public interface IItemLayerEditor
{
    void ReloadItems();

    ItemEditor ItemProvider { get; }
    LayerItem Spawn { get; }
}