using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHSE.Core;

namespace NHSE.WinForms;

public partial class SyncSaveDialog : Form
{
    private readonly HorizonSave _target;
    private HorizonSave? _source;
    private SaveSyncManager? _manager;
    private SaveSyncPreviewCollection? _preview;

    public SyncSaveDialog(HorizonSave target)
    {
        InitializeComponent();
        this.TranslateInterface(GameInfo.CurrentLanguage);
        _target = target;
        DialogResult = DialogResult.Cancel;
        InitializeCategories();
    }

    private void InitializeCategories()
    {
        // Add all sync categories to the list
        CLB_Categories.Items.Add("Villagers", false);
        CLB_Categories.Items.Add("Villager Houses", false);
        CLB_Categories.Items.Add("Buildings", false);
        CLB_Categories.Items.Add("Player Houses", false);
        CLB_Categories.Items.Add("Design Patterns", false);
        CLB_Categories.Items.Add("PRO Design Patterns", false);
        CLB_Categories.Items.Add("Field Items", false);
        CLB_Categories.Items.Add("Terrain", false);
        CLB_Categories.Items.Add("Museum", false);
        CLB_Categories.Items.Add("Turnip Prices", false);
        CLB_Categories.Items.Add("Weather Seed", false);
        CLB_Categories.Items.Add("Recycle Bin", false);
        CLB_Categories.Items.Add("Acres", false);
    }

    private void B_SelectSource_Click(object sender, EventArgs e)
    {
        using var fbd = new FolderBrowserDialog
        {
            Description = "Select the folder containing the source save (main.dat)"
        };

        if (fbd.ShowDialog() != DialogResult.OK)
            return;

        var folder = fbd.SelectedPath;
        if (!File.Exists(Path.Combine(folder, "main.dat")))
        {
            WinFormsUtil.Error("main.dat not found in the selected folder.");
            return;
        }

        try
        {
            _source = HorizonSave.FromFolder(folder);
            _manager = new SaveSyncManager(_target, _source);
            _preview = _manager.GetPreview();
            LoadPreview();
        }
        catch (Exception ex)
        {
            WinFormsUtil.Error("Failed to load source save.", ex.Message);
            _source = null;
            _manager = null;
            _preview = null;
        }
    }

    private void LoadPreview()
    {
        if (_preview == null)
        {
            L_SourceInfo.Text = "No source selected";
            RTB_Preview.Clear();
            B_Sync.Enabled = false;
            return;
        }

        L_SourceInfo.Text = $"{_preview.SourceSaveName} ({_preview.SourceSaveVersion})";

        var sb = new StringBuilder();
        if (!_preview.IsCompatible)
        {
            sb.AppendLine($"⚠ {_preview.CompatibilityMessage}");
            sb.AppendLine();
        }

        foreach (var p in _preview.Previews)
        {
            var status = p.IsAvailable ? "✓" : "✗";
            sb.AppendLine($"{status} {p.Category}: {p.Summary}");
            if (!string.IsNullOrEmpty(p.ErrorMessage))
                sb.AppendLine($"   ⚠ {p.ErrorMessage}");
        }

        RTB_Preview.Text = sb.ToString();
        UpdateSyncButtonState();
    }

    private void CLB_Categories_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateSyncButtonState();
        UpdatePreviewSelection();
    }

    private void UpdatePreviewSelection()
    {
        if (_preview == null || CLB_Categories.SelectedIndex < 0)
            return;

        var index = CLB_Categories.SelectedIndex;
        if (index < _preview.Previews.Count)
        {
            var p = _preview.Previews[index];
            var sb = new StringBuilder();
            sb.AppendLine($"Category: {p.Category}");
            sb.AppendLine($"Items: {p.ItemCount}");
            sb.AppendLine($"Summary: {p.Summary}");
            sb.AppendLine($"Available: {(p.IsAvailable ? "Yes" : "No")}");
            if (!string.IsNullOrEmpty(p.ErrorMessage))
                sb.AppendLine($"Warning: {p.ErrorMessage}");

            // Keep the full preview but highlight selection
        }
    }

    private void UpdateSyncButtonState()
    {
        B_Sync.Enabled = _manager != null && CLB_Categories.CheckedItems.Count > 0;
    }

    private void B_SelectAll_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < CLB_Categories.Items.Count; i++)
            CLB_Categories.SetItemChecked(i, true);
        UpdateSyncButtonState();
    }

    private void B_SelectNone_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < CLB_Categories.Items.Count; i++)
            CLB_Categories.SetItemChecked(i, false);
        UpdateSyncButtonState();
    }

    private void B_Cancel_Click(object sender, EventArgs e) => Close();

    private void B_Sync_Click(object sender, EventArgs e)
    {
        if (_manager == null)
            return;

        var categories = GetSelectedCategories();
        if (categories == SaveSyncCategory.None)
        {
            WinFormsUtil.Alert("Please select at least one category to sync.");
            return;
        }

        var categoryNames = string.Join(", ", GetSelectedCategoryNames());
        var result = WinFormsUtil.Prompt(MessageBoxButtons.YesNo,
            $"Are you sure you want to sync the following categories?\n\n{categoryNames}\n\nThis will overwrite the corresponding data in your current save.");

        if (result != DialogResult.Yes)
            return;

        try
        {
            _manager.Sync(categories);
            DialogResult = DialogResult.OK;
            WinFormsUtil.Alert("Sync completed successfully!");
            Close();
        }
        catch (Exception ex)
        {
            WinFormsUtil.Error("Sync failed.", ex.Message);
        }
    }

    private SaveSyncCategory GetSelectedCategories()
    {
        var categories = SaveSyncCategory.None;

        if (CLB_Categories.GetItemChecked(0)) categories |= SaveSyncCategory.Villagers;
        if (CLB_Categories.GetItemChecked(1)) categories |= SaveSyncCategory.VillagerHouses;
        if (CLB_Categories.GetItemChecked(2)) categories |= SaveSyncCategory.Buildings;
        if (CLB_Categories.GetItemChecked(3)) categories |= SaveSyncCategory.PlayerHouses;
        if (CLB_Categories.GetItemChecked(4)) categories |= SaveSyncCategory.DesignPatterns;
        if (CLB_Categories.GetItemChecked(5)) categories |= SaveSyncCategory.DesignPatternsPRO;
        if (CLB_Categories.GetItemChecked(6)) categories |= SaveSyncCategory.FieldItems;
        if (CLB_Categories.GetItemChecked(7)) categories |= SaveSyncCategory.Terrain;
        if (CLB_Categories.GetItemChecked(8)) categories |= SaveSyncCategory.Museum;
        if (CLB_Categories.GetItemChecked(9)) categories |= SaveSyncCategory.TurnipPrices;
        if (CLB_Categories.GetItemChecked(10)) categories |= SaveSyncCategory.WeatherSeed;
        if (CLB_Categories.GetItemChecked(11)) categories |= SaveSyncCategory.RecycleBin;
        if (CLB_Categories.GetItemChecked(12)) categories |= SaveSyncCategory.Acres;

        return categories;
    }

    private string[] GetSelectedCategoryNames()
    {
        return Enumerable.Range(0, CLB_Categories.Items.Count)
            .Where(i => CLB_Categories.GetItemChecked(i))
            .Select(i => CLB_Categories.Items[i]?.ToString() ?? string.Empty)
            .ToArray();
    }
}

