using System;
using System.Collections.Generic;
using System.Linq;

namespace Bayesian_network_ES
{
    /// <summary>
    /// Class with realization of Bayesian network
    /// </summary>
    public class BayesianTree
    {
        int Id;// need to initialize new nodes
        List<Node> _nodes;
        List<Edge> _edges;
        List<Node> _evidences;

        /// <summary>
        /// List nodes of BayesianTree
        /// </summary>
        public List<Node> Nodes { get => _nodes; }

        /// <summary>
        /// List edges of BayesianTree
        /// </summary>
        public List<Edge> Edges { get => _edges; }

        /// <summary>
        /// List evidences which were input
        /// </summary>
        public List<Node> Evidences { get => _evidences; }

        /// <summary>
        /// Create BayesianTree
        /// </summary>
        public BayesianTree()
        {
            _nodes = new List<Node>();
            _edges = new List<Edge>();
            _evidences = new List<Node>();
            Id = 0;
        }

        /// <summary>
        /// Create BayesianTree with nodes and edges
        /// </summary>
        /// <param name="Nodes"></param>
        /// <param name="Edges"></param>
        public BayesianTree(List<Node> Nodes, List<Edge> Edges) 
        {
            _nodes = Nodes;
            _edges = Edges;
            _evidences = new List<Node>();
            Id = Nodes.Count;
        }

        /// <summary>
        /// Copy-constructor
        /// </summary>
        /// <param name="otherListNodes"></param>
        public BayesianTree(BayesianTree otherListNodes)
        {
            this.Id = otherListNodes.Id;
            this._nodes = new List<Node>(otherListNodes._nodes);
            this._edges = new List<Edge>(otherListNodes._edges);
            this._evidences = new List<Node>(otherListNodes._evidences);
        }

