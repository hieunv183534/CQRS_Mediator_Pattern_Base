using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class View_Item_ToanTrinh
    {
        public string ItemCode { get; set; }
        public string AcceptancePOSCode { get; set; }
        public DateTime SendingTime { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int Phat { get; set; }
        public int? Gio { get; set; }
        public string Tu { get; set; }
        public string ToiHuyen { get; set; }
        public string ToiTinh { get; set; }
    }
}
