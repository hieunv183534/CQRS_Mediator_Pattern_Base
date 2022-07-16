using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ItemPropertyValue_Sync
    {
        public string ItemCode { get; set; }
        public string PropertyCode { get; set; }
        public string Value { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
