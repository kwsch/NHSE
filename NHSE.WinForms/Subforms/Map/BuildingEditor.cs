using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Sprites;

namespace NHSE.WinForms
{
    public partial class BuildingEditor : Form
    {
        private readonly IReadOnlyList<Building> Buildings;
        private readonly MainSave SAV;
        private readonly TerrainManager Terrain;
        private static readonly IReadOnlyDictionary<string, string[]> HelpDictionary = StructureUtil.GetStructureHelpList();

        public BuildingEditor(IReadOnlyList<Building> buildings, MainSave sav)
        {
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);
            SAV = sav;
            Buildings = buildings;
            Terrain = new TerrainManager(sav.GetTerrainTiles());

            NUD_PlazaX.Value = sav.PlazaX;
            NUD_PlazaY.Value = sav.PlazaY;

            foreach (var obj in buildings)
                LB_Items.Items.Add(obj.ToString());

            LB_Items.SelectedIndex = 0;
            foreach (var entry in HelpDictionary)
                CB_StructureType.Items.Add(entry.Key);
            CB_StructureType.SelectedIndex = 0;

            DialogResult = DialogResult.Cancel;
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            SAV.PlazaX = (uint)NUD_PlazaX.Value;
            SAV.PlazaY = (uint)NUD_PlazaY.Value;

            DialogResult = DialogResult.OK;
            Close();
        }

        private int Index;
        private bool Loading;

        private void DrawMap(in int index)
        {
            var font = B_Save.Font;
            const int scale = 4;
            var px = (ushort) NUD_PlazaX.Value;
            var py = (ushort) NUD_PlazaY.Value;
            PB_Map.Image = TerrainSprite.GetMapWithBuildings(Terrain, Buildings, px, py, font, scale, index);
        }

        private void LB_Items_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_Items.SelectedIndex < 0)
                return;
            LoadIndex(LB_Items.SelectedIndex);
            DrawMap(Index);
        }

        private void LoadIndex(int index)
        {
            Loading = true;
            Index = index;
            var b = Buildings[index];
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

            var b = Buildings[Index];
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

            LB_Items.Items[Index] = Buildings[Index].ToString();
            DrawMap(Index);
        }

        private void CB_StructureType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = CB_StructureType.Text;
            var values = HelpDictionary[name];
            CB_StructureValues.Items.Clear();
            foreach (var item in values)
                CB_StructureValues.Items.Add(item);
            CB_StructureValues.SelectedIndex = 0;
        }

        private void NUD_PlazaCoordinate_ValueChanged(object sender, EventArgs e) => DrawMap(Index);

        private void B_DumpAll_Click(object sender, EventArgs e) => MapDumpHelper.DumpBuildings(Buildings);

        private void B_ImportAll_Click(object sender, EventArgs e)
        {
            if (!MapDumpHelper.ImportBuildings(Buildings))
                return;

            for (int i = 0; i < Buildings.Count; i++)
                LB_Items.Items[i] = Buildings[i].ToString();
            LB_Items.SelectedIndex = 0;
            DrawMap(0);
            System.Media.SystemSounds.Asterisk.Play();
        }
    }
}
