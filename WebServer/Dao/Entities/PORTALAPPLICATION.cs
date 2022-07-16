using System;
using System.Collections.Generic;

namespace NOM.Dao.Entities
{
    public partial class PortalApplication
    {
        public string ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public bool Actived { get; set; }
    }
}
