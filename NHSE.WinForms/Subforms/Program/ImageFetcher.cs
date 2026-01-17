using NHSE.Sprites;
using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NHSE.WinForms;

public sealed partial class ImageFetcher : Form
{
    private const string Filename = "image.zip";
    private const int MaxBufferSize = 8192;
    private static string ZipFilePath => Path.Combine(ItemSprite.PlatformAppDataPath, Filename);

    private readonly string[] AllHosts;

    public ImageFetcher()
    {
        InitializeComponent();
        L_Status.Text = L_FileSize.Text = string.Empty;

        var splitHosts = AllHosts = LoadHosts();

        CB_HostSelect.Items.Clear();
        foreach (var host in splitHosts)
            CB_HostSelect.Items.Add(CleanUrl(host));

        CB_HostSelect.SelectedIndex = 0; // set outside of initialise to update filesize via HEAD response

        CheckFileStatusLabel();
    }

    private static string[] LoadHosts()
    {
        var hosts = Properties.Resources.hosts_images;
        var splitHosts = hosts.Split(["\r", "\n", "\r\n"], StringSplitOptions.RemoveEmptyEntries);

        return splitHosts;
    }

    private async void B_Download_Click(object sender, EventArgs e)
    {
        try
        {
            var path = ItemSprite.PlatformAppDataPath;
            var hostSelected = AllHosts[CB_HostSelect.SelectedIndex];

            SetUIDownloadState(false);

            L_Status.PerformSafely(() => L_Status.Text = "Downloading...");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            using var httpClient = new System.Net.Http.HttpClient();
            using var response = await httpClient.GetAsync(hostSelected, System.Net.Http.HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var totalBytes = response.Content.Headers.ContentLength ?? -1L;
            var canReportProgress = totalBytes != -1 && PBar_MultiUse != null;

            using (var contentStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
            using (var fileStream = new FileStream(ZipFilePath, FileMode.Create, FileAccess.Write, FileShare.None, MaxBufferSize, true))
            {
                var buffer = new byte[MaxBufferSize];
                long totalRead = 0;
                int read;
                while ((read = await contentStream.ReadAsync(buffer).ConfigureAwait(false)) > 0)
                {
                    await fileStream.WriteAsync(buffer.AsMemory(0, read)).ConfigureAwait(false);
                    totalRead += read;
                    if (canReportProgress && PBar_MultiUse != null)
                    {
                        int progress = (int)((totalRead * 100) / totalBytes);
                        PBar_MultiUse.PerformSafely(() => PBar_MultiUse.Value = Math.Min(progress, 100));
                    }
                }
            }

            PBar_MultiUse?.PerformSafely(() => PBar_MultiUse.Value = 100);
            L_Status.Invoke((Action)(() => L_Status.Text = "Unzipping..."));
            UnzipFile();
        }
        catch (Exception ex)
        {
            WinFormsUtil.Error(ex.Message, ex.InnerException == null ? string.Empty : ex.InnerException.Message);
            SetUIDownloadState(true);
        }
    }

    private async void UnzipFile()
    {
        try
        {
            var outputFolderPath = ItemSprite.PlatformAppDataImagePath;

            if (Directory.Exists(outputFolderPath)) // overwrite existing
                Directory.Delete(outputFolderPath, true);

            Directory.CreateDirectory(outputFolderPath);

            await Task.Run(() => ZipFile.ExtractToDirectory(ZipFilePath, outputFolderPath)).ConfigureAwait(false);

            SetUIDownloadState(true, true);
        }
        catch (Exception ex)
        {
            WinFormsUtil.Error(ex.Message, ex.InnerException == null ? string.Empty : ex.InnerException.Message);
            SetUIDownloadState(true);
        }
    }

    private void SetUIDownloadState(bool val, bool success = false)
    {
        this.PerformSafely(() => ControlBox = val);
        B_Download.PerformSafely(() => B_Download.Enabled = val);
        PBar_MultiUse.PerformSafely(() => PBar_MultiUse.Value = 0);

        L_Status.PerformSafely(() => L_Status.Text = success ? "Images installed successfully." : string.Empty);

        CheckFileStatusLabel();

        if (success)
            ItemSprite.Initialize(Core.GameInfo.GetStrings("en").itemlist);

        if (File.Exists(ZipFilePath))
            File.Delete(ZipFilePath);
    }

    private void CB_HostSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckNetworkFileSizeAsync();
    }

    private async void CheckNetworkFileSizeAsync()
    {
        try
        {
            L_FileSize.PerformSafely(() => L_FileSize.Text = string.Empty);
            var host = AllHosts[CB_HostSelect.SelectedIndex];
            using var httpClient = new System.Net.Http.HttpClient();
            var httpInitialResponse = await httpClient.GetAsync(host).ConfigureAwait(false);
            var hdr = httpInitialResponse.Content.Headers.ContentLength;

            if (hdr == null)
            {
                L_FileSize.PerformSafely(() => L_FileSize.Text = "Failed.");
                return;
            }
            var totalSizeBytes = Convert.ToInt64(hdr);
            var totalSizeMb = totalSizeBytes / 1e+6;
            L_FileSize.PerformSafely(() => L_FileSize.Text = $"{totalSizeMb:0.##}MB");
        }
        catch (Exception ex)
        {
            L_FileSize.PerformSafely(() => L_FileSize.Text = ex.Message);
        }
    }

    private static string CleanUrl(string url)
    {
        var uri = new Uri(url);
        return uri.Segments.Length < 2 ? url : $"{uri.Host}/{uri.Segments[1]}";
    }

    private void CheckFileStatusLabel() => L_ImgStatus.PerformSafely(() => L_ImgStatus.Visible = ItemSprite.SingleSpriteExists);
}