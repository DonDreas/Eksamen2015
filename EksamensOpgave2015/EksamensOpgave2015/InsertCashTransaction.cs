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
            return "Payment " + this.amount + " " + this.user + " " + this.date + " " + this.transactionID;
            //return this.amount + " " + this.user + " " + this.date + " " + this.transactionID;
        }

        public override void Execute()
        {
            this.user.balance += this.amount;
        }
    }
}
