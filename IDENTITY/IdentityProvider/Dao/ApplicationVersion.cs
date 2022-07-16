using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ApplicationVersion
    {
        public string ApplicationVersionNumber { get; set; }
        public string RequiredDbVersionNumber { get; set; }
        public bool IsFullVersion { get; set; }
        public DateTime DateApplied { get; set; }
        public string FileName { get; set; }
        public int FileSizeInBytes { get; set; }
        public string VersionChanges { get; set; }
    }
}
