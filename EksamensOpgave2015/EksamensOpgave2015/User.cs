using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    class User
    {
        private int ID { get; set; }
        private string firstName
        {
            get;
            set
            {
                if (firstName == null)
                    throw new ArgumentException();
            }
        }

        private string lastName
        {
            get;
            set
            {
                if (lastName == null)
                    throw new ArgumentException();
            }
        }
        public User(int ID, string firstName, string lastName,
            string username, string email, string balance)
        {

        }
    }
}
