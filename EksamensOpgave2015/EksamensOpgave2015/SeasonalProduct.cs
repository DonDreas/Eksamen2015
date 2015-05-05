using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    class SeasonalProduct : Product
    {
        private string _seasonStartDate;
        public string seasonStartDate 
        {
            get { return _seasonStartDate; }
            set
            {
                if (value == null)
                    this.active = true;
                else
                    this.seasonStartDate = value;

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
                    this.seasonEndDate = value;

                _seasonEndDate = value;
            }
        }

        public bool active { get; set; }

        public SeasonalProduct(int productId, string name, decimal price, bool canBeboughtOnCredit, string seasonStartDate, string seasonEndDate, bool active)
            : base(productId, name, price, canBeboughtOnCredit)
        {
            this.seasonStartDate = seasonStartDate;
            this.seasonEndDate = seasonEndDate;
            this.active = active;
        }
        
    }
}
