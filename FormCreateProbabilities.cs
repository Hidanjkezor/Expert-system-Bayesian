using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bayesian_network_ES
{
    /// <summary>
    /// Form with input probabilities interface
    /// </summary>
    public partial class FormCreateProbabilities : Form
    {
        /// <summary>
        /// List nodes from main form
        /// </summary>
        BayesianTree listNodes;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="formMain"></param>
        public FormCreateProbabilities(FormMain formMain)
        {
            this.listNodes = formMain.listNodes;

            InitializeComponent();
            InitProbs();
            InitForm();
        }

        /// <summary>
        /// Constructor without initialize probabilities
        /// </summary>
        /// <param name="formMain"></param> 
        public FormCreateProbabilities(FormMain formMain, bool withoutInit)
        {
            this.listNodes = formMain.listNodes;

            InitializeComponent();
            InitForm();
            IsProbabilityEntered();
        }

        /// <summary>
        /// Initialize form with start fields
        /// </summary>
        private void InitForm()
        {
            fillListBoxNodes();
            Node defaultNode = listNodes.Nodes[0]; 
            fillListBoxProbabilities(defaultNode, false);
            fillListBoxParents(defaultNode);

            listBoxNodes.SelectedIndex = 0;
            listBoxProbabilities.SelectedIndex = 0;
            textBoxImputValue.Select();
        }

        /// <summary>
        /// Initialize probabilities with default values
        /// </summary>
        private void InitProbs()
        {
            listNodes.InitProbs();
        }

        /// <summary>
        /// Fill listBoxNodes
        /// </summary>
        private void fillListBoxNodes()
        {
            //Save selected string
            int selectedIndex = listBoxNodes.SelectedIndex;
            listBoxNodes.Items.Clear();

            string sOut = "";
            int countNode = listNodes.Nodes.Count;

            //Print listBoxNodes
            for (int i = 0; i < countNode; i++)
            {
                sOut = (i + 1) + " - " + listNodes.Nodes[i].NameFact + "--->" 
                    + (listNodes.Nodes[i].CheckProbabilities() ? "OK" : "CHECK");
                listBoxNodes.Items.Add(sOut);
            }

            //Turn selected string back
            listBoxNodes.SelectedIndex = selectedIndex;
        }

        /// <summary>
        /// Fill listBoxProbabilities
        /// </summary>
        /// <param name="selectedNode"></param>
        /// <param name="IsChangeProb"></param>
        private void fillListBoxProbabilities(Node selectedNode, bool IsChangeProb)
        {
            //Save selected string
            int selectedIndex = listBoxProbabilities.SelectedIndex;
            listBoxProbabilities.Items.Clear();

            int countProb = selectedNode.Probabilities.Count;
            List<double> selectedProbs = selectedNode.Probabilities;

            if (countProb == 1)
            {
                listBoxProbabilities.Items.Add("P(X) = " 
                    + (selectedProbs[0] != -1 ? selectedProbs[0].ToString() : ""));
            }
            else
            {
                for (int index = 0; index < countProb; index++)
                {
                    listBoxProbabilities.Items.Add("P(X | " + selectedNode.conditionalProb(index) + ")" + " = "
                        + (selectedProbs[index] != -1 ? selectedProbs[index].ToString() : ""));
                }
            }

            if (IsChangeProb)
            {
                //Turn selected string back
                listBoxProbabilities.SelectedIndex = selectedIndex;
            }
            else
            {
                //Turn selected string to first one
                listBoxProbabilities.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Fill listBoxParents
        /// </summary>
        /// <param name="selectedNode"></param>
        private void fillListBoxParents(Node selectedNode)
        {
            listBoxNodeAndParents.Items.Clear();

            List<Node> Parents = listNodes.FindParents(selectedNode);
            int countParents = Parents.Count;

            //Add selected fact to list
            listBoxNodeAndParents.Items.Add((char)('X') + " - " 
                + selectedNode.NameFact + " (Выбранный факт)");
            listBoxNodeAndParents.Items.Add("-----------------------------------------");

            //Add parents
            for (int index = 0; index < countParents; index++)
            {
                listBoxNodeAndParents.Items.Add((char)('a' + index) + " - "
                    + Parents[index].NameFact);
            }
        }

        /// <summary>
        /// Accept button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (listNodes.checkFillingOfProbabilities()) //all probabilities were inputed
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                throw new Exception("Введены не все вероятности");
            }
        }

        /// <summary>
        /// Cancel button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            FormDialogCancel formDialogCancel = new FormDialogCancel();
            if (formDialogCancel.ShowDialog(this) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }

        }

        /// <summary>
        /// Back button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Event of changing index in listBoxNodes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxNodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Node selectedNode = listNodes.Nodes[listBoxNodes.SelectedIndex];
            fillListBoxProbabilities(selectedNode, false);
            fillListBoxParents(selectedNode);
        }

        /// <summary>
        /// Add button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                double ImputValue = Convert.ToDouble(textBoxImputValue.Text);
                if (ImputValue <= 0 || ImputValue >= 1)
                {
                    throw (new Exception("Значение должно быть между нулем и единицей"));
                }
                else
                {
                    int selectedNodeID = listBoxNodes.SelectedIndex;
                    int selectedProbID = listBoxProbabilities.SelectedIndex;
                    Node currectNode = listNodes.FindFact(selectedNodeID);

                    currectNode.SetProbability(selectedProbID, ImputValue);

                    fillListBoxProbabilities(currectNode, true);
                    fillListBoxNodes();
                    IsProbabilityEntered();
                }
                
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, "Ошибка!");
            }
        }

        /// <summary>
        /// Is probability entered
        /// </summary>
        /// <returns></returns>
        private bool IsProbabilityEntered()
        {
            if (listNodes.checkFillingOfProbabilities())
            {
                buttonAccept.Enabled = true;
                return true;
            }
            return false;
        }
    }
}