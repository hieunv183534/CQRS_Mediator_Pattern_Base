using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DomesticFarRegion
    {
        public int Id { get; set; }
        public int DomesticFreightRuleId { get; set; }
        public string DistrictCode { get; set; }

        public virtual District DistrictCodeNavigation { get; set; }
        public virtual DomesticFreightRule DomesticFreightRule { get; set; }
    }
}
