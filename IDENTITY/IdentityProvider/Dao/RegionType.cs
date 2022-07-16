using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class RegionType
    {
        public RegionType()
        {
            PhaseQualityTarget = new HashSet<PhaseQualityTarget>();
            WholeQualityTarget = new HashSet<WholeQualityTarget>();
        }

        public string RegionTypeCode { get; set; }
        public string RegionTypeName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PhaseQualityTarget> PhaseQualityTarget { get; set; }
        public virtual ICollection<WholeQualityTarget> WholeQualityTarget { get; set; }
    }
}
