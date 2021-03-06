﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    public class SeasonalProduct : Product
    {
        //Nedarver fra klassen Product.
        private string _seasonStartDate;
        public string seasonStartDate 
        {
            get { return _seasonStartDate; }
            set
            {
                if (value == null)
                    this.active = true;
                else
                    _seasonStartDate = value;
            }
        }

        private string _seasonEndDate;
        public string seasonEndDate
        {
            get { return _seasonEndDate; }
            set
            {
                if (value == null)
                    this.active = true;
                else
                    _seasonEndDate = value;
            }
        }

        public bool active { get; set; }

        public SeasonalProduct(int productId, string name, decimal price, bool canBeBoughtOnCredit, string seasonStartDate, string seasonEndDate, bool active)
            : base(productId, name, price, canBeBoughtOnCredit)
        {
            this.seasonStartDate = seasonStartDate;
            this.seasonEndDate = seasonEndDate;
            this.active = active;
        }
    }
}
