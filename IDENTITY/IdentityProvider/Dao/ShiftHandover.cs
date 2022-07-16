using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ShiftHandover
    {
        public ShiftHandover()
        {
            ItemInventory = new HashSet<ItemInventory>();
            PostBagEmptyInventory = new HashSet<PostBagEmptyInventory>();
            ShiftHandoverBC37 = new HashSet<ShiftHandoverBC37>();
            ShiftHandoverDevice = new HashSet<ShiftHandoverDevice>();
            ShiftHandoverItem = new HashSet<ShiftHandoverItem>();
            ShiftHandoverMailtrip = new HashSet<ShiftHandoverMailtrip>();
            ShiftHandoverMailtripDelivery = new HashSet<ShiftHandoverMailtripDelivery>();
            ShiftHandoverMailtripTransport = new HashSet<ShiftHandoverMailtripTransport>();
            ShiftHandoverPostBag = new HashSet<ShiftHandoverPostBag>();
            ShiftHandoverPostBagEmpty = new HashSet<ShiftHandoverPostBagEmpty>();
            ShiftHandoverRequestAccepted = new HashSet<ShiftHandoverRequestAccepted>();
        }

        public long ShiftHandoverID { get; set; }
        public int HandoverIndex { get; set; }
        public string ShiftCode { get; set; }
        public string POSCode { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? HandoverTime { get; set; }
        public string GivingUserName { get; set; }
        public string RecevingUserName { get; set; }
        public byte Status { get; set; }
        public string Note { get; set; }
        public string HotIssue { get; set; }
        public string ConfirmUserName { get; set; }
        public DateTime? ConfirmTime { get; set; }
        public string ConfirmContent { get; set; }
        public string StartDate { get; set; }
        public string StartMonth { get; set; }
        public string StartYear { get; set; }
        public string GivingFullName { get; set; }
        public string RecevingFullName { get; set; }

        public virtual Shift Shift { get; set; }
        public virtual ICollection<ItemInventory> ItemInventory { get; set; }
        public virtual ICollection<PostBagEmptyInventory> PostBagEmptyInventory { get; set; }
        public virtual ICollection<ShiftHandoverBC37> ShiftHandoverBC37 { get; set; }
        public virtual ICollection<ShiftHandoverDevice> ShiftHandoverDevice { get; set; }
        public virtual ICollection<ShiftHandoverItem> ShiftHandoverItem { get; set; }
        public virtual ICollection<ShiftHandoverMailtrip> ShiftHandoverMailtrip { get; set; }
        public virtual ICollection<ShiftHandoverMailtripDelivery> ShiftHandoverMailtripDelivery { get; set; }
        public virtual ICollection<ShiftHandoverMailtripTransport> ShiftHandoverMailtripTransport { get; set; }
        public virtual ICollection<ShiftHandoverPostBag> ShiftHandoverPostBag { get; set; }
        public virtual ICollection<ShiftHandoverPostBagEmpty> ShiftHandoverPostBagEmpty { get; set; }
        public virtual ICollection<ShiftHandoverRequestAccepted> ShiftHandoverRequestAccepted { get; set; }
    }
}
