using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ClaimAnswerMethod
    {
        public ClaimAnswerMethod()
        {
            Claim = new HashSet<Claim>();
        }

        public int ClaimAnswerMethodCode { get; set; }
        public string ClaimAnswerMethodName { get; set; }
        public string ClaimAnswerMethodDescription { get; set; }

        public virtual ICollection<Claim> Claim { get; set; }
    }
}
