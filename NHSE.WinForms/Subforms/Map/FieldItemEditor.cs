using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Sprites;

namespace NHSE.WinForms
{
    public sealed partial class FieldItemEditor : Form
    {
        private readonly MainSave SAV;

        private readonly MapManager Map;
        private readonly MapViewer View;

        private bool Loading;
        private int SelectedBuildingIndex;

        private int HoverX;
        private int HoverY;

        public FieldItemEditor(MainSave sav)
        {
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);

            SAV = sav;
            Map = new MapManager(sav);
            View = new MapViewer(Map);

            Loading = true;
            foreach (var acre in MapGrid.Acres)
                CB_Acre.Items.Add(acre.Name);

            NUD_PlazaX.Value = sav.EventPlazaLeftUpX;
            NUD_PlazaY.Value = sav.EventPlazaLeftUpZ;

            foreach (var obj in Map.Buildings)
                LB_Items.Items.Add(obj.ToString());

            ReloadMapBackground();

            var data = GameInfo.Strings.ItemDataSource.ToList();
            var field = FieldItemList.Items.Select(z => z.Value).ToList();
            data.Add(field, GameInfo.Strings.InternalNameTranslation);
            ItemEdit.Initialize(data, true);
            PG_TerrainTile.SelectedObject = new TerrainTile();
            LB_Items.SelectedIndex = 0;
            CB_Acre.SelectedIndex = 0;
            Loading = false;
            LoadItemGridAcre();
        }

        private int AcreIndex => CB_Acre.SelectedIndex;

