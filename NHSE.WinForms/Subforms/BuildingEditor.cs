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
        private readonly TerrainManager Terrain;
        private static readonly IReadOnlyDictionary<string, string[]> HelpDictionary = StructureUtil.GetStructureHelpList();

        public BuildingEditor(IReadOnlyList<Building> buildings, MainSave sav)
        {
            InitializeComponent();
            Buildings = buildings;
            DialogResult = DialogResult.Cancel;

            foreach (var obj in buildings)
                LB_Items.Items.Add(obj.ToString());

            Terrain = new TerrainManager(sav.GetTerrain());

            LB_Items.SelectedIndex = 0;
            foreach (var entry in HelpDictionary)
                CB_StructureType.Items.Add(entry.Key);
            CB_StructureType.SelectedIndex = 0;
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private int Index;
        private bool Loading;
        private void DrawMap(in int index) => PB_Map.Image = TerrainSprite.GetMapWithBuildings(Terrain, Buildings, B_Save.Font, 4, index);

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
            NUD_Rot.Value = b.Rotation;
            NUD_08.Value = b.Unk08;
            NUD_0C.Value = b.Unk0C;
            NUD_10.Value = b.Unk10;
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
            else if (sender == NUD_Rot)
                b.Rotation = (ushort)n.Value;
            else if (sender == NUD_08)
                b.Unk08 = (uint)n.Value;
            else if (sender == NUD_0C)
                b.Unk0C = (uint)n.Value;
            else if (sender == NUD_10)
                b.Unk10 = (uint)n.Value;

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
    }
}
