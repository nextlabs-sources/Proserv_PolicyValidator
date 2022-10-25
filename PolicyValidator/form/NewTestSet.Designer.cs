namespace PolicyValidator
{
    partial class NewTestSet
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
        {            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewTestSet));
            this.testSetNameLabel = new System.Windows.Forms.Label();
            this.testSetNameField = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.excludeCharLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // testSetNameLabel
            // 
            this.testSetNameLabel.AutoSize = true;
            this.testSetNameLabel.Location = new System.Drawing.Point(15, 17);
            this.testSetNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.testSetNameLabel.Name = "testSetNameLabel";
            this.testSetNameLabel.Size = new System.Drawing.Size(104, 17);
            this.testSetNameLabel.TabIndex = 0;
            this.testSetNameLabel.Text = "Test Set Name : ";
            // 
            // testSetNameField
            // 
            this.testSetNameField.Location = new System.Drawing.Point(133, 12);
            this.testSetNameField.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.testSetNameField.Name = "testSetNameField";
            this.testSetNameField.Size = new System.Drawing.Size(301, 25);
            this.testSetNameField.TabIndex = 1;
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.SteelBlue;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.okButton.Location = new System.Drawing.Point(346, 113);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(88, 29);
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
            this.cancelButton.Location = new System.Drawing.Point(252, 113);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(88, 29);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // excludeCharLabel
            // 
            this.excludeCharLabel.AutoSize = true;
            this.excludeCharLabel.Location = new System.Drawing.Point(217, 43);
            this.excludeCharLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.excludeCharLabel.Name = "excludeCharLabel";
            this.excludeCharLabel.Size = new System.Drawing.Size(227, 17);
            this.excludeCharLabel.TabIndex = 4;
            this.excludeCharLabel.Text = "( Exclude Characters : \\ / : * ? \" < > | )";
            // 
            // NewTestSet
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 160);
            this.Controls.Add(this.excludeCharLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.testSetNameField);
            this.Controls.Add(this.testSetNameLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(464, 198);
            this.MinimumSize = new System.Drawing.Size(464, 198);
            this.Name = "NewTestSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Test Set";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label testSetNameLabel;
        private System.Windows.Forms.TextBox testSetNameField;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label excludeCharLabel;
    }
}