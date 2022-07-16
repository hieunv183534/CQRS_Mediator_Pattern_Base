using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class TraceItem
    {
        public long TraceItemID { get; set; }
        public long ItemID { get; set; }
        public int TraceIndex { get; set; }
        public string POSCode { get; set; }
        public byte Status { get; set; }
        public DateTime TraceDate { get; set; }
        public string StatusDesc { get; set; }
        public string Note { get; set; }
        public string TableName { get; set; }
        public long? TableID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? IsLast { get; set; }
        public long? NextLast { get; set; }
        public string ItemCode { get; set; }

        public virtual Item Item { get; set; }
    }
}
