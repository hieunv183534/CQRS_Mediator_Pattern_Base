using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Permission_Report_ShiftReport
    {
        public string ReportID { get; set; }
        public string ReportName { get; set; }
        public int? ReportOrder { get; set; }
        public string ReportDes { get; set; }
        public bool Enable { get; set; }
    }
}
