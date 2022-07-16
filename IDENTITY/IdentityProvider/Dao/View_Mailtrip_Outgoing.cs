using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class View_Mailtrip_Outgoing
    {
        public string ShiftCode { get; set; }
        public DateTime StartTime { get; set; }
        public string ShiftName { get; set; }
        public long ShiftHandoverID { get; set; }
        public long MailtripID { get; set; }
        public string StartingCode { get; set; }
        public string DestinationCode { get; set; }
        public int MailtripType { get; set; }
        public string ServiceCode { get; set; }
        public string Year { get; set; }
        public int MailtripNumber { get; set; }
        public DateTime? InitialDate { get; set; }
        public string InitialBy { get; set; }
        public string InitialMachine { get; set; }
        public DateTime? PackagingDate { get; set; }
        public string PackagingBy { get; set; }
        public string PackagingMachine { get; set; }
        public DateTime? OpeningDate { get; set; }
        public string OpeningBy { get; set; }
        public string OpeningMachine { get; set; }
        public int? Quantity { get; set; }
        public double? Weight { get; set; }
        public byte Type { get; set; }
        public byte Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedContent { get; set; }
        public int? TransferStatus { get; set; }
        public string OpeningDateOnly { get; set; }
        public string PackagingDateOnly { get; set; }
        public byte? UpdateDeliveryPointStatus { get; set; }
        public int? InitialType { get; set; }
        public string StartingName { get; set; }
        public string StartingProvinceCode { get; set; }
        public string DestinationName { get; set; }
        public string DestinationProvinceCode { get; set; }
        public int? StartingInternal { get; set; }
        public int? DestinationInternal { get; set; }
        public int? TotalPostBag { get; set; }
        public int? TotalItem { get; set; }
        public int ScopeType { get; set; }
    }
}
