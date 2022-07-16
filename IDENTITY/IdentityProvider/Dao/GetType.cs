using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class GetType
    {
        public GetType()
        {
            MessageTypeTable = new HashSet<MessageTypeTable>();
        }

        public int GetTypeId { get; set; }
        public string GetTypeName { get; set; }

        public virtual ICollection<MessageTypeTable> MessageTypeTable { get; set; }
    }
}
