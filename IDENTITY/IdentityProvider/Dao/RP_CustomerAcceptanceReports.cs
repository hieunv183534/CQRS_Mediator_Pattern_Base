using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class RP_CustomerAcceptanceReports
    {
        public string InsertedDate { get; set; }
        public string POSCode { get; set; }
        public string ShiftCode { get; set; }
        public string ReportTargetCode { get; set; }
        public string CustomerCode { get; set; }
        public int TargetIndex { get; set; }
        public int? SoLuong { get; set; }
        public double? KhoiLuong { get; set; }
        public double? TienMat { get; set; }
        public double? No { get; set; }
        public double? VATTienMat { get; set; }
        public double? VATNo { get; set; }
        public string UserName { get; set; }
        public string Machinename { get; set; }
        public DateTime CreatedDate { get; set; }
        public double? SAUCK_KHONGVAT { get; set; }
        public double? SAUCK_COVAT { get; set; }
        public double? TRUOCCK_COVAT { get; set; }
        public double? TRUOCCK_KHONGVAT { get; set; }
        public double? CuocChinh { get; set; }
        public double? CuocVAT { get; set; }
        public double? CuocGTGT { get; set; }
        public double? TongCuoc { get; set; }
        public double? Test { get; set; }
        public double? SoLuongNo { get; set; }
        public double? KhoiLuongNo { get; set; }
        public double? CuocThuChiHo { get; set; }
        public double? CuocThuNguoiNhan { get; set; }
        public double? TienThuHo { get; set; }
        public double? KhoiLuongQuyDoi { get; set; }
    }
}
