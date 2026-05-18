using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using LogCompareTool.Logging;
using LogWriteTestApp;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

namespace LogCompareTool
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var dict = args
                .Select(a => a.Split('='))
                .Where(a => a.Length == 2)
                .ToDictionary(a => a[0], a => a[1]);

            if (dict.ContainsKey("mode"))
            {
                try
                {
                    RunLoggingTest(dict);
                }
                catch
                {
                    // 子プロセス側の例外はここでは握りつぶす
                }
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void RunLoggingTest(Dictionary<string, string> dict)
        {
            string mode = dict["mode"];
            int procId = int.Parse(dict["proc"]);
            int lines = int.Parse(dict["lines"]);

            ILogWriter writer;
            switch (mode)
            {
                case "log4net":
                    writer = new Log4NetWriter();
                    break;
                case "nlog":
                    writer = new NLogWriter();
                    break;
                case "filesystem":
                    writer = new FileSystemWriter();
                    break;
                case "streamwriter":
                    writer = new StreamWriterWriter();
                    break;
                default:
                    throw new Exception("Unknown mode");
            }

            for (int i = 0; i < lines; i++)
            {
                writer.Write($"{procId},{i},{DateTime.Now:HH:mm:ss.fff}");
                Thread.Sleep(1);
            }
        }
    }
}
