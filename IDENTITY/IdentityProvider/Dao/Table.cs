using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Table
    {
        public Table()
        {
            Column = new HashSet<Column>();
            MessageTypeTable = new HashSet<MessageTypeTable>();
        }

        public string TableName { get; set; }

        public virtual ICollection<Column> Column { get; set; }
        public virtual ICollection<MessageTypeTable> MessageTypeTable { get; set; }
    }
}
