using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    public class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(int transactionId, User user, string date, decimal amount)
            : base(transactionId, user, date, amount)
        {
        }

        public override string ToString()
        {
            return "Lort" + "" + base.ToString(); //Charlie jeg tror jeg er smart
            //return this.insertAmount + " " + this.amount + " " + this.user + " " + this.date + " " + this.transactionID;
        }

        public override void Execute()
        {
            this.user.balance += this.amount;
            string text = this.ToString();

            System.IO.File.WriteAllText("log.txt", text);
        }
    }
}
