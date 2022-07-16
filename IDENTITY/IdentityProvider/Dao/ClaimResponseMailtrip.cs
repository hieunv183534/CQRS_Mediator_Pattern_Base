using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ClaimResponseMailtrip
    {
        public string ClaimResponseMailtripCode { get; set; }
        public string ClaimResponseNumber { get; set; }
        public string ReceivingClaimPOSCode { get; set; }
        public string ClaimNumber { get; set; }
        public string FromPOSCode { get; set; }
        public string ToPOSCode { get; set; }

        public virtual ClaimResponse ClaimResponse { get; set; }
        public virtual ClaimMailTrip ClaimResponseMailtripCodeNavigation { get; set; }
    }
}
