using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class IntercityJourneysTarget_View
    {
        public string FromRegionGroupCode { get; set; }
        public string ToRegionGroupCode { get; set; }
        public string District { get; set; }
        public string Provice { get; set; }
        public int Type { get; set; }
    }
}
