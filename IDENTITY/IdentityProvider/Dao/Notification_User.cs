using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Notification_User
    {
        public long Id { get; set; }
        public long? NotificationId { get; set; }
        public int Status { get; set; }
        public string UserName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ReadTime { get; set; }

        public virtual Notification Notification { get; set; }
    }
}
