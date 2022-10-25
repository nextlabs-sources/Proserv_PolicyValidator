namespace PolicyValidator
{
    partial class ActionEditDialogBox
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
        {            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionEditDialogBox));
            this.targetSystemLabel = new System.Windows.Forms.Label();
            this.targetSystemComboBox = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.actionLabel = new System.Windows.Forms.Label();
            this.actionComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // targetSystemLabel
            // 
            this.targetSystemLabel.AutoSize = true;
            this.targetSystemLabel.Location = new System.Drawing.Point(16, 18);
            this.targetSystemLabel.Name = "targetSystemLabel";
            this.targetSystemLabel.Size = new System.Drawing.Size(141, 17);
            this.targetSystemLabel.TabIndex = 0;
            this.targetSystemLabel.Text = "New Target System * : ";
            // 
            // targetSystemComboBox
            // 
            this.targetSystemComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.targetSystemComboBox.FormattingEnabled = true;
            this.targetSystemComboBox.Location = new System.Drawing.Point(157, 16);
            this.targetSystemComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.targetSystemComboBox.Name = "targetSystemComboBox";
            this.targetSystemComboBox.Size = new System.Drawing.Size(276, 25);
            this.targetSystemComboBox.TabIndex = 1;
            this.targetSystemComboBox.SelectedIndexChanged += new System.EventHandler(this.targetSytstemComboBox_SelectedIndexChanged);
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
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
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
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.Location = new System.Drawing.Point(16, 55);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(94, 17);
            this.actionLabel.TabIndex = 4;
            this.actionLabel.Text = "New Action * : ";
            // 
            // actionComboBox
            // 
            this.actionComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.actionComboBox.FormattingEnabled = true;
            this.actionComboBox.Location = new System.Drawing.Point(157, 51);
            this.actionComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.actionComboBox.Name = "actionComboBox";
            this.actionComboBox.Size = new System.Drawing.Size(276, 25);
            this.actionComboBox.TabIndex = 5;
            this.actionComboBox.SelectedIndexChanged += new System.EventHandler(this.actionComboBox_SelectedIndexChanged);
            // 
            // ActionEditDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 160);
            this.Controls.Add(this.actionComboBox);
            this.Controls.Add(this.actionLabel);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.targetSystemComboBox);
            this.Controls.Add(this.targetSystemLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(464, 198);
            this.MinimumSize = new System.Drawing.Size(464, 198);
            this.Name = "ActionEditDialogBox";
            this.Text = "Edit Action";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label targetSystemLabel;
        private System.Windows.Forms.ComboBox targetSystemComboBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label actionLabel;
        private System.Windows.Forms.ComboBox actionComboBox;
    }
}