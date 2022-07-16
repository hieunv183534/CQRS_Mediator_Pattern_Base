using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Type { get; set; }
        public string Version { get; set; }
        public string AttackFile { get; set; }
    }
}
