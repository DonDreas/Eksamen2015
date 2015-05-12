using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    public class ProductNotActiveException : Exception
    {
        //laver exception-klasser, som kan kaldes i programmet, frem for at skrive dem igen og igen. 
        public ProductNotActiveException(Product product)
            : base("Currently product is not active and cannot be bought.")
        {

        }

        public ProductNotActiveException(string message)
            : base(message)
        {

        }

        public ProductNotActiveException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
