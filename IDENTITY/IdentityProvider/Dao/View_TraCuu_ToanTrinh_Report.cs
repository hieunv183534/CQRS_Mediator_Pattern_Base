using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class View_TraCuu_ToanTrinh_Report
    {
        public long ItemID { get; set; }
        public string ItemCode { get; set; }
        public string ItemTypeCode { get; set; }
        public string ArCode { get; set; }
        public bool? Internal { get; set; }
        public string AcceptancePOSCode { get; set; }
        public string AcceptanceProvinceCode { get; set; }
        public string ReceiverProvinceCode { get; set; }
        public DateTime SendingTime { get; set; }
        public string ToPOSCode { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryUser { get; set; }
        public string ReceiverAddress { get; set; }
        public string RealReciverName { get; set; }
        public DateTime? ThoiGianToanTrinh { get; set; }
        public int? ConLaiToanTrinh { get; set; }
        public int? ThoiGianPhatCham { get; set; }
        public int? ThoiGianPhat { get; set; }
        public string LastPosCode { get; set; }
        public byte LastStatus { get; set; }
    }
}
