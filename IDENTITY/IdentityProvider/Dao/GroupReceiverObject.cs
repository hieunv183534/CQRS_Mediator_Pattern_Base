using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class GroupReceiverObject
    {
        public GroupReceiverObject()
        {
            GroupReceiverObjectDetail = new HashSet<GroupReceiverObjectDetail>();
        }

        public long GroupObjectID { get; set; }
        public string GroupObjectCode { get; set; }
        public string GroupObjectName { get; set; }
        public string POSCode { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual POS POSCodeNavigation { get; set; }
        public virtual ICollection<GroupReceiverObjectDetail> GroupReceiverObjectDetail { get; set; }
    }
}
