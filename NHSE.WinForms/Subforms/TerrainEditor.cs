using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Sprites;

namespace NHSE.WinForms
{
    public partial class TerrainEditor : Form
    {
        private readonly MainSave SAV;
        private readonly Button[] Grid;
        private readonly TerrainManager Terrain;

        private const int SquareSize = 50;

        public TerrainEditor(MainSave sav)
        {
            SAV = sav;
            InitializeComponent();

            Terrain = new TerrainManager(SAV.Terrain);
            Grid = GenerateGrid(TerrainManager.GridWidth, TerrainManager.GridHeight);

            foreach (var acre in Terrain.Acres)
                CB_Acre.Items.Add(acre.Name);

            PG_Tile.SelectedObject = new TerrainTile();
            CB_Acre.SelectedIndex = 0;
            ReloadMap();
        }

        private int AcreIndex => CB_Acre.SelectedIndex;
        private void ChangeAcre(object sender, EventArgs e) => LoadGrid(AcreIndex);
        private void ReloadMap() => PB_Map.Image = TerrainSprite.CreateMap(Terrain, 2, AcreIndex);

        private void LoadGrid(int index)
        {
            for (int i = 0; i < TerrainManager.AcreSize; i++)
            {
                var b = Grid[i];
                var tile = Terrain.GetAcreTile(index, i);
                RefreshTile(b, tile);
            }
            UpdateArrowVisibility(index);
            ReloadMap();
        }

        private void UpdateArrowVisibility(int index)
        {
            B_Up.Enabled = index > TerrainManager.AcreWidth;
            B_Down.Enabled = index < TerrainManager.AcreWidth * (TerrainManager.AcreHeight - 1);
            B_Left.Enabled = index % TerrainManager.AcreWidth != 0;
            B_Right.Enabled = index % TerrainManager.AcreWidth != TerrainManager.AcreWidth - 1;
        }

        private Button[] GenerateGrid(int w, int h)
        {
            var grid = new Button[w * h];
            int i = 0;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    var item = GetGridItem(index: i, x, y);
                    FLP_Tile.Controls.Add(item);
                    grid[i++] = item;
                }

                var last = grid[i - 1];
                FLP_Tile.SetFlowBreak(last, true);
            }

            return grid;
        }

        private Button GetGridItem(int index, int x, int y)
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
                GetTile(button, out var tile, out var obj);
                switch (ModifierKeys)
                {
                    default: ViewTile(tile); return;
                    case Keys.Shift: SetTile(tile, obj); return;
                    case Keys.Alt: DeleteTile(tile, obj); return;
                }
            };
            return button;
        }

        private void ViewTile(TerrainTile tile)
        {
            var pgt = (TerrainTile)PG_Tile.SelectedObject;
            pgt.CopyFrom(tile);
            PG_Tile.SelectedObject = pgt;
        }

        private void SetTile(TerrainTile tile, Control obj)
        {
            var pgt = (TerrainTile)PG_Tile.SelectedObject;
            tile.CopyFrom(pgt);
            RefreshTile(obj, tile);
            ReloadMap();
        }

        private void DeleteTile(TerrainTile tile, Control obj)
        {
            tile.Clear();
            RefreshTile(obj, tile);
            ReloadMap();
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            SAV.Terrain = Terrain.Tiles;
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

        private void GetTile(object sender, out TerrainTile tile, out Button obj)
        {
            obj = WinFormsUtil.GetUnderlyingControl<Button>(sender) ?? throw new ArgumentNullException(nameof(sender));

            var index = Array.IndexOf(Grid, obj);
            if (index < 0)
                throw new ArgumentException(nameof(Button));

            tile = Terrain.GetAcreTile(AcreIndex, index);
        }

        private static void RefreshTile(Control button, TerrainTile tile)
        {
            button.Text = TerrainSprite.GetTileName(tile);
            button.BackColor = TerrainSprite.GetTileColor(tile);
        }

        private void B_Up_Click(object sender, EventArgs e) => CB_Acre.SelectedIndex -= TerrainManager.AcreWidth;
        private void B_Left_Click(object sender, EventArgs e) => --CB_Acre.SelectedIndex;
        private void B_Right_Click(object sender, EventArgs e) => ++CB_Acre.SelectedIndex;
        private void B_Down_Click(object sender, EventArgs e) => CB_Acre.SelectedIndex += TerrainManager.AcreWidth;

        private void B_ZeroElevation_Click(object sender, EventArgs e)
        {
            foreach (var t in Terrain.Tiles)
                t.Elevation = 0;
            LoadGrid(AcreIndex);
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void B_ClearAll_Click(object sender, EventArgs e)
        {
            foreach (var t in Terrain.Tiles)
                t.Clear();
            LoadGrid(AcreIndex);
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void B_DumpAcre_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Terrain (*.nht)|*.nht|All files (*.*)|*.*",
                FileName = $"{CB_Acre.Text}.nht",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var path = sfd.FileName;
            var acre = AcreIndex;
            var data = Terrain.DumpAcre(acre);
            File.WriteAllBytes(path, data);
        }

        private void B_DumpAllAcres_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "New Horizons Terrain (*.nht)|*.nht|All files (*.*)|*.*",
                FileName = $"{CB_Acre.Text}.nht",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            var path = sfd.FileName;
            var data = Terrain.DumpAllAcres();
            File.WriteAllBytes(path, data);
        }

        private void B_ImportAcre_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Terrain (*.nht)|*.nht|All files (*.*)|*.*",
                FileName = "terrainAcres.nht",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            var path = ofd.FileName;
            var fi = new FileInfo(path);

            const int expect = TerrainManager.AcreSize * TerrainTile.SIZE;
            if (fi.Length != expect)
            {
                WinFormsUtil.Error($"Expected size (0x{expect:X}) != Input size (0x{fi.Length:X}", path);
                return;
            }

            var data = File.ReadAllBytes(path);
            Terrain.ImportAcre(AcreIndex, data);
            LoadGrid(AcreIndex);
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void B_ImportAllAcres_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "New Horizons Terrain (*.nht)|*.nht|All files (*.*)|*.*",
                FileName = "terrainAcres.nht",
            };
            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            var path = ofd.FileName;
            var fi = new FileInfo(path);

            const int expect = TerrainManager.TileCount * TerrainTile.SIZE;
            if (fi.Length != expect)
            {
                WinFormsUtil.Error($"Expected size (0x{expect:X}) != Input size (0x{fi.Length:X}", path);
                return;
            }

            var data = File.ReadAllBytes(path);
            Terrain.ImportAllAcres(data);
            LoadGrid(AcreIndex);
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
            var bmp = TerrainSprite.CreateMap(Terrain);
            using var sfd = new SaveFileDialog
            {
                Filter = "png file (*.png)|*.png|All files (*.*)|*.*",
                FileName = $"{name}.png",
            };
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            bmp.Save(sfd.FileName, ImageFormat.Png);
        }

        private void PB_Map_MouseDown(object sender, MouseEventArgs e)
        {
            var x = e.X / (2 * TerrainManager.GridWidth);
            var y = e.Y / (2 * TerrainManager.GridHeight);

            var index = (y * TerrainManager.AcreWidth) + x;
            var clamp = Math.Max(0, Math.Min((TerrainManager.AcreHeight * TerrainManager.AcreWidth) - 1, index));

            if (AcreIndex != clamp)
                CB_Acre.SelectedIndex = clamp;
        }
    }
}
