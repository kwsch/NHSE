using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class VillagerMemoryEditor : Form
    {
        private readonly Villager Villager;
        private readonly GSaveMemory[] Memories;

        private int PlayerIndex = -1;
        private int FlagIndex = -1;
        private byte[] Flags = Array.Empty<byte>();

        public VillagerMemoryEditor(Villager villager)
        {
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);

            Villager = villager;
            Memories = villager.GetMemories();

            for (int i = 0; i < Memories.Length; i++)
                LB_Players.Items.Add($"{i} - {Memories[i].PlayerName} ({Memories[i].TownName})");

            LB_Players.SelectedIndex = 0;

            DialogResult = DialogResult.Cancel;
            LB_Counts.SelectedIndex = 0;
        }

        private void B_Cancel_Click(object sender, EventArgs e) => Close();

        private void B_Save_Click(object sender, EventArgs e)
        {
            SavePlayer(PlayerIndex);
            Villager.SetMemories(Memories);
            DialogResult = DialogResult.OK;
            Close();
        }

        private static string GetFlagDescription(int index, IReadOnlyList<byte> flags, IReadOnlyDictionary<string, string> str)
        {
            return EventFlagVillagerMemoryPlayer.GetName((ushort)index, flags[index], str);
        }

        private void NUD_Count_ValueChanged(object sender, EventArgs e)
        {
            var flagIndex = FlagIndex;
            if (flagIndex < 0)
                return;

            Flags[FlagIndex] = (byte) NUD_Count.Value;
            LB_Counts.Items[FlagIndex] = GetFlagDescription(flagIndex, Flags, GameInfo.Strings.InternalNameTranslation);
        }

        private void LB_Counts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_Counts.SelectedIndex < 0)
                return;

            NUD_Count.Value = Flags[FlagIndex = LB_Counts.SelectedIndex];
        }

        private void LB_Players_SelectedIndexChanged(object sender, EventArgs e)
        {
            SavePlayer(PlayerIndex);
            PlayerIndex = LB_Players.SelectedIndex;
            LoadPlayer(PlayerIndex);
        }

        private void LoadPlayer(in int playerIndex)
        {
            FlagIndex = -1;
            var index = LB_Counts.SelectedIndex;
            var memory = Memories[playerIndex];
            var flags = memory.GetEventFlags();

            var str = GameInfo.Strings.InternalNameTranslation;
            LB_Counts.Items.Clear();
            for (int i = 0; i < flags.Length; i++)
                LB_Counts.Items.Add(GetFlagDescription((byte)i, flags, str));

            Flags = flags;
            LB_Counts.SelectedIndex = FlagIndex = index;
        }

        private void SavePlayer(in int playerIndex)
        {
            if (playerIndex < 0)
                return;

            var memory = Memories[playerIndex];
            memory.SetEventFlags(Flags);
        }

        private void B_Dump_Click(object sender, EventArgs e)
        {
            SavePlayer(PlayerIndex);
            MiscDumpHelper.DumpVillagerMemoryPlayer(Villager, Memories[PlayerIndex]);
        }

        private void B_Load_Click(object sender, EventArgs e)
        {
            if (!MiscDumpHelper.LoadVillagerMemoryPlayer(Villager, Memories, PlayerIndex))
                return;
            LoadPlayer(PlayerIndex);
            System.Media.SystemSounds.Asterisk.Play();
        }
    }
}
