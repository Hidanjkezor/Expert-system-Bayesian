namespace Bayesian_network_ES
{
    partial class FormCreateGraph
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
            this.buttonCreateLeaf = new System.Windows.Forms.Button();
            this.buttonCreateRoot = new System.Windows.Forms.Button();
            this.listBoxMatrixAdj = new System.Windows.Forms.ListBox();
            this.listBoxMatrixInc = new System.Windows.Forms.ListBox();
            this.listBoxNodes = new System.Windows.Forms.ListBox();
            this.listBoxEdges = new System.Windows.Forms.ListBox();
            this.buttonEndInputNodes = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCreateLeaf
            // 
            this.buttonCreateLeaf.Location = new System.Drawing.Point(825, 129);
            this.buttonCreateLeaf.Name = "buttonCreateLeaf";
            this.buttonCreateLeaf.Size = new System.Drawing.Size(124, 23);
            this.buttonCreateLeaf.TabIndex = 0;
            this.buttonCreateLeaf.Text = "Добавить ребенка";
            this.buttonCreateLeaf.UseVisualStyleBackColor = true;
            this.buttonCreateLeaf.Click += new System.EventHandler(this.buttonCreateLeaf_Click);
            // 
            // buttonCreateRoot
            // 
            this.buttonCreateRoot.Location = new System.Drawing.Point(825, 71);
            this.buttonCreateRoot.Name = "buttonCreateRoot";
            this.buttonCreateRoot.Size = new System.Drawing.Size(124, 23);
            this.buttonCreateRoot.TabIndex = 1;
            this.buttonCreateRoot.Text = "Добавить родителя";
            this.buttonCreateRoot.UseVisualStyleBackColor = true;
            this.buttonCreateRoot.Click += new System.EventHandler(this.buttonCreateRoot_Click);
            // 
            // listBoxMatrixAdj
            // 
            this.listBoxMatrixAdj.FormattingEnabled = true;
            this.listBoxMatrixAdj.Location = new System.Drawing.Point(39, 30);
            this.listBoxMatrixAdj.Name = "listBoxMatrixAdj";
            this.listBoxMatrixAdj.Size = new System.Drawing.Size(180, 173);
            this.listBoxMatrixAdj.TabIndex = 2;
            // 
            // listBoxMatrixInc
            // 
            this.listBoxMatrixInc.FormattingEnabled = true;
            this.listBoxMatrixInc.Location = new System.Drawing.Point(39, 227);
            this.listBoxMatrixInc.Name = "listBoxMatrixInc";
            this.listBoxMatrixInc.Size = new System.Drawing.Size(180, 173);
            this.listBoxMatrixInc.TabIndex = 3;
            // 
            // listBoxNodes
            // 
            this.listBoxNodes.FormattingEnabled = true;
            this.listBoxNodes.Location = new System.Drawing.Point(292, 30);
            this.listBoxNodes.Name = "listBoxNodes";
            this.listBoxNodes.Size = new System.Drawing.Size(354, 173);
            this.listBoxNodes.TabIndex = 4;
            // 
            // listBoxEdges
            // 
            this.listBoxEdges.FormattingEnabled = true;
            this.listBoxEdges.Location = new System.Drawing.Point(292, 227);
            this.listBoxEdges.Name = "listBoxEdges";
            this.listBoxEdges.Size = new System.Drawing.Size(354, 173);
            this.listBoxEdges.TabIndex = 5;
            // 
            // buttonEndInputNodes
            // 
            this.buttonEndInputNodes.Location = new System.Drawing.Point(825, 362);
            this.buttonEndInputNodes.Name = "buttonEndInputNodes";
            this.buttonEndInputNodes.Size = new System.Drawing.Size(124, 38);
            this.buttonEndInputNodes.TabIndex = 6;
            this.buttonEndInputNodes.Text = "Закончить ввод вершин";
            this.buttonEndInputNodes.UseVisualStyleBackColor = true;
            this.buttonEndInputNodes.Click += new System.EventHandler(this.buttonEndInputNodes_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(705, 362);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(101, 38);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(825, 180);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(124, 23);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // FormCreateGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 450);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonEndInputNodes);
            this.Controls.Add(this.listBoxEdges);
            this.Controls.Add(this.listBoxNodes);
            this.Controls.Add(this.listBoxMatrixInc);
            this.Controls.Add(this.listBoxMatrixAdj);
            this.Controls.Add(this.buttonCreateRoot);
            this.Controls.Add(this.buttonCreateLeaf);
            this.Name = "FormCreateGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание/изменение графа";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateLeaf;
        private System.Windows.Forms.Button buttonCreateRoot;
        private System.Windows.Forms.ListBox listBoxMatrixAdj;
        private System.Windows.Forms.ListBox listBoxMatrixInc;
        private System.Windows.Forms.ListBox listBoxNodes;
        private System.Windows.Forms.ListBox listBoxEdges;
        private System.Windows.Forms.Button buttonEndInputNodes;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonDelete;
    }
}