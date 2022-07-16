using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ClaimTypeError
    {
        public int ClaimTypeErrorCode { get; set; }
        public string ClaimTypeErrorName { get; set; }
        public string Description { get; set; }
        public bool? Enable { get; set; }
    }
}
