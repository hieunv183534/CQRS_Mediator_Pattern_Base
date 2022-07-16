using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class CN08
    {
        public string CN08Code { get; set; }
        public DateTime? CN08CreateDate { get; set; }
        public byte? CN08ResultCode { get; set; }
        public string CN08OtherResult { get; set; }
        public string CN08Note { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
    }
}
