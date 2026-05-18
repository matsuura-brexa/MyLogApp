using System.IO;
using System.Text;
using System.Xml.Linq;

namespace LogCompareTool.Logging
{
    public class StreamWriterWriter : ILogWriter
    {
        private readonly string logPath;

        public StreamWriterWriter()
        {
            var xml = XDocument.Load("streamwriter.config");
            logPath = xml.Root.Element("logpath").Value;
        }

        public void Write(string message)
        {
            try
            {
                using (var writer = new StreamWriter(
                    logPath,
                    true,
                    Encoding.GetEncoding("shift-jis")
                ))
                {
                    writer.WriteLine(message);
                }
            }
            catch
            {
                // 排他エラー等は無視
            }
        }
    }
}
