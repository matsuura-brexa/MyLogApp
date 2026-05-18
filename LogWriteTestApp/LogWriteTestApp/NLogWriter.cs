namespace LogCompareTool.Logging
{
    public class Log4NetWriter : ILogWriter
    {
        private readonly log4net.ILog _log;

        public Log4NetWriter()
        {
            _log = log4net.LogManager.GetLogger(typeof(Log4NetWriter));
        }

        public void Write(string message)
        {
            _log.Info(message);
        }
    }
}
