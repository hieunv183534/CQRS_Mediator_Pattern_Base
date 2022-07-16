using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Postbag_Sync
    {
        public long? PostBagID { get; set; }
        public long? MailtripID { get; set; }
        public int PostBagIndex { get; set; }
        public string PostBagTypeCode { get; set; }
        public bool F { get; set; }
        public string FromPOSCode { get; set; }
        public string ToPOSCode { get; set; }
        public string MailTripType { get; set; }
        public string ServiceCode { get; set; }
        public string Year { get; set; }
        public string MailTripNumber { get; set; }
        public string PostBagNumber { get; set; }
        public double Weight { get; set; }
        public byte? Status { get; set; }
        public int? Quantity { get; set; }
        public bool? IsPrinted { get; set; }
        public DateTime? BC37Date { get; set; }
        public DateTime? PackagingTime { get; set; }
        public string PackagingUser { get; set; }
        public string PackagingMachine { get; set; }
        public DateTime? OpeningTime { get; set; }
        public string OpeningMachine { get; set; }
        public string OpeningUser { get; set; }
        public DateTime? IncomingDate { get; set; }
        public double? CaseWeight { get; set; }
        public bool? IsDiscrete { get; set; }
        public bool? IsDeliveryRoute { get; set; }
        public string PostBagCode { get; set; }
        public string Note { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public double? PostBagWeightConvert { get; set; }
    }
}
