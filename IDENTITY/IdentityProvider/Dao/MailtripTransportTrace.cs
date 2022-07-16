using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class MailtripTransportTrace
    {
        public long MailtripTransportTraceIndex { get; set; }
        public string POSCode { get; set; }
        public DateTime TraceDate { get; set; }
        public string TraceDescription { get; set; }
        public string Status { get; set; }
        public string FromPOSCode { get; set; }
        public string TransportDate { get; set; }
        public string TransportCode { get; set; }
        public int TransportNumber { get; set; }
        public byte? Direct { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public long MailtripTransportID { get; set; }

        public virtual MailtripTransport MailtripTransport { get; set; }
    }
}