        /// <summary>
        /// Add any node
        /// </summary>
        /// <param name="NameFact"></param>
        /// <returns></returns>
        Node AddFact_Node(string NameFact)
        {
            if (_nodes.All(x => x.NameFact != NameFact))
            {
                Node newNode = new Node(NameFact, Id++);
                _nodes.Add(newNode);
                return newNode;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Add edge to edges
        /// </summary>
        /// <param name="newEdge"></param>
        void AddRelation_Edge(Edge newEdge)
        {
            if (_edges.All(x => !x.Equals(newEdge)))
            {
                _edges.Add(newEdge);
            }
            else
            {
                throw new Exception("Эта связь уже задана!");
            }
        }

        /// <summary>
        /// Add new Edge to Edges
        /// </summary>
        /// <param name="ParentID"></param>
        /// <param name="ChildID"></param>
        public void AddEdge(int ParentID, int ChildID)
        {
            AddRelation_Edge(new Edge(ParentID, ChildID));
        }

        /// <summary>
        /// Add new Edge to Edges
        /// </summary>
        /// <param name="Parent"></param>
        /// <param name="child"></param>
        public void AddEdge(Node Parent, Node child)
        {
            AddEdge(Parent.ID, child.ID);
        }

        /// <summary>
        /// Input first node without parents and children
        /// </summary>
        /// <param name="NameFact"></param>
        public void AddFact(string NameFact)
        {
            AddFact_Node(NameFact);
        }

        /// <summary>
        /// Add node with currect parents
        /// </summary>
        /// <param name="NameFact"></param>
        /// <param name="Parents"></param>
        public void AddFactLeaf(string NameFact, List<Node> Parents)
        {
            AddFact(NameFact, Parents, null);
        }

        /// <summary>
        /// Add node with currect children
        /// </summary>
        /// <param name="NameFact"></param>
        /// <param name="Children"></param>
        public void AddFactRoot(string NameFact, List<Node> Children)
        {
            AddFact(NameFact, null, Children);
        }

        /// <summary>
        /// Add any node
        /// </summary>
        /// <param name="NameFact"></param>
        /// <param name="Parents"></param>
        /// <param name="Children"></param>
        private void AddFact(string NameFact, List<Node> Parents,
            List<Node> Children)
        {
            Node newNode;
            if (_nodes.All(x => x.NameFact != NameFact))
            {
                newNode = AddFact_Node(NameFact);
            }
            else
            {
                newNode = _nodes.Find(x => x.NameFact == NameFact);
            }

            if (Parents != null)
            {
                int countParents = Parents.Count();
                for (int i = 0; i < countParents; i++)
                {
                    AddEdge(Parents[i].ID, newNode.ID);
                }
            }
            if (Children != null)
            {
                int countChildren = Children.Count();
                for (int i = 0; i < countChildren; i++)
                {
                    AddEdge(newNode.ID, Children[i].ID);
                }
            }
        }

        /// <summary>
        /// Find fact in Nodes via name
        /// </summary>
        /// <param name="nameFact"></param>
        /// <returns></returns>
        public Node FindFact(string nameFact)
        {
            return _nodes.Find(x => x.NameFact == nameFact);
        }

        /// <summary>
        /// Find fact in Nodes via ID
        /// </summary>
        /// <param name="FactID"></param>
        /// <returns></returns>
        public Node FindFact(int FactID)
        {
            return _nodes.Find(x => x.ID == FactID);
        }

        /// <summary>
        /// Find fact's parents
        /// </summary>
        /// <param name="FactID"></param>
        /// <returns></returns>
        public List<Node> FindParents(int FactID)
        {
            return FindParents(FindFact(FactID));
        }

        /// <summary>
        /// Find fact's parents
        /// </summary>
        /// <param name="fact"></param>
        /// <returns></returns>
        public List<Node> FindParents(Node fact)
        {
            List<Edge> suitableEdges = 
                _edges.FindAll(x => x.ChildID == fact.ID);
            suitableEdges.Sort((x, y) => x.ParentID < y.ParentID ? 0 : 1);

            List<int> ParentsID = new List<int>();
            foreach (var Edge in suitableEdges)
            {
                ParentsID.Add(Edge.ParentID);
            }

            List<Node> Parents = new List<Node>();
            foreach (var Id in ParentsID)
            {
                Parents.Add(_nodes.Find(x => x.ID == Id));
            }

            return Parents;
        }

        /// <summary>
        /// Find fact's children
        /// </summary>
        /// <param name="FactID"></param>
        /// <returns></returns>
        public List<Node> FindChildren(int FactID)
        {
            return FindChildren(FindFact(FactID));
        }

        /// <summary>
        /// Find fact's children
        /// </summary>
        /// <param name="fact"></param>
        /// <returns></returns>
        public List<Node> FindChildren(Node fact)
        {
            List<Edge> suitableEdges =
                _edges.FindAll(x => x.ParentID == fact.ID);
            suitableEdges.Sort((x, y) => x.ChildID < y.ChildID ? 0 : 1);

            List<int> ChildrenID = new List<int>();
            foreach (var Edge in suitableEdges)
            {
                ChildrenID.Add(Edge.ChildID);
            }

            List<Node> Children = new List<Node>();
            foreach (var Id in ChildrenID)
            {
                Children.Add(_nodes.Find(x => x.ID == Id));
            }

            return Children;
        }

        /// <summary>
        /// Create adjacency matrix
        /// </summary>
        /// <returns></returns>
        public int[,] fillAdjacencyMatrix()
        {
            int countNode = Nodes.Count();
            int[,] matrix = new int[countNode, countNode];
            for (int i = 0; i < countNode; i++)
                for (int j = 0; j < countNode; j++)
                    matrix[i, j] = 0;
            int countEdges = Edges.Count;
            for (int i = 0; i < countEdges; i++)
            {
                matrix[Edges[i].ChildID, Edges[i].ParentID] = 1;
                matrix[Edges[i].ParentID, Edges[i].ChildID] = 1;
            }
            return matrix;
        }

        /// <summary>
        /// Create incidence matrix
        /// </summary>
        /// <returns></returns>
        public int[,] fillIncidenceMatrix()
        {
            int countNodes = Nodes.Count;
            int countEdges = Edges.Count;
            int[,] matrix = new int[countNodes, countEdges];

            for (int i = 0; i < countNodes; i++)
            {
                for (int j = 0; j < countEdges; j++)
                {
                    matrix[i, j] = 0;
                }
            }

            for (int i = 0; i < countEdges; i++)
            {
                matrix[Edges[i].ParentID, i] = 1;
                matrix[Edges[i].ChildID, i] = 1;
            }

            return matrix;
        }

        /// <summary>
        /// Is all probabilities filled
        /// </summary>
        /// <returns></returns>
        public bool checkFillingOfProbabilities()
        {
            int countID = Id;
            bool res = true;

            for (int ID = 0; ID < countID; ID++)
            {
                res &= checkFillingProbability(ID);
            }
            return res;
        }

        /// <summary>
        /// Is probability filled
        /// </summary>
        /// <param name="FactID"></param>
        /// <returns></returns>
        public bool checkFillingProbability(int FactID)
        {
            Node currectFact = FindFact(FactID);
            return checkFillingProbability(currectFact);
        }

        /// <summary>
        /// Is probability filled
        /// </summary>
        /// <param name="currectFact"></param>
        /// <returns></returns>
        public bool checkFillingProbability(Node currectFact)
        {
            int countParents = FindParents(currectFact).Count;
            if (currectFact.Probabilities.Count == Math.Pow(2, countParents))
            {
                return currectFact.CheckProbabilities();
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Fill the dictinary of probability of currect fact
        /// </summary>
        public bool createСonditionalProbability(int FactID, List<double> Probs)
        {
            List<Node> Parents = FindParents(FactID);
            int countParents = Parents.Count;
            int countProbs = (int)Math.Pow(2, countParents);
            Node currectFact = FindFact(FactID);

            if (Probs.Count == countProbs)
            {
                currectFact.InitProbabilities(countParents);
                currectFact.SetProbability(Probs);

                return checkFillingProbability(currectFact);
            }

            return false;
        }

        /// <summary>
        /// Initialize each probability in Nodes
        /// </summary>
        public void InitProbs()
        {
            foreach (var fact in Nodes)
            {
                int countParents = FindParents(fact).Count;
                fact.InitProbabilities(countParents);
            }
        }

        /// <summary>
        /// Remove node from Nodes
        /// </summary>
        /// <param name="Node"></param>
        public void Delete(Node Node)
        {
            bool resultOfDeleteEdges = true;
            if (FindFact(Node.ID) != null)
            {
                List<Node> parents = FindParents(Node);
                List<Node> children = FindChildren(Node);

                //Remove all commits with Node
                _edges.RemoveAll(x => x.ChildID == Node.ID);
                _edges.RemoveAll(x => x.ParentID == Node.ID);
                
                //Remove Node
                _nodes.Remove(Node);

                //Commiting parents with children
                int countChildren = children.Count;
                for (int i = 0; i < countChildren; i++)
                {
                    foreach (var parent in parents)
                    {
                        AddEdge(parent, children[i]);
                    }
                }

                ////Rechange IDs
                //foreach (var item in collection)
                //{

                //}
            }
            else if (resultOfDeleteEdges)
            {
                //Бросить исключение
            }
            else
            {
                //Бросить исключение
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Edges"></param>
        /// <returns></returns>
        public bool Delete(List<Edge> Edges)
        {
            foreach (var Edge in Edges)
            {
                return Delete(Edge);
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Edge"></param>
        /// <returns></returns>
        public bool Delete(Edge Edge)
        {
            return _edges.Remove(Edge);
        }

        /// <summary>
        /// Remove evidence from evidences
        /// </summary>
        /// <param name="Evidence"></param>
        public void DeleteEvidence(Node Evidence)
        {
            if (!_evidences.Remove(Evidence) && !Nodes.Contains(Evidence))
            {
                throw new Exception("Событие не найдено!");
            }
        }

        /// <summary>
        /// Add new evidence to evidences
        /// </summary>
        /// <param name="Evidence"></param>
        public void AddEvidence(Node Evidence)
        {
            if (!_evidences.Contains(Evidence) && Nodes.Contains(Evidence))
            {
                _evidences.Add(Evidence);
            }
            else if (!_evidences.Contains(Evidence))
            {
                throw new Exception("Событие уже является свидетельством");
            }
            else if (Nodes.Contains(Evidence))
            {
                throw new Exception("Событие не найдено!");
            }
        }

        /// <summary>
        /// Clear list of evidences
        /// </summary>
        public void ClearEvidences()
        {
            _evidences.Clear();
        }

        /// <summary>
        /// Is evidences contains evidence
        /// </summary>
        /// <param name="Fact"></param>
        /// <returns></returns>
        public bool IsInEvidence(Node Fact)
        {
            return _evidences.Contains(Fact);
        }

        /// <summary>
        /// Is evidences contains evidence
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool IsInEvidence(int ID)
        {
            return IsInEvidence(FindFact(ID));
        }

        /// <summary>
        /// Normalize probability distribution
        /// </summary>
        /// <param name="Prob"></param>
        /// <returns></returns>
        public List<double> Normalization(List<double> Prob)
        {
            int countProb = Prob.Count;
            List<double> res = new List<double>(countProb);
            double normKoef = 0;

            for (int i = 0; i < countProb; i++)
            {
                normKoef += Prob[i];
            }
            for (int i = 0; i < countProb; i++)
            {
                res.Add(Prob[i] / normKoef);
            }

            return res;
        }
        
        /// <summary>
        /// Find E+ set
        /// </summary>
        /// <param name="Fact"></param>
        /// <param name="WithoutFacts"></param>
        /// <returns></returns>
        public List<Node> FindCommitedEvidencesWith(Node Fact, List<Node> WithoutFacts)
        {
            List<Node> result = new List<Node>();

            if (IsInEvidence(Fact))
            {
                result.Add(Fact);
                return result;
            }
            else
            {
                FindCommitedHelper(Fact, WithoutFacts, ref result);

                return result;
            }
        }

        /// <summary>
        /// Help func of FindCommitedEvidencesWith
        /// </summary>
        /// <param name="Fact"></param>
        /// <param name="WithoutFacts"></param>
        /// <param name="result"></param>
        private void FindCommitedHelper(Node Fact, List<Node> WithoutFacts, ref List<Node> result)
        {
            List<Node> parents = FindParents(Fact);
            foreach (Node parent in parents)
            {
                if (IsInEvidence(parent))
                {
                    result.Add(parent);
                }
                else if (!WithoutFacts.Contains(parent))
                {
                    FindCommitedHelper(parent, WithoutFacts, ref result);
                }
            }
        }

        /// <summary>
        /// Find E- set
        /// </summary>
        /// <param name="Fact"></param>
        /// <param name="WithoutFacts"></param>
        /// <returns></returns>
        public List<Node> FindBottomCommitedEvidencesWith(Node Fact, List<Node> WithoutFacts)
        {
            List<Node> result = new List<Node>();

            if (IsInEvidence(Fact))
            {
                result.Add(Fact);
                return result;
            }
            else
            {
                FindBottomCommitedHelper(Fact, WithoutFacts, ref result);

                return result;
            }
        }

        /// <summary>
        /// Help func of FindBottomCommitedEvidencesWith
        /// </summary>
        /// <param name="Fact"></param>
        /// <param name="WithoutFacts"></param>
        /// <param name="result"></param>
        private void FindBottomCommitedHelper(Node Fact, List<Node> WithoutFacts, ref List<Node> result)
        {
            List<Node> children = FindChildren(Fact);
            foreach (Node child in children)
            {
                if (IsInEvidence(child))
                {
                    result.Add(child);
                }
                else if (!WithoutFacts.Contains(child))
                {
                    FindCommitedHelper(child, WithoutFacts, ref result);
                }
            }
        }

        /// <summary>
        /// Find posterior probability
        /// </summary>
        /// <param name="Fact"></param>
        /// <returns></returns>
        public double Belief(Node Fact)
        {
            if (Evidences.Count > 0)
            {
                if (IsInEvidence(Fact))
                {
                    return 1;
                }

                List<Node> V = new List<Node>();
                return BeliefExcept(Fact, V);
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Belief of fact
        /// </summary>
        /// <param name="Fact"></param>
        /// <param name="V"></param>
        /// <returns></returns>
        private double BeliefExcept(Node Fact, List<Node> V)
        {
            if (IsInEvidence(Fact))
            {
                return 1;
            }

            double BottomProb = EvidenceExcept(Fact, V);
            List<Node> parents = FindParents(Fact);

            if (parents.Count == 0)
            {
                List<double> temp = new List<double>();
                temp.Add(BottomProb);
                temp.Add(Fact.Probabilities[0]);
                temp = Normalization(temp);

                return temp[0] * temp[1];
            }
            else
            {
                List<double> parentsIfEvidence = new List<double>();
                foreach (var parent in parents)
                {
                    List<Node> newV = new List<Node>();
                    newV.Add(Fact);
                    parentsIfEvidence.Add(BeliefExcept(parent, newV));
                }

                double secondSum = 0;
                foreach (var prob in Fact.Probabilities)
                {
                    secondSum += prob;
                }

                double thirdProd = 1;
                foreach (var prob in parentsIfEvidence)
                {
                    thirdProd *= prob;
                }

                List<double> temp = new List<double>();
                temp.Add(BottomProb);
                temp.Add(secondSum);
                temp.Add(thirdProd);
                temp = Normalization(temp);
                return temp[0] * temp[1] * temp[2];
            }
        }

        /// <summary>
        /// Except evidence
        /// </summary>
        /// <param name="Fact"></param>
        /// <param name="V"></param>
        /// <returns></returns>
        private double EvidenceExcept(Node Fact, List<Node> V)
        {
            List<Node> children = FindChildren(Fact);
            if (V != null)
            {
                foreach (var currectFact in V)
                {
                    children.Remove(currectFact);
                }
            }


            if (children.Count == 0)
            {
                Random r = new Random();
                return r.NextDouble();
            }
            else
            {
                double probOfEvidenceBottom = 0;
                double probOfEvidenceMiddle = 0;
                double probOfEvidenceTop = 1;
                foreach (var child in children)
                {
                    probOfEvidenceBottom += EvidenceExcept(child, null);
                    List<Node> parents = FindParents(child);
                    parents.Remove(Fact);

                    foreach (var parent in parents)
                    {
                        List<Node> newV = new List<Node>();
                        newV.Add(child);
                        probOfEvidenceTop *= BeliefExcept(parent, newV);

                    }
                    Random r = new Random();
                    probOfEvidenceTop = r.NextDouble();

                    probOfEvidenceMiddle += child.Probabilities.Sum();
                }

                List<double> temp = new List<double>();
                temp.Add(probOfEvidenceBottom);
                temp.Add(probOfEvidenceMiddle);
                temp.Add(probOfEvidenceTop);
                temp = Normalization(temp);
                return temp[0] * temp[1] * temp[2];
            }
        }
    }
}
