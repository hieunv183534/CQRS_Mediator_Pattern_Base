using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class sp_BangKe_BuuGui_ChuyenPhat
    {
        public string ItemCode { get; set; }
        public string ItemTypeCode { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceCode { get; set; }
        public string DistrictName { get; set; }
        public string DistrictCode { get; set; }
        public string CommuneName { get; set; }
        public string CommuneCode { get; set; }
        public double? Weight { get; set; }
        public string CoQuanGui { get; set; }
        public string CoQuanNhan { get; set; }
        public string ToPOSCode { get; set; }
        public string SendingDate { get; set; }
        public string ShiftHandoverDate { get; set; }
        public string AcceptancePOSCode { get; set; }
        public string SenderCustomerCode { get; set; }
        public string ReceiverCustomerCode { get; set; }
        public int VungXa { get; set; }
        public double FarRegionFreight { get; set; }
    }
}
