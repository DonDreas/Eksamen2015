using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    public class Program
    {
        static void Main(string[] args)
        {
            Linesystem linesystem = new Linesystem();
            LinesystemCLI cli = new LinesystemCLI(linesystem);
            LinesystemCommandParser parser = new LinesystemCommandParser(cli, linesystem);
            cli.Start();
            Console.ReadKey();
        }
    }
}
