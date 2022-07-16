using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class CN48Item
    {
        public string CN48Code { get; set; }
        public string ItemCode { get; set; }
        public string AcceptancePOSCode { get; set; }
        public string ReferenceCode { get; set; }
        public DateTime? DateOfPosting { get; set; }
        public double? SDR { get; set; }
        public bool? CompensateStatus { get; set; }
        public bool? IsAcceptPayCompensate { get; set; }
        public bool? IsPaidCompensate { get; set; }
        public bool? IsPrint { get; set; }
        public string Destination { get; set; }
        public string ClaimNumber { get; set; }
        public string Description { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }

        public virtual CN48 CN48CodeNavigation { get; set; }
    }
}
