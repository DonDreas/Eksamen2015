﻿using System;
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

        public BuyTransaction(int transactionID, User user, string date, decimal amount, Product product)
            : base(transactionID, user, date, amount)
        {
            this.product = product;
        }

        public override string ToString()
        {
            return "Buy: " + this.amount + " " + this.user + " " + this.date + " " + this.transactionID + " " + this.product.productId;
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