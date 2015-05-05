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
                    throw new ArgumentNullException();
            }
        }

        private string lastName
        {
            get;
            set
            {
                if (lastName == null)
                    throw new ArgumentNullException();
            }
        }

        private string userName
        {
            get;
            set
            {
                if (userName.All(c => c < 0 || 9 < c || c < 'a' || 'z' < c))
                {
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        public User(int ID, string firstName, string lastName,
            string userName, string email, double balance)
        {

        }
    }
}
