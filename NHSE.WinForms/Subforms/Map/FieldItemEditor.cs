using System;
using System.Collections.Generic;
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

    private readonly bool IsExtendedMap30;

    private bool Loading;
    private int SelectedBuildingIndex;

    private int HoverX;
    private int HoverY;
    private int DragX = -1;
    private int DragY = -1;
    private bool Dragging;

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
        var scale = (PB_Acre.Width - 2) / LayerFieldItem.TilesPerAcreDim; // 1px border
        SAV = sav;
        IsExtendedMap30 = sav.FieldItemAcreWidth != 7;
        Editor = MapEditor.FromSaveFile(sav);
        Editor.MapScale = scale;
        Editor.ViewScale = scale;
        Renderer = new MapRenderer(Editor);

        Loading = true;

        LoadComboBoxes();
        LoadBuildings(sav);
        ReloadMapBackground();
        LoadEditors();
        LB_Items.SelectedIndex = 0;
        CB_Acre.SelectedIndex = 0;
        CB_MapAcre.SelectedIndex = 0;
        Loading = false;
        LoadItemGridAcre();
    }

    private void LoadComboBoxes()
    {
        // Snap viewport to acre
        foreach (var acre in AcreCoordinate.Acres)
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

    private int AcreIndex => CB_Acre.SelectedIndex;

    private void ChangeAcre(object sender, EventArgs e)
    {
        ChangeViewToAcre(AcreIndex);
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
        ReloadAcreBackground();
        UpdateArrowVisibility();
    }

    private int GetItemTransparency() => ((int)(0xFF * TR_Transparency.Value / 100d) << 24) | 0x00FF_FFFF;

    private void ReloadMapBackground()
    {
        var img = Renderer.GetBackgroundTerrain(SelectedBuildingIndex);
        SetMapBackgroundImage(img);
    }

    private void ReloadMapItemGrid() => SetMapForegroundImage(Renderer.GetMapWithReticle(GetItemTransparency()));

    private void SetMapBackgroundImage(Bitmap img)
    {
        if (IsExtendedMap30)
            img = Renderer.GetInflatedImage(img);
        PB_Map.BackgroundImage = img;
        PB_Map.Invalidate(); // background image reassigning to same img doesn't redraw; force it
    }

    private void SetMapForegroundImage(Bitmap img)
    {
        PB_Map.Image = img;
    }

    private void ReloadAcreBackground()
    {
        var tbuild = (byte)TR_BuildingTransparency.Value;
        var tterrain = (byte)TR_Terrain.Value;
        var img = Renderer.GetBackgroundAcre(L_Coordinates.Font, tbuild, tterrain, SelectedBuildingIndex);
        PB_Acre.BackgroundImage = img;
        PB_Acre.Invalidate(); // background image reassigning to same img doesn't redraw; force it
    }

    private void ReloadAcreItemGrid() => PB_Acre.Image = Renderer.GetLayerAcre(GetItemTransparency());

    public void ReloadItems()
    {
        ReloadAcreItemGrid();
        ReloadMapItemGrid();
    }

    private void ReloadBuildingsTerrain()
    {
        ReloadAcreBackground();
        ReloadMapBackground();
    }

    private void UpdateArrowVisibility()
    {
        B_Up.Enabled = View.CanUp;
        B_Down.Enabled = View.CanDown;
        B_Left.Enabled = View.CanLeft;
        B_Right.Enabled = View.CanRight;
    }

    private void PB_Acre_MouseClick(object sender, MouseEventArgs e)
    {
        if (Dragging)
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
        Dragging = false;
    }

    private void OmniTile(MouseEventArgs e)
    {
        var tile = GetTile(CurrentLayer, e, out var x, out var y);
        OmniTile(tile, x, y);
    }

    private void OmniTileTerrain(MouseEventArgs e)
    {
        SetHoveredItem(e);
        var x = View.X + HoverX;
        var y = View.Y + HoverY;
        TerrainTile tile = Editor.Terrain.GetTile(x / 2, y / 2);
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
                    selectedTiles.Add(Editor.Terrain.GetTile((x / 2) + i, (y / 2) + j));
            }
        }

        SetTiles(selectedTiles);
    }

    private void OmniTile(Item tile, int x, int y)
    {
        switch (ModifierKeys)
        {
            default:
                ViewTile(tile, x, y);
                return;

            case Keys.Alt | Keys.Control:
            case Keys.Alt | Keys.Control | Keys.Shift:
                ReplaceTile(tile, x, y);
                return;

            case Keys.Shift:
                SetTile(tile, x, y);
                return;

            case Keys.Alt:
                DeleteTile(tile, x, y);
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

    private Item GetTile(LayerFieldItem layerField, MouseEventArgs e, out int x, out int y)
    {
        SetHoveredItem(e);
        return layerField.GetTile(x = View.X + HoverX, y = View.Y + HoverY);
    }

    private void SetHoveredItem(MouseEventArgs e)
    {
        GetAcreCoordinates(e, out HoverX, out HoverY);

        // Mouse event may fire with a slightly too large x/y; clamp just in case.
        HoverX &= 0x1F;
        HoverY &= 0x1F;
    }

    private void GetAcreCoordinates(MouseEventArgs e, out int x, out int y)
    {
        x = e.X / Editor.ViewScale;
        y = e.Y / Editor.ViewScale;
    }

    private void PB_Acre_MouseDown(object sender, MouseEventArgs e) => ResetDrag();

    private void PB_Acre_MouseMove(object sender, MouseEventArgs e)
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

        var oldTile = l.GetTile(View.X + HoverX, View.Y + HoverY);
        var tile = GetTile(l, e, out var x, out var y);
        if (ReferenceEquals(tile, oldTile))
            return;
        var str = GameInfo.Strings;
        var name = str.GetItemName(tile);
        var flagLayer = NUD_Layer.Value == 0 ? Map.LayerItemFlag0 : Map.LayerItemFlag1;
        var isActive = flagLayer.GetIsActive(x, y);
        if (isActive)
            name = $"{name} [Active]";
        TT_Hover.SetToolTip(PB_Acre, name);
        SetCoordinateText(x, y);
    }

    private void MoveDrag(MouseEventArgs e)
    {
        GetAcreCoordinates(e, out var nhX, out var nhY);

        if (DragX == -1)
        {
            DragX = nhX;
            DragY = nhY;
            return;
        }

        var dX = DragX - nhX;
        var dY = DragY - nhY;

        if (ModifierKeys == Keys.Control)
        {
            dX *= 2;
            dY *= 2;
        }

        if ((dX & 1) == 1)
            dX ^= 1;
        if ((dY & 1) == 1)
            dY ^= 1;

        var aX = Math.Abs(dX);
        var aY = Math.Abs(dY);
        if (aX < 2 && aY < 2)
            return;

        DragX = nhX;
        DragY = nhY;
        if (!View.SetViewTo(View.X + dX, View.Y + dY))
            return;

        Dragging = true;
        LoadItemGridAcre();
    }

    private void ViewTile(Item tile, int x, int y)
    {
        if (CHK_RedirectExtensionLoad.Checked && tile.IsExtension)
        {
            var l = CurrentLayer;
            var rx = Math.Max(0, Math.Min(l.TileInfo.TotalWidth - 1, x - tile.ExtensionX));
            var ry = Math.Max(0, Math.Min(l.TileInfo.TotalHeight - 1, y - tile.ExtensionY));
            var redir = l.GetTile(rx, ry);
            if (redir.IsRoot && redir.ItemId == tile.ExtensionItemId)
                tile = redir;
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

    private void SetTile(Item tile, int x, int y)
    {
        var l = CurrentLayer;
        var pgt = new Item();
        ItemEdit.SetItem(pgt);

        if (pgt.IsFieldItem && CHK_FieldItemSnap.Checked)
        {
            // coordinates must be even (not odd-half)
            x &= 0xFFFE;
            y &= 0xFFFE;
            tile = l.GetTile(x, y);
        }

        var permission = l.IsOccupied(pgt, x, y);
        switch (permission)
        {
            case PlacedItemPermission.OutOfBounds:
            case PlacedItemPermission.Collision when CHK_NoOverwrite.Checked:
                System.Media.SystemSounds.Asterisk.Play();
                return;
        }

        // Clean up original placed data
        if (tile.IsRoot && CHK_AutoExtension.Checked)
            l.DeleteExtensionTiles(tile, x, y);

        // Set new placed data
        if (pgt.IsRoot && CHK_AutoExtension.Checked)
            l.SetExtensionTiles(pgt, x, y);
        tile.CopyFrom(pgt);

        ReloadItems();
    }

    private void ReplaceTile(Item tile, int x, int y)
    {
        var l = CurrentLayer;
        var pgt = new Item();
        ItemEdit.SetItem(pgt);

        if (pgt.IsFieldItem && CHK_FieldItemSnap.Checked)
        {
            // coordinates must be even (not odd-half)
            x &= 0xFFFE;
            y &= 0xFFFE;
            tile = l.GetTile(x, y);
        }

        var permission = l.IsOccupied(pgt, x, y);
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
        bool rotated = tile.Rotate();
        if (!rotated)
        {
            System.Media.SystemSounds.Asterisk.Play();
            return;
        }
        ReloadBuildingsTerrain();
    }

    private void SetTile(TerrainTile tile)
    {
        var pgt = (TerrainTile)PG_TerrainTile.SelectedObject!;
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
        foreach (TerrainTile tile in tiles)
        {
            tile.CopyFrom(pgt);
        }

        ReloadBuildingsTerrain();
    }

    private void DeleteTile(Item tile, int x, int y)
    {
        if (CHK_AutoExtension.Checked)
        {
            var layer = CurrentLayer;
            if (!tile.IsRoot)
            {
                x -= tile.ExtensionX;
                y -= tile.ExtensionY;
                tile = layer.GetTile(x, y);
            }
            layer.DeleteExtensionTiles(tile, x, y);
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
        var x = View.X + HoverX;
        var y = View.Y + HoverY;

        if (RB_Item.Checked)
        {
            var tile = CurrentLayer.GetTile(x, y);
            ViewTile(tile, x, y);
        }
        else if (RB_Terrain.Checked)
        {
            TerrainTile tile = Editor.Terrain.GetTile(x / 2, y / 2);
            ViewTile(tile);
        }
    }

    private void Menu_Set_Click(object sender, EventArgs e)
    {
        var x = View.X + HoverX;
        var y = View.Y + HoverY;

        if (RB_Item.Checked)
        {
            var tile = CurrentLayer.GetTile(x, y);
            SetTile(tile, x, y);
        }
        else if (RB_Terrain.Checked)
        {
            var tile = Editor.Terrain.GetTile(x / 2, y / 2);
            SetTile(tile);
        }
    }

    private void Menu_Reset_Click(object sender, EventArgs e)
    {
        var x = View.X + HoverX;
        var y = View.Y + HoverY;

        if (RB_Item.Checked)
        {
            var tile = CurrentLayer.GetTile(x, y);
            DeleteTile(tile, x, y);
        }
        else if (RB_Terrain.Checked)
        {
            var tile = Editor.Terrain.GetTile(x / 2, y / 2);
            DeleteTile(tile);
        }
    }

    private bool hasActivate = true;

    private void CM_Click_Opening(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (!RB_Item.Checked)
        {
            if (hasActivate)
                CM_Click.Items.Remove(Menu_Activate);
            hasActivate = false;
            return;
        }

        var x = View.X + HoverX;
        var y = View.Y + HoverY;
        var flagLayer = NUD_Layer.Value == 0 ? Map.LayerItemFlag0 : Map.LayerItemFlag1;
        var isActive = flagLayer.GetIsActive(x, y);
        Menu_Activate.Text = isActive ? "Inactivate" : "Activate";
        CM_Click.Items.Add(Menu_Activate);
        hasActivate = true;
    }

    private void Menu_Activate_Click(object sender, EventArgs e)
    {
        var x = View.X + HoverX;
        var y = View.Y + HoverY;
        var flagLayer = NUD_Layer.Value == 0 ? Map.LayerItemFlag0 : Map.LayerItemFlag1;
        var isActive = flagLayer.GetIsActive(x, y);
        flagLayer.SetIsActive(x, y, !isActive);
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

    private void B_DumpAcre_Click(object sender, EventArgs e) => MapDumpHelper.DumpLayerAcreSingle(CurrentLayer, AcreIndex, CB_Acre.Text, (int)NUD_Layer.Value);

    private void B_DumpAllAcres_Click(object sender, EventArgs e) => MapDumpHelper.DumpLayerAcreAll(CurrentLayer);

    private void B_ImportAcre_Click(object sender, EventArgs e)
    {
        var layer = CurrentLayer;
        if (!MapDumpHelper.ImportToLayerAcreSingle(layer, AcreIndex, CB_Acre.Text, (int)NUD_Layer.Value))
            return;
        ChangeViewToAcre(AcreIndex);
        System.Media.SystemSounds.Asterisk.Play();
    }

    private void B_ImportAllAcres_Click(object sender, EventArgs e)
    {
        if (!MapDumpHelper.ImportToLayerAcreAll(CurrentLayer))
            return;
        ChangeViewToAcre(AcreIndex);
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

    private void B_DumpTerrainAcre_Click(object sender, EventArgs e) => MapDumpHelper.DumpTerrainAcre(Editor.Terrain, AcreIndex, CB_Acre.Text);

    private void B_DumpTerrainAll_Click(object sender, EventArgs e) => MapDumpHelper.DumpTerrainAll(Editor.Terrain);

    private void B_ImportTerrainAcre_Click(object sender, EventArgs e)
    {
        if (!MapDumpHelper.ImportTerrainAcre(Editor.Terrain, AcreIndex, CB_Acre.Text))
            return;
        ChangeViewToAcre(AcreIndex);
        System.Media.SystemSounds.Asterisk.Play();
    }

    private void B_ImportTerrainAll_Click(object sender, EventArgs e)
    {
        if (!MapDumpHelper.ImportTerrainAll(Editor.Terrain))
            return;
        ChangeViewToAcre(AcreIndex);
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
        var (x, y) = Editor.GetMapCoordinates(e.X, e.Y, CHK_SnapToAcre.Checked ? MapViewCoordinateRequest.SnapAcre : MapViewCoordinateRequest.Centered);

        // Truncate to root-node coordinates. The map is only 1px per tile, and nobody is wanting to click on extension-tiles.
        x &= 0xFFFE;
        y &= 0xFFFE;

        if (View.SetViewTo(x, y))
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
            Editor.GetCursorCoordinates(e.X, e.Y, out var x, out var y);
            SetCoordinateText(x, y);
        }
    }

    private void SetCoordinateText(int x, int y) => L_Coordinates.Text = $"({x:000},{y:000}) = (0x{x:X2},0x{y:X2})";

    private void NUD_Layer_ValueChanged(object sender, EventArgs e)
    {
        View.ItemLayerIndex = (int)NUD_Layer.Value - 1;
        LoadItemGridAcre();
    }

    private void Remove(ToolStripItem sender, Func<int, int, int, int, int> removal)
    {
        bool wholeMap = (ModifierKeys & Keys.Shift) != 0;

        string q = string.Format(MessageStrings.MsgFieldItemRemoveAsk, sender.Text);
        var question = WinFormsUtil.Prompt(MessageBoxButtons.YesNo, q);
        if (question != DialogResult.Yes)
            return;

        int count = Editor.Mutator.ModifyFieldItems(removal, wholeMap);

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
        bool wholeMap = (ModifierKeys & Keys.Shift) != 0;

        string q = string.Format(MessageStrings.MsgFieldItemModifyAsk, sender.Text);
        var question = WinFormsUtil.Prompt(MessageBoxButtons.YesNo, q);
        if (question != DialogResult.Yes)
            return;

        int count = Editor.Mutator.ModifyFieldItems(action, wholeMap);

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
        LoadIndex(LB_Items.SelectedIndex);

        // View location snap has changed the view. Reload everything
        LoadItemGridAcre();
        ReloadMapBackground();
    }

    private void LoadIndex(int index)
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

        // -32 for relative offset on map (buildings can be placed on the exterior ocean acres)
        // -16 to put it in the center of the view
        const int shift = 48;
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

        var span = Editor.Terrain.BaseAcres.Span.Slice(index * 2, 2);
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