using System;
using System.Windows.Forms;
using xdcb.FormServices.BaseForm;
using Squirrel;
using Microsoft.Win32;
using System.Configuration;
using System.Net;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace xdcb.FormMain
{
    static class Program
    {
        [STAThread]
        static void Main()
        {

            Process process = Process.Start("updater.exe", "/justcheck");

            process.WaitForExit();
            int updateCode = process.ExitCode;

            if (updateCode == 0)
            {
                process = Process.Start("updater.exe", "/checknow");
            }
            else
            {
                var url = ConfigurationManager.AppSettings["AutoUpdateServer"];
                WebClient client = new WebClient();
                client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["USERNAME"], ConfigurationManager.AppSettings["PASSWORD"]);
                using (var mgr = new UpdateManager(url, urlDownloader: new FileDownloader(client), applicationName: "XDCBQN"))
                {
                    try
                    {
                        var updateInfo = mgr.CheckForUpdate().GetAwaiter().GetResult();
                        Assembly assembly = Assembly.GetExecutingAssembly();
                        FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

                        string path = Directory.GetCurrentDirectory();
                        string version = fileVersionInfo.ProductVersion;
                        var directories = Directory.GetParent(path).GetDirectories();

                        var check = mgr.IsInstalledApp;
                        if (updateInfo.ReleasesToApply.Any())
                        {
                            checkNewVersionIfExistBeforeUpdate(directories, updateInfo);

                            var versionCount = updateInfo.ReleasesToApply.Count;
                            var message = new StringBuilder().AppendLine($"Phần mềm đã có {versionCount} bản cập nhật mới.").
                                                              AppendLine("Bạn có muốn cập nhật không?").
                                                              ToString();
                            var result = MessageBox.Show(message, "Cập nhật phần mềm", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                var updateResult = mgr.UpdateApp().GetAwaiter().GetResult();
                                updateInfo = mgr.CheckForUpdate().GetAwaiter().GetResult();
                                versionCount = updateInfo.ReleasesToApply.Count;
                                if (versionCount == 0)
                                {
                                    var success = new StringBuilder().AppendLine($"Phầm mềm đã được cập nhật phiên bản mới.").
                                                              AppendLine("Vui lòng chạy lại phần mềm").
                                                              ToString();
                                    MessageBox.Show(success);
                                }
                                return;
                            }
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }
            }
        }

        private static void checkNewVersionIfExistBeforeUpdate(DirectoryInfo[] directories, UpdateInfo updateInfo)
        {
            if (directories != null && directories.Length > 0 && updateInfo != null)
            {
                foreach (DirectoryInfo info in directories)
                {
                    var app = $"app-{updateInfo.ReleasesToApply.Last().Version}";
                    if (info.Name.Equals(app))
                    {
                        var delete = info.FullName;
                        if (Directory.Exists(delete))
                        {
                            Directory.Delete(delete, true);
                        }
                        break;
                    }
                }
            }
        }

    }
}
