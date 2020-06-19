using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bayesian_network_ES
{
    public class Edge
    {
        public int ParentID { get ; }

        public int ChildID { get ; }

        public Edge(int ParentID, int ChildID)
        {
            this.ParentID = ParentID;
            this.ChildID = ChildID;
        }
    }
}
