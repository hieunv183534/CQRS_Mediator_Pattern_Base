using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class PrintedMatterMachine
    {
        public string PrintedMatterCode { get; set; }
        public string POSCode { get; set; }
        public string PrinterName { get; set; }

        public virtual PrintedMatter PrintedMatterCodeNavigation { get; set; }
    }
}
