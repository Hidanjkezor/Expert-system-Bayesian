using System;
using System.Windows.Forms;

namespace Bayesian_network_ES
{
    /// <summary>
    /// Form with dialog about changing probabilities
    /// </summary>
    public partial class FormDialogChangeProb : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FormDialogChangeProb()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Accept button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        /// <summary>
        /// Cancel button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        /// <summary>
        /// Abort button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAbort_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
    }
}