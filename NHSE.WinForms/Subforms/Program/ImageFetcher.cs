using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHSE.Sprites;

namespace NHSE.WinForms
{
    public sealed partial class ImageFetcher : Form
    {
        private const string Filename = "image.zip";
        private static string ZipFilePath { get => Path.Combine(ItemSprite.PlatformAppDataPath, Filename); }

        private readonly IReadOnlyList<string> AllHosts;

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
            var splitHosts = hosts.Split(new[] { "\r", "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            return splitHosts;
        }

        private void B_Download_Click(object sender, EventArgs e)
        {
            var path = ItemSprite.PlatformAppDataPath;
            var hostSelected = AllHosts[CB_HostSelect.SelectedIndex];

            SetUIDownloadState(false);

            L_Status.Text = "Downloading...";

            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                using var webClient = new WebClient();
                webClient.DownloadFileCompleted += Completed;
                webClient.DownloadProgressChanged += ProgressChanged;
                webClient.DownloadFileAsync(new Uri(hostSelected), ZipFilePath);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                WinFormsUtil.Error(ex.Message, ex.InnerException == null ? string.Empty : ex.InnerException.Message);
                SetUIDownloadState(true);
            }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e) => PBar_MultiUse.Value = e.ProgressPercentage;
        
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                WinFormsUtil.Error(e.Error.Message, e.Error.InnerException == null ? string.Empty : e.Error.InnerException.Message);
                SetUIDownloadState(true);
                return;
            }

            PBar_MultiUse.Value = 100; 
            L_Status.Text = "Unzipping...";
            UnzipFile();
        }

        private async void UnzipFile()
        {
            try
            {
                var outputFolderPath = ItemSprite.PlatformAppDataImagePath;

                if (Directory.Exists(outputFolderPath)) // overwrite existing
                    Directory.Delete(outputFolderPath, true);

                Directory.CreateDirectory(outputFolderPath);

                await Task.Run(() => ZipFile.ExtractToDirectory(ZipFilePath, outputFolderPath));

                SetUIDownloadState(true, true);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                WinFormsUtil.Error(ex.Message, ex.InnerException == null ? string.Empty : ex.InnerException.Message);
                SetUIDownloadState(true);
            }
        }

        private void SetUIDownloadState(bool val, bool success = false)
        {
            ControlBox = val;
            B_Download.Enabled = val;
            PBar_MultiUse.Value = 0;

            L_Status.Text = success ? "Images installed successfully." : string.Empty;

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
            L_FileSize.Text = string.Empty;
            try
            {
                using var webClient = new WebClient();
                await webClient.OpenReadTaskAsync(new Uri(AllHosts[CB_HostSelect.SelectedIndex], UriKind.Absolute));

                var totalSizeBytes = Convert.ToInt64(webClient.ResponseHeaders["Content-Length"]);
                var totalSizeMb = totalSizeBytes / 1e+6;
                L_FileSize.Text = $"{totalSizeMb:0.##}MB";
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                L_FileSize.Text = ex.Message;
            }
        }

        private static string CleanUrl(string url)
        {
            var uri = new Uri(url);
            return uri.Segments.Length < 2 ? url : $"{uri.Host}/{uri.Segments[1]}";
        }

        private bool CheckFileStatusLabel() => L_ImgStatus.Visible = ItemSprite.SingleSpriteExists;
    }
}
