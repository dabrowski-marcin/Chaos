using NLog;

namespace Chaos.Src.Helpers
{
    public static class LoggerController
    {
        static LoggerController()
        {
            var config = new NLog.Config.LoggingConfiguration();

            var logfile = new NLog.Targets.FileTarget("logfile") {FileName = "Log.txt"};
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            NLog.LogManager.Configuration = config;
        }

        public static readonly Logger Boot = LogManager.GetLogger("Boot");

        public static readonly Logger Phase = LogManager.GetLogger("Phase");

        public static readonly Logger Gameboard = LogManager.GetLogger("Gameboard");

        public static readonly Logger Spellboard = LogManager.GetLogger("Spellboard");

        public static readonly Logger Buttons = LogManager.GetLogger("Buttons");

        public static readonly Logger Sound = LogManager.GetLogger("Sound");
    }
}