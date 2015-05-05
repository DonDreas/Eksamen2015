using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Text.RegularExpressions;

namespace EksamensOpgave2015
{
    class User : IComparable
    {
        public int ID { get; private set; }

        private string _firstName;
        public string firstName
        {
            get { return _firstName; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                _firstName = value;
            }
        }

        private string _lastName;
        public string lastName
        {
            get { return _lastName; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                _lastName = value;
            }
        }

        private string _userName;
        public string userName
        {
            get { return _userName; }
            set
            {
                if (value.All(c => !(c >= 0 || 9 >= c || c >= 'a' || 'z' >= c || c == '_')))
                    throw new ArgumentOutOfRangeException("value");

                _userName = value;
            }
        }

        private string _email;
        public string email
        {
            get { return _email; }
            set
            {
                string[] split = value.Split('@');
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

                _email = value;
            }
        }

        public decimal balance { get; private set; }

        public User(int ID, string firstName, string lastName,
            string userName, string email, decimal balance)
        {
            this.ID = ID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.userName = userName;
            this.email = email;
            this.balance = balance;
        }

        private override string AutomaticInfo()
        {
            return this.firstName + this.lastName + this.email;
        }

        public override int GetHashCode()
        {
            return this.ID;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is User || obj == null))
                return false;
            else
            {
                User compareID = (User)obj;
                if (this.GetHashCode() == compareID.GetHashCode())
                    return true;
                else
                    return false;
            }
        }

        public int CompareTo(object obj)
        {

        }
    }
}
