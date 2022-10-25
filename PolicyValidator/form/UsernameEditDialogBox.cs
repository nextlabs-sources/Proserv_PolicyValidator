using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PolicyValidator
{
    public partial class UsernameEditDialogBox : Form
    {
        public string Username { get; set; }
        public string Sid { get; set; }


        public UsernameEditDialogBox()
        {
            InitializeComponent();
            okButton.Enabled = false;
        }


        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (usernameTextBox.Text.Trim().Length == 0 || sidTextBox.Text.Trim().Length == 0)
            {
                okButton.Enabled = false;
            }
            else
            {
                okButton.Enabled = true;
            }
        }


        private void okButton_Click(object sender, EventArgs e)
        {
            this.Username = usernameTextBox.Text;
            this.Sid = sidTextBox.Text;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Username = "";
            this.Sid = "";
            this.Close();
        }
    }
}

