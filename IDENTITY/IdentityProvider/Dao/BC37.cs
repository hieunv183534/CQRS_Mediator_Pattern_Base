using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class BC37
    {
        public BC37()
        {
            MailtripTransportBC37 = new HashSet<MailtripTransportBC37>();
            MailtripTransportPostBag = new HashSet<MailtripTransportPostBag>();
            ShiftHandoverBC37 = new HashSet<ShiftHandoverBC37>();
        }

        public long BC37ID { get; set; }
        public int BC37Index { get; set; }
        public string FromPOSCode { get; set; }
        public string ToPOSCode { get; set; }
        public string TransportTypeCode { get; set; }
        public byte Status { get; set; }
        public string BC37Date { get; set; }
        public string ConfirmUser { get; set; }
        public string ConfirmPOSCode { get; set; }
        public string CreateUser { get; set; }
        public string CreatePOSCode { get; set; }
        public string BC37Code { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public string TransferMachine { get; set; }
        public string TransferUser { get; set; }
        public string TransferPOSCode { get; set; }
        public DateTime? TransferDate { get; set; }
        public bool? TransferStatus { get; set; }
        public int? TransferTimes { get; set; }
        public int? TotalOtherPostBag { get; set; }
        public double? TotalWeightOtherPostBag { get; set; }
        public int? TotalPHBCPostBag { get; set; }
        public double? TotalWeightPHBCPostBag { get; set; }
        public string MailRouteCode { get; set; }
        public string MailRouteFromPOSCode { get; set; }
        public string MailRouteScheduleCode { get; set; }
        public DateTime? SendingTime { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }

        public virtual ICollection<MailtripTransportBC37> MailtripTransportBC37 { get; set; }
        public virtual ICollection<MailtripTransportPostBag> MailtripTransportPostBag { get; set; }
        public virtual ICollection<ShiftHandoverBC37> ShiftHandoverBC37 { get; set; }
    }
}
