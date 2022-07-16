using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class AffairItemVASPropertyValue
    {
        public Guid ItemID { get; set; }
        public int AffairIndex { get; set; }
        public string ValueAddedServiceCode { get; set; }
        public string PropertyCode { get; set; }
        public string ItemCode { get; set; }
        public string Value { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
