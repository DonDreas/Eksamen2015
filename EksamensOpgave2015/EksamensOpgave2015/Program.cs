using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    class Program
    {
        static void Main(string[] args)
        {
            LineSystem linesystem = new LineSystem();
            linesystem.ReadFile();
            LinesystemCLI cli = new LinesystemCLI(linesystem);
            cli.Start();
            Console.ReadKey();
        }
    }
}
