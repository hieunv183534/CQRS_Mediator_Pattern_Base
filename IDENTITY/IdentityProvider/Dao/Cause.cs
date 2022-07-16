using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Cause
    {
        public Cause()
        {
            CauseCustomer = new HashSet<CauseCustomer>();
            CauseSolution = new HashSet<CauseSolution>();
            RangeCauseNavigation = new HashSet<RangeCause>();
        }

        public string CauseCode { get; set; }
        public string VietnameseCauseName { get; set; }
        public string EnglishCauseName { get; set; }
        public int? RangeCause { get; set; }
        public int? DeliveryType { get; set; }

        public virtual ICollection<CauseCustomer> CauseCustomer { get; set; }
        public virtual ICollection<CauseSolution> CauseSolution { get; set; }
        public virtual ICollection<RangeCause> RangeCauseNavigation { get; set; }
    }
}
