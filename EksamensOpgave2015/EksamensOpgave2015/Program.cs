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
            cli.Start();
            //linesystem.AddUser(0, "Andreas", "Skov", "Store-D", "ajosefskov@gmail.com", 20);
            //linesystem.AddUser(1, "Magnus", "Møller", "MøllerOP", "magnus@gmail.com", 400);
            //linesystem.AddUser(2, "Marius", "LARGE", "StorBøs", "marius@gmail.com", 60);
            //linesystem.AddUser(3, "Jones", "TheHound", "Batman", "jonas@gmail.com", 5400);
            //linesystem.AddUser(4, "Charlie", "Charles", "Mojn", "charlie@gmail.com", 10);
            //linesystem.AddCreditsToAccount(linesystem.GetUser("stored"), 5000);
            //linesystem.AddCreditsToAccount(linesystem.GetUser("Batman"), 80);
            Console.ReadKey();
        }
    }
}
