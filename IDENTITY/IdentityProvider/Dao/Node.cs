using System;
using System.Collections.Generic;

namespace IdentityProvider.Dao
{
    public partial class Node
    {
        public Node()
        {
            NodeToNodeFromNodeNameNavigation = new HashSet<NodeToNode>();
            NodeToNodeToNodeNameNavigation = new HashSet<NodeToNode>();
        }

        public string NodeName { get; set; }
        public string IPAddress { get; set; }
        public string HttpAddress { get; set; }
        public string HttpsAddress { get; set; }
        public string NetTcpAddress { get; set; }
        public string MsmqAddress { get; set; }
        public string QueueName { get; set; }
        public string DnsIdentity { get; set; }

        public virtual ICollection<NodeToNode> NodeToNodeFromNodeNameNavigation { get; set; }
        public virtual ICollection<NodeToNode> NodeToNodeToNodeNameNavigation { get; set; }
    }
}
