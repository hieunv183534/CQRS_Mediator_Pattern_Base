using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ItemVASPropertyValue
    {
        public long ItemID { get; set; }
        public string PropertyCode { get; set; }
        public string ValueAddedServiceCode { get; set; }
        public string ItemCode { get; set; }
        public string Value { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }

        public virtual VASProperty VASProperty { get; set; }
    }
}
