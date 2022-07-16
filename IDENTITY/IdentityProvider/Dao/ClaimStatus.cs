using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ClaimStatus
    {
        public ClaimStatus()
        {
            Claim = new HashSet<Claim>();
        }

        public byte ClaimStatusCode { get; set; }
        public string ClaimStatusName { get; set; }
        public string ClaimStatusDescription { get; set; }

        public virtual ICollection<Claim> Claim { get; set; }
    }
}
