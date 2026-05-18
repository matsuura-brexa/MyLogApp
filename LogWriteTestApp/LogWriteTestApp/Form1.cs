using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using log4net;
using NLog;

namespace LogCompareTool
{
    public partial class Form1 : Form
    {
        private async void btnStartTest_Click(object sender, EventArgs e)
        {
            try
            {
                string mode =
                    rdoLog4net.Checked ? "log4net" :
                    rdoNLog.Checked ? "nlog" :
                    rdoFileSystem.Checked ? "filesystem" :
                    "streamwriter";

                int processCount = (int)numProcessCount.Value;
                int lineCount = (int)numLineCount.Value;

                string exe = Application.ExecutablePath;

                string logPath = GetLogPathForMode(mode);
                if (!string.IsNullOrEmpty(logPath))
                {
                    File.WriteAllText(logPath, "");
                }

                List<Process> processes = new List<Process>();

                for (int i = 0; i < processCount; i++)
                {
                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = exe;
                    psi.Arguments = $"mode={mode} proc={i} lines={lineCount}";
                    psi.UseShellExecute = false;

                    var p = Process.Start(psi);
                    processes.Add(p);
                }

                txtResult.Text = "プロセス起動完了。終了待ち中…";

                await Task.Run(() =>
                {
                    foreach (var p in processes)
                    {
                        p.WaitForExit();
                    }
                });

                txtResult.Text = "全プロセス終了。ログ解析中…";

                AnalyzeLog(mode, processCount, lineCount);
            }
            catch (Exception ex)
            {
                txtResult.Text = "メイン処理で例外が発生しました。\r\n\r\n" + ex.ToString();
            }
        }

        private string GetLogPathForMode(string mode)
        {
            try
            {
                switch (mode)
                {
                    case "log4net":
                        {
                            var repo = log4net.LogManager.GetRepository();
                            foreach (var appender in repo.GetAppenders())
                            {
                                if (appender is log4net.Appender.FileAppender fa)
                                {
                                    return fa.File;
                                }
                            }
                            return null;
                        }
                    case "nlog":
                        {
                            var config = NLog.LogManager.Configuration;
                            var fileTarget = config.FindTargetByName("file") as NLog.Targets.FileTarget;
                            if (fileTarget == null) return null;
                            var logEvent = new NLog.LogEventInfo();
                            return fileTarget.FileName.Render(logEvent);
                        }
                    case "filesystem":
                        {
                            var xml = XDocument.Load("filesystem.config");
                            return xml.Root.Element("logpath").Value;
                        }
                    case "streamwriter":
                        {
                            var xml = XDocument.Load("streamwriter.config");
                            return xml.Root.Element("logpath").Value;
                        }
                    default:
                        return null;
                }
            }
            catch
            {
                return null;
            }
        }

        private void AnalyzeLog(string mode, int processCount, int lineCount)
        {
            try
            {
                string logPath = GetLogPathForMode(mode);
                if (string.IsNullOrEmpty(logPath) || !File.Exists(logPath))
                {
                    txtResult.Text = "ログ解析中にエラー：ログファイルが見つかりません。\r\nパス：" + (logPath ?? "(null)");
                    return;
                }

                string[] lines = File.ReadAllLines(logPath);

                var dict = new Dictionary<int, HashSet<int>>();

                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length < 2) continue;

                    if (!int.TryParse(parts[0], out int proc)) continue;
                    if (!int.TryParse(parts[1], out int idx)) continue;

                    if (!dict.ContainsKey(proc))
                        dict[proc] = new HashSet<int>();

                    dict[proc].Add(idx);
                }

                int expected = processCount * lineCount;
                int actual = lines.Length;

                var sb = new StringBuilder();
                sb.AppendLine($"モード：{mode}");
                sb.AppendLine($"ログファイル：{logPath}");
                sb.AppendLine($"期待行数：{expected}");
                sb.AppendLine($"実際の行数：{actual}");
                sb.AppendLine($"欠損行数：{expected - actual}");
                sb.AppendLine("");

                for (int p = 0; p < processCount; p++)
                {
                    sb.AppendLine($"▼ Process {p}");

                    if (!dict.ContainsKey(p))
                    {
                        sb.AppendLine("  全行欠損");
                        continue;
                    }

                    var set = dict[p];

                    for (int i = 0; i < lineCount; i++)
                    {
                        if (!set.Contains(i))
                        {
                            sb.AppendLine($"  行 {i} が欠損");
                        }
                    }
                }

                txtResult.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                txtResult.Text = "ログ解析中に例外が発生しました。\r\n\r\n" + ex.ToString();
            }
        }
    }
}
