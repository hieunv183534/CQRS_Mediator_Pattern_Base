using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class StoreType
    {
        public StoreType()
        {
            MessageTypeTable = new HashSet<MessageTypeTable>();
        }

        public int StoreTypeId { get; set; }
        public string StoreTypeName { get; set; }

        public virtual ICollection<MessageTypeTable> MessageTypeTable { get; set; }
    }
}
