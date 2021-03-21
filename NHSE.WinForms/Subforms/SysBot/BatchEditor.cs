using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class BatchEditor : Form
    {
        private readonly ItemMutator Mutator;
        private readonly ItemProcessor Processor;
        private readonly IReadOnlyList<Item> Items;
        private readonly Item item;
        private int currentFormat = -1;

        public BatchEditor(IReadOnlyList<Item> items, Item item)
        {
            InitializeComponent();
            Items = items;
            this.item = item;
            Mutator = new ItemMutator();
            Processor = new ItemProcessor(Mutator);

            CB_Format.Items.Clear();
            CB_Format.Items.Add("Any");
            foreach (Type t in Mutator.Reflect.Types)
                CB_Format.Items.Add(t.Name.ToLower());
            CB_Format.Items.Add("All");

            CB_Format.SelectedIndex = CB_Require.SelectedIndex = 0;
            toolTip1.SetToolTip(CB_Property, "Name");
            toolTip2.SetToolTip(L_PropType, "Type");
            toolTip3.SetToolTip(L_PropValue, "Value");
        }

        private void SysBotRAMEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void B_Go_Click(object sender, EventArgs e)
        {
            RunBackgroundWorker();
        }

        private void B_Add_Click(object sender, EventArgs e)
        {
            if (CB_Property.SelectedIndex < 0)
            { WinFormsUtil.Alert("Invalid Property"); return; }

            var prefix = StringInstruction.Prefixes;
            string s = prefix[CB_Require.SelectedIndex] + CB_Property.Items[CB_Property.SelectedIndex].ToString() + StringInstruction.SplitInstruction;
            if (RTB_Instructions.Lines.Length != 0 && RTB_Instructions.Lines.Last().Length > 0)
                s = Environment.NewLine + s;

            RTB_Instructions.AppendText(s);
        }

        private void CB_Format_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentFormat == CB_Format.SelectedIndex)
                return;

            int format = CB_Format.SelectedIndex;
            CB_Property.Items.Clear();
            CB_Property.Items.AddRange(Mutator.Reflect.Properties[format]);
            CB_Property.SelectedIndex = 0;
            currentFormat = format;
        }

        private void CB_Property_SelectedIndexChanged(object sender, EventArgs e)
        {
            L_PropType.Text = Mutator.GetPropertyType(CB_Property.Text, CB_Format.SelectedIndex);
            if (Mutator.TryGetHasProperty(item, CB_Property.Text, out var pi))
            {
                L_PropValue.Text = pi.GetValue(item)?.ToString();
                L_PropType.ForeColor = L_PropValue.ForeColor; // reset color
            }
            else // no property, flag
            {
                L_PropValue.Text = string.Empty;
                L_PropType.ForeColor = Color.Red;
            }
        }

        private void RunBackgroundWorker()
        {
            if (RTB_Instructions.Lines.Any(line => line.Length == 0))
            { WinFormsUtil.Error("Invalid instruction detected."); return; }

            var sets = StringInstructionSet.GetBatchSets(RTB_Instructions.Lines).ToArray();
            if (sets.Any(s => s.Filters.Any(z => string.IsNullOrWhiteSpace(z.PropertyValue))))
            { WinFormsUtil.Error("Filter empty."); return; }

            if (sets.Any(z => z.Instructions.Count == 0))
            { WinFormsUtil.Error("No instructions."); return; }

            var emptyVal = sets.SelectMany(s => s.Instructions.Where(z => string.IsNullOrWhiteSpace(z.PropertyValue))).ToArray();
            if (emptyVal.Length > 0)
            {
                string props = string.Join(", ", emptyVal.Select(z => z.PropertyName));
                string invalid = "Property empty." + Environment.NewLine + props;
                if (DialogResult.Yes != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, invalid, "Continue?"))
                    return;
            }

            RTB_Instructions.Enabled = B_Go.Enabled = false;
            RunBatchEdit(sets);
        }

        private void RunBatchEdit(StringInstructionSet[] sets)
        {
            bool finished = false, displayed = false; // hack cuz DoWork event isn't cleared after completion
            b.DoWork += (sender, e) =>
            {
                if (finished)
                    return;
                // don't bother reporting progress...
                Processor.Process(sets, Items);
                finished = true;
            };

            b.ProgressChanged += (sender, e) => SetProgressBar(e.ProgressPercentage);
            b.RunWorkerCompleted += (sender, e) =>
            {
                string result = Processor.GetEditorResults(sets);
                if (!displayed) WinFormsUtil.Alert(result);
                displayed = true;
                RTB_Instructions.Enabled = B_Go.Enabled = true;
                SetupProgressBar(0);
            };
            b.RunWorkerAsync();
        }

        // Progress Bar
        private void SetupProgressBar(int count)
        {
            MethodInvoker mi = () => { PB_Show.Minimum = 0; PB_Show.Step = 1; PB_Show.Value = 0; PB_Show.Maximum = count; };
            if (PB_Show.InvokeRequired)
                PB_Show.Invoke(mi);
            else
                mi.Invoke();
        }

        private void SetProgressBar(int i)
        {
            if (PB_Show.InvokeRequired)
                PB_Show.Invoke((MethodInvoker)(() => PB_Show.Value = i));
            else
                PB_Show.Value = i;
        }
    }
}
