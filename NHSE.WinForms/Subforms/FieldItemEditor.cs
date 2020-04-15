using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Sprites;

namespace NHSE.WinForms
{
    public partial class FieldItemEditor : Form
    {
        private readonly MainSave SAV;
        private readonly FieldItemManager Items;

        private const int MapScale = 1;
        private const int AcreScale = 16;

        // Cached acre view objects to remove allocation/GC
        private readonly int[] Scale1;
        private readonly int[] ScaleX;
        private readonly Bitmap ScaleAcre;

        private readonly int[] Map;
        private readonly Bitmap MapReticle;

        private int X;
        private int Y;

        public FieldItemEditor(MainSave sav)
        {
            SAV = sav;
            InitializeComponent();

            Items = new FieldItemManager(SAV.GetFieldItems());

            var l1 = Items.Layer1;
            Scale1 = new int[l1.GridWidth * l1.GridHeight];
            ScaleX = new int[Scale1.Length * AcreScale * AcreScale];
            ScaleAcre = new Bitmap(l1.GridWidth * AcreScale, l1.GridHeight * AcreScale);

            Map = new int[l1.MapWidth * l1.MapHeight * MapScale * MapScale];
            MapReticle = new Bitmap(l1.MapWidth * MapScale, l1.MapHeight * MapScale);

            foreach (var acre in MapGrid.Acres)
                CB_Acre.Items.Add(acre.Name);

            PG_Tile.SelectedObject = new FieldItem();
            CB_Acre.SelectedIndex = 0;
            LoadGrid(X, Y);
        }

        private int AcreIndex => CB_Acre.SelectedIndex;

        private void ChangeAcre(object sender, EventArgs e) => ChangeViewToAcre(AcreIndex);

        private void ChangeViewToAcre(int acre)
        {
            Items.Layer1.GetViewAnchorCoordinates(acre, out X, out Y);
            LoadGrid(X, Y);
        }

        private FieldItemLayer Layer => NUD_Layer.Value == 1 ? Items.Layer1 : Items.Layer2;

        private void ReloadMap()
        {
            PB_Map.Image = FieldItemSpriteDrawer.GetBitmapLayer(Layer, X, Y, Map, MapReticle);
        }

        private void LoadGrid(int topX, int topY)
        {
            ReloadGrid(Layer, topX, topY);
            UpdateArrowVisibility();
            ReloadMap();
        }

        private void ReloadGrid(FieldItemLayer layer, int topX, int topY)
        {
            PB_Acre.Image = FieldItemSpriteDrawer.GetBitmapLayerAcre(layer, topX, topY, AcreScale, Scale1, ScaleX, ScaleAcre);
        }

        private void UpdateArrowVisibility()
        {
            B_Up.Enabled = Y != 0;
            B_Down.Enabled = Y < Layer.MapHeight - Layer.GridHeight;
            B_Left.Enabled = X != 0;
            B_Right.Enabled = X < Layer.MapWidth - Layer.GridWidth;
        }

        private void PB_Acre_MouseClick(object sender, MouseEventArgs e)
        {
            var tile = GetTile(Layer, e);
            switch (ModifierKeys)
            {
                default: ViewTile(tile); return;
                case Keys.Shift: SetTile(tile); return;
                case Keys.Alt: DeleteTile(tile); return;
            }
        }

        private int HoverX;
        private int HoverY;

        private FieldItem GetTile(FieldItemLayer layer, MouseEventArgs e)
        {
            SetHoveredItem(e);
            return layer.GetTile(X + HoverX, Y + HoverY);
        }

        private void SetHoveredItem(MouseEventArgs e)
        {
            HoverX = e.X / AcreScale;
            HoverY = e.Y / AcreScale;
        }

        private void PB_Acre_MouseMove(object sender, MouseEventArgs e)
        {
            var oldTile = Layer.GetTile(X + HoverX, Y + HoverY);
            var tile = GetTile(Layer, e);
            if (tile == oldTile)
                return;
            var str = GameInfo.Strings;
            var name = str.GetItemName(tile);
            TT_Hover.SetToolTip(PB_Acre, name);
        }

