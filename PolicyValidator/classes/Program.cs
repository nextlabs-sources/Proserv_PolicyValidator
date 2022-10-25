using System;

using System.Diagnostics;

using System.Linq;

using System.Reflection;

using System.Windows.Forms;

using log4net;

using System.Collections.Generic;

using System.Text;

using System.Runtime.InteropServices;





namespace PolicyValidator

{

    internal static class Program

    {

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        

        /// <summary>

        ///     The main entry point for the application.

        /// </summary>

        [STAThread]

        private static void Main()

        {

            String thisprocessname = Process.GetCurrentProcess().ProcessName;



            if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)

            {

                MessageBox.Show("Running multiple instances of Policy Validator is not supported.",

                    "Multiple Instances Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }



            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

            try

            {

                Application.Run(new PolicyValidatorForm());

            }

            catch (Exception ex)

            {

                Log.Error("An error occured. ", ex);

                MessageBox.Show("Error : " + ex.Message + " Please see the log for more details.",

                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

    }

}