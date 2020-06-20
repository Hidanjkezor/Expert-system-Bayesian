using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bayesian_network_ES
{
    /// <summary>
    /// Form with create node interface
    /// </summary>
    public partial class FormCreateNode : Form
    {
        /// <summary>
        /// List with childrens or parents
        /// </summary>
        public List<Node> listChildrenOrParents;

        /// <summary>
        /// Instance of BayesianTree
        /// </summary>
        BayesianTree fact_Nodes;

        /// <summary>
        /// Name of new node
        /// </summary>
        public string newFactName;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="LeafOrNot"></param>
        /// <param name="fact_Nodes"></param>
        public FormCreateNode(bool LeafOrNot, BayesianTree fact_Nodes)
        {
            InitializeComponent();

            listChildrenOrParents = new List<Node>();
            this.fact_Nodes = fact_Nodes;
            if (LeafOrNot)
            {
                labelLeafOrRoot.Text = "Родители";
            }
            else
            {
                labelLeafOrRoot.Text = "Дети";
            }

            foreach (var fact in fact_Nodes.Nodes)
            {
                checkedListBoxConnectedNodes.Items.Add(fact.NameFact);
            }
        }

        /// <summary>
        /// Cancel button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Accept button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            newFactName = textBoxNameNode.Text;

            if (newFactName == "")
            {
                //Диалоговое окно - введите имя
                this.DialogResult = DialogResult.Cancel;
            }
            else if(fact_Nodes.FindFact(newFactName) != null)
            {
                //Диалоговое окно - введите другое имя
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                foreach (var connectedNodes in checkedListBoxConnectedNodes.CheckedItems)
                {
                    Node newConnectedFact = fact_Nodes.FindFact(connectedNodes.ToString());
                    listChildrenOrParents.Add(newConnectedFact);
                }
                this.DialogResult = DialogResult.OK;
            }

            this.Close();
        }
    }
}