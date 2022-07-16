using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class View_CompareRequestAcceptance
    {
        public string ShiftCode { get; set; }
        public string ShiftName { get; set; }
        public DateTime? StartTime { get; set; }
        public long? ShiftHandoverID { get; set; }
        public string AcceptancePOSCode { get; set; }
        public string SenderCustomerCode { get; set; }
        public string ItemTypeCode { get; set; }
        public int ItemNumberConfirm { get; set; }
        public int ItemNumberAccepted { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
    }
}
