﻿using System;
namespace PolicyValidator
        public string PolicyType { get; set; }

        private void okButton_Click(object sender, EventArgs e)
            this.PolicyType = policyTypeComboBox.Text;
        private void cancelButton_Click(object sender, EventArgs e)
            this.PolicyType = "";
        private void NewTestCase_Load(object sender, EventArgs e)

            string[] policyTypes = Enum.GetNames(typeof (PolicyType));
            foreach (string policyType in policyTypes)
            {
                policyTypeComboBox.Items.Add(policyType);
            }
            policyTypeComboBox.SelectedIndex = 0;