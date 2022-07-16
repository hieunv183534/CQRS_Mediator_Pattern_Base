using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class IntercityJourneysTarget
    {
        public long Id { get; set; }
        public string FromRegionGroupCode { get; set; }
        public string ToRegionGroupCode { get; set; }
        public int Type { get; set; }
        public double? ProcessTime { get; set; }
        public int ServiceType { get; set; }
    }
}