        private void ViewTile(FieldItem tile)
        {
            var pgt = (FieldItem)PG_Tile.SelectedObject;
            pgt.CopyFrom(tile);
            PG_Tile.SelectedObject = pgt;
        }

        private void SetTile(FieldItem tile)
        {
            var pgt = (FieldItem)PG_Tile.SelectedObject;
            tile.CopyFrom(pgt);
            ReloadGrid(Layer, X, Y);
            ReloadMap();
        }

        private void DeleteTile(FieldItem tile)
        {
            tile.Delete();
            ReloadGrid(Layer, X, Y);
            ReloadMap();
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            var all = ArrayUtil.ConcatAll(Items.Layer1.Tiles, Items.Layer2.Tiles);
            SAV.SetFieldItems(all);
            Close();
        }

        private void Menu_View_Click(object sender, EventArgs e)
        {
            var tile = Layer.GetTile(X + HoverX, Y + HoverY);
            ViewTile(tile);
        }

        private void Menu_Set_Click(object sender, EventArgs e)
        {
            var tile = Layer.GetTile(X + HoverX, Y + HoverY);
            SetTile(tile);
        }

        private void Menu_Reset_Click(object sender, EventArgs e)
        {
            var tile = Layer.GetTile(X + HoverX, Y + HoverY);
            DeleteTile(tile);
        }

        private void B_Up_Click(object sender, EventArgs e)
        {
            if (ModifierKeys != Keys.Shift)
            {
                if (Y != 0)
                    LoadGrid(X, --Y);
                return;
            }

            CB_Acre.SelectedIndex -= MapGrid.AcreWidth;
        }

        private void B_Left_Click(object sender, EventArgs e)
        {
            if (ModifierKeys != Keys.Shift)
            {
                if (X != 0)
                    LoadGrid(--X, Y);
                return;
            }

            --CB_Acre.SelectedIndex;
        }

        private void B_Right_Click(object sender, EventArgs e)
        {
            if (ModifierKeys != Keys.Shift)
            {
                if (X != Layer.MapWidth - 1)
                    LoadGrid(++X, Y);
                return;
            }

            ++CB_Acre.SelectedIndex;
        }

        private void B_Down_Click(object sender, EventArgs e)
        {
            if (ModifierKeys != Keys.Shift)
            {
                if (Y != Layer.MapHeight - 1)
                    LoadGrid(X, ++Y);
                return;
            }

            CB_Acre.SelectedIndex += MapGrid.AcreWidth;
        }

        private void B_DumpAcre_Click(object sender, EventArgs e)
        {
            var layer = Layer;
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Field Item Layer (*.nhl)|*.nhl|All files (*.*)|*.*",
                FileName = $"{CB_Acre.Text}-{NUD_Layer.Value}.nhl",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var path = sfd.FileName;
            var acre = AcreIndex;
            var data = layer.DumpAcre(acre);
            File.WriteAllBytes(path, data);
        }

        private void B_DumpAllAcres_Click(object sender, EventArgs e)
        {
            var layer = Layer;
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Field Item Layer (*.nhl)|*.nhl|All files (*.*)|*.*",
                FileName = "acres.nhl",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var path = sfd.FileName;
            var data = layer.DumpAllAcres();
            File.WriteAllBytes(path, data);
        }

