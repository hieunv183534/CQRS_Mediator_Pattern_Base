using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Invitation
    {
        public string ItemCode { get; set; }
        public DateTime InvitationDate { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public int? InvitationType { get; set; }
    }
}
