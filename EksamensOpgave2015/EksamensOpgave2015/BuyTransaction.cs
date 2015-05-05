using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    public class BuyTransaction : Transaction
    {
        public string product { get; set; }
        public decimal amount { get; set; }

        BuyTransaction(decimal transactionID, User user, string date, string product, decimal amount)
            : base(transactionID, user, date, amount)
        {
            this.product = product;
            this.amount = amount;
        }
    }
}