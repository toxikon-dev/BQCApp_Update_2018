namespace Toxikon.BatchQC.Views.Forms
{
    partial class SpikeSolutionOptionsView
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
            this.addButton = new System.Windows.Forms.Button();
            this.ItemCodeListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addButton.Location = new System.Drawing.Point(101, 227);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 38);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // ItemCodeListBox
            // 
            this.ItemCodeListBox.FormattingEnabled = true;
            this.ItemCodeListBox.ItemHeight = 21;
            this.ItemCodeListBox.Location = new System.Drawing.Point(13, 13);
            this.ItemCodeListBox.Name = "ItemCodeListBox";
            this.ItemCodeListBox.Size = new System.Drawing.Size(188, 193);
            this.ItemCodeListBox.TabIndex = 2;
            this.ItemCodeListBox.SelectedIndexChanged += new System.EventHandler(this.ItemCodeListBox_SelectedIndexChanged);
            // 
            // SpikeSolutionOptionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 277);
            this.Controls.Add(this.ItemCodeListBox);
            this.Controls.Add(this.addButton);
            this.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SpikeSolutionOptionsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Selected Spike Solution Codes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpikeSolutionOptionsView_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListBox ItemCodeListBox;
    }
}