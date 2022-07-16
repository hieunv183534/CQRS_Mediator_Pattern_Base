using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ClaimResult
    {
        public ClaimResult()
        {
            ClaimResponse = new HashSet<ClaimResponse>();
        }

        public int ClaimResultCode { get; set; }
        public string ClaimResultName { get; set; }
        public string ClaimResultDescription { get; set; }

        public virtual ICollection<ClaimResponse> ClaimResponse { get; set; }
    }
}
