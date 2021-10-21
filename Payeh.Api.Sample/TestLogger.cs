using System;
using Payeh.Utilities.Services.Logger;

namespace Payeh.Api.Sample
{
    public class TestLogger : ILogger
    {
        public void Log(string tag, string message)
        {
            Console.WriteLine(message);
        }
    }
}