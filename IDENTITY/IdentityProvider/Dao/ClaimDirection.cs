using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ClaimDirection
    {
        public ClaimDirection()
        {
            Claim = new HashSet<Claim>();
        }

        public int ClaimDirectionCode { get; set; }
        public string ClaimDirectionName { get; set; }
        public string ClaimDirectionDescription { get; set; }

        public virtual ICollection<Claim> Claim { get; set; }
    }
}
