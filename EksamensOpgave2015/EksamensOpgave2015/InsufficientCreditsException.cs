using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    public class InsufficientCreditsException : Exception
    {
        private User user { get; set; }
        private Product product { get; set; }

        public InsufficientCreditsException()
            : base("Your can currently not affort this product. Insufficient result")
        {
        }
    }
}
