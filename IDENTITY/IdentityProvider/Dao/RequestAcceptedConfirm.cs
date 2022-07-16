using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class RequestAcceptedConfirm
    {
        public long ConfirmID { get; set; }
        public long RequestID { get; set; }
        public string ItemTypeCode { get; set; }
        public int ItemNumber { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ItemType ItemTypeCodeNavigation { get; set; }
        public virtual RequestAccepted Request { get; set; }
    }
}
