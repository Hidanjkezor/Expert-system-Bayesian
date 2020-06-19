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
    public partial class FormCreateGraph : Form
    {
        FormMain formMain;
        public BayesianTree listNodes;
        bool isGraphChanged;

        public FormCreateGraph(FormMain formMain)
        {
            this.formMain = formMain;
            this.listNodes = formMain.listNodes;
            this.isGraphChanged = false;

            InitializeComponent();
            RefreshForm();
        }

        private void RefreshForm()
        {
            formMain.createAdjAndIncMatrix(listBoxMatrixAdj, listBoxMatrixInc);
            formMain.fillListBoxNodes(listBoxNodes);
            formMain.fillListBoxEdges(listBoxEdges);
        }

        private void buttonCreateRoot_Click(object sender, EventArgs e)
        {
            List<Node> Children = new List<Node>();
            string newFactName = "";

            FormCreateNode formCreateNode = new FormCreateNode(false, listNodes);
            formCreateNode.FormClosing += (sender1, e1) =>
            {
                newFactName = formCreateNode.newFactName;
                Children = formCreateNode.listChildrenOrRoot;
            };

            if (formCreateNode.ShowDialog(this) == DialogResult.OK)
            {
                isGraphChanged = true;
                listNodes.AddFactRoot(newFactName, Children);
            }

            formCreateNode.Dispose();
            RefreshForm();
        }

        private void buttonCreateLeaf_Click(object sender, EventArgs e)
        {
            List<Node> Parents = new List<Node>();
            string newFactName = "";

            FormCreateNode formCreateNode = new FormCreateNode(true, listNodes);
            formCreateNode.FormClosing += (sender1, e1) =>
            {
                newFactName = formCreateNode.newFactName;
                Parents = formCreateNode.listChildrenOrRoot;
            };

            if (formCreateNode.ShowDialog(this) == DialogResult.OK)
            {
                isGraphChanged = true;
                listNodes.AddFactLeaf(newFactName, Parents);
            }

            formCreateNode.Dispose();
            RefreshForm();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Form dialogCancel = new FormDialogCancel();

            if (dialogCancel.ShowDialog(this) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        private void buttonEndInputNodes_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (true)//isGraphChanged) //Граф изменился
            {
                FormCreateProbabilities formCreateProbabilities = new FormCreateProbabilities(formMain);
                DialogResult formCreateProbabilitiesRESULT = formCreateProbabilities.ShowDialog(this);
                if (formCreateProbabilitiesRESULT == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (formCreateProbabilitiesRESULT == DialogResult.Cancel)
                {
                    this.listNodes.InitProbs();
                    this.Show();
                }
                else if (formCreateProbabilitiesRESULT == DialogResult.Abort)
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
                else
                {
                    formCreateProbabilities.Close(); //!!!!
                }
            }
            else
            {
                this.DialogResult = DialogResult.Abort;
                this.Show();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxNodes.SelectedItem != null)
            {
                Node selectedNode = listNodes.FindFact(((Node)(listBoxNodes.SelectedItem)).NameFact);
                listNodes.Delete(selectedNode);
            }
            else if (listBoxEdges.SelectedItem != null)
            {
                if (listNodes.Delete(listNodes.Edges[listBoxEdges.SelectedIndex]))
                {
                    MessageBox.Show("Неопознанная ошибка удаления!", "Ошибка!");
                }
            }
            else
            {
                MessageBox.Show("Выберите объект удаления", "Ошибка!");
            }
        }
    }
}
