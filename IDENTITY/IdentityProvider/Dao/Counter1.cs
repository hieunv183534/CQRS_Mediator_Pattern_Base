using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Counter1
    {
        public string Key { get; set; }
        public int Value { get; set; }
        public DateTime? ExpireAt { get; set; }
    }
}
