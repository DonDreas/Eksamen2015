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

        public void DisplayUserNotFound(string message)
        {
            throw new NotImplementedException();
        }

        public void DisplayProductNotFound(string message)
        {
            throw new NotImplementedException();
        }

        public void DisplayUserInfo()
        {

        }

        public void DisplayTooManyArgumentsError()
        {

        }

        public void DisplayAdminCommandNotFoundMessage(string message)
        {

        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {

        }

        public void DisplayUserBuysProduct(int count)
        {

        }

        public void Close()
        {
            Environment.Exit(0); //ikke sikker her. Google sagde det var godt?
        }

        public void DisplayInsufficientCash(string message)
        {

        }

        public void DisplayGeneralError(string message)
        {
            Console.SetCursorPosition(42, 42); //husk at sæt det her rigtigt.
            Console.WriteLine(message);
        }
    }
}
