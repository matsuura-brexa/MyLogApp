using System.Xml.Linq;
using Microsoft.VisualBasic;

namespace LogCompareTool.Logging
{
    public class FileSystemWriter : ILogWriter
    {
        private readonly string logPath;

        public FileSystemWriter()
        {
            var xml = XDocument.Load("filesystem.config");
            logPath = xml.Root.Element("logpath").Value;
        }

        public void Write(string message)
        {
            try
            {
                int fileNo = FileSystem.FreeFile();
                FileSystem.FileOpen(
                    fileNo,
                    logPath,
                    OpenMode.Append,
                    OpenAccess.Write,
                    OpenShare.LockWrite
                );

                FileSystem.PrintLine(fileNo, message);
                FileSystem.FileClose(fileNo);
            }
            catch
            {
                // 排他エラー等は無視
            }
        }
    }
}
