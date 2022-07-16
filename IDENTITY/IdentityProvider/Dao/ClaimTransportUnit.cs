using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class ClaimTransportUnit
    {
        public int ClaimTransportUnitCode { get; set; }
        public string TransportUnitName { get; set; }
        public string Description { get; set; }
        public DateTime? SignedContractDate { get; set; }
        public string SignedPerson { get; set; }
        public DateTime? CanceledContractDate { get; set; }
        public string CanceledPerson { get; set; }
        public bool? Enable { get; set; }
    }
}
