using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ReportManagerParam
    {
        public long Id { get; set; }
        public long ReportManagerId { get; set; }
        public string Name { get; set; }
        public int DataType { get; set; }
        public int InputType { get; set; }
        public string DataDefault { get; set; }
        public string DataFileDefault { get; set; }

        public virtual ReportManager ReportManager { get; set; }
    }
}
