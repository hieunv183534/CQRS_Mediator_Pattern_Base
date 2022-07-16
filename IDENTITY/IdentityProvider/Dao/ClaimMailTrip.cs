using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ClaimMailTrip
    {
        public ClaimMailTrip()
        {
            ClaimResponseMailtrip = new HashSet<ClaimResponseMailtrip>();
        }

        public string ClaimResponseMailtripCode { get; set; }
        public string StartingCode { get; set; }
        public string DestinationCode { get; set; }
        public string MailtripType { get; set; }
        public string ServiceCode { get; set; }
        public string Year { get; set; }
        public string MailtripNumber { get; set; }
        public string PostBagNumber { get; set; }
        public int? MailtripTransportType { get; set; }
        public string Notes { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }

        public virtual ICollection<ClaimResponseMailtrip> ClaimResponseMailtrip { get; set; }
    }
}
