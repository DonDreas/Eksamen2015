using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    class Product
    {
        private int _produktId;
        public int productId
        {
            get { return _produktId; }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("value");

                _produktId = value;
            }
        }

        private string _name;
        public string name
        {
            get { return _name; }
            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException();

                _name = value;
            }
        }

        public decimal price { get {return this.price; }  set {this.price = value; } }

        public bool active { get {return this.active; } set {this.active = value; } }

        public bool canBeBoughtOnCredit { get { return this.canBeBoughtOnCredit; } set { this.canBeBoughtOnCredit = value; } }

        public Product(int productId, string name, decimal price, 
            bool active, bool canBeboughtOnCredit)
        {
            this.productId = productId;
            this.name = name;
            this.price = price;
            this.active = active;
            this.canBeBoughtOnCredit = canBeBoughtOnCredit;

        }
    }
}
