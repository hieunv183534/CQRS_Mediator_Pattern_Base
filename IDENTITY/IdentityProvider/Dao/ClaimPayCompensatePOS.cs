using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ClaimPayCompensatePOS
    {
        public string PayCompensatePOSCode { get; set; }
        public string ClaimResponseInvestigationCode { get; set; }
        public string ClaimNumber { get; set; }
        public string ReceivingClaimPOSCode { get; set; }
        public string FromPOSCode { get; set; }
        public string ToPOSCode { get; set; }
        public string ClaimSendInvestigationCode { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
