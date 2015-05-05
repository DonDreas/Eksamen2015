using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Text.RegularExpressions;

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
                if (userName.All(c => !(c >= 0 || 9 >= c || c >= 'a' || 'z' >= c || c == '_')))
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        private string email
        {
            get;
            set
            {
                string[] split = email.Split('@');
                if (split[0].All(c => !(c >= 0 || 9 >= c || c >= 'a' || 'z' >= c || c >= 'A' || 'Z' >= c
                    || c == '.' || c == '-' || c == '_')))
                    throw new ArgumentOutOfRangeException();

                else if (split[1].All(c => !(c >= 0 || 9 >= c 
                    || c >= 'a' || 'z' >= c || c >= 'A' || 'Z' >= c || c == '-' || c == '.')))
                    throw new ArgumentOutOfRangeException();

                char checkFirstLetter = split[1].First();
                if (checkFirstLetter == '.' || checkFirstLetter == '-')
                    throw new ArgumentOutOfRangeException();

                char checkLastLetter = split[1].First();
                if (checkLastLetter == '.' || checkLastLetter == '-')
                    throw new ArgumentOutOfRangeException();

            }
        }
        public User(int ID, string firstName, string lastName,
            string userName, string email, double balance)
        {

        }
    }
}
