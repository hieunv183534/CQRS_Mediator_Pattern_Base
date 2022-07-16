using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Transport
    {
        public Transport()
        {
            MailtripTransport = new HashSet<MailtripTransport>();
            TransportError = new HashSet<TransportError>();
        }

        public string TransportCode { get; set; }
        public string TransportGroup { get; set; }
        public double? TotalLoad { get; set; }
        public byte? Status { get; set; }
        public string POSCode { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public int? Partner { get; set; }
        public string Description { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
        public double? Speed { get; set; }

        public virtual POS POSCodeNavigation { get; set; }
        public virtual TransportGroup TransportGroupNavigation { get; set; }
        public virtual ICollection<MailtripTransport> MailtripTransport { get; set; }
        public virtual ICollection<TransportError> TransportError { get; set; }
    }
}
