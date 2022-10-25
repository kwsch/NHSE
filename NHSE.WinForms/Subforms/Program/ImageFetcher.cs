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
        private static string ZipFilePath => Path.Combine(ItemSprite.PlatformAppDataPath, Filename);

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

#if NETFRAMEWORK
        private void B_Download_Click(object sender, EventArgs e)
#elif NETCOREAPP
        private async void B_Download_Click(object sender, EventArgs e)
#endif
        {
            var path = ItemSprite.PlatformAppDataPath;
            var hostSelected = AllHosts[CB_HostSelect.SelectedIndex];

            SetUIDownloadState(false);

            L_Status.Text = "Downloading...";

            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
#if NETFRAMEWORK
                using var webClient = new WebClient();
                webClient.DownloadFileCompleted += Completed;
                webClient.DownloadProgressChanged += ProgressChanged;
                webClient.DownloadFileAsync(new Uri(hostSelected), ZipFilePath);
#elif NETCOREAPP
                using var httpClient = new System.Net.Http.HttpClient();
                using var stream = await httpClient.GetStreamAsync(hostSelected).ConfigureAwait(false);
                using var fileStream = new FileStream(ZipFilePath, FileMode.CreateNew);
                await stream.CopyToAsync(fileStream).ConfigureAwait(false);
#endif
            }
            catch (Exception ex)
            {
                WinFormsUtil.Error(ex.Message, ex.InnerException == null ? string.Empty : ex.InnerException.Message);
                SetUIDownloadState(true);
            }
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e) => PBar_MultiUse.Value = e.ProgressPercentage;

        private void Completed(object? sender, AsyncCompletedEventArgs e)
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
                var host = AllHosts[CB_HostSelect.SelectedIndex];
#if NETFRAMEWORK
                using var webClient = new WebClient();
                await webClient.OpenReadTaskAsync(new Uri(host, UriKind.Absolute)).ConfigureAwait(false);
                var hdr = webClient.ResponseHeaders?["Content-Length"];
#elif NETCOREAPP
                using var httpClient = new System.Net.Http.HttpClient();
                var httpInitialResponse = await httpClient.GetAsync(host).ConfigureAwait(false);
                var hdr = httpInitialResponse.Content.Headers.ContentLength;
#endif

                if (hdr == null)
                {
                    L_FileSize.Text = "Failed.";
                    return;
                }
                var totalSizeBytes = Convert.ToInt64(hdr);
                var totalSizeMb = totalSizeBytes / 1e+6;
                L_FileSize.Text = $"{totalSizeMb:0.##}MB";
            }
            catch (Exception ex)
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
