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
                    throw new ArgumentNullException("value");

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
                    throw new ArgumentNullException("value");

                _date = value;
            }
        }

        public decimal amout { get; set; }

        public Transaction(decimal transactionID, User user, string date, decimal amount)
        {
            this.transactionID = transactionID;
            this.user = user;
            this.date = date;
            this.amout = amout;
        }

        private string toString()
        {
            return this.transactionID + " " + this.amout + " " + this.date;
        }

        private void execute()
        {

        }
    }
}
