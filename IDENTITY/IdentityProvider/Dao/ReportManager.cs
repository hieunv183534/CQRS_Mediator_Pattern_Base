using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ReportManager
    {
        public ReportManager()
        {
            ReportManagerDataSet = new HashSet<ReportManagerDataSet>();
            ReportManagerGroupBy = new HashSet<ReportManagerGroupBy>();
            ReportManagerParam = new HashSet<ReportManagerParam>();
            ReportManagerPrinter = new HashSet<ReportManagerPrinter>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public string ParentTag { get; set; }
        public int Type { get; set; }
        public string FileTemplate { get; set; }
        public string DataSource { get; set; }
        public int DataType { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ReportManagerDataSet> ReportManagerDataSet { get; set; }
        public virtual ICollection<ReportManagerGroupBy> ReportManagerGroupBy { get; set; }
        public virtual ICollection<ReportManagerParam> ReportManagerParam { get; set; }
        public virtual ICollection<ReportManagerPrinter> ReportManagerPrinter { get; set; }
    }
}
