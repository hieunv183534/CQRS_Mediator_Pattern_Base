using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class AffairTransport
    {
        public string AffairIndex { get; set; }
        public string FromPOSCode { get; set; }
        public string TransportDate { get; set; }
        public string TransportCode { get; set; }
        public string TransportNumber { get; set; }
        public DateTime? AffairDate { get; set; }
        public string InputUser { get; set; }
        public byte? AffairType { get; set; }
        public byte? Status { get; set; }
        public string AffairContent { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public double? TotalWeight { get; set; }
        public int? TotalBag { get; set; }
        public DateTime? ProcessDate { get; set; }
        public string MailRouteScheduleCode { get; set; }
        public string MailRouteCode { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
