using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ObjectRef
    {
        public ObjectRef()
        {
            RoleObject = new HashSet<RoleObject>();
        }

        public int ObjectRefId { get; set; }
        public string ObjectRefName { get; set; }
        public string ObjectType { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public bool? Enable { get; set; }

        public virtual ICollection<RoleObject> RoleObject { get; set; }
    }
}
