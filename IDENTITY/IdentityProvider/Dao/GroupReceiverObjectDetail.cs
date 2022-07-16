using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class GroupReceiverObjectDetail
    {
        public long ObjectDetailID { get; set; }
        public long GroupObjectID { get; set; }
        public string ReceiverDeliveryPointCode { get; set; }
        public string ReceiverDeliveryPointName { get; set; }
        public string ReceiverCustomerCode { get; set; }
        public string ReceiverCustomerName { get; set; }
        public string ReceiverCustomerAddress { get; set; }
        public string ReceiverCustomerTel { get; set; }
        public string ReceiverFullName { get; set; }
        public string ReceiverProvinceCode { get; set; }
        public string ReceiverDistrictCode { get; set; }
        public string ReceiverCommuneCode { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverTel { get; set; }
        public string ReceiverEmail { get; set; }
        public string ReceiverFax { get; set; }
        public string ReceiverTaxCode { get; set; }
        public string ReceiverIdentifyNumber { get; set; }
        public string ReceiverContact { get; set; }
        public long? ReceiverObjectID { get; set; }
        public int? IndexNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual GroupReceiverObject GroupObject { get; set; }
        public virtual Commune ReceiverCommuneCodeNavigation { get; set; }
        public virtual District ReceiverDistrictCodeNavigation { get; set; }
        public virtual Province ReceiverProvinceCodeNavigation { get; set; }
    }
}
