using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bayesian_network_ES
{
    /// <summary>
    /// Start form with user interface
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// Exemplar of Bayesian network
        /// </summary>
        public BayesianTree listNodes;

        /// <summary>
        /// Exemplar of adjacency matrix
        /// </summary>
        int[,] matrixAdj;

        /// <summary>
        /// Exemplar of incidents matrix
        /// </summary>
        int[,] matrixInc;

        /// <summary>
        /// Form constructor
        /// </summary>
        public FormMain()
        {
            listNodes = new BayesianTree();
            InitializeComponent();
            TestListNodes();
        }

        /// <summary>
        /// Create test Bayesian network
        /// </summary>
        void TestListNodes()
        {
            List<Node> Parents = new List<Node>();
            List<Node> Children = new List<Node>();

            listNodes.AddFact("Пациент пожилого возраста");

            listNodes.AddFact("Пациент перенес операцию");

            Parents.Add(listNodes.FindFact("Пациент перенес операцию"));
            listNodes.AddFact("Патология аккомодации");
            listNodes.AddFactLeaf("Патология аккомодации", Parents);
            Parents.Clear();

            Parents.Add(listNodes.FindFact("Пациент пожилого возраста"));
            listNodes.AddFactLeaf("Помутнение хрусталика", Parents);
            Parents.Clear();

            Parents.Add(listNodes.FindFact("Патология аккомодации"));
            listNodes.AddFactLeaf("Развитие косоглазия", Parents);
            Parents.Clear();

            Parents.Add(listNodes.FindFact("Патология аккомодации"));
            Parents.Add(listNodes.FindFact("Помутнение хрусталика"));
            listNodes.AddFactLeaf("Синдром ухудшения зрения", Parents);
            Parents.Clear();

            Parents.Add(listNodes.FindFact("Синдром ухудшения зрения"));
            listNodes.AddFactLeaf("Повышенное давление", Parents);
            Parents.Clear();

            Parents.Add(listNodes.FindFact("Помутнение хрусталика"));
            listNodes.AddFactLeaf("Патологический рефлекс сетчатки", Parents);
            Parents.Clear();
            RefreshForm();

            //-------------------------------------Create test network
            listNodes.InitProbs();

            listNodes.Nodes[0].SetProbability(0, 0.01);

            listNodes.Nodes[1].SetProbability(0, 0.2);

            listNodes.Nodes[2].SetProbability(0, 0.16);
            listNodes.Nodes[2].SetProbability(1, 0.05);

            listNodes.Nodes[3].SetProbability(0, 0.1);
            listNodes.Nodes[3].SetProbability(1, 0.001);

            listNodes.Nodes[4].SetProbability(0, 0.2);
            listNodes.Nodes[4].SetProbability(1, 0.025);

            listNodes.Nodes[5].SetProbability(0, 0.95);
            //listNodes.Nodes[5].SetProbability(1, 0.04);
            listNodes.Nodes[5].SetProbability(1, 0.25);
            listNodes.Nodes[5].SetProbability(2, 0.9);
            listNodes.Nodes[5].SetProbability(3, 0.02);

            listNodes.Nodes[6].SetProbability(0, 0.4);
            listNodes.Nodes[6].SetProbability(1, 0.001);

            listNodes.Nodes[7].SetProbability(0, 0.99);
            listNodes.Nodes[7].SetProbability(1, 0.001);
        }

        /// <summary>
        /// Create and print MatrixAdj and MatrixInc
        /// </summary>
        /// <param name="listBoxMatrixAdj">ListBox which would be filled by adjacency matrix</param>
        /// <param name="listBoxMatrixInc">ListBox which would be filled by incidents matrix</param>
        public void createAdjAndIncMatrix(ListBox listBoxMatrixAdj, ListBox listBoxMatrixInc)
        {
            matrixAdj = listNodes.fillAdjacencyMatrix();
            matrixInc = listNodes.fillIncidenceMatrix();
            listBoxMatrixAdj.Items.Clear();
            listBoxMatrixInc.Items.Clear();
            string sOut = new string(' ',7);
            int countNode = listNodes.Nodes.Count;
            int countEdge = listNodes.Edges.Count;

            //Print of AdjMatrix
            for (int i = 0; i < countNode; i++)
                sOut += string.Format("{0,3}", i + 1);
            listBoxMatrixAdj.Items.Add(sOut);
            for (int i = 0; i < countNode; i++)
            {
                sOut = string.Format("{0,2} |  ", i + 1);
                for (int j = 0; j < countNode; j++)
                    sOut += string.Format("{0,3}", matrixAdj[i, j]);

                listBoxMatrixAdj.Items.Add(sOut);
            }

            //Print of IncMatrix
            if (listNodes.Edges.Count > 0)
            {
                sOut = "     ";
                for (int i = 0; i < countEdge; i++)
                    sOut += (char)('a' + i) + "  ";
                listBoxMatrixInc.Items.Add(sOut);
                for (int i = 0; i < countNode; i++)
                {
                    sOut = (i + 1) + " | ";
                    for (int j = 0; j < countEdge; j++)
                        sOut += matrixInc[i, j] + "  ";
                    listBoxMatrixInc.Items.Add(sOut);
                }
            }
        }

        /// <summary>
        /// Print list of nodes
        /// </summary>
        /// <param name="listBoxNodes">ListBox which would be filled</param>
        public void fillListBoxNodes(ListBox listBoxNodes)
        {
            listBoxNodes.Items.Clear();

            string sOut = "";
            int countNode = listNodes.Nodes.Count;

            //Print listBoxNodes
            for (int i = 0; i < countNode; i++)
            {
                sOut = (i + 1) + " - " + listNodes.Nodes[i].NameFact;
                listBoxNodes.Items.Add(sOut);
            }
        }

        /// <summary>
        /// Print on list edges
        /// </summary>
        /// <param name="listBoxEdges">ListBox which would be filled</param>
        public void fillListBoxEdges(ListBox listBoxEdges)
        {
            listBoxEdges.Items.Clear();

            string sOut;
            int countEdge = listNodes.Edges.Count;

            //Print listBoxEdges
            for (int i = 0; i < countEdge; i++)
            {
                sOut = "";
                string parent = listNodes.FindFact(listNodes.Edges[i].ParentID).NameFact;
                string child = listNodes.FindFact(listNodes.Edges[i].ChildID).NameFact;
                sOut += (char)('a' + i) + " - " + parent + " -> " + child;
                listBoxEdges.Items.Add(sOut);
            }
        }

        /// <summary>
        /// Print on checkedList evidences
        /// </summary>
        /// <param name="checkedListBoxEvidences">ListBox which would be filled</param>
        public void fillListBoxEvidences(CheckedListBox checkedListBoxEvidences)
        {
            checkedListBoxEvidences.Items.Clear();

            foreach (var fact in listNodes.Nodes)
            {
                checkedListBoxEvidences.Items.Add(fact.NameFact);
            }
        }

        /// <summary>
        /// Refill all listboxes
        /// </summary>
        private void RefreshForm()
        {
            createAdjAndIncMatrix(listBoxMatrixAdj, listBoxMatrixInc);
            fillListBoxNodes(listBoxNodes);
            fillListBoxEdges(listBoxEdges);
            fillListBoxEvidences(checkedListBoxEvidences);
        }

        /// <summary>
        /// buttonChangeGraph click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChangeGraph_Click(object sender, EventArgs e)
        {
            changeOrCreateGraphResult();
        }

        /// <summary>
        /// buttonCreateGraph click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateGraph_Click(object sender, EventArgs e)
        {
            FormDialogCreate dialogCreate = new FormDialogCreate();
            if (dialogCreate.ShowDialog(this) == DialogResult.Yes)
            {
                listNodes = new BayesianTree();

                changeOrCreateGraphResult();
            }
        }

        /// <summary>
        /// Perform execute to create or change graph
        /// </summary>
        private void changeOrCreateGraphResult()
        {
            Form formCreateGraph = new FormCreateGraph(this);
            BayesianTree backupListNodes = new BayesianTree(listNodes);

            this.Hide();
            if (formCreateGraph.ShowDialog() == DialogResult.Abort)
            {
                listNodes = backupListNodes;
            }
            RefreshForm();
            this.Show();
        }

        /// <summary>
        /// Execute posterior probability
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExecute_Click(object sender, EventArgs e)
        {
            listNodes.ClearEvidences();
            foreach (var evidence in checkedListBoxEvidences.CheckedItems)
            {
                listNodes.AddEvidence(listNodes.FindFact(evidence.ToString()));
            }

            listBoxResults.Items.Clear();
            List<double> temp = new List<double>();
            foreach (var fact in listNodes.Nodes)
            {
                temp.Add(listNodes.Belief(fact));
            }

            for (int i = 0; i < temp.Count; i++)
            {
                listBoxResults.Items.Add((i+1).ToString() + ": " + temp[i].ToString()); 
            }
        }
    }
}
