using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms;

public partial class VillagerHouseEditor : Form
{
    private readonly MainSave SAV;
    private readonly IVillagerHouse[] Houses;
    private readonly IReadOnlyList<IVillager> Villagers;

    private int Index;

    public VillagerHouseEditor(IVillagerHouse[] houses, IReadOnlyList<IVillager> villagers, MainSave sav, int index)
    {
        InitializeComponent();
        this.TranslateInterface(GameInfo.CurrentLanguage);
        SAV = sav;
        Houses = houses;
        Villagers = villagers;
        DialogResult = DialogResult.Cancel;

        foreach (var obj in Houses)
            LB_Items.Items.Add(GetHouseSummary(obj));

        var hIndex = Array.FindIndex(houses, z => z.NPC1 == index);
        if (hIndex < 0)
            hIndex = 0;
        LB_Items.SelectedIndex = hIndex;
    }

    private void B_Cancel_Click(object sender, EventArgs e) => Close();

    private void B_Save_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Close();
    }

    private void LB_Items_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (LB_Items.SelectedIndex < 0)
            return;
        PG_Item.SelectedObject = Houses[Index = LB_Items.SelectedIndex];
    }

    private void PG_Item_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
    {
        LB_Items.Items[Index] = GetHouseSummary(Houses[Index]);
    }

    private string GetHouseSummary(IVillagerHouse house) => $"{GetVillagerName(house)}'s House";

    private string GetVillagerName(IVillagerHouse house)
    {
        var villagerIndex = house.NPC1;
        var v = (uint) villagerIndex >= Villagers.Count ? "???" : Villagers[villagerIndex].InternalName;
        var name = GameInfo.Strings.GetVillager(v);
        return name;
    }

    private void B_DumpHouse_Click(object sender, EventArgs e)
    {
        if (ModifierKeys == Keys.Shift)
        {
            using var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() != DialogResult.OK)
                return;

            var dir = Path.GetDirectoryName(fbd.SelectedPath);
            if (dir == null || !Directory.Exists(dir))
                return;
            SAV.DumpVillagerHouses(fbd.SelectedPath);
            return;
        }

        var h = Houses[Index];
        var name = GetVillagerName(h);
        using var sfd = new SaveFileDialog();
        sfd.Filter = "New Horizons Villager House (*.nhvh)|*.nhvh|" +
                     "New Horizons Villager House (*.nhvh2)|*.nhvh2|" +
                     "All files (*.*)|*.*";
        sfd.FileName = $"{name}.{h.Extension}";
        if (sfd.ShowDialog() != DialogResult.OK)
            return;

        var data = h.Write();
        File.WriteAllBytes(sfd.FileName, data);
    }

    private void B_LoadHouse_Click(object sender, EventArgs e)
    {
        var h = Houses[Index];
        var name = GetVillagerName(Houses[Index]);
        if (name == "???")
            name = "*";
        using var ofd = new OpenFileDialog();
        ofd.Filter = "New Horizons Villager House (*.nhvh)|*.nhvh|" +
                     "New Horizons Villager House (*.nhvh2)|*.nhvh2|" +
                     "All files (*.*)|*.*";
        ofd.FileName = $"{name}.{h.Extension}";
        if (ofd.ShowDialog() != DialogResult.OK)
            return;

        var path = ofd.FileName;
        var expectLength = SAV.Offsets.VillagerHouseSize;
        var fi = new FileInfo(path);
        if (!VillagerHouseConverter.IsCompatible((int)fi.Length, expectLength))
        {
            WinFormsUtil.Error(string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expectLength), path);
            return;
        }

        Memory<byte> data = File.ReadAllBytes(ofd.FileName);
        data = VillagerHouseConverter.GetCompatible(data, expectLength);
        if (data.Length != expectLength)
        {
            WinFormsUtil.Error(string.Format(MessageStrings.MsgDataSizeMismatchImport, fi.Length, expectLength), path);
            return;
        }

        h = SAV.Offsets.ReadVillagerHouse(data);
        var current = Houses[Index];
        h.NPC1 = current.NPC1;
        Houses[Index] = h;
        PG_Item.SelectedObject = h;
    }
}