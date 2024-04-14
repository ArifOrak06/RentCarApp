using NLog;

namespace Application.Services.Logging
{
	public class LoggerService : ILoggerService
	{
		private static ILogger _logger => LogManager.GetCurrentClassLogger(); //concrete hali
		public void LogDebug(string message) => _logger.Debug(message);

		public void LogError(string message) => _logger.Error(message);

		public void LogInfo(string message) => _logger.Info(message);
		public void LogWarning(string message) => _logger.Warn(message);
	}
}
