using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class PostBag
    {
        public PostBag()
        {
            Dispatch = new HashSet<Dispatch>();
            ItemExclude = new HashSet<ItemExclude>();
            MailtripTransportPostBag = new HashSet<MailtripTransportPostBag>();
            PostBagLog = new HashSet<PostBagLog>();
            ShiftHandoverPostBag = new HashSet<ShiftHandoverPostBag>();
            TracePostBag = new HashSet<TracePostBag>();
        }

        public long PostBagID { get; set; }
        public long MailtripID { get; set; }
        public int? PostBagIndex { get; set; }
        public string PostBagNumber { get; set; }
        public string PostBagTypeCode { get; set; }
        public string PostBagCode { get; set; }
        public string SealNumber { get; set; }
        public bool F { get; set; }
        public double? CaseWeight { get; set; }
        public double Weight { get; set; }
        public double? ConvertWeight { get; set; }
        public int? Quantity { get; set; }
        public byte Status { get; set; }
        public string Note { get; set; }
        public DateTime? PackagingDate { get; set; }
        public string PackagingBy { get; set; }
        public string PackagingMachine { get; set; }
        public DateTime? OpeningDate { get; set; }
        public string OpeningBy { get; set; }
        public string OpeningMachine { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedMachine { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string IdentityNumber { get; set; }

        public virtual Mailtrip Mailtrip { get; set; }
        public virtual PostBagType PostBagTypeCodeNavigation { get; set; }
        public virtual ICollection<Dispatch> Dispatch { get; set; }
        public virtual ICollection<ItemExclude> ItemExclude { get; set; }
        public virtual ICollection<MailtripTransportPostBag> MailtripTransportPostBag { get; set; }
        public virtual ICollection<PostBagLog> PostBagLog { get; set; }
        public virtual ICollection<ShiftHandoverPostBag> ShiftHandoverPostBag { get; set; }
        public virtual ICollection<TracePostBag> TracePostBag { get; set; }
    }
}
