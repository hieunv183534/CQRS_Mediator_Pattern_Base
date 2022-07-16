using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class MessageTypeTable
    {
        public MessageTypeTable()
        {
            GetDependOn = new HashSet<GetDependOn>();
            GetParameter = new HashSet<GetParameter>();
            StoreDependOn = new HashSet<StoreDependOn>();
        }

        public string MessageTypeName { get; set; }
        public string TableName { get; set; }
        public int GetOrder { get; set; }
        public int GetTypeId { get; set; }
        public string GetSql { get; set; }
        public int StoreOrder { get; set; }
        public int StoreTypeId { get; set; }
        public int StoreBehaviorId { get; set; }
        public string ClientUpdateSql { get; set; }
        public bool DeleteAfterSent { get; set; }
        public bool DeleteRedundantData { get; set; }
        public string DeleteSql { get; set; }

        public virtual GetType GetType { get; set; }
        public virtual MessageType MessageTypeNameNavigation { get; set; }
        public virtual StoreBehavior StoreBehavior { get; set; }
        public virtual StoreType StoreType { get; set; }
        public virtual Table TableNameNavigation { get; set; }
        public virtual ICollection<GetDependOn> GetDependOn { get; set; }
        public virtual ICollection<GetParameter> GetParameter { get; set; }
        public virtual ICollection<StoreDependOn> StoreDependOn { get; set; }
    }
}
