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
            PG_TerrainTile = pG_TerrainTile;
            FIEWindow = fieWindow;
        }

        #region Tiles buttons

        #region Dirt tiles

        private void NW_Rounded_Tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.Cliff3B,
            LandMakingAngle = 0,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void N_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.Cliff5B,
            LandMakingAngle = 3,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void NE_rounded_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.Cliff3B,
            LandMakingAngle = 3,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void W_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.Cliff5B,
            LandMakingAngle = 0,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void Middle_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            Elevation = (ushort)slider_elevation.Value,
        };

        private void E_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.Cliff5B,
            LandMakingAngle = 2,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void SW_rounded_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.Cliff3B,
            LandMakingAngle = 1,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void S_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.Cliff5B,
            LandMakingAngle = 1,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void SE_rounded_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.Cliff3B,
            LandMakingAngle = 2,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void NW_angular_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.Cliff3C,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void NE_angular_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.Cliff3C,
            LandMakingAngle = 3,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void SW_angular_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.Cliff3C,
            LandMakingAngle = 1,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void SE_angular_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.Cliff3C,
            LandMakingAngle = 2,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void TR_dirt_inside_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.Cliff7A,
            LandMakingAngle = 2,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void DL_dirt_inside_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.Cliff7A,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void DR_dirt_inside_Click(object sender, EventArgs e)
        {
            PG_TerrainTile.SelectedObject = new TerrainTile
            {
                UnitModel = TerrainUnitModel.Cliff7A,
                LandMakingAngle = 1,
                Elevation = (ushort)slider_elevation.Value,
            };
        }

        #endregion Dirt tiles

        #region Water tiles

        private void NW_diagonal_water_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.River3B,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void N_water_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.River5B,
            LandMakingAngle = 3,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void NE_diagonal_water_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.River3B,
            LandMakingAngle = 3,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void W_water_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.River5B,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void Center_water_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.River8A,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void e_water_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.River5B,
            LandMakingAngle = 2,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void sw_diagonal_water_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.River3B,
            LandMakingAngle = 1,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void s_water_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.River5B,
            LandMakingAngle = 1,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void SE_diagonal_water_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.River3B,
            LandMakingAngle = 2,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void NW_angular_water_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.River3C,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void NE_angular_water_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.River3C,
            LandMakingAngle = 3,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void SW_angular_water_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.River3C,
            LandMakingAngle = 1,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void SE_angular_water_tile_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.River3C,
            LandMakingAngle = 2,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void TL_dirt_inside_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.Cliff7A,
            LandMakingAngle = 3,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void TL_water_inside_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.River7A,
            LandMakingAngle = 3,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void TR_water_inside_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.River7A,
            LandMakingAngle = 2,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void DL_water_inside_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.River7A,
            Elevation = (ushort)slider_elevation.Value,
        };

        private void DR_water_inside_Click(object sender, EventArgs e) => PG_TerrainTile.SelectedObject = new TerrainTile
        {
            UnitModel = TerrainUnitModel.River7A,
            LandMakingAngle = 1,
            Elevation = (ushort)slider_elevation.Value,
        };

        #endregion Water tiles

        #endregion Tiles buttons

        private void SliderThicknessValueChanged(object sender, EventArgs e)
        {
            lbl_size_count.Text = slider_thickness.Value.ToString();
        }

        private void SliderElevationValueChanged(object sender, EventArgs e)
        {
            lbl_elevation_count.Text = slider_elevation.Value.ToString();
            TerrainTile currentTile = (TerrainTile)PG_TerrainTile.SelectedObject;
            currentTile.Elevation = (ushort)slider_elevation.Value;
            PG_TerrainTile.SelectedObject = currentTile;
        }

        private void B_Brush_Click(object sender, EventArgs e)
        {
            brushSelected = true;
        }

        private void TerrainBrushEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            brushSelected = false;
        }

        private void B_Normal_Click(object sender, EventArgs e)
        {
            brushSelected = false;
        }

        private void CB_TileVariation_CheckedChanged(object sender, EventArgs e)
        {
            randomizeVariation = cb_tileVariation.Checked;
        }
    }
}