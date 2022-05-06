using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiIntegrationTest.Cli.Output
{
    internal class ConsoleWritter : IConsoleWritter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
