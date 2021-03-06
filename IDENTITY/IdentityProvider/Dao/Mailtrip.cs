using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Mailtrip
    {
        public Mailtrip()
        {
            MailtripPostBagEmpty = new HashSet<MailtripPostBagEmpty>();
            PostBag = new HashSet<PostBag>();
            ShiftHandoverMailtrip = new HashSet<ShiftHandoverMailtrip>();
        }

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

        public virtual POS DestinationCodeNavigation { get; set; }
        public virtual MailtripType MailtripTypeNavigation { get; set; }
        public virtual Service ServiceCodeNavigation { get; set; }
        public virtual POS StartingCodeNavigation { get; set; }
        public virtual ICollection<MailtripPostBagEmpty> MailtripPostBagEmpty { get; set; }
        public virtual ICollection<PostBag> PostBag { get; set; }
        public virtual ICollection<ShiftHandoverMailtrip> ShiftHandoverMailtrip { get; set; }
    }
}
