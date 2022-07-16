using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DeductionPOS
    {
        public string POSCode { get; set; }
        public string DeductionCode { get; set; }

        public virtual Deduction DeductionCodeNavigation { get; set; }
        public virtual POS POSCodeNavigation { get; set; }
    }
}
