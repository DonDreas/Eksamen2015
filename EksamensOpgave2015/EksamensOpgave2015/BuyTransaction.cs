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
        public decimal amount { get; set; }
        public decimal insertAmount { get; set; }

        BuyTransaction(decimal transactionID, User user, string date, Product product, decimal amount, decimal insertAmount)
            : base(transactionID, user, date, amount)
        {
            this.product = product;
            this.amount = amount;
            this.insertAmount = insertAmount;
        }

        public override string toString()
        {
            return "This happens:" + "" + base.ToString();
            //return this.insertAmount + " " + this.amount + " " + this.user + " " + this.date + " " + this.transactionID;
        }

        public override decimal Execute()
        {
            if (user.balance - product.price < 0)
                throw new InsufficientCreditsException();
            else
                return user.balance - product.price;
        }
    }
}