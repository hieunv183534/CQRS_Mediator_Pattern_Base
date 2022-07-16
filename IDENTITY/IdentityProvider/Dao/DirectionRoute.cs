using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class DirectionRoute
    {
        public string OnMailRoutePOSCode { get; set; }
        public string ExchangePOSCode { get; set; }
        public string ServiceCode { get; set; }
        public string DestinationCode { get; set; }
    }
}
