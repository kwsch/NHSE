using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class RestrictedItemSelect : UserControl
    {
        private IList<ComboItem> DataSource = Array.Empty<ComboItem>();

        public RestrictedItemSelect() => InitializeComponent();

        public void Initialize(IList<ComboItem> items, bool canType = false)
        {
            CB_ItemID.DisplayMember = nameof(ComboItem.Text);
            CB_ItemID.ValueMember = nameof(ComboItem.Value);
            CB_ItemID.DataSource = DataSource = items;

            if (!canType)
                CB_ItemID.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public ushort Value
        {
            get => CHK_CustomItem.Checked ? (ushort) NUD_CustomItem.Value : (ushort) WinFormsUtil.GetIndex(CB_ItemID);
            set
            {
                if (DataSource.Any(z => z.Value == value))
                {
                    CHK_CustomItem.Checked = false;
                    CB_ItemID.SelectedValue = (int)value;
                }
                else
                {
                    CHK_CustomItem.Checked = true;
                    NUD_CustomItem.Value = value;
                }
            }
        }

        private void CHK_Custom_CheckedChanged(object sender, EventArgs e)
        {
            CB_ItemID.Enabled = !CHK_CustomItem.Checked;
            NUD_CustomItem.Enabled = CHK_CustomItem.Checked;
        }

        private void CB_ItemID_SelectedValueChanged(object sender, EventArgs e)
        {
            NUD_CustomItem.Value = WinFormsUtil.GetIndex(CB_ItemID);
        }
    }
}
