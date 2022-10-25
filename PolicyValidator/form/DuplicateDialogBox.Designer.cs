namespace PolicyValidator
{
    partial class DuplicateDialogBox
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
        {            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuplicateDialogBox));
            this.testSetNameLabel = new System.Windows.Forms.Label();
            this.baseNameField = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.noOfDuplicates = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.noOfDuplicates)).BeginInit();
            this.SuspendLayout();
            // 
            // testSetNameLabel
            // 
            this.testSetNameLabel.AutoSize = true;
            this.testSetNameLabel.Location = new System.Drawing.Point(15, 17);
            this.testSetNameLabel.Name = "testSetNameLabel";
            this.testSetNameLabel.Size = new System.Drawing.Size(118, 17);
            this.testSetNameLabel.TabIndex = 0;
            this.testSetNameLabel.Text = "Enter New Name : ";
            // 
            // baseNameField
            // 
            this.baseNameField.Location = new System.Drawing.Point(133, 13);
            this.baseNameField.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.baseNameField.Name = "baseNameField";
            this.baseNameField.Size = new System.Drawing.Size(300, 25);
            this.baseNameField.TabIndex = 1;
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.SteelBlue;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.okButton.Location = new System.Drawing.Point(346, 114);
            this.okButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(87, 30);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancelButton.Location = new System.Drawing.Point(252, 114);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 30);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "No. of Duplicates : ";
            // 
            // noOfDuplicates
            // 
            this.noOfDuplicates.Location = new System.Drawing.Point(133, 47);
            this.noOfDuplicates.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.noOfDuplicates.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.noOfDuplicates.Name = "noOfDuplicates";
            this.noOfDuplicates.Size = new System.Drawing.Size(85, 25);
            this.noOfDuplicates.TabIndex = 6;
            this.noOfDuplicates.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // DuplicateDialogBox
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 160);
            this.Controls.Add(this.noOfDuplicates);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.baseNameField);
            this.Controls.Add(this.testSetNameLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(464, 198);
            this.MinimumSize = new System.Drawing.Size(464, 198);
            this.Name = "DuplicateDialogBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.noOfDuplicates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label testSetNameLabel;
        private System.Windows.Forms.TextBox baseNameField;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown noOfDuplicates;
    }
}