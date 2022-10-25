using System;
using System.Reflection;
using System.Windows.Forms;
using log4net;
using log4net.Core;

namespace PolicyValidator
{
    public partial class LogLevel : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public LogLevel()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (infoRadioButton.Checked)
            {
                ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level = Level.Info;
                ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);
            }
            else
            {
                ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).Root.Level = Level.Debug;
                ((log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository()).RaiseConfigurationChanged(EventArgs.Empty);
            }

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogLevel_Load(object sender, EventArgs e)
        {
            if (((log4net.Repository.Hierarchy.Hierarchy) LogManager.GetRepository()).Root.Level == Level.Info)
            {
                infoRadioButton.Checked = true;
            }
            else
            {
                debugRadioButton.Checked = true;
            }
        }
    }
}
