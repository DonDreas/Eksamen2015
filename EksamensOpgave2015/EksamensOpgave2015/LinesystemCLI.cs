using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    public class LinesystemCLI : ILinesystemUI
    {
        public Linesystem Linesystem;

        public LinesystemCLI(Linesystem linesystem)
        {
            this.Linesystem = linesystem;
        }

        public void Start()
        {
            Console.SetWindowSize(75, 30);
            Console.BufferHeight = 30;
            Console.BufferWidth = 75;

            PrintActiveMenu();
            
            string input = Console.ReadLine();
        }

        public void PrintActiveMenu()
        {
            Console.CursorVisible = false;
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("Please insert your username and product ID to buy: ");
            Console.WriteLine();

            Console.Write(PrintProductFormatted().PadRight(Console.WindowWidth));
            List<Product> Productlist = new List<Product>();
            Productlist = Linesystem.GetActiveProducts();
            foreach (Product product in Productlist)
            {
                Console.Write(PrintProductFormatted(product).PadRight(Console.WindowWidth));
            }
            Console.SetCursorPosition(51, 1);
            Console.CursorVisible = true;
        }

        public string PrintProductFormatted()
        {
            return "[ID]".PadRight(6) + "[Produkt]".PadRight(36) + "[Pris]".PadRight(6);
        }

        public string PrintProductFormatted(Product product)
        {
            return product.productId.ToString().PadRight(6) + product.name.PadRight(36) + product.price.ToString().PadRight(6);
        }

        public void DisplayUserNotFound(string username, string message)
        {
            ErrorLine();
            Console.Write(string.Format("Username[" + username + "] was not found.", username));
        }

        public void DisplayProductNotFound(string productID, string message)
        {
            ErrorLine();
            Console.Write(string.Format("Product[" + productID + "] was not found.", productID));
        }

        public void DisplayUserInfo(User user)
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo cki;
            do
            {
                cki = Console.ReadKey();

                Console.WriteLine(string.Format(" Username: {0}", user.userName));
                Console.WriteLine(string.Format(" Full Name: {0} {1}", user.firstName, user.lastName));
            } 
            while (cki.Key != ConsoleKey.Escape);
            PrintActiveMenu();
        }

        public void DisplayTooManyArgumentsError(string message)
        {
            ErrorLine();
            Console.Write("Too many arguments! " + message);
        }

        public void DisplayAdminCommandCompleted(string message)
        {
            ErrorLine();
            Console.Write("Admin command: [" + message + "] succes!");
        }

        public void DisplayAdminCommandNotFoundMessage(string message)
        {
            ErrorLine();
            Console.Write("Admin command: [" + message + "] was not recognized!");
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            ErrorLine();
            Console.WriteLine("Succes.");
            Console.Write(transaction.ToString());
        }

        public void DisplayUserBuysProduct(int count)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            Environment.Exit(0);
        }

        public void DisplayInsufficientCash(string message)
        {
            ErrorLine();
        }

        public void DisplayGeneralError(string message)
        {
            ErrorLine();
            Console.Write("Something went wrong. Try again.");
        }

        public void ErrorLine()
        {
            Console.SetCursorPosition(10, 50);
            Console.Write(new string(' ', Console.WindowWidth));
        }
    }
}
