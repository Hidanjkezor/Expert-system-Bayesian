using System;
using System.Windows.Forms;

namespace Bayesian_network_ES
{
    /// <summary>
    /// Form with dialog about canceling changes
    /// </summary>
    public partial class FormDialogCancel : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FormDialogCancel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Accept event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        /// <summary>
        /// Cancel event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
