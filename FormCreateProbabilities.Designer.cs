namespace Bayesian_network_ES
{
    partial class FormCreateProbabilities
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
            this.listBoxProbabilities = new System.Windows.Forms.ListBox();
            this.textBoxImputValue = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.listBoxNodes = new System.Windows.Forms.ListBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.listBoxNodeAndParents = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxProbabilities
            // 
            this.listBoxProbabilities.FormattingEnabled = true;
            this.listBoxProbabilities.Location = new System.Drawing.Point(349, 27);
            this.listBoxProbabilities.Name = "listBoxProbabilities";
            this.listBoxProbabilities.Size = new System.Drawing.Size(281, 342);
            this.listBoxProbabilities.TabIndex = 0;
            // 
            // textBoxImputValue
            // 
            this.textBoxImputValue.Location = new System.Drawing.Point(349, 393);
            this.textBoxImputValue.Name = "textBoxImputValue";
            this.textBoxImputValue.Size = new System.Drawing.Size(200, 20);
            this.textBoxImputValue.TabIndex = 1;
            this.textBoxImputValue.Text = "0,";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(555, 391);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Enabled = false;
            this.buttonAccept.Location = new System.Drawing.Point(555, 492);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 3;
            this.buttonAccept.TabStop = false;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(349, 492);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.TabStop = false;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // listBoxNodes
            // 
            this.listBoxNodes.FormattingEnabled = true;
            this.listBoxNodes.Location = new System.Drawing.Point(31, 27);
            this.listBoxNodes.Name = "listBoxNodes";
            this.listBoxNodes.Size = new System.Drawing.Size(281, 342);
            this.listBoxNodes.TabIndex = 5;
            this.listBoxNodes.SelectedIndexChanged += new System.EventHandler(this.listBoxNodes_SelectedIndexChanged);
            // 
            // buttonBack
            // 
            this.buttonBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonBack.Location = new System.Drawing.Point(474, 492);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 6;
            this.buttonBack.TabStop = false;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // listBoxNodeAndParents
            // 
            this.listBoxNodeAndParents.Enabled = false;
            this.listBoxNodeAndParents.FormattingEnabled = true;
            this.listBoxNodeAndParents.Location = new System.Drawing.Point(31, 393);
            this.listBoxNodeAndParents.Name = "listBoxNodeAndParents";
            this.listBoxNodeAndParents.Size = new System.Drawing.Size(281, 121);
            this.listBoxNodeAndParents.TabIndex = 7;
            // 
            // FormCreateProbabilities
            // 
            this.AcceptButton = this.buttonAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonBack;
            this.ClientSize = new System.Drawing.Size(651, 540);
            this.Controls.Add(this.listBoxNodeAndParents);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.listBoxNodes);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxImputValue);
            this.Controls.Add(this.listBoxProbabilities);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormCreateProbabilities";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ввод вероятностей";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxProbabilities;
        private System.Windows.Forms.TextBox textBoxImputValue;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ListBox listBoxNodes;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.ListBox listBoxNodeAndParents;
    }
}