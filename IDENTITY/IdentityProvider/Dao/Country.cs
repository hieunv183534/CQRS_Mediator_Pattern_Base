using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Country
    {
        public Country()
        {
            LimitWeight = new HashSet<LimitWeight>();
            OE = new HashSet<OE>();
        }

        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string ContinentCode { get; set; }
        public bool? isPrintedCN23 { get; set; }
        public bool? isPostalParcels { get; set; }

        public virtual Continent ContinentCodeNavigation { get; set; }
        public virtual ICollection<LimitWeight> LimitWeight { get; set; }
        public virtual ICollection<OE> OE { get; set; }
    }
}
