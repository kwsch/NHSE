using NHSE.Core;
using NHSE.Sprites;
using System;
using System.Windows.Forms;

namespace NHSE.WinForms;

public partial class CampsiteEditor : Form
{
    private readonly HorizonSave SAV;
    private bool CampsiteUnlocked;
    private string GetUpdatedVillagerInternalName() => VillagerUtil.GetInternalVillagerName((VillagerSpecies)NUD_Species.Value, (int)NUD_Variant.Value);
    private void ChangeVillager(object sender, EventArgs e) => ChangeVillager();
    private void ChangeVillager()
    {
        var name = GetUpdatedVillagerInternalName();
        L_InternalName.Text = name;
        L_ExternalName.Text = GameInfo.Strings.GetVillager(name);
        PB_Villager.Image = VillagerSprite.GetVillagerSprite(name);
    }

    public CampsiteEditor(HorizonSave sav)
    {
        InitializeComponent();
        SAV = sav;

        CheckCampsiteStatus();

        LoadCampsiteVisitor();

        DialogResult = DialogResult.Cancel;
    }

    private void CheckCampsiteStatus()
    {
        switch (SAV.Main.CampsiteStatus)
        {
            case 01:
                CampsiteUnlocked = false;
                CB_CampsiteOccupied.Checked = false;
                break;
            case 02:
                CampsiteUnlocked = true;
                CB_CampsiteOccupied.Checked = false;
                break;
            case 03:
                CampsiteUnlocked = true;
                CB_CampsiteOccupied.Checked = true;
                break;
        }

        B_Save.Enabled = CampsiteUnlocked;
        L_CampsiteUnlockStatus.Enabled = !CampsiteUnlocked;
        if (CampsiteUnlocked)
            L_CampsiteUnlockStatus.Text = null;
        CB_CampsiteOccupied.Enabled = CampsiteUnlocked;
        L_Camper_ExternalName.Enabled = CampsiteUnlocked;
        L_ExternalName.Enabled = CampsiteUnlocked;
        PB_Villager.Enabled = CampsiteUnlocked;
        L_Camper_InternalName.Enabled = CampsiteUnlocked;
        L_InternalName.Enabled = CampsiteUnlocked;
        L_Camper_Edit.Enabled = CampsiteUnlocked;
        L_Species.Enabled = CampsiteUnlocked;
        NUD_Species.Enabled = CampsiteUnlocked;
        L_Variant.Enabled = CampsiteUnlocked;
        NUD_Variant.Enabled = CampsiteUnlocked;
    }

    private void LoadCampsiteVisitor()
    {
        NUD_Species.Value = SAV.Main.CampsiteVillagerSpeciesID;
        NUD_Variant.Value = SAV.Main.CampsiteVillagerVariantID;
        var name = GetUpdatedVillagerInternalName();
        L_InternalName.Text = name;
        L_ExternalName.Text = GameInfo.Strings.GetVillager(name);
        PB_Villager.Image = VillagerSprite.GetVillagerSprite(name);
        CAL_CampTimestamp.Value = DateTime.Now;
    }

    private void SaveCampsiteVisitor()
    {
        if (CampsiteUnlocked)
        {
            switch (CB_CampsiteOccupied.Checked)
            {
                case true:
                    SAV.Main.CampsiteStatus = 0x03;
                    SAV.Main.CampsiteVillagerVariantID = (byte)NUD_Variant.Value;
                    SAV.Main.CampsiteVillagerSpeciesID = (byte)NUD_Species.Value;
                    SAV.Main.CampTimestamp = CAL_CampTimestamp.Value;
                    break;
                case false:
                    // The game performs a check and corrects status based on
                    // villagerID or status - but let's clean up anyway.
                    SAV.Main.CampsiteStatus = 0x02;
                    SAV.Main.CampsiteVillagerVariantID = 0x00;
                    SAV.Main.CampsiteVillagerSpeciesID = 0x23;
                    break;
            }
        }
    }

    private void B_Save_Click(object sender, EventArgs e)
    {
        SaveCampsiteVisitor();

        DialogResult = DialogResult.OK;
        Close();
    }

    private void B_Cancel_Click(object sender, EventArgs e) => Close();
}