using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class StoreDependOn
    {
        public string MessageTypeName { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string StoreDependOnTableName { get; set; }
        public string StoreDependOnColumnName { get; set; }

        public virtual Column Column { get; set; }
        public virtual MessageTypeTable MessageTypeTable { get; set; }
        public virtual Column StoreDependOnNavigation { get; set; }
    }
}
