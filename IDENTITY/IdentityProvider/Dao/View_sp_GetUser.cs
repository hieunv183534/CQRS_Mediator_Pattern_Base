using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class View_sp_GetUser
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string AreaPos { get; set; }
        public string POSCode { get; set; }
        public string CustomerCode { get; set; }
    }
}
