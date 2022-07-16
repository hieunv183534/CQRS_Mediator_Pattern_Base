using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class View_sp_BaoCaoChuyenThuNoiTinh
    {
        public int MailtripNumber { get; set; }
        public string PackagingBy { get; set; }
        public string PackingTime { get; set; }
        public string ApprovedBy { get; set; }
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
        public string AcceptancePOSCode { get; set; }
        public string ItemTypeCode { get; set; }
        public string ItemCode { get; set; }
        public string BCChapNhan { get; set; }
        public string StartingCode { get; set; }
        public string StartingProvice { get; set; }
        public string DestinationProvice { get; set; }
        public int KT1 { get; set; }
        public int HTHTG { get; set; }
        public int ABC { get; set; }
    }
}
