using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Receptacles_OETemp
    {
        public int? ID { get; set; }
        public int? OE_ID { get; set; }
        public int? MAIL_ID { get; set; }
        public int? MAIL_CODE { get; set; }
        public int SERIAL_NUMBER { get; set; }
        public bool HIGHEST_NUMBER { get; set; }
        public int REGISTERED_INSURED { get; set; }
        public double? COVER_WEIGHT { get; set; }
        public int? Weight { get; set; }
        public int TYPE { get; set; }
        public int? MEDIUM { get; set; }
        public int UserID { get; set; }
        public int TotalNormal { get; set; }
        public int WeightNormal { get; set; }
        public int? Exempt { get; set; }
        public int? TotalEmpty { get; set; }
        public int? InBag { get; set; }
        public int FreeWeight { get; set; }
        public int? InBagNumber { get; set; }
        public int? DateCreate { get; set; }
        public int? EndWorkingID { get; set; }
        public int R_Weight { get; set; }
        public int RealWeight { get; set; }
        public string Origin_Impc { get; set; }
        public string Destination_Impc { get; set; }
        public string Mail_Number { get; set; }
        public int? Empty_Weight { get; set; }
        public int? BCCI_Weight { get; set; }
        public int? Total_InBag { get; set; }
        public string ServiceCode { get; set; }
        public string MailTripType { get; set; }
        public string Year { get; set; }
        public string MAIL_SUB_CLASS_CODE { get; set; }
        public int TransportTypeId { get; set; }
        public DateTime? DATE_DEPARTURE { get; set; }
    }
}
