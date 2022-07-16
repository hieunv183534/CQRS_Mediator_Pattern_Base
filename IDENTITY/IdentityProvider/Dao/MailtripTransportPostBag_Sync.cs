﻿using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class MailtripTransportPostBag_Sync
    {
        public int? PostBagIndex { get; set; }
        public string FromPOSCode { get; set; }
        public string ToPOSCode { get; set; }
        public string MailtripType { get; set; }
        public string ServiceCode { get; set; }
        public string Year { get; set; }
        public string MailTripNumber { get; set; }
        public int? Status { get; set; }
        public int? BC37Index { get; set; }
        public string BC37FromPOSCode { get; set; }
        public string BC37Date { get; set; }
        public string BC37ToPOSCode { get; set; }
        public string TransportTypeCode { get; set; }
        public int? BC37Order { get; set; }
        public string ConfirmUser { get; set; }
        public string ConfirmPOSCode { get; set; }
        public string CreateUser { get; set; }
        public string CreatePOSCode { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public long? PostbagID { get; set; }
        public long? BC37ID { get; set; }
    }
}
