using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
  
    public interface ILogger
    {
        void Log(string message);
    }
    public class ConsoleLogger: ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Консольный логгер: " + message);
        }
    }
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            File.AppendAllText("log.txt", message + Environment.NewLine);

            Console.WriteLine("Сообщение записано в log.txt");
        }
    }
    public abstract class LoggerFactory
    {
        public abstract ILogger CreateLogger();
        public void LogMessage(string message)
        {
            ILogger logger = CreateLogger();
            logger.Log(message);
        }
    }
    public class ConsoleLoggerFactory : LoggerFactory
    {
        public override ILogger CreateLogger()
        {
            return new ConsoleLogger();
        }   
    }
    public class FileLoggerFactory : LoggerFactory
    {
        public override ILogger CreateLogger()
        {
            return new FileLogger();
        }
    }
}

