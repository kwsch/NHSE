using NHSE.Core;
using System;
using System.Windows.Forms;
using static NHSE.Core.TerrainUnitModel;

namespace NHSE.WinForms.Subforms.Map;

public partial class TerrainBrushEditor : Form
{
    public readonly PropertyGrid PG_TerrainTile;
    private readonly FieldItemEditor FIEWindow;

    public TrackBar Slider_thickness => slider_thickness;

    public bool IsBrushSelected;

    public bool RandomizeVariation;

    public TerrainBrushEditor(PropertyGrid pG_TerrainTile, FieldItemEditor fieWindow)
    {
        PG_TerrainTile = pG_TerrainTile;
        FIEWindow = fieWindow;
        InitializeComponent();
        this.TranslateInterface(GameInfo.CurrentLanguage);
    }

    protected override void OnLoad(EventArgs e)
    {
        CenterToParent();
        base.OnLoad(e);
    }

    #region Tiles buttons

    #region Dirt tiles

    private void NW_Rounded_Tile_Click(object sender, EventArgs e) => SelectTerrainTile(Cliff3B);
    private void N_tile_Click(object sender, EventArgs e) => SelectTerrainTile(Cliff5B, 3);
    private void NE_rounded_tile_Click(object sender, EventArgs e) => SelectTerrainTile(Cliff3B, 3);
    private void W_tile_Click(object sender, EventArgs e) => SelectTerrainTile(Cliff5B);
    private void Middle_tile_Click(object sender, EventArgs e) => SelectTerrainTile();
    private void E_tile_Click(object sender, EventArgs e) => SelectTerrainTile(Cliff5B, 2);
    private void SW_rounded_tile_Click(object sender, EventArgs e) => SelectTerrainTile(Cliff3B, 1);
    private void S_tile_Click(object sender, EventArgs e) => SelectTerrainTile(Cliff5B, 1);
    private void SE_rounded_tile_Click(object sender, EventArgs e) => SelectTerrainTile(Cliff3B, 2);
    private void NW_angular_tile_Click(object sender, EventArgs e) => SelectTerrainTile(Cliff3C);
    private void NE_angular_tile_Click(object sender, EventArgs e) => SelectTerrainTile(Cliff3C, 3);
    private void SW_angular_tile_Click(object sender, EventArgs e) => SelectTerrainTile(Cliff3C, 1);
    private void SE_angular_tile_Click(object sender, EventArgs e) => SelectTerrainTile(Cliff3C, 2);

    private void TR_dirt_inside_Click(object sender, EventArgs e) => SelectTerrainTile(Cliff7A, 2);
    private void DL_dirt_inside_Click(object sender, EventArgs e) => SelectTerrainTile(Cliff7A);
    private void DR_dirt_inside_Click(object sender, EventArgs e) => SelectTerrainTile(Cliff7A, 1);

    #endregion Dirt tiles

    #region Water tiles

    private void NW_diagonal_water_tile_Click(object sender, EventArgs e) => SelectTerrainTile(River3B);
    private void N_water_tile_Click(object sender, EventArgs e) => SelectTerrainTile(River5B, 3);
    private void NE_diagonal_water_tile_Click(object sender, EventArgs e) => SelectTerrainTile(River3B, 3);
    private void W_water_tile_Click(object sender, EventArgs e) => SelectTerrainTile(River5B);
    private void Center_water_tile_Click(object sender, EventArgs e) => SelectTerrainTile(River8A);
    private void e_water_tile_Click(object sender, EventArgs e) => SelectTerrainTile(River5B, 2);
    private void sw_diagonal_water_tile_Click(object sender, EventArgs e) => SelectTerrainTile(River3B, 1);
    private void s_water_tile_Click(object sender, EventArgs e) => SelectTerrainTile(River5B, 1);
    private void SE_diagonal_water_tile_Click(object sender, EventArgs e) => SelectTerrainTile(River3B, 2);
    private void NW_angular_water_tile_Click(object sender, EventArgs e) => SelectTerrainTile(River3C);
    private void NE_angular_water_tile_Click(object sender, EventArgs e) => SelectTerrainTile(River3C, 3);
    private void SW_angular_water_tile_Click(object sender, EventArgs e) => SelectTerrainTile(River3C, 1);
    private void SE_angular_water_tile_Click(object sender, EventArgs e) => SelectTerrainTile(River3C, 2);
    private void TL_dirt_inside_Click(object sender, EventArgs e) => SelectTerrainTile(Cliff7A, 3);
    private void TL_water_inside_Click(object sender, EventArgs e) => SelectTerrainTile(River7A, 3);
    private void TR_water_inside_Click(object sender, EventArgs e) => SelectTerrainTile(River7A, 2);
    private void DL_water_inside_Click(object sender, EventArgs e) => SelectTerrainTile(River7A);
    private void DR_water_inside_Click(object sender, EventArgs e) => SelectTerrainTile(River7A, 1);

    #endregion Water tiles

    #endregion Tiles buttons

    private void SliderThicknessValueChanged(object sender, EventArgs e) => lbl_size_count.Text = slider_thickness.Value.ToString();

    private void SliderElevationValueChanged(object sender, EventArgs e)
    {
        lbl_elevation_count.Text = slider_elevation.Value.ToString();
        var currentTile = (TerrainTile)PG_TerrainTile.SelectedObject!;
        currentTile.Elevation = (ushort)slider_elevation.Value;
        PG_TerrainTile.SelectedObject = currentTile;
    }

    private TerrainTile CreateTerrainTile(TerrainUnitModel unitModel = Base, ushort landMakingAngle = 0) => new()
    {
        Elevation = (ushort)slider_elevation.Value,
        UnitModel = unitModel,
        LandMakingAngle = landMakingAngle
    };

    private void SelectTerrainTile(TerrainUnitModel unitModel = Base, ushort landMakingAngle = 0)
        => PG_TerrainTile.SelectedObject = CreateTerrainTile(unitModel, landMakingAngle);

    private void B_Brush_Click(object sender, EventArgs e) => IsBrushSelected = true;
    private void TerrainBrushEditor_FormClosed(object sender, FormClosedEventArgs e) => IsBrushSelected = false;
    private void B_Normal_Click(object sender, EventArgs e) => IsBrushSelected = false;
    private void CB_TileVariation_CheckedChanged(object sender, EventArgs e) => RandomizeVariation = cb_tileVariation.Checked;
}