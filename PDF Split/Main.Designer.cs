namespace PDF_Split
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.txtPages = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSplit = new System.Windows.Forms.Button();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.txtInstructions = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(277, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Select or drag and drop a PDF file to split.";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(515, 63);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(113, 31);
            this.btnBrowse.TabIndex = 20;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(133, 67);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(376, 23);
            this.txtFile.TabIndex = 19;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(33, 70);
            this.lblFile.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(91, 17);
            this.lblFile.TabIndex = 18;
            this.lblFile.Text = "Selected File:";
            // 
            // txtPages
            // 
            this.txtPages.Location = new System.Drawing.Point(133, 133);
            this.txtPages.Name = "txtPages";
            this.txtPages.Size = new System.Drawing.Size(376, 23);
            this.txtPages.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 136);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Page Ranges:";
            // 
            // btnSplit
            // 
            this.btnSplit.Location = new System.Drawing.Point(515, 129);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(113, 31);
            this.btnSplit.TabIndex = 25;
            this.btnSplit.Text = "Split";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // lblPageCount
            // 
            this.lblPageCount.AutoSize = true;
            this.lblPageCount.Location = new System.Drawing.Point(130, 93);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(99, 17);
            this.lblPageCount.TabIndex = 26;
            this.lblPageCount.Text = "Page Count:  ";
            // 
            // txtInstructions
            // 
            this.txtInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInstructions.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtInstructions.Enabled = false;
            this.txtInstructions.Location = new System.Drawing.Point(133, 179);
            this.txtInstructions.Name = "txtInstructions";
            this.txtInstructions.Size = new System.Drawing.Size(495, 135);
            this.txtInstructions.TabIndex = 27;
            this.txtInstructions.Text = "";
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 326);
            this.Controls.Add(this.txtInstructions);
            this.Controls.Add(this.lblPageCount);
            this.Controls.Add(this.btnSplit);
            this.Controls.Add(this.txtPages);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.lblFile);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "PDF Split";
            this.Load += new System.EventHandler(this.Main_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Main_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.TextBox txtPages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.RichTextBox txtInstructions;
    }
}

