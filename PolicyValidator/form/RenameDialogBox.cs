using System;
using System.Windows.Forms;

namespace PolicyValidator
{
    public partial class RenameDialogBox : Form
    {
        public string NewName { get; set; }

        public RenameDialogBox()
        {
            InitializeComponent();
        }

        public RenameDialogBox(string currentName)
        {
            InitializeComponent();

            newNameField.Text = currentName;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.NewName = newNameField.Text;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.NewName = "";
            this.Close();
        }

    }
}