        private void B_ImportAcre_Click(object sender, EventArgs e)
        {
            var layer = Layer;
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Field Item Layer (*.nhl)|*.nhl|All files (*.*)|*.*",
                FileName = $"{CB_Acre.Text}-{NUD_Layer.Value}.nhl",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            var path = ofd.FileName;
            var fi = new FileInfo(path);

            int expect = layer.AcreTileCount * FieldItem.SIZE;
            if (fi.Length != expect)
            {
                WinFormsUtil.Error($"Expected size (0x{expect:X}) != Input size (0x{fi.Length:X}", path);
                return;
            }

            var data = File.ReadAllBytes(path);
            layer.ImportAcre(AcreIndex, data);
            ChangeViewToAcre(AcreIndex);
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void B_ImportAllAcres_Click(object sender, EventArgs e)
        {
            var layer = Layer;
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Field Item Layer (*.nhl)|*.nhl|All files (*.*)|*.*",
                FileName = "acres.nhl",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            var path = ofd.FileName;
            var fi = new FileInfo(path);

            int expect = layer.MapTileCount * FieldItem.SIZE;
            if (fi.Length != expect)
            {
                WinFormsUtil.Error($"Expected size (0x{expect:X}) != Input size (0x{fi.Length:X}", path);
                return;
            }

            var data = File.ReadAllBytes(path);
            layer.ImportAllAcres(data);
            ChangeViewToAcre(AcreIndex);
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void Menu_SavePNG_Click(object sender, EventArgs e)
        {
            var pb = WinFormsUtil.GetUnderlyingControl<PictureBox>(sender);
            if (pb?.Image == null)
            {
                WinFormsUtil.Alert("No picture loaded.");
                return;
            }

            const string name = "map";
            var bmp = FieldItemSpriteDrawer.GetBitmapLayer(Items.Layer1);
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
            var layer = Items.Layer1;
            int mX = e.X;
            int mY = e.Y;
            bool centerReticle = CHK_SnapToAcre.Checked;
            GetViewAnchorCoordinates(mX, mY, out var x, out var y, centerReticle);

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
                    var dx = Math.Abs(X - x);
                    var dy = Math.Abs(Y - y);
                    if (dx <= delta && dy <= delta && !sameAcre)
                        return;
                }
            }

            if (!CHK_SnapToAcre.Checked)
            {
                LoadGrid(X = x, Y = y);
                return;
            }

            if (!sameAcre)
                CB_Acre.SelectedIndex = acre;
        }

        private static void GetCursorCoordinates(int mX, int mY, out int x, out int y)
        {
            x = mX / MapScale;
            y = mY / MapScale;
        }

        private void GetViewAnchorCoordinates(int mX, int mY, out int x, out int y, bool centerReticle)
        {
            var layer = Items.Layer1;
            GetCursorCoordinates(mX, mY, out x, out y);
            layer.GetViewAnchorCoordinates(ref x, ref y, centerReticle);
        }

        private void PB_Map_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ClickMapAt(e, false);
            }
            else
            {
                int mX = e.X;
                int mY = e.Y;
                GetCursorCoordinates(mX, mY, out var x, out var y);
                L_Coordinates.Text = $"({x:000},{y:000}) = (0x{x:X2},0x{y:X2})";
            }
        }

        private void NUD_Layer_ValueChanged(object sender, EventArgs e) => LoadGrid(X, Y);

        private void Remove(Control sender, Func<int, int, int, int, int> removal)
        {
            bool wholeMap = ModifierKeys == Keys.Shift;

            string q = $"Are you sure you want to remove {sender.Text}?";
            var question = WinFormsUtil.Prompt(MessageBoxButtons.YesNo, q);
            if (question != DialogResult.Yes)
                return;

            var count = wholeMap
                ? removal(0, 0, Layer.MapWidth, Layer.MapHeight)
                : removal(X, Y, Layer.GridWidth, Layer.GridHeight);

            if (count == 0)
            {
                WinFormsUtil.Alert("Nothing removed (none found).");
                return;
            }
            LoadGrid(X, Y);
            WinFormsUtil.Alert($"Removed {count} from the map.");
        }

        private void B_RemoveAllWeeds_Click(object sender, EventArgs e) => Remove(B_RemoveAllWeeds, Layer.RemoveAllWeeds);
        private void B_FillHoles_Click(object sender, EventArgs e) => Remove(B_FillHoles, Layer.RemoveAllHoles);
        private void B_RemovePlants_Click(object sender, EventArgs e) => Remove(B_RemovePlants, Layer.RemoveAllPlants);
        private void B_RemoveFences_Click(object sender, EventArgs e) => Remove(B_RemoveFences, Layer.RemoveAllFences);
        private void B_RemoveObjects_Click(object sender, EventArgs e) => Remove(B_RemoveObjects, Layer.RemoveAllObjects);
        private void B_RemoveAll_Click(object sender, EventArgs e) => Remove(B_RemoveAll, Layer.RemoveAll);
        private void B_RemovePlacedItems_Click(object sender, EventArgs e) => Remove(B_RemovePlacedItems, Layer.RemoveAllPlacedItems);

        private void PG_Tile_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) => PG_Tile.SelectedObject = PG_Tile.SelectedObject;
    }
}
