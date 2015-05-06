﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    public class Product
    {
        private int _produktId;
        public int productId
        {
            get { return _produktId; }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("value");
                else
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
                else
                    _name = value;
            }
        }

        private decimal _price;
        public decimal price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Value");
                else
                    _price = value;
            }
        }

        public bool active { get; set; }

        public bool canBeBoughtOnCredit { get; set; }

        public Product(int productId, string name, decimal price, bool canBeboughtOnCredit)
        {
            this.productId = productId;
            this.name = name;
            this.price = price;
            this.active = active;
            this.canBeBoughtOnCredit = false;
        }
    }
}
