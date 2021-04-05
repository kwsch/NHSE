using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using NHSE.Core;
using NHSE.Sprites;

namespace NHSE.WinForms
{
    public partial class PlayerHouseEditor : Form
    {
        private readonly PlayerHouse[] Houses;
        private readonly IReadOnlyList<Player> Players;
        private RoomItemManager Manager;
        private const int scale = 24;

        private int Index = -1;
        private int RoomIndex = -1;

        public PlayerHouseEditor(PlayerHouse[] houses, IReadOnlyList<Player> players, int index)
        {
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);
            Houses = houses;
            Players = players;
            Manager = new RoomItemManager(houses[0].GetRoom(0));

            var data = GameInfo.Strings.ItemDataSource;
            ItemEdit.Initialize(data, true);

            DialogResult = DialogResult.Cancel;

            for (var i = 0; i < Houses.Length; i++)
            {
                var obj = Houses[i];
                LB_Items.Items.Add(GetHouseSummary(players, obj, i));
            }

            LB_Items.SelectedIndex = index;
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            SaveRoom();
            Close();
        }

        private void SaveRoom()
        {
            if (RoomIndex < 0)
                return;
            Manager.Save();
            var house = Houses[Index];
            house.SetRoom(RoomIndex, Manager.Room);
        }

        private void LB_Items_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_Items.SelectedIndex < 0)
                return;
            SaveRoom();
            var house = Houses[Index = LB_Items.SelectedIndex];
            PG_Item.SelectedObject = house;

            ChangeRoom(house);
        }

        private void PG_Item_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            LB_Items.Items[Index] = GetHouseSummary(Players, Houses[Index], Index);
        }

        public static string GetHouseSummary(IReadOnlyList<Player> players, PlayerHouse house, int index)
        {
            var houseName = index >= players.Count ? $"House {index}" : $"{players[index].Personal.PlayerName}'s House";
            return $"{houseName} (lv {house.HouseLevel})";
        }

        private void B_DumpHouse_Click(object sender, EventArgs e)
        {
            MiscDumpHelper.DumpHouse(Players, Houses, Index, ModifierKeys == Keys.Shift);
        }

        private void B_LoadHouse_Click(object sender, EventArgs e)
        {
            if (!MiscDumpHelper.LoadHouse(Players, Houses, Index))
                return;

            RoomIndex = -1;
            var house = Houses[Index];
            PG_Item.SelectedObject = house;
            ChangeRoom(house);
        }

        private void B_EditFlags_Click(object sender, EventArgs e)
        {
            var flags = Houses[Index].GetEventFlags();
            using var editor = new PlayerHouseFlagEditor(flags);
            if (editor.ShowDialog() == DialogResult.OK)
                Houses[Index].SetEventFlags(flags);
        }

        private int HoverX;
        private int HoverY;

        private void PB_Room_MouseMove(object sender, MouseEventArgs e)
        {
            var l = CurrentLayer;
            var oldTile = l.GetTile(HoverX, HoverY);
            var tile = GetTile(l, e, out var x, out var y);
            if (ReferenceEquals(tile, oldTile))
                return;
            var str = GameInfo.Strings;
            var name = str.GetItemName(tile);
            TT_Hover.SetToolTip(PB_Room, name);
            SetCoordinateText(x, y, name);
        }

        private void SetCoordinateText(int x, int y, string name) => L_Coordinates.Text = $"({x:000},{y:000}) = {name}";

        private Item GetTile(ItemLayer layer, MouseEventArgs e, out int x, out int y)
        {
            SetHoveredItem(e);
            return layer.GetTile(x = HoverX, y = HoverY);
        }

        private void SetHoveredItem(MouseEventArgs e)
        {
            GetCoordinates(e, out HoverX, out HoverY);

            // Mouse event may fire with a slightly too large x/y; clamp just in case.
            Manager.Layers[0].ClampCoordinatesInsideGrid(ref HoverX, ref HoverY);
        }

        private static void GetCoordinates(MouseEventArgs e, out int x, out int y)
        {
            x = e.X / scale;
            y = e.Y / scale;
        }

        private void ChangeRoom(PlayerHouse house)
        {
            RoomIndex = (int) NUD_Room.Value - 1;
            ReloadManager(house);
            DrawLayer();
        }

        private void ReloadManager(PlayerHouse house)
        {
            var unsupported = Manager.GetUnsupportedTiles();
            if (unsupported.Count != 0)
                WinFormsUtil.Alert(MessageStrings.MsgFieldItemUnsupportedLayer2Tile);
            var room = house.GetRoom(RoomIndex);
            Manager = new RoomItemManager(room);
        }

        private void DrawLayer() => DrawRoom(CurrentLayer);

        private void DrawRoom(ItemLayer layer)
        {
            var w = layer.MaxWidth;
            var h = layer.MaxHeight;
            int[] scale1 = new int[w * h];
            int[] scaleX = new int[scale * scale * scale1.Length];
            var bmp = new Bitmap(scale * w, scale * h);
            PB_Room.Image = ItemLayerSprite.GetBitmapItemLayerViewGrid(layer, 0, 0, scale, scale1, scaleX, bmp, gridlineColor: 0x7F000000);
        }

        private void NUD_Room_ValueChanged(object sender, EventArgs e)
        {
            ChangeRoom(Houses[Index]);
        }

        private void NUD_Layer_ValueChanged(object sender, EventArgs e)
        {
            DrawLayer();
        }

        #region Item Editing

        private void PlayerHouseEditor_Click(object sender, MouseEventArgs e)
        {
            var tile = GetTile(CurrentLayer, e, out var x, out var y);
            OmniTile(tile, x, y);
        }

        private void OmniTile(Item tile, int x, int y)
        {
            switch (ModifierKeys)
            {
                default:
                    ViewTile(tile, x, y);
                    return;
                case Keys.Shift:
                    SetTile(tile, x, y);
                    return;
                case Keys.Alt:
                    DeleteTile(tile, x, y);
                    return;
            }
        }

        private void Menu_View_Click(object sender, EventArgs e)
        {
            var x = HoverX;
            var y = HoverY;

            var tile = CurrentLayer.GetTile(x, y);
            ViewTile(tile, x, y);
        }

        private void Menu_Set_Click(object sender, EventArgs e)
        {
            var x = HoverX;
            var y = HoverY;

            var tile = CurrentLayer.GetTile(x, y);
            SetTile(tile, x, y);
        }

        private void Menu_Reset_Click(object sender, EventArgs e)
        {
            var x = HoverX;
            var y = HoverY;

            var tile = CurrentLayer.GetTile(x, y);
            DeleteTile(tile, x, y);
        }

        private ItemLayer CurrentLayer => Manager.Layers[(int)NUD_Layer.Value - 1];

        private void ViewTile(Item tile, int x, int y)
        {
            if (CHK_RedirectExtensionLoad.Checked && tile.IsExtension)
            {
                var l = CurrentLayer;
                var rx = Math.Max(0, Math.Min(l.MaxWidth - 1, x - tile.ExtensionX));
                var ry = Math.Max(0, Math.Min(l.MaxHeight - 1, y - tile.ExtensionY));
                var redir = l.GetTile(rx, ry);
                if (redir.IsRoot && redir.ItemId == tile.ExtensionItemId)
                    tile = redir;
            }

            ViewTile(tile);
        }

        private void ViewTile(Item tile)
        {
            ItemEdit.LoadItem(tile);
        }

        private void SetTile(Item tile, int x, int y)
        {
            var l = CurrentLayer;
            var pgt = new Item();
            ItemEdit.SetItem(pgt);
            var permission = l.IsOccupied(pgt, x, y);
            switch (permission)
            {
                case PlacedItemPermission.OutOfBounds:
                case PlacedItemPermission.Collision when CHK_NoOverwrite.Checked:
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

            DrawLayer();
        }

        private void DeleteTile(Item tile, int x, int y)
        {
            if (CHK_AutoExtension.Checked)
            {
                if (!tile.IsRoot)
                {
                    x -= tile.ExtensionX;
                    y -= tile.ExtensionY;
                    tile = CurrentLayer.GetTile(x, y);
                }
                CurrentLayer.DeleteExtensionTiles(tile, x, y);
            }

            tile.Delete();
            DrawLayer();
        }

        #endregion

        private void B_LoadRoom_Click(object sender, EventArgs e)
        {
            var room = Manager.Room;
            MiscDumpHelper.LoadRoom(room, RoomIndex);

            var house = Houses[Index];
            house.SetRoom(RoomIndex, room);
            ReloadManager(house);
            DrawLayer();
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void B_DumpRoom_Click(object sender, EventArgs e)
        {
            SaveRoom();
            MiscDumpHelper.DumpRoom(Manager.Room, RoomIndex);
        }
    }
}
