using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class IncidentItem
    {
        public long IncidentID { get; set; }
        public long ItemID { get; set; }
        public double? OldWeight { get; set; }
        public double? NewWeight { get; set; }
        public string OldReceiverFullname { get; set; }
        public string OldReceiverAddress { get; set; }
        public string OldReceiverProvinceCode { get; set; }
        public string OldReceiverDistrictCode { get; set; }
        public string OldReceiverCommuneCode { get; set; }
        public string NewReceiverFullName { get; set; }
        public string NewReceiverAddress { get; set; }
        public string NewReceiverProvinceCode { get; set; }
        public string NewReceiverDistrictCode { get; set; }
        public string NewReceiverCommuneCode { get; set; }
        public string OldSenderFullname { get; set; }
        public string OldSenderAddress { get; set; }
        public string OldSenderProvinceCode { get; set; }
        public string OldSenderDistrictCode { get; set; }
        public string OldSenderCommuneCode { get; set; }
        public string NewSenderFullName { get; set; }
        public string NewSenderAddress { get; set; }
        public string NewSenderProvinceCode { get; set; }
        public string NewSenderDistrictCode { get; set; }
        public string NewSenderCommuneCode { get; set; }
        public string OldSenderCustomerCode { get; set; }
        public string NewSenderCustomerCode { get; set; }
        public string OldReceiverCustomerCode { get; set; }
        public string NewReceiverCustomerCode { get; set; }
        public string OldSenderCustomerName { get; set; }
        public string NewSenderCustomerName { get; set; }
        public string OldReceiverCustomerName { get; set; }
        public string NewReceiverCustomerName { get; set; }

        public virtual Incident Incident { get; set; }
    }
}
