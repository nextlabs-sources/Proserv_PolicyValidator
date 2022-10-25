using System;

using System.Windows.Forms;



namespace PolicyValidator

{

    public partial class NewTestSet : Form

    {

        public string TestSetName { get; set; }

        

        public NewTestSet()

        {

            InitializeComponent();

        }



        private void okButton_Click(object sender, EventArgs e)

        {

            this.TestSetName = testSetNameField.Text;

            this.Close();

        }



        private void cancelButton_Click(object sender, EventArgs e)

        {

            this.TestSetName = "";

            this.Close();

        }



    }

}

