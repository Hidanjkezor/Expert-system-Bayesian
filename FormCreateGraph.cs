using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bayesian_network_ES
{
    /// <summary>
    /// Form with create Bayesian network interface
    /// </summary>
    public partial class FormCreateGraph : Form
    {
        /// <summary>
        /// Instance of FormMain
        /// </summary>
        FormMain formMain;

        /// <summary>
        /// Instance of BayesianTree
        /// </summary>
        public BayesianTree listNodes;

        /// <summary>
        /// Flag with info about changing graph
        /// </summary>
        bool isGraphChanged;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="formMain"></param>
        public FormCreateGraph(FormMain formMain)
        {
            this.formMain = formMain;
            this.listNodes = formMain.listNodes;
            this.isGraphChanged = false;

            InitializeComponent();
            RefreshForm();
        }

        /// <summary>
        /// Initialize refreshing form
        /// </summary>
        private void RefreshForm()
        {
            formMain.createAdjAndIncMatrix(listBoxMatrixAdj, listBoxMatrixInc);
            formMain.fillListBoxNodes(listBoxNodes);
            formMain.fillListBoxEdges(listBoxEdges);
        }

        /// <summary>
        /// CreateRoot button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateRoot_Click(object sender, EventArgs e)
        {
            List<Node> Children = new List<Node>();
            string newFactName = "";

            FormCreateNode formCreateNode = new FormCreateNode(false, listNodes);
            formCreateNode.FormClosing += (sender1, e1) =>
            {
                newFactName = formCreateNode.newFactName;
                Children = formCreateNode.listChildrenOrParents;
            };

            if (formCreateNode.ShowDialog(this) == DialogResult.OK)
            {
                isGraphChanged = true;
                listNodes.AddFactRoot(newFactName, Children);
            }

            formCreateNode.Dispose();
            RefreshForm();
        }

        /// <summary>
        /// CreateLeaf button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateLeaf_Click(object sender, EventArgs e)
        {
            List<Node> Parents = new List<Node>();
            string newFactName = "";

            FormCreateNode formCreateNode = new FormCreateNode(true, listNodes);
            formCreateNode.FormClosing += (sender1, e1) =>
            {
                newFactName = formCreateNode.newFactName;
                Parents = formCreateNode.listChildrenOrParents;
            };

            if (formCreateNode.ShowDialog(this) == DialogResult.OK)
            {
                isGraphChanged = true;
                listNodes.AddFactLeaf(newFactName, Parents);
            }

            formCreateNode.Dispose();
            RefreshForm();
        }

        /// <summary>
        /// Cancel button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Form dialogCancel = new FormDialogCancel();

            if (isGraphChanged)
            {
                if (dialogCancel.ShowDialog(this) == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
            }
            else
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        /// <summary>
        /// EndInputNodes button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEndInputNodes_Click(object sender, EventArgs e)
        {
            if (!isGraphChanged)//Graph was changed
            {
                FormDialogChangeProb formDialogChangeProb = new FormDialogChangeProb();
                DialogResult formDialogChangeProbRESULT = formDialogChangeProb.ShowDialog();
                if (formDialogChangeProbRESULT == DialogResult.No)
                {
                    this.Hide();
                    FormCreateProbabilities formCreateProbabilities = new FormCreateProbabilities(formMain, true);
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
                        throw new Exception("UNEXPECTED DIALOG RESULT");
                    }
                }
                else if (formDialogChangeProbRESULT == DialogResult.Abort)
                {
                    this.Show();
                }
                else if (formDialogChangeProbRESULT == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                this.Hide();
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
                    throw new Exception("UNEXPECTED DIALOG RESULT");
                }
            }
        }

        /// <summary>
        /// Delete button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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