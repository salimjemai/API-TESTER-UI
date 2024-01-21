using System;
using System.Diagnostics;
using System.Text;
using log4net;
using log4net.Config;

//[assembly: XmlConfigurator(Watch = true)]

namespace API_TESTER_UI.Utilities
{
    public static class Log
    {
        public static void Fatal(string message, Exception exception)
        {
            GetLogger().Fatal(message, exception);
        }

        public static void Exception(string message, Exception exception)
        {
            GetLogger().Error(message, exception);
        }

        public static void Error(string message, params object[] args)
        {
            GetLogger().Error(Format(message, args));
        }

        public static void Warn(string message, params object[] args)
        {
            GetLogger().Warn(Format(message, args));
        }

        public static void Info(string message, params object[] args)
        {
            GetLogger().Info(Format(message, args));
        }

        public static void Debug(string message, params object[] args)
        {
            GetLogger().Debug(Format(message, args));
        }

        private static ILog GetLogger(string logType = "MainApp")
        {
            var logger = LogManager.GetLogger(logType);
            return logger;
        }

        private static string Format(string message, object[] args)
        {
            return args.Length == 0 ? message : string.Format(message, args);
        }

        public static T Time<T>(string logText, bool _Throw, Func<T> code)
        {
            var rc = default(T);
            var timer = new Stopwatch();
            try
            {
                timer.Start();
                rc = code();
            }
            catch (Exception err)
            {
                Debug(err.Message);
                if (_Throw) throw;
            }
            finally
            {
                timer.Stop();
                if (!string.IsNullOrEmpty(logText))
                    Debug($"Timing: {logText} - {timer.ElapsedMilliseconds}ms");
            }

            return rc;
        }
    }
}