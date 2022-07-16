using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ReportManagerGroupBy
    {
        public long Id { get; set; }
        public long ReportManagerId { get; set; }
        public string Name { get; set; }
        public long DataSetId { get; set; }
        public string Key { get; set; }

        public virtual ReportManagerDataSet DataSet { get; set; }
        public virtual ReportManager ReportManager { get; set; }
    }
}
