namespace NOM.SMSGATEWAY.Domain.Models
{
    public class Sms
    {
        public string MobileNumber { get; set; }

        public string Content { get; set; }

        public string ClientSecrets { get; set; }
    }
}