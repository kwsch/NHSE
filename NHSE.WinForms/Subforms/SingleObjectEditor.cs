using System;
using System.Windows.Forms;

namespace NHSE.WinForms
{
    public partial class SingleObjectEditor<T> : Form where T : class
    {
        public SingleObjectEditor(T obj, PropertySort sort)
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
            PG_Item.PropertySort = sort;
            PG_Item.SelectedObject = obj;
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void PG_Item_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
        }
    }
}
