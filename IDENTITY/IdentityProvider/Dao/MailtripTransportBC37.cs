using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class MailtripTransportBC37
    {
        public string BC37Date { get; set; }
        public int? BC37Index { get; set; }
        public string BC37FromPOSCode { get; set; }
        public string BC37ToPOSCode { get; set; }
        public string TransportTypeCode { get; set; }
        public int? BC37Order { get; set; }
        public string MailtripTransportFromPOSCode { get; set; }
        public string TransportDate { get; set; }
        public string TransportCode { get; set; }
        public string ConfirmUser { get; set; }
        public string ConfirmPOSCode { get; set; }
        public string CreateUser { get; set; }
        public string CreatePOSCode { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public int? TransportNumber { get; set; }
        public byte? Direct { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public long BC37ID { get; set; }
        public long MailtripTransportID { get; set; }
        public byte? Status { get; set; }

        public virtual BC37 BC37 { get; set; }
        public virtual MailtripTransport MailtripTransport { get; set; }
    }
}
