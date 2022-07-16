using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Dispatch_Sync
    {
        public long? DispatchID { get; set; }
        public long? PostbagID { get; set; }
        public long? ItemID { get; set; }
        public int PostBagIndex { get; set; }
        public string FromPOSCode { get; set; }
        public string ToPOSCode { get; set; }
        public string MailTripType { get; set; }
        public string ServiceCode { get; set; }
        public string Year { get; set; }
        public string MailTripNumber { get; set; }
        public string ItemCode { get; set; }
        public byte? Status { get; set; }
        public int? IndexNumber { get; set; }
        public int? Sheet { get; set; }
        public string DeliveryRouteCode { get; set; }
        public string CounterCode { get; set; }
        public string ShiftCode { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public string PostmanCode { get; set; }
    }
}
