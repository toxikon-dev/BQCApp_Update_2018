namespace Toxikon.BatchQC.ICPRC.Views
{
    partial class DilutedSampleView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DilutedSampleView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SubmitButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BrowseFileButton = new System.Windows.Forms.ToolStripButton();
            this.SampleListView = new System.Windows.Forms.ListView();
            this.SampleNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.DilutionFactorTextBox = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubmitButton,
            this.toolStripSeparator1,
            this.BrowseFileButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(484, 28);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SubmitButton.Image = ((System.Drawing.Image)(resources.GetObject("SubmitButton.Image")));
            this.SubmitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(77, 25);
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // BrowseFileButton
            // 
            this.BrowseFileButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BrowseFileButton.Image = ((System.Drawing.Image)(resources.GetObject("BrowseFileButton.Image")));
            this.BrowseFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BrowseFileButton.Name = "BrowseFileButton";
            this.BrowseFileButton.Size = new System.Drawing.Size(103, 25);
            this.BrowseFileButton.Text = "Browse File";
            this.BrowseFileButton.Click += new System.EventHandler(this.BrowseFileButton_Click);
            // 
            // SampleListView
            // 
            this.SampleListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SampleListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SampleListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SampleNameCol});
            this.SampleListView.GridLines = true;
            this.SampleListView.Location = new System.Drawing.Point(0, 32);
            this.SampleListView.Name = "SampleListView";
            this.SampleListView.Size = new System.Drawing.Size(484, 282);
            this.SampleListView.TabIndex = 1;
            this.SampleListView.UseCompatibleStateImageBehavior = false;
            this.SampleListView.View = System.Windows.Forms.View.Details;
            this.SampleListView.SelectedIndexChanged += new System.EventHandler(this.SampleListView_SelectedIndexChanged);
            // 
            // SampleNameCol
            // 
            this.SampleNameCol.Text = "Sample Name";
            this.SampleNameCol.Width = 452;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dilution Factor:";
            // 
            // DilutionFactorTextBox
            // 
            this.DilutionFactorTextBox.Location = new System.Drawing.Point(130, 320);
            this.DilutionFactorTextBox.Name = "DilutionFactorTextBox";
            this.DilutionFactorTextBox.Size = new System.Drawing.Size(192, 29);
            this.DilutionFactorTextBox.TabIndex = 3;
            // 
            // DilutedSampleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(484, 362);
            this.Controls.Add(this.DilutionFactorTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SampleListView);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DilutedSampleView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Diluted Results";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton SubmitButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BrowseFileButton;
        private System.Windows.Forms.ListView SampleListView;
        private System.Windows.Forms.ColumnHeader SampleNameCol;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DilutionFactorTextBox;
    }
}