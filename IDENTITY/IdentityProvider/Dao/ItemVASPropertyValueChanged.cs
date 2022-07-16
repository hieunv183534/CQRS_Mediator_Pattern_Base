using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ItemVASPropertyValueChanged
    {
        public long ItemID { get; set; }
        public int ChangeIndex { get; set; }
        public int HandoverIndex { get; set; }
        public string ChangePOSCode { get; set; }
        public string ItemCode { get; set; }
        public string PropertyCode { get; set; }
        public string Value { get; set; }
        public string ValueAddedServiceCode { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
