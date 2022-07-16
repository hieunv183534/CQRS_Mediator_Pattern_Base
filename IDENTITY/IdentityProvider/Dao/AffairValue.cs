using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class AffairValue
    {
        public int AffairID { get; set; }
        public string AffairName { get; set; }
        public double? Value { get; set; }
    }
}
