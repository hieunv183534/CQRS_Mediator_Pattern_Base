using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Solution
    {
        public Solution()
        {
            CauseSolution = new HashSet<CauseSolution>();
            RangeSolution = new HashSet<RangeSolution>();
            SolutionCustomer = new HashSet<SolutionCustomer>();
        }

        public string SolutionCode { get; set; }
        public string SolutionName { get; set; }
        public string Description { get; set; }
        public int? DeliveryType { get; set; }

        public virtual ICollection<CauseSolution> CauseSolution { get; set; }
        public virtual ICollection<RangeSolution> RangeSolution { get; set; }
        public virtual ICollection<SolutionCustomer> SolutionCustomer { get; set; }
    }
}
