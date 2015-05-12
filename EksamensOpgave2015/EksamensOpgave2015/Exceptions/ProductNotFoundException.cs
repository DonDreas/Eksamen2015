using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException()
            : base()
        {

        }

        public ProductNotFoundException(string message)
            : base(message)
        {

        }

        public ProductNotFoundException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
