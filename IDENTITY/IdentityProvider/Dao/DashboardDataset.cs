using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DashboardDataset
    {
        public DashboardDataset()
        {
            DashboardSetting = new HashSet<DashboardSetting>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public int SourceType { get; set; }
        public int DataType { get; set; }
        public string DataValue { get; set; }
        public string ConnectString { get; set; }
        public int? Cache { get; set; }

        public virtual ICollection<DashboardSetting> DashboardSetting { get; set; }
    }
}
