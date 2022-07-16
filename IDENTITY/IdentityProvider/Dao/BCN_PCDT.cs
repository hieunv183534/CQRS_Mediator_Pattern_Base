using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class BCN_PCDT
    {
        public string BieuMau { get; set; }
        public int? CongDoan { get; set; }
        public int? Vung { get; set; }
        public string DichVu { get; set; }
        public string DichVuCongThem { get; set; }
        public string GiaTri { get; set; }
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }
    }
}
