using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class POSFreightRegion
    {
        public int Id { get; set; }
        public int FreightRegionId { get; set; }
        public string FreightRegionCode { get; set; }
        public string ServiceCode { get; set; }
        public string POSCode { get; set; }
        public string DomesticFreightRuleCode { get; set; }

        public virtual FreightRegion FreightRegion { get; set; }
        public virtual POS POSCodeNavigation { get; set; }
    }
}
