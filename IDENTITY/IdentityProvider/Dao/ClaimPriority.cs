using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ClaimPriority
    {
        public ClaimPriority()
        {
            Claim = new HashSet<Claim>();
        }

        public string ClaimPriorityCode { get; set; }
        public string ClaimPriorityName { get; set; }
        public double? ClaimPriorityWeight { get; set; }

        public virtual ICollection<Claim> Claim { get; set; }
    }
}
