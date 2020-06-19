namespace Bayesian_network_ES
{
    partial class FormCreateNode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxNameNode = new System.Windows.Forms.TextBox();
            this.labelNameNode = new System.Windows.Forms.Label();
            this.labelLeafOrRoot = new System.Windows.Forms.Label();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkedListBoxConnectedNodes = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // textBoxNameNode
            // 
            this.textBoxNameNode.Location = new System.Drawing.Point(12, 83);
            this.textBoxNameNode.Name = "textBoxNameNode";
            this.textBoxNameNode.Size = new System.Drawing.Size(147, 20);
            this.textBoxNameNode.TabIndex = 0;
            // 
            // labelNameNode
            // 
            this.labelNameNode.AutoSize = true;
            this.labelNameNode.Location = new System.Drawing.Point(45, 67);
            this.labelNameNode.Name = "labelNameNode";
            this.labelNameNode.Size = new System.Drawing.Size(78, 13);
            this.labelNameNode.TabIndex = 1;
            this.labelNameNode.Text = "Имя вершины";
            // 
            // labelLeafOrRoot
            // 
            this.labelLeafOrRoot.AutoSize = true;
            this.labelLeafOrRoot.Location = new System.Drawing.Point(250, 32);
            this.labelLeafOrRoot.Name = "labelLeafOrRoot";
            this.labelLeafOrRoot.Size = new System.Drawing.Size(35, 13);
            this.labelLeafOrRoot.TabIndex = 4;
            this.labelLeafOrRoot.Text = "label1";
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(429, 83);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 5;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(429, 119);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkedListBoxConnectedNodes
            // 
            this.checkedListBoxConnectedNodes.FormattingEnabled = true;
            this.checkedListBoxConnectedNodes.Location = new System.Drawing.Point(184, 48);
            this.checkedListBoxConnectedNodes.Name = "checkedListBoxConnectedNodes";
            this.checkedListBoxConnectedNodes.Size = new System.Drawing.Size(225, 94);
            this.checkedListBoxConnectedNodes.TabIndex = 7;
            // 
            // FormCreateNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 174);
            this.Controls.Add(this.checkedListBoxConnectedNodes);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.labelLeafOrRoot);
            this.Controls.Add(this.labelNameNode);
            this.Controls.Add(this.textBoxNameNode);
            this.Name = "FormCreateNode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCreateNode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNameNode;
        private System.Windows.Forms.Label labelNameNode;
        private System.Windows.Forms.Label labelLeafOrRoot;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckedListBox checkedListBoxConnectedNodes;
    }
}