using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class View_PostBagEmpty
    {
        public string ShiftCode { get; set; }
        public DateTime StartTime { get; set; }
        public string ShiftName { get; set; }
        public string PostBagTypeName { get; set; }
        public long PostBagEmptyID { get; set; }
        public string POSCode { get; set; }
        public string PostBagTypeCode { get; set; }
        public int PostBagEmptyType { get; set; }
        public int Amount { get; set; }
        public string ReturnPOSCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedContent { get; set; }
        public byte? Status { get; set; }
        public long? ShiftHandoverID { get; set; }
        public string Note { get; set; }
    }
}
