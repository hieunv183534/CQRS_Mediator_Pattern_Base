using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ReportManagerDataSet
    {
        public ReportManagerDataSet()
        {
            ReportManagerGroupBy = new HashSet<ReportManagerGroupBy>();
        }

        public long Id { get; set; }
        public long ReportManagerId { get; set; }
        public string Name { get; set; }
        public int SourceType { get; set; }
        public int DataType { get; set; }
        public string DataValue { get; set; }
        public string ConnectString { get; set; }

        public virtual ReportManager ReportManager { get; set; }
        public virtual ICollection<ReportManagerGroupBy> ReportManagerGroupBy { get; set; }
    }
}
