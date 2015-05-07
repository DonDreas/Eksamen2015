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
            Linesystem linesystem = new Linesystem();
            LinesystemCLI cli = new LinesystemCLI(linesystem);
            cli.Start();
            //linesystem.AddUser(1, "Andreas", "Seje", "stored", "ajosefskov@gmail.com", 20);
            //linesystem.AddCreditsToAccount(linesystem.GetUser("stored"), 5000);
            Console.ReadKey();
        }
    }
}
