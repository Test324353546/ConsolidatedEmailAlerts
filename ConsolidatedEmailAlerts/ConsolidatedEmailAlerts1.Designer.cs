
namespace ConsolidatedEmailAlerts
{
    partial class ConsolidatedEmailAlerts1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsolidatedEmailAlerts1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sfdgFileSelect = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnClearFiles = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSearchForEmailAlert = new System.Windows.Forms.Button();
            this.btnSaveAsHtml = new System.Windows.Forms.Button();
            this.btnSaveAsPdf = new System.Windows.Forms.Button();
            this.panMain = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfdgFileSelect)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panMain.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.sfdgFileSelect);
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(849, 431);
            this.splitContainer1.SplitterDistance = 318;
            this.splitContainer1.SplitterWidth = 20;
            this.splitContainer1.TabIndex = 1;
            // 
            // sfdgFileSelect
            // 
            this.sfdgFileSelect.AccessibleName = "Table";
            this.sfdgFileSelect.AllowFiltering = true;
            this.sfdgFileSelect.AllowTriStateSorting = true;
            this.sfdgFileSelect.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.Fill;
            this.sfdgFileSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sfdgFileSelect.Location = new System.Drawing.Point(0, 0);
            this.sfdgFileSelect.Name = "sfdgFileSelect";
            this.sfdgFileSelect.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Extended;
            this.sfdgFileSelect.Size = new System.Drawing.Size(318, 398);
            this.sfdgFileSelect.SummaryCalculationUnit = Syncfusion.Data.SummaryCalculationUnit.SelectedRows;
            this.sfdgFileSelect.TabIndex = 2;
            this.sfdgFileSelect.Text = "sfDataGrid1";
            this.sfdgFileSelect.SelectionChanged += new Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventHandler(this.sfdgFileSelect_SelectionChanged);
            this.sfdgFileSelect.CurrentCellActivating += new Syncfusion.WinForms.DataGrid.Events.CurrentCellActivatingEventHandler(this.sfDataGrid1_CurrentCellActivating);
            this.sfdgFileSelect.CellCheckBoxClick += new Syncfusion.WinForms.DataGrid.Events.CellCheckBoxClickEventHandler(this.sfdgFileSelect_CellCheckBoxClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 398);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(318, 33);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel5.Controls.Add(this.btnClearFiles);
            this.panel5.Controls.Add(this.btnView);
            this.panel5.Controls.Add(this.btnAdd);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(318, 30);
            this.panel5.TabIndex = 0;
            // 
            // btnClearFiles
            // 
            this.btnClearFiles.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnClearFiles.Location = new System.Drawing.Point(174, 4);
            this.btnClearFiles.Name = "btnClearFiles";
            this.btnClearFiles.Size = new System.Drawing.Size(75, 23);
            this.btnClearFiles.TabIndex = 8;
            this.btnClearFiles.Text = "Clear Files";
            this.btnClearFiles.UseVisualStyleBackColor = true;
            this.btnClearFiles.Click += new System.EventHandler(this.btnClearFiles_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnView.Location = new System.Drawing.Point(93, 3);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "View Alert";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAdd.Location = new System.Drawing.Point(12, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add Files";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(511, 431);
            this.panel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.webBrowser1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 431);
            this.panel1.TabIndex = 0;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(511, 401);
            this.webBrowser1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.btnSearchForEmailAlert);
            this.panel3.Controls.Add(this.btnSaveAsHtml);
            this.panel3.Controls.Add(this.btnSaveAsPdf);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 401);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(511, 30);
            this.panel3.TabIndex = 1;
            // 
            // btnSearchForEmailAlert
            // 
            this.btnSearchForEmailAlert.Location = new System.Drawing.Point(229, 2);
            this.btnSearchForEmailAlert.Name = "btnSearchForEmailAlert";
            this.btnSearchForEmailAlert.Size = new System.Drawing.Size(154, 23);
            this.btnSearchForEmailAlert.TabIndex = 4;
            this.btnSearchForEmailAlert.Text = "Search Email Text";
            this.btnSearchForEmailAlert.UseVisualStyleBackColor = true;
            this.btnSearchForEmailAlert.Click += new System.EventHandler(this.btnSearchForEmailAlert_Click);
            // 
            // btnSaveAsHtml
            // 
            this.btnSaveAsHtml.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSaveAsHtml.Location = new System.Drawing.Point(116, 2);
            this.btnSaveAsHtml.Name = "btnSaveAsHtml";
            this.btnSaveAsHtml.Size = new System.Drawing.Size(107, 23);
            this.btnSaveAsHtml.TabIndex = 2;
            this.btnSaveAsHtml.Text = "Save As Html";
            this.btnSaveAsHtml.UseVisualStyleBackColor = true;
            this.btnSaveAsHtml.Click += new System.EventHandler(this.btnSaveAsHtml_Click);
            // 
            // btnSaveAsPdf
            // 
            this.btnSaveAsPdf.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSaveAsPdf.Location = new System.Drawing.Point(3, 2);
            this.btnSaveAsPdf.Name = "btnSaveAsPdf";
            this.btnSaveAsPdf.Size = new System.Drawing.Size(107, 23);
            this.btnSaveAsPdf.TabIndex = 1;
            this.btnSaveAsPdf.Text = "Save As Pdf";
            this.btnSaveAsPdf.UseVisualStyleBackColor = true;
            this.btnSaveAsPdf.Click += new System.EventHandler(this.btnSaveAsPdf_Click);
            // 
            // panMain
            // 
            this.panMain.Controls.Add(this.splitContainer1);
            this.panMain.Controls.Add(this.panel6);
            this.panMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMain.Location = new System.Drawing.Point(0, 0);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(849, 458);
            this.panMain.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(849, 27);
            this.panel6.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(544, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Consolidated Email Alerts";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ConsolidatedEmailAlerts1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 458);
            this.Controls.Add(this.panMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConsolidatedEmailAlerts1";
            this.Text = "Consolidated Email Alerts";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ConsolidatedEmailAlerts1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sfdgFileSelect)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panMain.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panMain;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnSaveAsPdf;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckBox ChkEmailAlert;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfdgFileSelect;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnSaveAsHtml;
        private System.Windows.Forms.Button btnSearchForEmailAlert;
        private System.Windows.Forms.Button btnClearFiles;
    }
}