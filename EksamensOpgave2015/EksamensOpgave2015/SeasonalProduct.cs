using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamensOpgave2015
{
    public class SeasonalProduct : Product
    {
        public string seasonStartDate 
        {
            get { return seasonStartDate; }
            set
            {
                if (value == null)
                    this.active = true;
                else
                    this.seasonStartDate = value;
            }
        }

        public string seasonEndDate
        {
            get { return seasonEndDate; }
            set
            {
                if (value == null)
                    this.active = true;
                else
                    this.seasonEndDate = value;
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