        private void ChangeAcre(object sender, EventArgs e) => ChangeViewToAcre(AcreIndex);

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
            PB_Map.BackgroundImage = View.GetBackgroundTerrain(SelectedBuildingIndex);
            PB_Map.Invalidate(); // background image reassigning to same img doesn't redraw; force it
        }

        private void ReloadAcreBackground()
        {
            var tbuild = (byte)TR_BuildingTransparency.Value;
            var tterrain = (byte) TR_Terrain.Value;
            PB_Acre.BackgroundImage = View.GetBackgroundAcre(L_Coordinates.Font, tbuild, tterrain, SelectedBuildingIndex);
            PB_Acre.Invalidate(); // background image reassigning to same img doesn't redraw; force it
        }

        private void ReloadMapItemGrid() => PB_Map.Image = View.GetMapWithReticle(GetItemTransparency());
        private void ReloadAcreItemGrid() => PB_Acre.Image = View.GetLayerAcre(GetItemTransparency());

        private void ReloadItems()
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
            if (RB_Item.Checked)
                OmniTile(e);
            else if (RB_Terrain.Checked)
                OmniTileTerrain(e);
        }

        private void OmniTile(MouseEventArgs e)
        {
            var tile = GetTile(Map.CurrentLayer, e, out var x, out var y);
            OmniTile(tile, x, y);
        }

        private void OmniTileTerrain(MouseEventArgs e)
        {
            SetHoveredItem(e);
            var x = View.X + HoverX;
            var y = View.Y + HoverY;
            var tile = Map.Terrain.GetTile(x / 2, y / 2);
            OmniTileTerrain(tile);
        }

        private void OmniTile(Item tile, int x, int y)
        {
            switch (ModifierKeys)
            {
                default:
                    ViewTile(tile);
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
                case Keys.Shift:
                    SetTile(tile);
                    return;
                case Keys.Alt:
                    DeleteTile(tile);
                    return;
            }
        }

        private Item GetTile(FieldItemLayer layer, MouseEventArgs e, out int x, out int y)
        {
            SetHoveredItem(e);
            return layer.GetTile(x = View.X + HoverX, y = View.Y + HoverY);
        }

        private void SetHoveredItem(MouseEventArgs e)
        {
            // Mouse event may fire with a slightly too large x/y; clamp just in case.
            HoverX = (e.X / View.AcreScale) & 0x1F;
            HoverY = (e.Y / View.AcreScale) & 0x1F;
        }

        private void PB_Acre_MouseMove(object sender, MouseEventArgs e)
        {
            var l = Map.CurrentLayer;
            var oldTile = l.GetTile(View.X + HoverX, View.Y + HoverY);
            var tile = GetTile(l, e, out var x, out var y);
            if (tile == oldTile)
                return;
            var str = GameInfo.Strings;
            var name = str.GetItemName(tile);
            TT_Hover.SetToolTip(PB_Acre, name);
            SetCoordinateText(x, y);
        }

        private void ViewTile(Item tile)
        {
            ItemEdit.LoadItem(tile);
            TC_Editor.SelectedTab = Tab_Item;
        }

        private void ViewTile(TerrainTile tile)
        {
            var pgt = (TerrainTile)PG_TerrainTile.SelectedObject;
            pgt.CopyFrom(tile);
            PG_TerrainTile.SelectedObject = pgt;
            TC_Editor.SelectedTab = Tab_Terrain;
        }

        private void SetTile(Item tile, int x, int y)
        {
            var l = Map.CurrentLayer;
            var pgt = new Item();
            ItemEdit.SetItem(pgt);
            var permission = l.IsOccupied(pgt, x, y);
            switch (permission)
            {
                case FieldItemPermission.OutOfBounds:
                case FieldItemPermission.Collision when CHK_NoOverwrite.Checked:
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

        private void SetTile(TerrainTile tile)
        {
            var pgt = (TerrainTile)PG_TerrainTile.SelectedObject;
            tile.CopyFrom(pgt);

            ReloadBuildingsTerrain();
        }

        private void DeleteTile(Item tile, int x, int y)
        {
            if (tile.IsRoot && CHK_AutoExtension.Checked)
                Map.CurrentLayer.DeleteExtensionTiles(tile, x, y);
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
            var unsupported = Map.Items.GetUnsupportedTiles();
            if (unsupported.Count != 0)
            {
                var err = MessageStrings.MsgFieldItemUnsupportedLayer2Tile;
                var ask = MessageStrings.MsgAskContinue;
                var prompt = WinFormsUtil.Prompt(MessageBoxButtons.YesNo, err, ask);
                if (prompt != DialogResult.Yes)
                    return;
            }

            Map.Items.Save();
            SAV.SetTerrainTiles(Map.Terrain.Tiles);
            SAV.Buildings = Map.Buildings;
            SAV.EventPlazaLeftUpX = Map.PlazaX;
            SAV.EventPlazaLeftUpZ = Map.PlazaY;
            Close();
        }

        private void Menu_View_Click(object sender, EventArgs e)
        {
            var x = View.X + HoverX;
            var y = View.Y + HoverY;

            if (RB_Item.Checked)
            {
                var tile = Map.CurrentLayer.GetTile(x, y);
                ViewTile(tile);
            }
            else if (RB_Terrain.Checked)
            {
                var tile = Map.Terrain.GetTile(x / 2, y / 2);
                ViewTile(tile);
            }
        }

        private void Menu_Set_Click(object sender, EventArgs e)
        {
            var x = View.X + HoverX;
            var y = View.Y + HoverY;

            if (RB_Item.Checked)
            {
                var tile = Map.CurrentLayer.GetTile(x, y);
                SetTile(tile, x, y);
            }
            else if (RB_Terrain.Checked)
            {
                var tile = Map.Terrain.GetTile(x / 2, y / 2);
                SetTile(tile);
            }
        }

        private void Menu_Reset_Click(object sender, EventArgs e)
        {
            var x = View.X + HoverX;
            var y = View.Y + HoverY;

            if (RB_Item.Checked)
            {
                var tile = Map.CurrentLayer.GetTile(x, y);
                DeleteTile(tile, x, y);
            }
            else if (RB_Terrain.Checked)
            {
                var tile = Map.Terrain.GetTile(x / 2, y / 2);
                DeleteTile(tile);
            }
        }

        private void B_Up_Click(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Shift)
                CB_Acre.SelectedIndex = Math.Max(0, CB_Acre.SelectedIndex - MapGrid.AcreWidth);
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
                CB_Acre.SelectedIndex = Math.Min(CB_Acre.SelectedIndex + MapGrid.AcreWidth, CB_Acre.Items.Count - 1);
            else if (View.ArrowDown())
                LoadItemGridAcre();
        }

        private void B_DumpAcre_Click(object sender, EventArgs e) => MapDumpHelper.DumpLayerAcreSingle(Map.CurrentLayer, AcreIndex, CB_Acre.Text, (int)NUD_Layer.Value);
        private void B_DumpAllAcres_Click(object sender, EventArgs e) => MapDumpHelper.DumpLayerAcreAll(Map.CurrentLayer);

        private void B_ImportAcre_Click(object sender, EventArgs e)
        {
            var layer = Map.CurrentLayer;
            if (!MapDumpHelper.ImportToLayerAcreSingle(layer, AcreIndex, CB_Acre.Text, (int)NUD_Layer.Value))
                return;
            ChangeViewToAcre(AcreIndex);
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void B_ImportAllAcres_Click(object sender, EventArgs e)
        {
            if (!MapDumpHelper.ImportToLayerAcreAll(Map.CurrentLayer))
                return;
            ChangeViewToAcre(AcreIndex);
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void B_DumpBuildings_Click(object sender, EventArgs e) => MapDumpHelper.DumpBuildings(Map.Buildings);

        private void B_ImportBuildings_Click(object sender, EventArgs e)
        {
            if (!MapDumpHelper.ImportBuildings(Map.Buildings))
                return;

            for (int i = 0; i < Map.Buildings.Count; i++)
                LB_Items.Items[i] = Map.Buildings[i].ToString();
            LB_Items.SelectedIndex = 0;
            System.Media.SystemSounds.Asterisk.Play();
            ReloadBuildingsTerrain();
        }
        private void B_DumpTerrainAcre_Click(object sender, EventArgs e) => MapDumpHelper.DumpTerrainAcre(Map.Terrain, AcreIndex, CB_Acre.Text);
        private void B_DumpTerrainAll_Click(object sender, EventArgs e) => MapDumpHelper.DumpTerrainAll(Map.Terrain);

        private void B_ImportTerrainAcre_Click(object sender, EventArgs e)
        {
            if (!MapDumpHelper.ImportTerrainAcre(Map.Terrain, AcreIndex, CB_Acre.Text))
                return;
            ChangeViewToAcre(AcreIndex);
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void B_ImportTerrainAll_Click(object sender, EventArgs e)
        {
            if (!MapDumpHelper.ImportTerrainAll(Map.Terrain))
                return;
            ChangeViewToAcre(AcreIndex);
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void Menu_SavePNG_Click(object sender, EventArgs e)
        {
            var pb = WinFormsUtil.GetUnderlyingControl<PictureBox>(sender);
            if (pb?.Image == null)
            {
                WinFormsUtil.Alert(MessageStrings.MsgNoPictureLoaded);
                return;
            }

            const string name = "map";
            var bmp = FieldItemSpriteDrawer.GetBitmapItemLayer(Map.Items.Layer1);
            using var sfd = new SaveFileDialog
            {
                Filter = "png file (*.png)|*.png|All files (*.*)|*.*",
                FileName = $"{name}.png",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            bmp.Save(sfd.FileName, ImageFormat.Png);
        }

        private void PB_Map_MouseDown(object sender, MouseEventArgs e) => ClickMapAt(e, true);

        private void ClickMapAt(MouseEventArgs e, bool skipLagCheck)
        {
            var layer = Map.Items.Layer1;
            int mX = e.X;
            int mY = e.Y;
            bool centerReticle = CHK_SnapToAcre.Checked;
            View.GetViewAnchorCoordinates(mX, mY, out var x, out var y, centerReticle);
            x &= 0xFFFE;
            y &= 0xFFFE;

            var acre = layer.GetAcre(x, y);
            bool sameAcre = AcreIndex == acre;
            if (!skipLagCheck)
            {
                if (CHK_SnapToAcre.Checked)
                {
                    if (sameAcre)
                        return;
                }
                else
                {
                    const int delta = 0; // disabled = 0
                    var dx = Math.Abs(View.X - x);
                    var dy = Math.Abs(View.Y - y);
                    if (dx <= delta && dy <= delta && !sameAcre)
                        return;
                }
            }

            if (!CHK_SnapToAcre.Checked)
            {
                View.SetViewTo(x, y);
                LoadItemGridAcre();
                return;
            }

            if (!sameAcre)
                CB_Acre.SelectedIndex = acre;
        }

        private void PB_Map_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ClickMapAt(e, false);
            }
            else
            {
                View.GetCursorCoordinates(e.X, e.Y, out var x, out var y);
                SetCoordinateText(x, y);
            }
        }

        private void SetCoordinateText(int x, int y) => L_Coordinates.Text = $"({x:000},{y:000}) = (0x{x:X2},0x{y:X2})";

        private void NUD_Layer_ValueChanged(object sender, EventArgs e)
        {
            Map.MapLayer = (int) NUD_Layer.Value - 1;
            LoadItemGridAcre();
        }

        private void Remove(ToolStripItem sender, Func<int, int, int, int, int> removal)
        {
            bool wholeMap = ModifierKeys == Keys.Shift;

            string q = string.Format(MessageStrings.MsgFieldItemRemoveAsk, sender.Text);
            var question = WinFormsUtil.Prompt(MessageBoxButtons.YesNo, q);
            if (question != DialogResult.Yes)
                return;

            int count = View.RemoveFieldItems(removal, wholeMap);

            if (count == 0)
            {
                WinFormsUtil.Alert(MessageStrings.MsgFieldItemRemoveNone);
                return;
            }
            LoadItemGridAcre();
            WinFormsUtil.Alert(string.Format(MessageStrings.MsgFieldItemRemoveCount, count));
        }

        private void B_RemoveAllWeeds_Click(object sender, EventArgs e) => Remove(B_RemoveAllWeeds, Map.CurrentLayer.RemoveAllWeeds);
        private void B_FillHoles_Click(object sender, EventArgs e) => Remove(B_FillHoles, Map.CurrentLayer.RemoveAllHoles);
        private void B_RemovePlants_Click(object sender, EventArgs e) => Remove(B_RemovePlants, Map.CurrentLayer.RemoveAllPlants);
        private void B_RemoveFences_Click(object sender, EventArgs e) => Remove(B_RemoveFences, Map.CurrentLayer.RemoveAllFences);
        private void B_RemoveObjects_Click(object sender, EventArgs e) => Remove(B_RemoveObjects, Map.CurrentLayer.RemoveAllObjects);
        private void B_RemoveAll_Click(object sender, EventArgs e) => Remove(B_RemoveAll, Map.CurrentLayer.RemoveAll);
        private void B_RemovePlacedItems_Click(object sender, EventArgs e) => Remove(B_RemovePlacedItems, Map.CurrentLayer.RemoveAllPlacedItems);
        private void B_RemoveShells_Click(object sender, EventArgs e) => Remove(B_RemoveShells, Map.CurrentLayer.RemoveAllShells);
        private void B_RemoveBranches_Click(object sender, EventArgs e) => Remove(B_RemoveBranches, Map.CurrentLayer.RemoveAllBranches);
        private void B_RemoveFlowers_Click(object sender, EventArgs e) => Remove(B_RemoveFlowers, Map.CurrentLayer.RemoveAllFlowers);

        private static void ShowContextMenuBelow(ToolStripDropDown c, Control n) => c.Show(n.PointToScreen(new Point(0, n.Height)));
        private void B_RemoveItemDropDown_Click(object sender, EventArgs e) => ShowContextMenuBelow(CM_Remove, B_RemoveItemDropDown);
        private void B_DumpLoadField_Click(object sender, EventArgs e) => ShowContextMenuBelow(CM_DLField, B_DumpLoadField);
        private void B_DumpLoadTerrain_Click(object sender, EventArgs e) => ShowContextMenuBelow(CM_DLTerrain, B_DumpLoadTerrain);
        private void B_DumpLoadBuildings_Click(object sender, EventArgs e) => ShowContextMenuBelow(CM_DLBuilding, B_DumpLoadBuildings);
        private void B_ModifyAllTerrain_Click(object sender, EventArgs e) => ShowContextMenuBelow(CM_Terrain, B_ModifyAllTerrain);
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
            Map.PlazaX = (uint) NUD_PlazaX.Value;
            ReloadBuildingsTerrain();
        }

        private void NUD_PlazaY_ValueChanged(object sender, EventArgs e)
        {
            if (Loading)
                return;
            Map.PlazaY = (uint) NUD_PlazaY.Value;
            ReloadBuildingsTerrain();
        }

        private void LB_Items_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_Items.SelectedIndex < 0)
                return;
            LoadIndex(LB_Items.SelectedIndex);
            ReloadBuildingsTerrain();
        }

        private void LoadIndex(int index)
        {
            Loading = true;
            SelectedBuildingIndex = index;
            var b = Map.Buildings[index];
            NUD_BuildingType.Value = (int)b.BuildingType;
            NUD_X.Value = b.X;
            NUD_Y.Value = b.Y;
            NUD_Angle.Value = b.Angle;
            NUD_Bit.Value = b.Bit;
            NUD_Type.Value = b.Type;
            NUD_TypeArg.Value = b.TypeArg;
            NUD_UniqueID.Value = b.UniqueID;
            Loading = false;
        }

        private void NUD_BuildingType_ValueChanged(object sender, EventArgs e)
        {
            if (Loading || !(sender is NumericUpDown n))
                return;

            var b = Map.Buildings[SelectedBuildingIndex];
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

            LB_Items.Items[SelectedBuildingIndex] = Map.Buildings[SelectedBuildingIndex].ToString();
            ReloadBuildingsTerrain();
        }
        #endregion
    }
}
