using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Notification
    {
        public Notification()
        {
            Notification_User = new HashSet<Notification_User>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string PosCode { get; set; }
        public bool? IsSentAll { get; set; }

        public virtual ICollection<Notification_User> Notification_User { get; set; }
    }
}
