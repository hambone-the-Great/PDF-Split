namespace PDF_Split
{
    partial class PDF_Split_Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDF_Split_Main));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPages = new System.Windows.Forms.TextBox();
            this.btnSplit = new System.Windows.Forms.Button();
            this.lblFile = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.lblHelper = new System.Windows.Forms.Label();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.lblInstruct = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webview = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webview)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webview);
            this.splitContainer1.Size = new System.Drawing.Size(797, 674);
            this.splitContainer1.SplitterDistance = 231;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 28;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPages, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnSplit, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblFile, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnBrowse, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtFile, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblHelper, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblPageCount, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblInstruct, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(797, 207);
            this.tableLayoutPanel1.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 3);
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(791, 18);
            this.label3.TabIndex = 31;
            this.label3.Text = "Select or drag and drop a PDF file to split.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPages
            // 
            this.txtPages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPages.Location = new System.Drawing.Point(108, 131);
            this.txtPages.Name = "txtPages";
            this.txtPages.Size = new System.Drawing.Size(581, 25);
            this.txtPages.TabIndex = 33;
            // 
            // btnSplit
            // 
            this.btnSplit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSplit.Location = new System.Drawing.Point(695, 129);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(99, 28);
            this.btnSplit.TabIndex = 34;
            this.btnSplit.Text = "Split";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // lblFile
            // 
            this.lblFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(5, 52);
            this.lblFile.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(95, 18);
            this.lblFile.TabIndex = 28;
            this.lblFile.Text = "Selected File:";
            this.lblFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(695, 47);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(99, 28);
            this.btnBrowse.TabIndex = 30;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 134);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 32;
            this.label1.Text = "Page Ranges:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(108, 49);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(581, 25);
            this.txtFile.TabIndex = 29;
            // 
            // lblHelper
            // 
            this.lblHelper.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHelper.AutoSize = true;
            this.lblHelper.Location = new System.Drawing.Point(316, 176);
            this.lblHelper.Name = "lblHelper";
            this.lblHelper.Size = new System.Drawing.Size(164, 18);
            this.lblHelper.TabIndex = 36;
            this.lblHelper.Text = "Example: 1, 2-3, 4-6, 7-9, 10";
            // 
            // lblPageCount
            // 
            this.lblPageCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPageCount.AutoSize = true;
            this.lblPageCount.Location = new System.Drawing.Point(7, 176);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(90, 18);
            this.lblPageCount.TabIndex = 35;
            this.lblPageCount.Text = "Page Count: 0";
            // 
            // lblInstruct
            // 
            this.lblInstruct.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInstruct.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblInstruct, 3);
            this.lblInstruct.Location = new System.Drawing.Point(132, 93);
            this.lblInstruct.Name = "lblInstruct";
            this.lblInstruct.Size = new System.Drawing.Size(532, 18);
            this.lblInstruct.TabIndex = 37;
            this.lblInstruct.Text = "Enter the page numbers or page ranges you would like to split into individual doc" +
    "ument.";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(797, 24);
            this.menuStrip1.TabIndex = 36;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // webview
            // 
            this.webview.AllowExternalDrop = true;
            this.webview.CreationProperties = null;
            this.webview.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webview.Location = new System.Drawing.Point(0, 0);
            this.webview.Name = "webview";
            this.webview.Size = new System.Drawing.Size(797, 435);
            this.webview.TabIndex = 0;
            this.webview.ZoomFactor = 1D;
            this.webview.NavigationStarting += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs>(this.webview_NavigationStarting);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // PDF_Split_Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 674);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PDF_Split_Main";
            this.Text = "PDF Split";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PDF_Split_Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Main_DragEnter);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.TextBox txtPages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private Microsoft.Web.WebView2.WinForms.WebView2 webview;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblHelper;
        private System.Windows.Forms.Label lblInstruct;
    }
}

