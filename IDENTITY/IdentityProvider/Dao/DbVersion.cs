using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DbVersion
    {
        public string DbVersionNumber { get; set; }
        public string ScriptName { get; set; }
        public DateTime DateApplied { get; set; }
        public string DbChanges { get; set; }
    }
}
