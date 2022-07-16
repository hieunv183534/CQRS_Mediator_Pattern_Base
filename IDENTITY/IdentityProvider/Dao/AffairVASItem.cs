using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class AffairVASItem
    {
        public long ItemID { get; set; }
        public int AffairIndex { get; set; }
        public string ServiceCode { get; set; }
        public string ValueAddedServiceCode { get; set; }
        public string ItemCode { get; set; }
        public double? Freight { get; set; }
        public string PhaseCode { get; set; }
        public DateTime? AddedDate { get; set; }
        public double? FreightVAT { get; set; }
        public string POSCode { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
