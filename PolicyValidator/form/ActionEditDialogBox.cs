using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PolicyValidator.Properties;
using System.Reflection;

namespace PolicyValidator
{
    public partial class ActionEditDialogBox : Form
    {
        public string TargetSystem { get; set; }
        public string Action { get; set; }

        public ActionEditDialogBox()
        {
            InitializeComponent();
            foreach (string targetSystem in Enum.GetNames(typeof(TargetSystem)))
            {
                targetSystemComboBox.Items.Add(targetSystem);
            }
            targetSystemComboBox.SelectedIndex = 0;
            okButton.Enabled = false;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.TargetSystem = targetSystemComboBox.Text;
            this.Action = actionComboBox.Text;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.TargetSystem = "";
            this.Action = "";
            this.Close();
        }

        private void targetSytstemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTextArea();
        }

        private void UpdateTextArea()
        {
            TargetSystem ts = (TargetSystem)Enum.Parse(typeof(TargetSystem), targetSystemComboBox.Text, true);
            string csvAttributes = "";

            switch (ts)
            {
                case PolicyValidator.TargetSystem.Enovia:
                    csvAttributes = Settings.Default.Enovia_Action_Attributes;
                    break;
                case PolicyValidator.TargetSystem.Sap:
                    csvAttributes = Settings.Default.Sap_Action_Attributes;
                    break;
                case PolicyValidator.TargetSystem.Server:
                    csvAttributes = Settings.Default.Server_Action_Attributes;
                    break;
                case PolicyValidator.TargetSystem.Portal:
                    csvAttributes = Settings.Default.Portal_Action_Attributes;
                    break;
                case PolicyValidator.TargetSystem.Filesystem:
                    csvAttributes = Settings.Default.Filesystem_Action_Attributes;
                    break;
            }
            actionComboBox.Items.Clear();
            foreach (string attribute in csvAttributes.Split(','))
            {
                if (!string.IsNullOrEmpty(attribute) && !actionComboBox.Items.Contains(attribute))
                {
                    actionComboBox.Items.Add(attribute);
                }
            }
            if (actionComboBox.SelectedIndex > -1)
            {
                okButton.Enabled = true;
            }
            else
            {
                okButton.Enabled = false;
            }
        }

        private void actionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (actionComboBox.SelectedIndex > -1)
            {
                okButton.Enabled = true;
            }
            else
            {
                okButton.Enabled = false;
            }
        }
        
    }
}
