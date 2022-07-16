using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ReportManagerPrinter
    {
        public long PrinterID { get; set; }
        public long ReportManagerID { get; set; }
        public string POSCode { get; set; }
        public string PrinterName { get; set; }
        public string IP { get; set; }
        public string OptionPrint { get; set; }

        public virtual POS POSCodeNavigation { get; set; }
        public virtual ReportManager ReportManager { get; set; }
    }
}
