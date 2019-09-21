using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.API.Core.Logger
{
    public class Logger : ILogger
    {
        public void Log(LogType type)
        {
            Console.WriteLine(type.ToString());
        }
    }
    public interface ILogger
    {
        void Log(LogType type);
    }
    public enum LogType
    {
        Warning = 1,
        Error = 2,
        Debug = 3
    }
}
