namespace Bayesian_network_ES
{
    /// <summary>
    /// Class edges in Bayesian network
    /// </summary>
    public class Edge
    {
        /// <summary>
        /// ID parent's node
        /// </summary>
        public int ParentID { get ; }

        /// <summary>
        /// ID child's node
        /// </summary>
        public int ChildID { get ; }

        /// <summary>
        /// Create Edge
        /// </summary>
        /// <param name="ParentID"></param>
        /// <param name="ChildID"></param>
        public Edge(int ParentID, int ChildID)
        {
            this.ParentID = ParentID;
            this.ChildID = ChildID;
        }
    }
}