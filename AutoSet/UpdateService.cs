using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoSet
{
    internal static class UpdateService
    {
        private const string LatestReleaseUrl = "https://api.github.com/repos/kuzya1014/Autoset/releases/latest";
        private const string AssetName = "AutoSet.exe";
        private const long MaximumDownloadSize = 100 * 1024 * 1024;

        public static async Task CheckForUpdatesAsync()
        {
            var updateAccepted = false;
            try
            {
                Release release;
                using (var client = new HttpClient { Timeout = TimeSpan.FromSeconds(20) })
                {
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("AutoSet-Updater/1.0");
                    client.DefaultRequestHeaders.Accept.ParseAdd("application/vnd.github+json");
                    using (var response = await client.GetAsync(LatestReleaseUrl))
                    {
                        if (!response.IsSuccessStatusCode) return;
                        using (var stream = await response.Content.ReadAsStreamAsync())
                            release = (Release)new DataContractJsonSerializer(typeof(Release)).ReadObject(stream);
                    }
                }

                Version latest;
                if (release == null || !Version.TryParse((release.TagName ?? "").TrimStart('v', 'V'), out latest)) return;
                if (latest.CompareTo(typeof(UpdateService).Assembly.GetName().Version) <= 0) return;

                var asset = release.Assets == null ? null : release.Assets.FirstOrDefault(a => a.Name == AssetName);
                if (asset == null || asset.Size <= 0 || asset.Size > MaximumDownloadSize ||
                    asset.Digest == null || !asset.Digest.StartsWith("sha256:", StringComparison.OrdinalIgnoreCase)) return;
                var expectedHash = asset.Digest.Substring(7);
                if (expectedHash.Length != 64 || !expectedHash.All(Uri.IsHexDigit)) return;
                Uri downloadUrl;
                if (!Uri.TryCreate(asset.DownloadUrl, UriKind.Absolute, out downloadUrl) ||
                    downloadUrl.Scheme != Uri.UriSchemeHttps || downloadUrl.Host != "github.com") return;

                var answer = MessageBox.Show("Доступна версия " + latest + ". Обновить AutoSet сейчас?",
                    "Обновление AutoSet", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (answer != MessageBoxResult.Yes) return;
                updateAccepted = true;

                var target = System.Reflection.Assembly.GetExecutingAssembly().Location;
                var directory = Path.GetDirectoryName(target);
                var testFile = Path.Combine(directory, ".autoset-write-test-" + Guid.NewGuid().ToString("N"));
                try { File.WriteAllText(testFile, ""); }
                finally { if (File.Exists(testFile)) File.Delete(testFile); }

                var updateDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "AutoSet", "Updates");
                Directory.CreateDirectory(updateDirectory);
                var staged = Path.Combine(updateDirectory, Guid.NewGuid().ToString("N") + ".exe");
                try
                {
                    using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(5) })
                    using (var response = await client.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead))
                    {
                        response.EnsureSuccessStatusCode();
                        if (response.Content.Headers.ContentLength > MaximumDownloadSize)
                            throw new InvalidDataException("Файл обновления слишком большой.");
                        using (var source = await response.Content.ReadAsStreamAsync())
                        using (var destination = File.Create(staged))
                        {
                            var buffer = new byte[81920];
                            long total = 0;
                            int count;
                            while ((count = await source.ReadAsync(buffer, 0, buffer.Length)) != 0)
                            {
                                total += count;
                                if (total > MaximumDownloadSize) throw new InvalidDataException("Файл обновления слишком большой.");
                                await destination.WriteAsync(buffer, 0, count);
                            }
                        }
                    }

                    string actualHash;
                    using (var stream = File.OpenRead(staged))
                    using (var sha = SHA256.Create())
                        actualHash = BitConverter.ToString(sha.ComputeHash(stream)).Replace("-", "");
                    if (!actualHash.Equals(expectedHash, StringComparison.OrdinalIgnoreCase))
                        throw new InvalidDataException("Контрольная сумма обновления не совпадает.");

                    var fileVersion = FileVersionInfo.GetVersionInfo(staged).FileVersion;
                    Version downloadedVersion;
                    if (!Version.TryParse(fileVersion, out downloadedVersion) || downloadedVersion != latest)
                        throw new InvalidDataException("Версия EXE не совпадает с версией релиза.");

                    StartReplacement(target, staged);
                    Application.Current.Shutdown();
                }
                catch
                {
                    if (File.Exists(staged)) File.Delete(staged);
                    throw;
                }
            }
            catch (Exception error)
            {
                if (updateAccepted)
                    MessageBox.Show("Не удалось обновить AutoSet: " + error.Message,
                        "Обновление AutoSet", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private static void StartReplacement(string target, string staged)
        {
            var backup = target + ".previous";
            var script = @"
$ErrorActionPreference = 'Stop'
$pidToWait = " + Process.GetCurrentProcess().Id + @"
$target = '" + Quote(target) + @"'
$staged = '" + Quote(staged) + @"'
$backup = '" + Quote(backup) + @"'
$deadline = (Get-Date).AddSeconds(90)
while (Get-Process -Id $pidToWait -ErrorAction SilentlyContinue) {
    if ((Get-Date) -gt $deadline) { exit 1 }
    Start-Sleep -Milliseconds 500
}
try {
    Copy-Item -LiteralPath $target -Destination $backup -Force
    Copy-Item -LiteralPath $staged -Destination $target -Force
    Start-Process -FilePath $target
    Remove-Item -LiteralPath $backup -Force -ErrorAction SilentlyContinue
    Remove-Item -LiteralPath $staged -Force -ErrorAction SilentlyContinue
} catch {
    if (Test-Path -LiteralPath $backup) {
        Copy-Item -LiteralPath $backup -Destination $target -Force
        Start-Process -FilePath $target
    }
    exit 1
}";
            var encoded = Convert.ToBase64String(Encoding.Unicode.GetBytes(script));
            Process.Start(new ProcessStartInfo("powershell.exe", "-NoProfile -NonInteractive -EncodedCommand " + encoded)
            {
                UseShellExecute = false,
                CreateNoWindow = true
            });
        }

        private static string Quote(string value) { return value.Replace("'", "''"); }

        [DataContract]
        private sealed class Release
        {
            [DataMember(Name = "tag_name")] public string TagName { get; set; }
            [DataMember(Name = "assets")] public Asset[] Assets { get; set; }
        }

        [DataContract]
        private sealed class Asset
        {
            [DataMember(Name = "name")] public string Name { get; set; }
            [DataMember(Name = "browser_download_url")] public string DownloadUrl { get; set; }
            [DataMember(Name = "digest")] public string Digest { get; set; }
            [DataMember(Name = "size")] public long Size { get; set; }
        }
    }
}
