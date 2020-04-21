using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class PropertyEditor<T> : Form where T : INamedObject
    {
        private readonly IReadOnlyList<T> Objects;
        private readonly IReadOnlyList<string> Names;

        public PropertyEditor(IReadOnlyList<T> objects, IReadOnlyList<string> names)
        {
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);
            Objects = objects;
            Names = names;
            DialogResult = DialogResult.Cancel;

            foreach (var obj in Objects)
                LB_Items.Items.Add(obj.ToString(Names));

            LB_Items.SelectedIndex = 0;
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private int Index;

        private void LB_Items_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_Items.SelectedIndex < 0)
                return;
            PG_Item.SelectedObject = Objects[Index = LB_Items.SelectedIndex];
        }

        private void PG_Item_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            LB_Items.Items[Index] = Objects[Index].ToString(Names);
        }
    }
}
