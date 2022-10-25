using System;
using System.Reflection;
using System.Windows.Forms;

namespace PolicyValidator
{

    partial class TestCaseResult : Form
    {

        public EnforcementResult result { get; set; }
        public TestCaseResult(EnforcementResult result)
        {
            InitializeComponent();

            string overallDecision;
            if (result.response.Equals(Decision.Allow)) {                    overallDecision = "Allow";
                } else if (result.response.Equals(Decision.Deny)) {                    overallDecision = "Deny";
                } else {                    overallDecision = "Error";
                }

            this.Text = "Result for Test Case " + result.SourceTestCase.Name + ": " + overallDecision;

            TestCase testCase = result.SourceTestCase;

            for (int i = 0; i < result.subResults.Length; i ++) {
                EnforcementResult subResult = result.subResults[i];
                String subjectType;
                String subjectName;
                String resource;
                String resourceType;
                String decision;
                System.Drawing.Color color;
                if (i == 0 || i == 1 || i == 2) {
                    subjectType = "SENDER";
                    subjectName = testCase.Subject.Username;
                } else {
                    subjectType = "RECIPIENT";
                    subjectName = testCase.Recipients[(i - 3) / 3].Username;
                }

                if (i % 3 == 0) {
                    resource = testCase.EmailSubject;
                    resourceType = "Email Subject";
                }
                else if (i%  3 == 1)
                {
                    resource = testCase.EmailBody;
                    resourceType = "Email Body";
                }
                else
                {
                    resource = testCase.FromResource.ResourceName;
                    resourceType = "Attachment";
                }                if (subResult.response.Equals(Decision.Allow)) {                    decision = "Allow";
                    color = System.Drawing.Color.Green;
                } else if (subResult.response.Equals(Decision.Deny)) {                    decision = "Deny";
                    color = System.Drawing.Color.Red;
                } else {                    decision = "Error";
                    color = System.Drawing.Color.DarkRed;
                }

                string[] row = { subjectName, subjectType, resource, resourceType, decision };
                ListViewItem item = new ListViewItem(row);
                item.UseItemStyleForSubItems = false;
                item.SubItems[4].ForeColor = color;                this.testCaseResultListView.Items.Add(item);            }
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
