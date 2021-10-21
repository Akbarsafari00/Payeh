using System;

namespace Payeh.Utilities.Services.Logger
{
    public class Logger : ILogger
    {
        public void Log(string tag,string message)
        {
            Console.WriteLine($"[{DateTime.Now}] {tag} | {message}");
        }
    }
}