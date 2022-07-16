using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class MailtripDelivery
    {
        public MailtripDelivery()
        {
            MailtripItem = new HashSet<MailtripItem>();
            ShiftHandoverMailtripDelivery = new HashSet<ShiftHandoverMailtripDelivery>();
        }

        public long MailtripID { get; set; }
        public string POSCode { get; set; }
        public string DeliveryRouteCode { get; set; }
        public string ServiceCode { get; set; }
        public string MailtripDate { get; set; }
        public int MailtripNumber { get; set; }
        public string TransportCode { get; set; }
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
        public int? Type { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedContent { get; set; }
        public string URLFile { get; set; }
        public long? ShiftHandoverID { get; set; }
        public string ConfirmBy { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public string CreatedDateOnly { get; set; }

        public virtual ICollection<MailtripItem> MailtripItem { get; set; }
        public virtual ICollection<ShiftHandoverMailtripDelivery> ShiftHandoverMailtripDelivery { get; set; }
    }
}
