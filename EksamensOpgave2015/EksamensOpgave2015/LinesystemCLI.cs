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
            return "ID".PadRight(4) + "Produkt".PadRight(32) + "Pris".PadRight(6);
        }

        public string PrintProductFormatted(Product product)
        {
            return product.productId.ToString().PadRight(4) + product.name.PadRight(32) + product.price.ToString().PadRight(6);
        }
    }
}
