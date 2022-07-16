using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Column
    {
        public Column()
        {
            StoreDependOnColumn = new HashSet<StoreDependOn>();
            StoreDependOnStoreDependOnNavigation = new HashSet<StoreDependOn>();
        }

        public string ColumnName { get; set; }
        public string TableName { get; set; }
        public string DataType { get; set; }
        public bool IsIdentity { get; set; }
        public bool IsUnique { get; set; }
        public bool IsNullable { get; set; }
        public bool InPrimaryKey { get; set; }

        public virtual Table TableNameNavigation { get; set; }
        public virtual ICollection<StoreDependOn> StoreDependOnColumn { get; set; }
        public virtual ICollection<StoreDependOn> StoreDependOnStoreDependOnNavigation { get; set; }
    }
}
