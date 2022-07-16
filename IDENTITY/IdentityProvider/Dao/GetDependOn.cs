using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class GetDependOn
    {
        public string MessageTypeName { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string GetDependOnTableName { get; set; }
        public string GetDependOnColumnName { get; set; }

        public virtual MessageTypeTable MessageTypeTable { get; set; }
    }
}
