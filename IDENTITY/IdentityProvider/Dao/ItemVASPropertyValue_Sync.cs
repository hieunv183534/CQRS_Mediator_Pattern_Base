using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ItemVASPropertyValue_Sync
    {
        public long? ItemID { get; set; }
        public string ItemCode { get; set; }
        public string PropertyCode { get; set; }
        public string Value { get; set; }
        public string ValueAddedServiceCode { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
