using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    public class InsertCashTransaction : Transaction
    {
        public decimal insertAmount { get; set; }

        public InsertCashTransaction(int transactionId, User user, string date, decimal amount, decimal insertAmount)
            : base(transactionId, user, date, amount)
        {
            user.balance = user.balance + insertAmount;
        }

        public override string ToString()
        {
            return "Lort" + "" + base.ToString(); //Charlie jeg tror jeg er smart
            //return this.insertAmount + " " + this.amount + " " + this.user + " " + this.date + " " + this.transactionID;
        }

        public override void Execute()
        {
            user.balance = user.balance += insertAmount;
        }
    }
}
