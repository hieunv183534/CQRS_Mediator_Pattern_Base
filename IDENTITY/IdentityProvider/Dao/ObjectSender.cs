using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ObjectSender
    {
        public long SenderObjectID { get; set; }
        public string SenderObjectName { get; set; }
        public string CustomerCode { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }

        public virtual Customer CustomerCodeNavigation { get; set; }
    }
}
