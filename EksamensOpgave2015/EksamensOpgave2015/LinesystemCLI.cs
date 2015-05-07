using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    public class LinesystemCLI
    {
        public LineSystem Linesystem;

        public LinesystemCLI(LineSystem linesystem)
        {
            this.Linesystem = linesystem;
        }

        public void Start()
        {
            Console.WriteLine(PrintProductFormatted());

            foreach (Product product in Linesystem.ProductList)
            {
                if (product.active)
                {
                    Console.WriteLine(PrintProductFormatted(product));
                }
            }
        }

        public string PrintProductFormatted()
        {
            return "ID".PadRight(6) + "Produkt".PadRight(36) + "Pris".PadRight(6);
        }

        public string PrintProductFormatted(Product product)
        {
            return product.productId.ToString().PadRight(6) + product.name.PadRight(36) + product.price.ToString().PadRight(6);
        }

        public void DisplayUserNotFound()
        {

        }

        public void DisplayProductNotFound()
        {

        }

        public void DisplayUserInfo()
        {

        }

        public void DisplayTooManyArgumentsError()
        {

        }

        public void DisplayAdminCommandNotFoundMessage()
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

        }

        public void DisplayInsufficientCash()
        {

        }

        public void DisplayGeneralError(string errorString)
        {

        }
    }
}
