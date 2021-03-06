﻿using System;
using System.Windows.Forms;

namespace Bayesian_network_ES
{
    /// <summary>
    /// Form with dialog about creating new graph
    /// </summary>
    public partial class FormDialogCreate : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FormDialogCreate()
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