using System;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class SaveRoomFloorWallEditor : Form
    {
        public GSaveRoomFloorWall Entity { get; private set; }

        public SaveRoomFloorWallEditor(GSaveRoomFloorWall v)
        {
            Entity = v;
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);
            DialogResult = DialogResult.Cancel;

            var ent = Entity;
            NUD_DesignAccent.Value = ent.AccentWallMyDesignID;
            NUD_DesignWall.Value = ent.WallMyDesignID;
            NUD_DesignFloor.Value = ent.FloorMyDesignID;

            NUD_DirAccent.Value = ent.AccentWallDirection;
            NUD_InfoBit.Value = ent.InfoBit;
            NUD_DirFloor.Value = ent.FloorDirection;
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            var ent = Entity;

            ent.AccentWallMyDesignID = (ushort)NUD_DesignAccent.Value;
            ent.WallMyDesignID = (ushort)NUD_DesignWall.Value;
            ent.FloorMyDesignID = (ushort)NUD_DesignFloor.Value;

            ent.AccentWallDirection = (byte)NUD_DirAccent.Value;
            ent.InfoBit = (byte)NUD_InfoBit.Value;
            ent.FloorDirection = (byte)NUD_DirFloor.Value;

            Entity = ent;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void B_AccentWall_Click(object sender, EventArgs e)
        {
            var ent = Entity;
            var accent = ent.AccentWallItem.ToBytes().ToClass<Item>();
            using var editor = new SingleItemEditor(accent);
            editor.ShowDialog();
            if (editor.DialogResult == DialogResult.OK)
                ent.AccentWallItem = editor.Item.ToBytesClass().ToStructure<GSaveItemName>();
            Entity = ent;
        }

        private void B_Wall_Click(object sender, EventArgs e)
        {
            var ent = Entity;
            var accent = ent.WallItem.ToBytes().ToClass<Item>();
            using var editor = new SingleItemEditor(accent);
            editor.ShowDialog();
            if (editor.DialogResult == DialogResult.OK)
                ent.WallItem = editor.Item.ToBytesClass().ToStructure<GSaveItemName>();
            Entity = ent;
        }

        private void B_Floor_Click(object sender, EventArgs e)
        {
            var ent = Entity;
            var accent = ent.FloorItem.ToBytes().ToClass<Item>();
            using var editor = new SingleItemEditor(accent);
            editor.ShowDialog();
            if (editor.DialogResult == DialogResult.OK)
                ent.FloorItem = editor.Item.ToBytesClass().ToStructure<GSaveItemName>();
            Entity = ent;
        }
    }
}
