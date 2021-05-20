using NHSE.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NHSE.WinForms.Subforms.Map
{
    public partial class TerrainBrushEditor : Form
    {
        public PropertyGrid PG_TerrainTile;
        private FieldItemEditor FIEWindow;

        public TrackBar Slider_thickness { get => slider_thickness; }

        public bool brushSelected;

        public bool randomizeVariation;

        public TerrainBrushEditor(PropertyGrid pG_TerrainTile, FieldItemEditor fieWindow)
        {
            InitializeComponent();
            this.PG_TerrainTile = pG_TerrainTile;
            this.FIEWindow = fieWindow;
        }

        #region Tiles buttons

        #region Dirt tiles

        private void nw_rounded_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.Cliff3B;
            newTile.LandMakingAngle = 0;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void n_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.Cliff5B;
            newTile.LandMakingAngle = 3;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void ne_rounded_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.Cliff3B;
            newTile.LandMakingAngle = 3;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void w_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.Cliff5B;
            newTile.LandMakingAngle = 0;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void middle_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void e_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.Cliff5B;
            newTile.LandMakingAngle = 2;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void sw_rounded_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.Cliff3B;
            newTile.LandMakingAngle = 1;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void s_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.Cliff5B;
            newTile.LandMakingAngle = 1;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void se_rounded_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.Cliff3B;
            newTile.LandMakingAngle = 2;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void nw_angular_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.Cliff3C;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void ne_angular_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.Cliff3C;
            newTile.LandMakingAngle = 3;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void sw_angular_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.Cliff3C;
            newTile.LandMakingAngle = 1;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void se_angular_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.Cliff3C;
            newTile.LandMakingAngle = 2;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void tr_dirt_inside_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.Cliff7A;
            newTile.LandMakingAngle = 2;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void dl_dirt_inside_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.Cliff7A;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void dr_dirt_inside_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.Cliff7A;
            newTile.LandMakingAngle = 1;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        #endregion Dirt tiles

        #region Water tiles

        private void nw_diagonal_water_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.River3B;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void n_water_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.River5B;
            newTile.LandMakingAngle = 3;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void ne_diagonal_water_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.River3B;
            newTile.LandMakingAngle = 3;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void w_water_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.River5B;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void center_water_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.River8A;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void e_water_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.River5B;
            newTile.LandMakingAngle = 2;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void sw_diagonal_water_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.River3B;
            newTile.LandMakingAngle = 1;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void s_water_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.River5B;
            newTile.LandMakingAngle = 1;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void se_diagonal_water_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.River3B;
            newTile.LandMakingAngle = 2;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void nw_angular_water_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.River3C;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void ne_angular_water_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.River3C;
            newTile.LandMakingAngle = 3;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void sw_angular_water_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.River3C;
            newTile.LandMakingAngle = 1;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void se_angular_water_tile_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.River3C;
            newTile.LandMakingAngle = 2;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void tl_dirt_inside_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.Cliff7A;
            newTile.LandMakingAngle = 3;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void tl_water_inside_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.River7A;
            newTile.LandMakingAngle = 3;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void tr_water_inside_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.River7A;
            newTile.LandMakingAngle = 2;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void dl_water_inside_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.River7A;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        private void dr_water_inside_Click(object sender, EventArgs e)
        {
            TerrainTile newTile = new TerrainTile();
            newTile.UnitModel = TerrainUnitModel.River7A;
            newTile.LandMakingAngle = 1;
            newTile.Elevation = (ushort)slider_elevation.Value;

            PG_TerrainTile.SelectedObject = newTile;
        }

        #endregion Water tiles

        #endregion Tiles buttons

        private void slider_thickness_ValueChanged(object sender, EventArgs e)
        {
            lbl_size_count.Text = slider_thickness.Value.ToString();
        }

        private void slider_elevation_ValueChanged(object sender, EventArgs e)
        {
            lbl_elevation_count.Text = slider_elevation.Value.ToString();
            TerrainTile currentTile = (TerrainTile)PG_TerrainTile.SelectedObject;
            currentTile.Elevation = (ushort)slider_elevation.Value;
            PG_TerrainTile.SelectedObject = currentTile;
        }

        private void btn_brush_Click(object sender, EventArgs e)
        {
            brushSelected = true;
        }

        private void TerrainBrushEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            brushSelected = false;
        }

        private void btn_normal_click_Click(object sender, EventArgs e)
        {
            brushSelected = false;
        }

        private void cb_tileVariation_CheckedChanged(object sender, EventArgs e)
        {
            randomizeVariation = cb_tileVariation.Checked;
        }
    }
}