namespace LogCompareTool.Logging
{
    public class NLogWriter : ILogWriter
    {
        private readonly NLog.Logger _logger;

        public NLogWriter()
        {
            _logger = NLog.LogManager.GetCurrentClassLogger();
        }

        public void Write(string message)
        {
            _logger.Info(message);
        }
    }
}
