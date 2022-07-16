using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class TracePostBag_Sync
    {
        public long? TracePostBagID { get; set; }
        public long? PostBagID { get; set; }
        public int PostBagIndex { get; set; }
        public string FromPOSCode { get; set; }
        public string ToPOSCode { get; set; }
        public string MailTripType { get; set; }
        public string ServiceCode { get; set; }
        public string Year { get; set; }
        public string MailTripNumber { get; set; }
        public string POSCode { get; set; }
        public byte? Status { get; set; }
        public string StatusDescription { get; set; }
        public DateTime? TraceDate { get; set; }
        public int TraceIndex { get; set; }
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
