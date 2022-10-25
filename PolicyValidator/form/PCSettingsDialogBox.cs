using System;
using System.Reflection;
using System.Windows.Forms;
using log4net;
using PolicyValidator.Properties;

namespace PolicyValidator
{
    public partial class PCSettingsDialogBox : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public PolicyControllerType Type { get; set; }
        public string IpAddress { get; set; }
        public float TimeoutS { get; set; }
        public int Port { get; set; }

        public PCSettingsDialogBox()
        {
            InitializeComponent();

            windowsPcRadioButton.Checked = true;
            pcPortTextBox.Text = "9233";
        }

        private void windowsPcRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (windowsPcRadioButton.Checked)
            {
                pcPortTextBox.Enabled = false;
                pcPortTextBox.Text = "9233";
            }
            else if (javaPcRadioButton.Checked)
            {
                pcPortTextBox.Enabled = true;
                pcPortTextBox.Text = "1099";
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (windowsPcRadioButton.Checked)
                {
                    Type = PolicyControllerType.Windows;
                }
                else
                {
                    Type = PolicyControllerType.Java;
                }

                if (pcIpTextBox.Text.Length > 0)
                {
                    IpAddress = pcIpTextBox.Text;
                }
                else
                {
                    throw new Exception("IP Address is empty.");
                }
                if (pcTimeoutTextBox.Text.Length > 0)
                {
                    try
                    {
                        TimeoutS = float.Parse(pcTimeoutTextBox.Text);

                        if (TimeoutS <= 0)
                        {
                            throw new Exception("Timeout should be a positive number greater than 0.");
                        }
                    }
                    catch (Exception)
                    {
                        throw new Exception("Timeout should be a positive number greater than 0.");
                    }
                    
                }
                else
                {
                    throw new Exception("Timeout is empty.");
                }
                if (pcPortTextBox.Text.Length > 0)
                {
                    try
                    {
                        Port = int.Parse(pcPortTextBox.Text);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Port should be a positive number greater than 0.");
                    }
                }
                else
                {
                    throw new Exception("Port Number is empty.");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                Log.Error("An error occured while saving settings. ", ex);
                MessageBox.Show("Error : " + ex.Message + " Please see the log for more details.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PCSettingsDialogBox_Load(object sender, EventArgs e)
        {
            if (Settings.Default.JavaPC)
            {
                javaPcRadioButton.Checked = true;
            }
            else
            {
                windowsPcRadioButton.Checked = true;
            }

            pcIpTextBox.Text = Settings.Default.PC_IP_Address;
            pcTimeoutTextBox.Text = Settings.Default.Timeout_S.ToString();
            pcPortTextBox.Text = Settings.Default.PC_Port.ToString();
        }

        private void testConnectionButton_Click(object sender, EventArgs e)
        {
            if(!connectionTestBackgroundWorker.IsBusy)
                connectionTestBackgroundWorker.RunWorkerAsync(new string[] { javaPcRadioButton.Checked.ToString(), pcIpTextBox.Text, pcTimeoutTextBox.Text, pcPortTextBox.Text });
        }

        private void connectionTestBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Log.Debug("Testing connection to PC.");

            IValidate validator;

            string[] args = e.Argument as string[];

            if (args != null && !string.IsNullOrEmpty(args[0]) && Boolean.Parse(args[0]))
            {
                Log.Debug("PC type is set to Java PC.");
                validator = new ValidateJava();
            }
            else
            {
                Log.Debug("PC type is set to Windows PC.");
                validator = new ValidateWindows();
            }

            if (args != null && (!string.IsNullOrEmpty(args[1]) && !string.IsNullOrEmpty(args[2])))
            {
                bool connected = validator.ConnectToPC("Policy Validator", "PV SID", "PV Username", args[1], int.Parse(args[3]), 
                    float.Parse(args[2]));

                if (connected)
                {
                    Log.Debug("Connection test successful.");
                    e.Result = true;

                    Log.Debug("Attempting to disconnect.");
                    bool disconnect = validator.DisconnectFromPC();
                    if (disconnect)
                    {
                        Log.Debug("Disconnected successfully.");
                    }
                }
                else
                {
                    Log.Debug("Connection test failed.");
                    e.Result = false;
                }
            }
            else
            {
                Log.Warn("IP Address or Timeout value is NULL.");
            }
        }

        private void connectionTestBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Result!=null && (bool)e.Result)
            {
                MessageBox.Show("Connection established successfully!", "Connection Test", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
            else if (e.Result!=null && !(bool)e.Result)
            {
                MessageBox.Show("Unable to establish connection. Verify if the PC is running and the Firewall is configured properly.", "Connection Test", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
        }

    }
}
