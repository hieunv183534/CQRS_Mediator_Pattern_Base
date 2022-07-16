using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class POSService_MBCSync
    {
        public string POSCode { get; set; }
        public string ServiceCode { get; set; }
        public double? DomesticMaximumWeight { get; set; }
        public double? InternationMaximumWeight { get; set; }
        public double? DomesticMinimumFreight { get; set; }
        public double? InternationMinimumWeight { get; set; }
        public bool? IsRunning { get; set; }
    }
}
