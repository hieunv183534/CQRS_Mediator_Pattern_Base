using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class MenuParameter
    {
        public string ParameterCode { get; set; }
        public string MenuCode { get; set; }
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }

        public virtual Menu MenuCodeNavigation { get; set; }
    }
}
