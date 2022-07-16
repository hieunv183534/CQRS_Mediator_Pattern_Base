using System;
using System.Collections.Generic;
using System.Text;

namespace NOM.DomainGlobal.Models
{
    public class ShiftHandoverModel
    {
        public long ShiftHandoverID { get; set; }
        public int HandoverIndex { get; set; }
        public string ShiftCode { get; set; }
        public string POSCode { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime? HandoverTime { get; set; }
        public string GivingUserName { get; set; }
        public string RecevingUserName { get; set; }
        public byte Status { get; set; }
        public string ShiftName { get; set; }
    }
}
