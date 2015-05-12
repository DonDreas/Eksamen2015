using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Text.RegularExpressions;

namespace EksamensOpgave2015
{
    public class User : IComparable
    {
        //User klassen går hovedsageligt ud på, at lave propeties til hver af de følgende krav, så de opfylder de givne kriterier. 
        public int ID { get; set; }

        private string _firstName;
        public string firstName
        {
            get { return _firstName; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Firstname may not be null!");
                else
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
                    throw new ArgumentNullException("Lastname may not be null!");
                else
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
                    throw new ArgumentOutOfRangeException("Ugyldigt tegn!");
                else
                    _userName = value;
            }
        }

        //Splitter ved @. På den måde er det lettere at opfylde kriterierne.
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

                char checkLastLetter = split[1].Last();
                if (checkLastLetter == '.' || checkLastLetter == '-')
                    throw new ArgumentOutOfRangeException();

                else
                    _email = value;
            }
        }

        public decimal balance { get; set; }

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

        public string AutomaticInfo()
        {
            return "" + this.firstName + " " + this.lastName + "( " + this.email + ")";
        }

        //Min hashcode er i dette tilfælde ID, da det er unikt i programmmet.
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
            User UserID = obj as User;

            if (UserID != null)
                return this.ID.CompareTo(UserID.ID);
            else
                throw new ArgumentException();
        }
    }
}
