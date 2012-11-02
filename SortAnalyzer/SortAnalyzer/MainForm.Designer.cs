namespace SortAnalyzer
{
    partial class MainForm
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
            this.btnStartSort = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.txtResults = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnStartSort
            // 
            this.btnStartSort.Location = new System.Drawing.Point(12, 214);
            this.btnStartSort.Name = "btnStartSort";
            this.btnStartSort.Size = new System.Drawing.Size(75, 23);
            this.btnStartSort.TabIndex = 0;
            this.btnStartSort.Text = "Start sort";
            this.btnStartSort.UseVisualStyleBackColor = true;
            this.btnStartSort.Click += new System.EventHandler(this.btnStartSort_Click);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(12, 170);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(75, 23);
            this.btnAnalyze.TabIndex = 1;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // progress
            // 
            this.progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progress.Location = new System.Drawing.Point(12, 282);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(490, 17);
            this.progress.TabIndex = 2;
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(12, 12);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(100, 20);
            this.txtStart.TabIndex = 3;
            this.txtStart.Text = "10";
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(12, 64);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(100, 20);
            this.txtCount.TabIndex = 5;
            this.txtCount.Text = "10";
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(12, 38);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(100, 20);
            this.txtEnd.TabIndex = 6;
            this.txtEnd.Text = "1000";
            // 
            // txtResults
            // 
            this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResults.Location = new System.Drawing.Point(130, 12);
            this.txtResults.Name = "txtResults";
            this.txtResults.Size = new System.Drawing.Size(372, 264);
            this.txtResults.TabIndex = 8;
            this.txtResults.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 311);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.txtEnd);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.btnStartSort);
            this.Name = "MainForm";
            this.Text = "Sort Analyzer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartSort;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.RichTextBox txtResults;
    }
}

