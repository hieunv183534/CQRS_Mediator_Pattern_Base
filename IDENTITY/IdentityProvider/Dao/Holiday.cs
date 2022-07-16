using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Holiday
    {
        public int HolidayCode { get; set; }
        public string HolidayName { get; set; }
        public DateTime HolidayDate { get; set; }
        public string Reason { get; set; }
        public string Note { get; set; }
        public string HolidayDateText { get; set; }
        public string HolidayYear { get; set; }
    }
}
