using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using log4net;
using PolicyValidator.Properties;

namespace PolicyValidator
{
    public partial class ActionAttributeDialogBox : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public TargetSystem TargetSystemType { get; set; }
        public string AttributeList { get; set; }

        public ActionAttributeDialogBox()
        {
            InitializeComponent();

            foreach(string targetSystem in Enum.GetNames(typeof(TargetSystem)))
            {
                targetSystemComboBox.Items.Add(targetSystem);
            }

            targetSystemComboBox.SelectedIndex = 0;

            UpdateTextArea();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            List<string> attributeList = new List<string>();

            foreach (string attribute in attributeListTextArea.Text.Split(System.Environment.NewLine.ToCharArray()))
            {
                if (!string.IsNullOrEmpty(attribute))
                {
                    attributeList.Add(attribute);
                }
            }

            string csv = string.Join(",", attributeList.ToArray());

            AttributeList = csv;
            TargetSystemType = (TargetSystem) Enum.Parse(typeof (TargetSystem), targetSystemComboBox.Text, true);

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void targetSystemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTextArea();
            
        }

        private void UpdateTextArea()
        {
            TargetSystem ts = (TargetSystem)Enum.Parse(typeof(TargetSystem), targetSystemComboBox.Text, true);
            switch (ts)
            {
                case TargetSystem.Enovia:
                    attributeListTextArea.Text = Settings.Default.Enovia_Action_Attributes.Replace(",", System.Environment.NewLine); ;
                    break;
                case TargetSystem.Sap:
                    attributeListTextArea.Text = Settings.Default.Sap_Action_Attributes.Replace(",", System.Environment.NewLine); ;
                    break;
                case TargetSystem.Server:
                    attributeListTextArea.Text = Settings.Default.Server_Action_Attributes.Replace(",", System.Environment.NewLine); ;
                    break;
                case TargetSystem.Portal:
                    attributeListTextArea.Text = Settings.Default.Portal_Action_Attributes.Replace(",", System.Environment.NewLine); ;
                    break;
                case TargetSystem.Filesystem:
                    attributeListTextArea.Text = Settings.Default.Filesystem_Action_Attributes.Replace(",", System.Environment.NewLine); ;
                    break;
            }
        }

    }
}
