using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    public class BuyTransaction : Transaction
    {
        public Product product { get; set; }
        public decimal insertAmount { get; set; }

        public BuyTransaction(decimal transactionID, User user, string date, Product product)
            : base(transactionID, user, date, product.price)
        {
            this.product = product;
        }

        public override string ToString()
        {
            return "This happens:" + "" + base.ToString();
            //return this.insertAmount + " " + this.amount + " " + this.user + " " + this.date + " " + this.transactionID;
        }

        public override void Execute()
        {
            if (user.balance - product.price < 0)
                throw new InsufficientCreditsException(product, user);
            else
            {
                user.balance = user.balance - product.price;
            }
        }
    }
}