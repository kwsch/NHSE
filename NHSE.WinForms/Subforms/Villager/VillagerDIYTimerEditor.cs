using NHSE.Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NHSE.WinForms;

public partial class VillagerDIYTimerEditor : Form
{
    private readonly List<ComboItem> Recipes = GameInfo.Strings.CreateItemDataSource(RecipeList.Recipes, false);

    private readonly IVillager Villager;

    private byte Hour, Minute, Second;
    private ushort RecipeIndex;

    public VillagerDIYTimerEditor(IVillager v)
    {
        Villager = v;
        Hour = Villager.DIYEndHour;
        Minute = Villager.DIYEndMinute;
        Second = Villager.DIYEndSecond;

        InitializeComponent();

        // Both hour and minute will be 255 in most cases when villager is idling. 
        // If another villager's end time is earlier, this villager will not craft UNLESS the villager is crafting an "event" item, in which case it seems it will take priority.
        bool idleState = Hour == byte.MaxValue || Minute == byte.MaxValue;
        DT_Time.Value = idleState ? new DateTime(1970, 01, 01, 0, 0, 0) : new DateTime(1970, 01, 01, Hour, Minute, Second);

        CHK_Crafting.Checked = DT_Time.Enabled = !idleState;

        CB_Recipe.DisplayMember = nameof(ComboItem.Text);
        CB_Recipe.ValueMember = nameof(ComboItem.Value);
        CB_Recipe.DataSource = Recipes;

        RecipeIndex = Villager.DIYRecipeIndex;
        CB_Recipe.SelectedValue = (int)RecipeIndex;
    }

    private void CB_Recipe_SelectedIndexChanged(object sender, EventArgs e)
    {
        var val = WinFormsUtil.GetIndex((ComboBox)sender);
        RecipeIndex = (ushort)Math.Max(0, Math.Min(ushort.MaxValue, val));
    }

    private void B_Cancel_Click(object sender, EventArgs e) => Close();

    private void B_Save_Click(object sender, EventArgs e)
    {
        Villager.DIYEndHour = Hour;
        Villager.DIYEndMinute = Minute;
        Villager.DIYEndSecond = Second;
        Villager.DIYRecipeIndex = RecipeIndex;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void CHK_Crafting_CheckedChanged(object sender, EventArgs e)
    {
        Hour = CHK_Crafting.Checked ? (byte)DT_Time.Value.Hour : byte.MaxValue;
        Minute = CHK_Crafting.Checked ? (byte)DT_Time.Value.Minute : byte.MaxValue;
        DT_Time.Enabled = CHK_Crafting.Checked;
    }

    private void DT_Time_ValueChanged(object sender, EventArgs e)
    {
        Hour = (byte)DT_Time.Value.Hour;
        Minute = (byte)DT_Time.Value.Minute;
        Second = (byte)DT_Time.Value.Second;
    }
}