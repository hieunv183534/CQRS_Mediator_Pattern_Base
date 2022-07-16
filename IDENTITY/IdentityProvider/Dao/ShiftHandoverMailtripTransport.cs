using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ShiftHandoverMailtripTransport
    {
        public string POSCode { get; set; }
        public int HandoverIndex { get; set; }
        public string ShiftCode { get; set; }
        public string CounterCode { get; set; }
        public int TransportNumber { get; set; }
        public string FromPOSCode { get; set; }
        public string TransportDate { get; set; }
        public string TransportCode { get; set; }
        public byte Status { get; set; }
        public long MailtripTransportID { get; set; }
        public long ShiftHandoverID { get; set; }

        public virtual MailtripTransport MailtripTransport { get; set; }
        public virtual ShiftHandover ShiftHandover { get; set; }
    }
}
