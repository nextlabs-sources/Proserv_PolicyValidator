using System;
using System.Windows.Forms;

namespace PolicyValidator
{
    public partial class DuplicateDialogBox : Form
    {
        public string BaseName { get; set; }
        public int Count { get; set; }

        public DuplicateDialogBox()
        {
            InitializeComponent();
        }

        public DuplicateDialogBox(string baseName)
        {
            InitializeComponent();

            baseNameField.Text = baseName;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.BaseName = baseNameField.Text;
            this.Count = int.Parse(noOfDuplicates.Text);
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.BaseName = "";
            this.Count = 0;
            this.Close();
        }

    }
}
