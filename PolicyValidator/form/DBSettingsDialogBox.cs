using System;

using System.Reflection;

using System.Windows.Forms;

using log4net;

using PolicyValidator.Properties;



namespace PolicyValidator
{

    public partial class DBSettingsDialogBox : Form
    {

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public string Host { get; set; }
        public string Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }

        public DBSettingsDialogBox()
        {
            InitializeComponent();
        }

        private void validateInput()
        {

            if (dbHost.Text.Length > 0)
            {
                Host = dbHost.Text;
            }
            else
            {
                throw new Exception("Database Host is empty.");
            }

            if (dbPort.Text.Length > 0)
            {
                Port = dbPort.Text;
            }
            else
            {
                throw new Exception("Database Port is empty.");
            }

            if (dbUser.Text.Length > 0)
            {
                User = dbUser.Text;
            }
            else
            {
                throw new Exception("Database Username is empty.");
            }

            if (dbPassword.Text.Length > 0)
            {
                Password = dbPassword.Text;
            }
            else
            {
                throw new Exception("Database Pasword is empty.");
            }

            if (dbName.Text.Length > 0)
            {
                DatabaseName = dbName.Text;
            }
            else
            {
                throw new Exception("Database Name is empty.");
            }
        }



        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                validateInput();

            }
            catch (Exception ex)
            {
                Log.Error("An error occured while saving settings. ", ex);
                MessageBox.Show("Error : " + ex.Message + " Please see the log for more details.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }

            if (!MongoDBUtil.testDatabaseConnection(dbUser.Text, dbPassword.Text, dbHost.Text, dbPort.Text, dbName.Text))
            {
                MessageBox.Show("Unable to establish connection. Verify if the database is running and the Firewall is configured properly.", "Connection Test", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                DialogResult = DialogResult.None;
            }
        }



        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void DBSettingsDialogBox_Load(object sender, EventArgs e)
        {
            dbHost.Text = Settings.Default.Database_Host.ToString();
            dbPort.Text = Settings.Default.Database_Port.ToString();
            dbUser.Text = Settings.Default.Database_User.ToString();
            dbPassword.Text = Settings.Default.Database_Password.ToString();
            dbName.Text = Settings.Default.Database_Name.ToString();
        }



        private void testConnectionButton_Click(object sender, EventArgs e)
        {
            try
            {
                validateInput();
            }
            catch (Exception ex)
            {
                Log.Error("An error occured while testing connection. ", ex);
                MessageBox.Show("Error : " + ex.Message + " Please see the log for more details.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
            if (!MongoDBUtil.testDatabaseConnection(dbUser.Text, dbPassword.Text, dbHost.Text, dbPort.Text, dbName.Text))
            {
                MessageBox.Show("Unable to establish connection. Verify if the database is running and the Firewall is configured properly.", "Connection Test", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Connection established successfully!", "Connection Test", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
            }
        }
    }
}

