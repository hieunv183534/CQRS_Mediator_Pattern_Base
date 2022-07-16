using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class bcn_commissiontodeliveryspecial
    {
        public int Id { get; set; }
        public string ItemTypeCode { get; set; }
        public bool? IsSpecial { get; set; }
    }
}
