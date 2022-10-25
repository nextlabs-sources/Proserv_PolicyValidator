namespace PolicyValidator
{

    partial class PCSettingsDialogBox
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
        {            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PCSettingsDialogBox));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.pcTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.javaPcRadioButton = new System.Windows.Forms.RadioButton();
            this.windowsPcRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pcIpTextBox = new System.Windows.Forms.TextBox();
            this.pcTimeoutTextBox = new System.Windows.Forms.TextBox();
            this.pcPortTextBox = new System.Windows.Forms.TextBox();
            this.testConnectionButton = new System.Windows.Forms.Button();
            this.connectionTestBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.pcTypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.SteelBlue;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.okButton.Location = new System.Drawing.Point(352, 214);
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
            this.cancelButton.Location = new System.Drawing.Point(258, 214);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(87, 30);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // pcTypeGroupBox
            // 
            this.pcTypeGroupBox.Controls.Add(this.javaPcRadioButton);
            this.pcTypeGroupBox.Controls.Add(this.windowsPcRadioButton);
            this.pcTypeGroupBox.Location = new System.Drawing.Point(15, 17);
            this.pcTypeGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pcTypeGroupBox.Name = "pcTypeGroupBox";
            this.pcTypeGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pcTypeGroupBox.Size = new System.Drawing.Size(425, 59);
            this.pcTypeGroupBox.TabIndex = 4;
            this.pcTypeGroupBox.TabStop = false;
            this.pcTypeGroupBox.Text = "PC Type";
            // 
            // javaPcRadioButton
            // 
            this.javaPcRadioButton.AutoSize = true;
            this.javaPcRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.javaPcRadioButton.Location = new System.Drawing.Point(243, 25);
            this.javaPcRadioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.javaPcRadioButton.Name = "javaPcRadioButton";
            this.javaPcRadioButton.Size = new System.Drawing.Size(69, 21);
            this.javaPcRadioButton.TabIndex = 1;
            this.javaPcRadioButton.TabStop = true;
            this.javaPcRadioButton.Text = "Java PC";
            this.javaPcRadioButton.UseVisualStyleBackColor = true;
            // 
            // windowsPcRadioButton
            // 
            this.windowsPcRadioButton.AutoSize = true;
            this.windowsPcRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.windowsPcRadioButton.Location = new System.Drawing.Point(68, 25);
            this.windowsPcRadioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.windowsPcRadioButton.Name = "windowsPcRadioButton";
            this.windowsPcRadioButton.Size = new System.Drawing.Size(97, 21);
            this.windowsPcRadioButton.TabIndex = 0;
            this.windowsPcRadioButton.TabStop = true;
            this.windowsPcRadioButton.Text = "Windows PC";
            this.windowsPcRadioButton.UseVisualStyleBackColor = true;
            this.windowsPcRadioButton.CheckedChanged += new System.EventHandler(this.windowsPcRadioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "PC IP Address  : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "PC Timeout (S) : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "PC Port             : ";
            // 
            // pcIpTextBox
            // 
            this.pcIpTextBox.Location = new System.Drawing.Point(122, 98);
            this.pcIpTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pcIpTextBox.Name = "pcIpTextBox";
            this.pcIpTextBox.Size = new System.Drawing.Size(317, 25);
            this.pcIpTextBox.TabIndex = 8;
            // 
            // pcTimeoutTextBox
            // 
            this.pcTimeoutTextBox.Location = new System.Drawing.Point(122, 129);
            this.pcTimeoutTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pcTimeoutTextBox.Name = "pcTimeoutTextBox";
            this.pcTimeoutTextBox.Size = new System.Drawing.Size(317, 25);
            this.pcTimeoutTextBox.TabIndex = 9;
            // 
            // pcPortTextBox
            // 
            this.pcPortTextBox.Location = new System.Drawing.Point(122, 163);
            this.pcPortTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pcPortTextBox.Name = "pcPortTextBox";
            this.pcPortTextBox.Size = new System.Drawing.Size(317, 25);
            this.pcPortTextBox.TabIndex = 10;
            // 
            // testConnectionButton
            // 
            this.testConnectionButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.testConnectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testConnectionButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.testConnectionButton.Location = new System.Drawing.Point(14, 214);
            this.testConnectionButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.testConnectionButton.Name = "testConnectionButton";
            this.testConnectionButton.Size = new System.Drawing.Size(112, 30);
            this.testConnectionButton.TabIndex = 11;
            this.testConnectionButton.Text = "Test Connection";
            this.testConnectionButton.UseVisualStyleBackColor = false;
            this.testConnectionButton.Click += new System.EventHandler(this.testConnectionButton_Click);
            // 
            // connectionTestBackgroundWorker
            // 
            this.connectionTestBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.connectionTestBackgroundWorker_DoWork);
            this.connectionTestBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.connectionTestBackgroundWorker_RunWorkerCompleted);
            // 
            // PCSettingsDialogBox
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 264);
            this.Controls.Add(this.testConnectionButton);
            this.Controls.Add(this.pcPortTextBox);
            this.Controls.Add(this.pcTimeoutTextBox);
            this.Controls.Add(this.pcIpTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pcTypeGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(464, 302);
            this.MinimumSize = new System.Drawing.Size(464, 302);
            this.Name = "PCSettingsDialogBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Policy Controller Settings";
            this.Load += new System.EventHandler(this.PCSettingsDialogBox_Load);
            this.pcTypeGroupBox.ResumeLayout(false);
            this.pcTypeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox pcTypeGroupBox;
        private System.Windows.Forms.RadioButton javaPcRadioButton;
        private System.Windows.Forms.RadioButton windowsPcRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pcIpTextBox;
        private System.Windows.Forms.TextBox pcTimeoutTextBox;
        private System.Windows.Forms.TextBox pcPortTextBox;
        private System.Windows.Forms.Button testConnectionButton;
        private System.ComponentModel.BackgroundWorker connectionTestBackgroundWorker;
    }
}