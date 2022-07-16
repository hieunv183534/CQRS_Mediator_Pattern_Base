using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class BatchPOS
    {
        public string BatchCode { get; set; }
        public string POSCode { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }

        public virtual POS POSCodeNavigation { get; set; }
    }
}
