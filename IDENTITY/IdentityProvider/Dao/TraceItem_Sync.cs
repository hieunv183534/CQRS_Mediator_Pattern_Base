using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class TraceItem_Sync
    {
        public long? TraceItemID { get; set; }
        public long? ItemID { get; set; }
        public int TraceIndex { get; set; }
        public string ItemCode { get; set; }
        public string POSCode { get; set; }
        public byte? Status { get; set; }
        public DateTime? TraceDate { get; set; }
        public string StatusDesc { get; set; }
        public string Note { get; set; }
        public string TransferMachine { get; set; }
        public string TransferUser { get; set; }
        public string TransferPOSCode { get; set; }
        public DateTime? TransferDate { get; set; }
        public bool? TransferStatus { get; set; }
        public int? TransferTimes { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
