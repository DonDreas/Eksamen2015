using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    public abstract class Transaction
    {
        public decimal transactionID { get; set; }

        private User _user;
        public User user
        {
            get { return _user; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("User may not be null!");
                else
                    _user = value;
            }
        }

        private string _date;
        public string date
        {
            get { return _date; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Date may not be null!");
                else
                    _date = value;
            }
        }

        public decimal amount { get; set; }

        public Transaction(decimal transactionID, User user, string date, decimal amount)
        {
            this.transactionID = transactionID;
            this.user = user;
            this.date = date;
            this.amount = amount;
        }

        //new public abstract string toString();
        //new public abstract decimal Execute();

        public override string ToString()
        {
            return this.transactionID + "" + this.amount + "" + this.date;
            //return "ID:" + this.transactionID.ToString().PadLeft(4) + ":Amount" + this.amount.ToString().PadLeft(4) + ":Date " + this.date;
        }

        public abstract void Execute();
    }
}
