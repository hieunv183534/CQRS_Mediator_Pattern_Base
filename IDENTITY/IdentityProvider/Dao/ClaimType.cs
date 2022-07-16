using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ClaimType
    {
        public ClaimType()
        {
            Claim = new HashSet<Claim>();
        }

        public string ClaimTypeCode { get; set; }
        public string ClaimTypeName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Claim> Claim { get; set; }
    }
}
