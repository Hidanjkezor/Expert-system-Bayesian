using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bayesian_network_ES
{
    public partial class FormCreateNode : Form
    {
        public List<Node> listChildrenOrRoot;
        BayesianTree fact_Nodes;
        public string newFactName;

        public FormCreateNode(bool LeafOrNot, BayesianTree fact_Nodes)
        {
            InitializeComponent();

            listChildrenOrRoot = new List<Node>();
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

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
                    listChildrenOrRoot.Add(newConnectedFact);
                }
                this.DialogResult = DialogResult.OK;
            }

            this.Close();
        }
    }
}
