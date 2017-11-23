using System;
using System.Reflection;
using log4net;

namespace CQRSExample.ProductApi.Infra.CrossCutting.Common
{
    public class Log
    {
        private static readonly ILog _log;

        static Log()
        {
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public static void LogError(string message, Exception ex = null)
        {
            _log.Error(message, ex);
        }

        public static void LogDebug(string message)
        {
            _log.Debug(message);
        }

        public static void LogInfo(string message)
        {
            _log.Info(message);
        }
    }
}
