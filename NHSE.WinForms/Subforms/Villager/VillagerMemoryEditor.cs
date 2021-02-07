using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms
{
    public partial class VillagerMemoryEditor : Form
    {
        private readonly IVillager Villager;
        private readonly GSaveMemory[] Memories;

        private int PlayerIndex = -1;
        private int FlagIndex = -1;
        private byte[] Flags = Array.Empty<byte>();

        private readonly TextBox[] Greetings;

        public VillagerMemoryEditor(IVillager villager)
        {
            InitializeComponent();
            this.TranslateInterface(GameInfo.CurrentLanguage);

            Greetings = new[]
            {
                TB_Greeting,
                TB_Greeting1, TB_Greeting2, TB_Greeting3, TB_Greeting4, TB_Greeting5,
                TB_Greeting6, TB_Greeting7, TB_Greeting8, TB_Greeting9, TB_Greeting10
            };

            Villager = villager;
            Memories = villager.GetMemories();

            UpdatePlayerIslandStrings();

            LB_Players.SelectedIndex = 0;

            DialogResult = DialogResult.Cancel;
            LB_Counts.SelectedIndex = 0;
        }

        private void UpdatePlayerIslandStrings()
        {
            if (LB_Players.Items.Count < 1)
                for (int i = 0; i < Memories.Length; i++)
                    LB_Players.Items.Add($"{i} - {Memories[i].PlayerName} ({Memories[i].TownName})");
            else
                for (int i = 0; i < LB_Players.Items.Count; i++)
                    LB_Players.Items[i] = $"{i} - {Memories[i].PlayerName} ({Memories[i].TownName})";
                
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
            if (PlayerIndex >= 0)
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

            TB_NickName.Text = memory.NickName;
            for (int i = 0; i < Greetings.Length; i++)
                Greetings[i].Text = memory.GetGreeting(i);

            var date = memory.GreetingSetDate;
            if (date < CAL_GreetDate.MinDate)
                date = CAL_GreetDate.MinDate;
            CAL_GreetDate.Value = date;

            TB_NamePlayer.Text = memory.PlayerName;
            TB_Island.Text = memory.TownName;
        }

        private void SavePlayer(in int playerIndex)
        {
            if (playerIndex < 0)
                return;

            var memory = Memories[playerIndex];
            memory.SetEventFlags(Flags);

            memory.NickName = TB_NickName.Text;
            for (int i = 0; i < Greetings.Length; i++)
                memory.SetGreeting(Greetings[i].Text, i);
            memory.GreetingSetDate = CAL_GreetDate.Value == CAL_GreetDate.MinDate ? new GSaveDate() : (GSaveDate)CAL_GreetDate.Value;
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

        private void TB_NamePlayer_TextChanged(object sender, EventArgs e)
        {
            if (LB_Players.SelectedIndex < 0)
                return;
            Memories[LB_Players.SelectedIndex].PlayerName = TB_NamePlayer.Text; // this should be enough for player name changes within NHSE as identities are never changed by the end-user
            UpdatePlayerIslandStrings();
        }

        private void TB_Island_TextChanged(object sender, EventArgs e)
        {
            if (LB_Players.SelectedIndex < 0)
                return;
            Memories[LB_Players.SelectedIndex].TownName = TB_Island.Text; // as above
            UpdatePlayerIslandStrings();
        }
    }
}
