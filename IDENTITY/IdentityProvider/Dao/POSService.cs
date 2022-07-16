using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class POSService
    {
        public string POSCode { get; set; }
        public string ServiceCode { get; set; }
        public double? DomesticMaximumWeight { get; set; }
        public double? InternationMaximumWeight { get; set; }
        public double? DomesticMinimumFreight { get; set; }
        public double? InternationMinimumWeight { get; set; }
        public bool? IsRunning { get; set; }
        public bool? AllowsQuick { get; set; }

        public virtual POS POSCodeNavigation { get; set; }
        public virtual Service ServiceCodeNavigation { get; set; }
    }
}
