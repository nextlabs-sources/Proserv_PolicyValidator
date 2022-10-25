namespace PolicyValidator
{

    partial class DBSettingsDialogBox
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
        {            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBSettingsDialogBox));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dbHost = new System.Windows.Forms.TextBox();
            this.dbPort = new System.Windows.Forms.TextBox();
            this.dbUser = new System.Windows.Forms.TextBox();
            this.testConnectionButton = new System.Windows.Forms.Button();
            this.connectionTestBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.label4 = new System.Windows.Forms.Label();
            this.dbPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dbName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.Color.SteelBlue;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.okButton.Location = new System.Drawing.Point(346, 218);
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
            this.cancelButton.Location = new System.Drawing.Point(253, 218);
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
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "DB Host";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "DB Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "DB User Name";
            // 
            // dbHost
            // 
            this.dbHost.Location = new System.Drawing.Point(124, 13);
            this.dbHost.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dbHost.Name = "dbHost";
            this.dbHost.Size = new System.Drawing.Size(310, 25);
            this.dbHost.TabIndex = 8;
            // 
            // dbPort
            // 
            this.dbPort.Location = new System.Drawing.Point(124, 52);
            this.dbPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dbPort.Name = "dbPort";
            this.dbPort.Size = new System.Drawing.Size(310, 25);
            this.dbPort.TabIndex = 9;
            // 
            // dbUser
            // 
            this.dbUser.Location = new System.Drawing.Point(125, 92);
            this.dbUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dbUser.Name = "dbUser";
            this.dbUser.Size = new System.Drawing.Size(308, 25);
            this.dbUser.TabIndex = 10;
            // 
            // testConnectionButton
            // 
            this.testConnectionButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.testConnectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testConnectionButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.testConnectionButton.Location = new System.Drawing.Point(14, 218);
            this.testConnectionButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.testConnectionButton.Name = "testConnectionButton";
            this.testConnectionButton.Size = new System.Drawing.Size(112, 30);
            this.testConnectionButton.TabIndex = 11;
            this.testConnectionButton.Text = "Test Connection";
            this.testConnectionButton.UseVisualStyleBackColor = false;
            this.testConnectionButton.Click += new System.EventHandler(this.testConnectionButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "DB Password";
            // 
            // dbPassword
            // 
            this.dbPassword.Location = new System.Drawing.Point(125, 131);
            this.dbPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dbPassword.Name = "dbPassword";
            this.dbPassword.Size = new System.Drawing.Size(308, 25);
            this.dbPassword.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "DB Name";
            // 
            // dbName
            // 
            this.dbName.Location = new System.Drawing.Point(124, 171);
            this.dbName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dbName.Name = "dbName";
            this.dbName.Size = new System.Drawing.Size(310, 25);
            this.dbName.TabIndex = 17;
            // 
            // DBSettingsDialogBox
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 264);
            this.Controls.Add(this.dbName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dbPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.testConnectionButton);
            this.Controls.Add(this.dbUser);
            this.Controls.Add(this.dbPort);
            this.Controls.Add(this.dbHost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(464, 302);
            this.MinimumSize = new System.Drawing.Size(464, 302);
            this.Name = "DBSettingsDialogBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Database Settings";
            this.Load += new System.EventHandler(this.DBSettingsDialogBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dbHost;
        private System.Windows.Forms.TextBox dbPort;
        private System.Windows.Forms.TextBox dbUser;
        private System.Windows.Forms.Button testConnectionButton;
        private System.ComponentModel.BackgroundWorker connectionTestBackgroundWorker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dbPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox dbName;
    }
}