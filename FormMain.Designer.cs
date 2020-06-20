namespace Bayesian_network_ES
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxMatrixAdj = new System.Windows.Forms.ListBox();
            this.listBoxMatrixInc = new System.Windows.Forms.ListBox();
            this.buttonCreateGraph = new System.Windows.Forms.Button();
            this.listBoxEdges = new System.Windows.Forms.ListBox();
            this.listBoxNodes = new System.Windows.Forms.ListBox();
            this.buttonChangeGraph = new System.Windows.Forms.Button();
            this.labelCheckEvidence = new System.Windows.Forms.Label();
            this.checkedListBoxEvidences = new System.Windows.Forms.CheckedListBox();
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxMatrixAdj
            // 
            this.listBoxMatrixAdj.FormattingEnabled = true;
            this.listBoxMatrixAdj.Location = new System.Drawing.Point(45, 34);
            this.listBoxMatrixAdj.Name = "listBoxMatrixAdj";
            this.listBoxMatrixAdj.Size = new System.Drawing.Size(218, 264);
            this.listBoxMatrixAdj.TabIndex = 0;
            // 
            // listBoxMatrixInc
            // 
            this.listBoxMatrixInc.FormattingEnabled = true;
            this.listBoxMatrixInc.Location = new System.Drawing.Point(45, 385);
            this.listBoxMatrixInc.Name = "listBoxMatrixInc";
            this.listBoxMatrixInc.Size = new System.Drawing.Size(218, 264);
            this.listBoxMatrixInc.TabIndex = 1;
            // 
            // buttonCreateGraph
            // 
            this.buttonCreateGraph.Location = new System.Drawing.Point(188, 696);
            this.buttonCreateGraph.Name = "buttonCreateGraph";
            this.buttonCreateGraph.Size = new System.Drawing.Size(126, 23);
            this.buttonCreateGraph.TabIndex = 2;
            this.buttonCreateGraph.Text = "Создать новую сеть";
            this.buttonCreateGraph.UseVisualStyleBackColor = true;
            this.buttonCreateGraph.Click += new System.EventHandler(this.buttonCreateGraph_Click);
            // 
            // listBoxEdges
            // 
            this.listBoxEdges.FormattingEnabled = true;
            this.listBoxEdges.Location = new System.Drawing.Point(328, 385);
            this.listBoxEdges.Name = "listBoxEdges";
            this.listBoxEdges.Size = new System.Drawing.Size(354, 264);
            this.listBoxEdges.TabIndex = 7;
            // 
            // listBoxNodes
            // 
            this.listBoxNodes.FormattingEnabled = true;
            this.listBoxNodes.Location = new System.Drawing.Point(328, 29);
            this.listBoxNodes.Name = "listBoxNodes";
            this.listBoxNodes.Size = new System.Drawing.Size(354, 264);
            this.listBoxNodes.TabIndex = 6;
            // 
            // buttonChangeGraph
            // 
            this.buttonChangeGraph.Location = new System.Drawing.Point(43, 696);
            this.buttonChangeGraph.Name = "buttonChangeGraph";
            this.buttonChangeGraph.Size = new System.Drawing.Size(126, 23);
            this.buttonChangeGraph.TabIndex = 8;
            this.buttonChangeGraph.Text = "Изменить сеть";
            this.buttonChangeGraph.UseVisualStyleBackColor = true;
            this.buttonChangeGraph.Click += new System.EventHandler(this.buttonChangeGraph_Click);
            // 
            // labelCheckEvidence
            // 
            this.labelCheckEvidence.AutoSize = true;
            this.labelCheckEvidence.Location = new System.Drawing.Point(841, 18);
            this.labelCheckEvidence.Name = "labelCheckEvidence";
            this.labelCheckEvidence.Size = new System.Drawing.Size(136, 13);
            this.labelCheckEvidence.TabIndex = 9;
            this.labelCheckEvidence.Text = "Выберите свидетельства";
            // 
            // checkedListBoxEvidences
            // 
            this.checkedListBoxEvidences.FormattingEnabled = true;
            this.checkedListBoxEvidences.Location = new System.Drawing.Point(813, 34);
            this.checkedListBoxEvidences.Name = "checkedListBoxEvidences";
            this.checkedListBoxEvidences.Size = new System.Drawing.Size(208, 259);
            this.checkedListBoxEvidences.TabIndex = 10;
            // 
            // listBoxResults
            // 
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.Location = new System.Drawing.Point(813, 385);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.Size = new System.Drawing.Size(208, 264);
            this.listBoxResults.TabIndex = 11;
            // 
            // buttonExecute
            // 
            this.buttonExecute.Location = new System.Drawing.Point(877, 311);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(75, 23);
            this.buttonExecute.TabIndex = 12;
            this.buttonExecute.Text = "Вычислить";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 749);
            this.Controls.Add(this.buttonExecute);
            this.Controls.Add(this.listBoxResults);
            this.Controls.Add(this.checkedListBoxEvidences);
            this.Controls.Add(this.labelCheckEvidence);
            this.Controls.Add(this.buttonChangeGraph);
            this.Controls.Add(this.listBoxEdges);
            this.Controls.Add(this.listBoxNodes);
            this.Controls.Add(this.buttonCreateGraph);
            this.Controls.Add(this.listBoxMatrixInc);
            this.Controls.Add(this.listBoxMatrixAdj);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Байесовская сеть";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxMatrixAdj;
        private System.Windows.Forms.ListBox listBoxMatrixInc;
        private System.Windows.Forms.Button buttonCreateGraph;
        private System.Windows.Forms.ListBox listBoxEdges;
        private System.Windows.Forms.ListBox listBoxNodes;
        private System.Windows.Forms.Button buttonChangeGraph;
        private System.Windows.Forms.Label labelCheckEvidence;
        private System.Windows.Forms.CheckedListBox checkedListBoxEvidences;
        private System.Windows.Forms.ListBox listBoxResults;
        private System.Windows.Forms.Button buttonExecute;
    }
}

