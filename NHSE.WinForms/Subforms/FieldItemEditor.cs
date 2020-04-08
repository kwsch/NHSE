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
        private readonly Button[] Grid;
        private readonly FieldItemManager Items;

        private int GridWidth => Items.Layer1.GridWidth;
        private int GridHeight => Items.Layer1.GridHeight;

        private const int SquareSize = 25;
        private const int MapScale = 1;

        public FieldItemEditor(MainSave sav)
        {
            SAV = sav;
            InitializeComponent();

            Items = new FieldItemManager(SAV.GetFieldItems());
            Grid = GenerateGrid(GridWidth, GridHeight);

            foreach (var acre in MapGrid.Acres)
                CB_Acre.Items.Add(acre.Name);

            PG_Tile.SelectedObject = new FieldItem();
            CB_Acre.SelectedIndex = 0;
            ReloadMap();
        }

        private int X;
        private int Y;

        private int AcreIndex => CB_Acre.SelectedIndex;

        private void ChangeAcre(object sender, EventArgs e) => ChangeViewToAcre(AcreIndex);

        private void ChangeViewToAcre(int acre)
        {
            Items.Layer1.GetViewAnchorCoordinates(acre, out X, out Y);
            LoadGrid(X, Y);
            UpdateArrowVisibility(acre);
        }

        private FieldItemLayer Layer => NUD_Layer.Value == 1 ? Items.Layer1 : Items.Layer2;

        private void ReloadMap()
        {
            PB_Map.Image = SpriteUtil.FieldItems.GetBitmapLayer(Layer, X, Y);
        }

        private void LoadGrid(int topX, int topY)
        {
            var layer = Layer;
            for (int x = 0; x < GridWidth; x++)
            {
                for (int y = 0; y < GridHeight; y++)
                {
                    var controlIndex = (y * GridWidth) + x;
                    var b = Grid[controlIndex];

                    var rx = topX + x;
                    var ry = topY + y;
                    var tile = layer.GetTile(rx, ry);
                    RefreshTile(b, tile);
                }
            }
            ReloadMap();
        }

        private void UpdateArrowVisibility(int index)
        {
            B_Up.Enabled = index >= MapGrid.AcreWidth;
            B_Down.Enabled = index < MapGrid.AcreWidth * (MapGrid.AcreHeight - 1);
            B_Left.Enabled = index % MapGrid.AcreWidth != 0;
            B_Right.Enabled = index % MapGrid.AcreWidth != MapGrid.AcreWidth - 1;
        }

        private Button[] GenerateGrid(int w, int h)
        {
            var grid = new Button[w * h];
            int i = 0;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    var item = CreateGridItem(index: i, x, y);
                    FLP_Tile.Controls.Add(item);
                    grid[i++] = item;
                }

                var last = grid[i - 1];
                FLP_Tile.SetFlowBreak(last, true);
            }

            return grid;
        }

        private Button CreateGridItem(int index, int x, int y)
        {
            var button = new Button
            {
                Name = index.ToString(),
                Text = $"{index:000} ({x},{y})",
                Size = new Size(SquareSize, SquareSize),
                Padding = Padding.Empty,
                Margin = Padding.Empty,
                ContextMenuStrip = CM_Click,
                FlatStyle = FlatStyle.Flat,
            };

            button.Click += (sender, args) =>
            {
                var tile = GetTile(Layer, index);
                switch (ModifierKeys)
                {
                    default: ViewTile(tile); return;
                    case Keys.Shift: SetTile(tile, button); return;
                    case Keys.Alt: DeleteTile(tile, button); return;
                }
            };
            button.MouseEnter += (sender, args) =>
            {
                var tile = GetTile(Layer, index);
                var str = GameInfo.Strings;
                var name = str.GetItemName(tile.DisplayItemId);
                TT_Hover.SetToolTip(button, name);
            };
            button.MouseLeave += (sender, args) => TT_Hover.RemoveAll();

            return button;
        }

        private void ViewTile(FieldItem tile)
        {
            var pgt = (FieldItem)PG_Tile.SelectedObject;
            pgt.CopyFrom(tile);
            PG_Tile.SelectedObject = pgt;
        }

        private void SetTile(FieldItem tile, Control obj)
        {
            var pgt = (FieldItem)PG_Tile.SelectedObject;
            tile.CopyFrom(pgt);
            RefreshTile(obj, tile);
            ReloadMap();
        }

        private void DeleteTile(FieldItem tile, Control obj)
        {
            tile.Delete();
            RefreshTile(obj, tile);
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
            GetTile(sender, out var tile, out _);
            ViewTile(tile);
        }

        private void Menu_Set_Click(object sender, EventArgs e)
        {
            GetTile(sender, out var tile, out var obj);
            SetTile(tile, obj);
        }

        private void Menu_Reset_Click(object sender, EventArgs e)
        {
            GetTile(sender, out var tile, out var obj);
            DeleteTile(tile, obj);
        }

        private void GetTile(object sender, out FieldItem tile, out Button obj)
        {
            obj = WinFormsUtil.GetUnderlyingControl<Button>(sender) ?? throw new ArgumentNullException(nameof(sender));

            var index = Array.IndexOf(Grid, obj);
            if (index < 0)
                throw new ArgumentException(nameof(Button));

            tile = GetTile(Layer, index);
        }

        private FieldItem GetTile(FieldItemLayer layer, int index)
        {
            var x = X + (index % layer.GridWidth);
            var y = Y + (index / layer.GridWidth);
            return layer.GetTile(x, y);
        }

        private static void RefreshTile(Control button, FieldItem tile)
        {
            button.Text = ItemInfo.GetItemKind(tile).ToString();
            button.BackColor = FieldItemSprite.GetItemColor(tile);
        }

        private void B_Up_Click(object sender, EventArgs e) => CB_Acre.SelectedIndex -= MapGrid.AcreWidth;
        private void B_Left_Click(object sender, EventArgs e) => --CB_Acre.SelectedIndex;
        private void B_Right_Click(object sender, EventArgs e) => ++CB_Acre.SelectedIndex;
        private void B_Down_Click(object sender, EventArgs e) => CB_Acre.SelectedIndex += MapGrid.AcreWidth;

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

            int expect = layer.AcreTileCount * FieldItem.SIZE;
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
            var bmp = SpriteUtil.FieldItems.GetBitmapLayer(Items.Layer1);
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
    }
}
