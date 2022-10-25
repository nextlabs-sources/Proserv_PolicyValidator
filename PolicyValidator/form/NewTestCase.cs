using System;using System.Windows.Forms;
namespace PolicyValidator{    public partial class NewTestCase : Form    {        public string TestCaseName { get; set; }        public string TargetSystem { get; set; }
        public string PolicyType { get; set; }                public NewTestCase()        {            InitializeComponent();        }

        private void okButton_Click(object sender, EventArgs e)        {            this.TestCaseName = testCaseNameField.Text;            this.TargetSystem = targetSystemComboBox.Text;
            this.PolicyType = policyTypeComboBox.Text;            this.Close();        }
        private void cancelButton_Click(object sender, EventArgs e)        {            this.TestCaseName = "";            this.TargetSystem = "";
            this.PolicyType = "";            this.Close();        }
        private void NewTestCase_Load(object sender, EventArgs e)        {            string[] targetSystems = Enum.GetNames(typeof (TargetSystem));            foreach (string targetSystem in targetSystems)            {                targetSystemComboBox.Items.Add(targetSystem.ToUpper());            }            targetSystemComboBox.SelectedIndex = 0;

            string[] policyTypes = Enum.GetNames(typeof (PolicyType));
            foreach (string policyType in policyTypes)
            {
                policyTypeComboBox.Items.Add(policyType);
            }
            policyTypeComboBox.SelectedIndex = 0;        }    }}
