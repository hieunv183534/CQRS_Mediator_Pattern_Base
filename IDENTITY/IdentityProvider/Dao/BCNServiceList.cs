using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class BCNServiceList
    {
        public int ID { get; set; }
        public string CurrentIndex { get; set; }
        public string ServiceName { get; set; }
        public string LevelValue { get; set; }
        public string ServiceCode { get; set; }
        public string ValueAddedServiceCode { get; set; }
        public string ItemTypeCode { get; set; }
        public string ValueAddedServiceCodeRef { get; set; }
        public int? ColOrder { get; set; }
        public string LevelValueName { get; set; }
        public string ServiceCodeName { get; set; }
        public int? ListType { get; set; }
        public string ServiceNameCombobox { get; set; }
        public string CurrentIndexOrder { get; set; }
        public string CurrentIndexSort { get; set; }
        public int? FatherID { get; set; }
    }
}
