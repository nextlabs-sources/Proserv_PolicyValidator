namespace PolicyValidator
{
    partial class NewTestCase
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
        {            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewTestCase));
            this.testCaseNameLabel = new System.Windows.Forms.Label();
            this.testCaseNameField = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.excludeCharLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.targetSystemComboBox = new System.Windows.Forms.ComboBox();
            this.policyTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // testCaseNameLabel
            // 
            this.testCaseNameLabel.AutoSize = true;
            this.testCaseNameLabel.Location = new System.Drawing.Point(15, 17);
            this.testCaseNameLabel.Name = "testCaseNameLabel";
            this.testCaseNameLabel.Size = new System.Drawing.Size(114, 17);
            this.testCaseNameLabel.TabIndex = 0;
            this.testCaseNameLabel.Text = "Test Case Name : ";
            // 
            // testCaseNameField
            // 
            this.testCaseNameField.Location = new System.Drawing.Point(133, 13);
            this.testCaseNameField.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.testCaseNameField.Name = "testCaseNameField";
            this.testCaseNameField.Size = new System.Drawing.Size(300, 25);
            this.testCaseNameField.TabIndex = 1;
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.SteelBlue;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.okButton.Location = new System.Drawing.Point(346, 192);
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
            this.cancelButton.Location = new System.Drawing.Point(252, 192);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 30);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // excludeCharLabel
            // 
            this.excludeCharLabel.AutoSize = true;
            this.excludeCharLabel.Location = new System.Drawing.Point(217, 43);
            this.excludeCharLabel.Name = "excludeCharLabel";
            this.excludeCharLabel.Size = new System.Drawing.Size(227, 17);
            this.excludeCharLabel.TabIndex = 4;
            this.excludeCharLabel.Text = "( Exclude Characters : \\ / : * ? \" < > | )";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Target System : ";
            // 
            // targetSystemComboBox
            // 
            this.targetSystemComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.targetSystemComboBox.FormattingEnabled = true;
            this.targetSystemComboBox.Location = new System.Drawing.Point(133, 133);
            this.targetSystemComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.targetSystemComboBox.Name = "targetSystemComboBox";
            this.targetSystemComboBox.Size = new System.Drawing.Size(300, 25);
            this.targetSystemComboBox.TabIndex = 6;
            // 
            // policyTypeComboBox
            // 
            this.policyTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.policyTypeComboBox.FormattingEnabled = true;
            this.policyTypeComboBox.Location = new System.Drawing.Point(133, 84);
            this.policyTypeComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.policyTypeComboBox.Name = "policyTypeComboBox";
            this.policyTypeComboBox.Size = new System.Drawing.Size(300, 25);
            this.policyTypeComboBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Policy Type : ";
            // 
            // NewTestCase
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 238);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.policyTypeComboBox);
            this.Controls.Add(this.targetSystemComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.excludeCharLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.testCaseNameField);
            this.Controls.Add(this.testCaseNameLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(464, 276);
            this.MinimumSize = new System.Drawing.Size(464, 276);
            this.Name = "NewTestCase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Test Case";
            this.Load += new System.EventHandler(this.NewTestCase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label testCaseNameLabel;
        private System.Windows.Forms.TextBox testCaseNameField;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label excludeCharLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox targetSystemComboBox;
        private System.Windows.Forms.ComboBox policyTypeComboBox;
        private System.Windows.Forms.Label label2;
    }
}