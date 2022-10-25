using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CETYPE;
using com.nextlabs.destiny.sdk;
using ikvm.extensions;
using log4net;
using log4net.Config;
using PolicyValidator.Properties;
using sun.reflect.generics.tree;
using CEResource = com.nextlabs.destiny.sdk.CEResource;


namespace PolicyValidator
{
    public partial class PolicyValidatorForm : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private bool dirty;
        private bool empty;
        private bool changeSelectedNode = false;

        private TestCase previousTestCase;
        private string previousTestCasePath;

        private int _fromResourceAttributeCount;
        private int _subjectAttributeCount;
        private int _toResourceAttributeCount;

        private static int testCasesPassed = 0;
        private bool closeRequested = false;

        private Dictionary<string, EnforcementResult[]> testSetResultTable;



        public PolicyValidatorForm()
        {
            InitializeComponent();

            XmlConfigurator.Configure();
            if (!MongoDBUtil.getDatabaseClient())
            {
                MessageBox.Show("The application cannot be started because the database server cannot be connected. Please update the database details.", "Cannot connect to the database",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Log.Debug("Showing DB Settings dialog box.");

                DBSettingsDialogBox dbSettingsDialog = new DBSettingsDialogBox();
                System.Windows.Forms.DialogResult dr = dbSettingsDialog.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    Settings.Default.Database_Host = dbSettingsDialog.Host;
                    Settings.Default.Database_Port = dbSettingsDialog.Port;
                    Settings.Default.Database_User = dbSettingsDialog.User;
                    Settings.Default.Database_Password = dbSettingsDialog.Password;
                    Settings.Default.Database_Name = dbSettingsDialog.DatabaseName;
                }
                else
                {
                    if (System.Windows.Forms.Application.MessageLoop)
                    {
                        System.Windows.Forms.Application.Exit();
                    }
                    else
                    {
                        System.Environment.Exit(1);
                    }
                }
                Settings.Default.Save();
            }
            this.imageList.Images.Add("test_set_icon", ((System.Drawing.Image)(Resources.folder)));
            this.imageList.Images.Add("test_case_icon", ((System.Drawing.Image)(Resources.file)));
            this.imageList.Images.Add("root_icon", ((System.Drawing.Image)(Resources.root)));
            this.imageList.Images.SetKeyName(2, "root_icon");
            this.imageList.Images.SetKeyName(3, "test_set_icon");
            this.imageList.Images.SetKeyName(4, "test_case_icon");

            Log.Info("Policy Validator - Starting...");

            _fromResourceAttributeCount = 0;
            _toResourceAttributeCount = 0;
            _subjectAttributeCount = 0;
            testSetResultTable = new Dictionary<string, EnforcementResult[]>();
        }

        private Button returnNewAddButton(string buttonName)
        {
            Button button = new Button
                {
                    Name = buttonName,
                    Width = 23,
                    Height = 23,
                    Text = "+",
                    BackColor = System.Drawing.SystemColors.ControlDark,
                    FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                    Margin = new System.Windows.Forms.Padding(0, 1, 1, 0),
                    ForeColor = System.Drawing.SystemColors.ControlLightLight,
                    Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))),
                    Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                    TextAlign = ContentAlignment.MiddleCenter
                };
            button.FlatAppearance.BorderSize = 0;
            return button;
        }


        private CueComboBox returnNewCueComboBox(string boxName)
        {
            var comboBox = new CueComboBox()
            {
                Name = boxName,
                Width = 180,
                Height = 24,
                DropDownStyle = ComboBoxStyle.DropDown,
                Cue = "Attribute Name",
                Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))),
                Margin = new System.Windows.Forms.Padding(0, 1, 1, 0),
            };
            return comboBox;
        }

        private CueTextBox returnNewCueTextBox(string boxName)
        {
            var textField = new CueTextBox
            {
                Cue = "Attribute Value",
                Name = boxName,
                Width = 180,
                Height = 24,
                Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right))),
                Margin = new System.Windows.Forms.Padding(0, 1, 1, 0),
            };

            return textField;
        }


        private void addSubjectAttribute_Click(object sender, EventArgs e)
        {
            var addAttributeButton = sender as Button;

            if (addAttributeButton != null && addAttributeButton.Text.Equals("+"))
            {
                Log.Debug("Adding a new subject attribute.");

                subjectDynamicAttributeTable.AutoScroll = false;
                subjectDynamicAttributeTable.SuspendLayout();

                var comboBox = returnNewCueComboBox("combo" + _subjectAttributeCount);

                comboBox.TextChanged += SetStateDirty;

                comboBox.DropDown += subjectCombobox_DropDown;

                var textField = returnNewCueTextBox("text" + _subjectAttributeCount);

                comboBox.TextChanged += SetStateDirty;

                var newAddButton = returnNewAddButton("btn" + _subjectAttributeCount);

                newAddButton.Click += addSubjectAttributeHandler;

                addAttributeButton.Text = "-";
                subjectDynamicAttributeTable.Controls.Add(comboBox, 1, 0);
                subjectDynamicAttributeTable.Controls.Add(textField, 2, 0);
                subjectDynamicAttributeTable.Controls.Add(newAddButton, 0, 1);

                subjectDynamicAttributeTable.RowCount = 2;
                subjectDynamicAttributeTable.RowStyles.Add(new RowStyle());
                subjectDynamicAttributeTable.VerticalScroll.Value = subjectDynamicAttributeTable.VerticalScroll.Maximum;
                subjectDynamicAttributeTable.AutoScroll = true;
                subjectDynamicAttributeTable.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
                subjectDynamicAttributeTable.ResumeLayout();

                subjectDynamicAttributeTable.ScrollControlIntoView(newAddButton);

                _subjectAttributeCount++;
            }
            else if (addAttributeButton != null && addAttributeButton.Text.Equals("-"))
            {
                Log.Debug("Removing subject attribute at index 0.");

                subjectDynamicAttributeTable.AutoScroll = false;
                subjectDynamicAttributeTable.SuspendLayout();

                const int index = 0;

                var combo = (ComboBox)subjectDynamicAttributeTable.Controls.Find("combo" + index, true)[0];
                var text = (TextBox)subjectDynamicAttributeTable.Controls.Find("text" + index, true)[0];
                var btn = (Button)subjectDynamicAttributeTable.Controls.Find("btn" + index, true)[0];

                subjectDynamicAttributeTable.ScrollControlIntoView(addAttributeButton);

                subjectDynamicAttributeTable.Controls.Remove(combo);
                subjectDynamicAttributeTable.Controls.Remove(text);
                subjectDynamicAttributeTable.Controls.Remove(btn);
                UpdateTableLayout(subjectDynamicAttributeTable, index, ref _subjectAttributeCount);
                subjectDynamicAttributeTable.RowStyles.RemoveAt(0);
                subjectDynamicAttributeTable.RowCount--;

                subjectDynamicAttributeTable.VerticalScroll.Value = subjectDynamicAttributeTable.VerticalScroll.Maximum;
                subjectDynamicAttributeTable.AutoScroll = true;
                subjectDynamicAttributeTable.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
                subjectDynamicAttributeTable.ResumeLayout();

                _subjectAttributeCount--;
            }

            SetTableLayoutRowSize(subjectDynamicAttributeTable, 26);
        }


        private void addSubjectAttributeHandler(object sender, EventArgs e)
        {
            var addAttributeButton = sender as Button;

            if (addAttributeButton != null && addAttributeButton.Text.Equals("+"))
            {
                Log.Debug("Adding a new subject attribute.");

                subjectDynamicAttributeTable.AutoScroll = false;
                subjectDynamicAttributeTable.SuspendLayout();

                var comboBox = returnNewCueComboBox("combo" + _subjectAttributeCount);

                comboBox.TextChanged += SetStateDirty;

                comboBox.DropDown += subjectCombobox_DropDown;

                var textField = returnNewCueTextBox("text" + _subjectAttributeCount);

                textField.TextChanged += SetStateDirty;

                var newAddButton = returnNewAddButton("btn" + _subjectAttributeCount);

                newAddButton.Click += addSubjectAttributeHandler;

                addAttributeButton.Text = "-";

                subjectDynamicAttributeTable.Controls.Add(comboBox, 1, _subjectAttributeCount);
                subjectDynamicAttributeTable.Controls.Add(textField, 2, _subjectAttributeCount);
                subjectDynamicAttributeTable.Controls.Add(newAddButton, 0, _subjectAttributeCount + 1);

                subjectDynamicAttributeTable.RowCount = _subjectAttributeCount + 2;
                subjectDynamicAttributeTable.RowStyles.Add(new RowStyle());
                subjectDynamicAttributeTable.VerticalScroll.Value = subjectDynamicAttributeTable.VerticalScroll.Maximum;
                subjectDynamicAttributeTable.AutoScroll = true;
                subjectDynamicAttributeTable.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
                subjectDynamicAttributeTable.ResumeLayout();

                subjectDynamicAttributeTable.ScrollControlIntoView(newAddButton);

                _subjectAttributeCount++;
            }
            else if (addAttributeButton != null && addAttributeButton.Text.Equals("-"))
            {
                subjectDynamicAttributeTable.AutoScroll = false;
                subjectDynamicAttributeTable.SuspendLayout();

                string buttonName = addAttributeButton.Name;
                buttonName = buttonName.Replace("btn", "");
                int index = int.Parse(buttonName);

                index++;

                Log.Debug("Removing subject attribute at index " + index + ".");

                var combo = (ComboBox)subjectDynamicAttributeTable.Controls.Find("combo" + index, true)[0];
                var text = (TextBox)subjectDynamicAttributeTable.Controls.Find("text" + index, true)[0];

                subjectDynamicAttributeTable.ScrollControlIntoView(addAttributeButton);

                subjectDynamicAttributeTable.Controls.Remove(combo);
                subjectDynamicAttributeTable.Controls.Remove(text);
                subjectDynamicAttributeTable.Controls.Remove(addAttributeButton);
                subjectDynamicAttributeTable.RowStyles.RemoveAt(index);
                UpdateTableLayout(subjectDynamicAttributeTable, index, ref _subjectAttributeCount);
                subjectDynamicAttributeTable.RowCount--;

                subjectDynamicAttributeTable.VerticalScroll.Value = subjectDynamicAttributeTable.VerticalScroll.Maximum;
                subjectDynamicAttributeTable.AutoScroll = true;
                subjectDynamicAttributeTable.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
                subjectDynamicAttributeTable.ResumeLayout();

                _subjectAttributeCount--;
            }

            SetTableLayoutRowSize(subjectDynamicAttributeTable, 26);
        }



        private void addFromResourceAttribute_Click(object sender, EventArgs e)
        {
            var addAttributeButton = sender as Button;

            if (addAttributeButton != null && addAttributeButton.Text.Equals("+"))
            {
                Log.Debug("Adding a new from resource attribute.");

                fromResourceDynamicAttributeTable.AutoScroll = false;
                fromResourceDynamicAttributeTable.SuspendLayout();

                var comboBox = returnNewCueComboBox("combo" + _fromResourceAttributeCount);

                comboBox.TextChanged += SetStateDirty;

                comboBox.DropDown += resourceCombobox_DropDown;

                var textField = returnNewCueTextBox("text" + _fromResourceAttributeCount);

                textField.TextChanged += SetStateDirty;

                var newAddButton = returnNewAddButton("btn" + _fromResourceAttributeCount);

                newAddButton.Click += addFromResourceAttributeHandler;

                addAttributeButton.Text = "-";

                fromResourceDynamicAttributeTable.Controls.Add(comboBox, 1, 0);
                fromResourceDynamicAttributeTable.Controls.Add(textField, 2, 0);
                fromResourceDynamicAttributeTable.Controls.Add(newAddButton, 0, 1);

                fromResourceDynamicAttributeTable.RowCount = 2;
                fromResourceDynamicAttributeTable.RowStyles.Add(new RowStyle());
                fromResourceDynamicAttributeTable.VerticalScroll.Value = fromResourceDynamicAttributeTable.VerticalScroll.Maximum;
                fromResourceDynamicAttributeTable.AutoScroll = true;
                fromResourceDynamicAttributeTable.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
                fromResourceDynamicAttributeTable.ResumeLayout();

                fromResourceDynamicAttributeTable.ScrollControlIntoView(newAddButton);

                _fromResourceAttributeCount++;
            }
            else if (addAttributeButton != null && addAttributeButton.Text.Equals("-"))
            {
                Log.Debug("Removing from resource attribute at index 0.");

                fromResourceDynamicAttributeTable.AutoScroll = false;
                fromResourceDynamicAttributeTable.SuspendLayout();

                const int index = 0;
                var combo = (ComboBox)fromResourceDynamicAttributeTable.Controls.Find("combo" + index, true)[0];
                var text = (TextBox)fromResourceDynamicAttributeTable.Controls.Find("text" + index, true)[0];
                var btn = (Button)fromResourceDynamicAttributeTable.Controls.Find("btn" + index, true)[0];

                fromResourceDynamicAttributeTable.ScrollControlIntoView(addAttributeButton);

                fromResourceDynamicAttributeTable.Controls.Remove(combo);
                fromResourceDynamicAttributeTable.Controls.Remove(text);
                fromResourceDynamicAttributeTable.Controls.Remove(btn);
                UpdateTableLayout(fromResourceDynamicAttributeTable, index, ref _fromResourceAttributeCount);
                fromResourceDynamicAttributeTable.RowStyles.RemoveAt(0);
                fromResourceDynamicAttributeTable.RowCount--;

                fromResourceDynamicAttributeTable.VerticalScroll.Value = fromResourceDynamicAttributeTable.VerticalScroll.Maximum;
                fromResourceDynamicAttributeTable.AutoScroll = true;
                fromResourceDynamicAttributeTable.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
                fromResourceDynamicAttributeTable.ResumeLayout();

                _fromResourceAttributeCount--;
            }

            SetTableLayoutRowSize(fromResourceDynamicAttributeTable, 26);
        }



        private void addFromResourceAttributeHandler(object sender, EventArgs e)
        {
            var addAttributeButton = sender as Button;

            if (addAttributeButton != null && addAttributeButton.Text.Equals("+"))
            {
                Log.Debug("Adding a new from resource attribute.");

                fromResourceDynamicAttributeTable.AutoScroll = false;
                fromResourceDynamicAttributeTable.SuspendLayout();

                var comboBox = returnNewCueComboBox("combo" + _fromResourceAttributeCount);

                comboBox.TextChanged += SetStateDirty;

                comboBox.DropDown += resourceCombobox_DropDown;

                var textField = returnNewCueTextBox("text" + _fromResourceAttributeCount);

                textField.TextChanged += SetStateDirty;

                var newAddButton = returnNewAddButton("btn" + _fromResourceAttributeCount);

                newAddButton.Click += addFromResourceAttributeHandler;

                addAttributeButton.Text = "-";

                fromResourceDynamicAttributeTable.Controls.Add(comboBox, 1, _fromResourceAttributeCount);
                fromResourceDynamicAttributeTable.Controls.Add(textField, 2, _fromResourceAttributeCount);
                fromResourceDynamicAttributeTable.Controls.Add(newAddButton, 0, _fromResourceAttributeCount + 1);

                fromResourceDynamicAttributeTable.RowCount = _fromResourceAttributeCount + 2;
                fromResourceDynamicAttributeTable.RowStyles.Add(new RowStyle());
                fromResourceDynamicAttributeTable.VerticalScroll.Value = fromResourceDynamicAttributeTable.VerticalScroll.Maximum;
                fromResourceDynamicAttributeTable.AutoScroll = true;
                fromResourceDynamicAttributeTable.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
                fromResourceDynamicAttributeTable.ResumeLayout();

                fromResourceDynamicAttributeTable.ScrollControlIntoView(newAddButton);

                _fromResourceAttributeCount++;
            }
            else if (addAttributeButton != null && addAttributeButton.Text.Equals("-"))
            {
                fromResourceDynamicAttributeTable.AutoScroll = false;
                fromResourceDynamicAttributeTable.SuspendLayout();

                string buttonName = addAttributeButton.Name;
                buttonName = buttonName.Replace("btn", "");
                int index = int.Parse(buttonName);

                index++;

                Log.Debug("Removing from resource attribute at " + index + ".");

                var combo = (ComboBox)fromResourceDynamicAttributeTable.Controls.Find("combo" + index, true)[0];
                var text = (TextBox)fromResourceDynamicAttributeTable.Controls.Find("text" + index, true)[0];

                fromResourceDynamicAttributeTable.ScrollControlIntoView(addAttributeButton);

                fromResourceDynamicAttributeTable.Controls.Remove(combo);
                fromResourceDynamicAttributeTable.Controls.Remove(text);
                fromResourceDynamicAttributeTable.Controls.Remove(addAttributeButton);
                fromResourceDynamicAttributeTable.RowStyles.RemoveAt(index);
                UpdateTableLayout(fromResourceDynamicAttributeTable, index, ref _fromResourceAttributeCount);
                fromResourceDynamicAttributeTable.RowCount--;

                fromResourceDynamicAttributeTable.VerticalScroll.Value = fromResourceDynamicAttributeTable.VerticalScroll.Maximum;
                fromResourceDynamicAttributeTable.AutoScroll = true;
                fromResourceDynamicAttributeTable.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
                fromResourceDynamicAttributeTable.ResumeLayout();

                _fromResourceAttributeCount--;
            }

            SetTableLayoutRowSize(fromResourceDynamicAttributeTable, 26);
        }


        private void addToResourceAttribute_Click(object sender, EventArgs e)
        {
            var addAttributeButton = sender as Button;

            if (addAttributeButton != null && addAttributeButton.Text.Equals("+"))
            {
                Log.Debug("Adding a new to resource attribute.");

                toResourceDynamicAttributeTable.AutoScroll = false;
                toResourceDynamicAttributeTable.SuspendLayout();

                var comboBox = returnNewCueComboBox("combo" + _toResourceAttributeCount);

                comboBox.TextChanged += SetStateDirty;

                comboBox.DropDown += resourceCombobox_DropDown;

                var textField = returnNewCueTextBox("text" + _toResourceAttributeCount);

                textField.TextChanged += SetStateDirty;

                var newAddButton = returnNewAddButton("btn" + _toResourceAttributeCount);

                newAddButton.Click += addToResourceAttributeHandler;

                addAttributeButton.Text = "-";

                toResourceDynamicAttributeTable.Controls.Add(comboBox, 1, 0);
                toResourceDynamicAttributeTable.Controls.Add(textField, 2, 0);
                toResourceDynamicAttributeTable.Controls.Add(newAddButton, 0, 1);

                toResourceDynamicAttributeTable.RowCount = 2;
                toResourceDynamicAttributeTable.RowStyles.Add(new RowStyle());
                toResourceDynamicAttributeTable.VerticalScroll.Value = toResourceDynamicAttributeTable.VerticalScroll.Maximum;
                toResourceDynamicAttributeTable.AutoScroll = true;
                toResourceDynamicAttributeTable.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
                toResourceDynamicAttributeTable.ResumeLayout();

                toResourceDynamicAttributeTable.ScrollControlIntoView(addAttributeButton);

                _toResourceAttributeCount++;
            }
            else if (addAttributeButton != null && addAttributeButton.Text.Equals("-"))
            {
                Log.Debug("Removing to resource attribute at index 0.");

                toResourceDynamicAttributeTable.AutoScroll = false;
                toResourceDynamicAttributeTable.SuspendLayout();

                const int index = 0;

                var combo = (ComboBox)toResourceDynamicAttributeTable.Controls.Find("combo" + index, true)[0];
                var text = (TextBox)toResourceDynamicAttributeTable.Controls.Find("text" + index, true)[0];
                var btn = (Button)toResourceDynamicAttributeTable.Controls.Find("btn" + index, true)[0];

                toResourceDynamicAttributeTable.ScrollControlIntoView(addAttributeButton);

                toResourceDynamicAttributeTable.Controls.Remove(combo);
                toResourceDynamicAttributeTable.Controls.Remove(text);
                toResourceDynamicAttributeTable.Controls.Remove(btn);
                UpdateTableLayout(toResourceDynamicAttributeTable, index, ref _toResourceAttributeCount);
                toResourceDynamicAttributeTable.RowStyles.RemoveAt(0);
                toResourceDynamicAttributeTable.RowCount--;

                toResourceDynamicAttributeTable.VerticalScroll.Value = toResourceDynamicAttributeTable.VerticalScroll.Maximum;
                toResourceDynamicAttributeTable.AutoScroll = true;
                toResourceDynamicAttributeTable.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
                toResourceDynamicAttributeTable.ResumeLayout();

                _toResourceAttributeCount--;
            }

            SetTableLayoutRowSize(toResourceDynamicAttributeTable, 26);
        }



        private void addToResourceAttributeHandler(object sender, EventArgs e)
        {
            var addAttributeButton = sender as Button;

            if (addAttributeButton != null && addAttributeButton.Text.Equals("+"))
            {
                Log.Debug("Adding a new to resource attribute.");

                toResourceDynamicAttributeTable.AutoScroll = false;
                toResourceDynamicAttributeTable.SuspendLayout();

                var comboBox = returnNewCueComboBox("combo" + _toResourceAttributeCount);

                comboBox.TextChanged += SetStateDirty;

                comboBox.DropDown += resourceCombobox_DropDown;

                var textField = returnNewCueTextBox("text" + _toResourceAttributeCount);

                textField.TextChanged += SetStateDirty;

                var newAddButton = returnNewAddButton("btn" + _toResourceAttributeCount);

                newAddButton.Click += addToResourceAttributeHandler;

                addAttributeButton.Text = "-";

                toResourceDynamicAttributeTable.Controls.Add(comboBox, 1, _toResourceAttributeCount);
                toResourceDynamicAttributeTable.Controls.Add(textField, 2, _toResourceAttributeCount);
                toResourceDynamicAttributeTable.Controls.Add(newAddButton, 0, _toResourceAttributeCount + 1);

                toResourceDynamicAttributeTable.RowCount = _toResourceAttributeCount + 2;
                toResourceDynamicAttributeTable.RowStyles.Add(new RowStyle());
                toResourceDynamicAttributeTable.VerticalScroll.Value = toResourceDynamicAttributeTable.VerticalScroll.Maximum;
                toResourceDynamicAttributeTable.AutoScroll = true;
                toResourceDynamicAttributeTable.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
                toResourceDynamicAttributeTable.ResumeLayout();

                toResourceDynamicAttributeTable.ScrollControlIntoView(newAddButton);

                _toResourceAttributeCount++;
            }
            else if (addAttributeButton != null && addAttributeButton.Text.Equals("-"))
            {
                toResourceDynamicAttributeTable.AutoScroll = false;
                toResourceDynamicAttributeTable.SuspendLayout();

                string buttonName = addAttributeButton.Name;
                buttonName = buttonName.Replace("btn", "");
                int index = int.Parse(buttonName);

                index++;

                Log.Debug("Removing to resource attribute at index " + index + ".");

                var combo = (ComboBox)toResourceDynamicAttributeTable.Controls.Find("combo" + index, true)[0];
                var text = (TextBox)toResourceDynamicAttributeTable.Controls.Find("text" + index, true)[0];

                toResourceDynamicAttributeTable.ScrollControlIntoView(addAttributeButton);

                toResourceDynamicAttributeTable.Controls.Remove(combo);
                toResourceDynamicAttributeTable.Controls.Remove(text);
                toResourceDynamicAttributeTable.Controls.Remove(addAttributeButton);
                toResourceDynamicAttributeTable.RowStyles.RemoveAt(index);
                UpdateTableLayout(toResourceDynamicAttributeTable, index, ref _toResourceAttributeCount);
                toResourceDynamicAttributeTable.RowCount--;

                toResourceDynamicAttributeTable.VerticalScroll.Value = toResourceDynamicAttributeTable.VerticalScroll.Maximum;
                toResourceDynamicAttributeTable.AutoScroll = true;
                toResourceDynamicAttributeTable.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
                toResourceDynamicAttributeTable.ResumeLayout();

                _toResourceAttributeCount--;
            }

            SetTableLayoutRowSize(toResourceDynamicAttributeTable, 26);
        }


        private static void UpdateTableLayout(TableLayoutPanel layoutPanel, int deletedIndex, ref int count)
        {
            Log.Debug("Deleted row at " + deletedIndex + " in " + layoutPanel.Name + ". Updating layout");

            foreach (Control p in layoutPanel.Controls)
            {
                if (p is TextBox)
                {
                    string name = p.Name;
                    name = name.Replace("text", "");
                    int index = int.Parse(name);
                    if (index <= deletedIndex) continue;
                    index--;
                    layoutPanel.SetRow(p, index);
                    layoutPanel.SetColumn(p, 2);
                    p.Name = "text" + (index);
                }
                else if (p is ComboBox)
                {
                    string name = p.Name;
                    name = name.Replace("combo", "");
                    int index = int.Parse(name);
                    if (index <= deletedIndex) continue;
                    index--;
                    layoutPanel.SetRow(p, index);
                    layoutPanel.SetColumn(p, 1);
                    p.Name = "combo" + (index);
                }
                else if (p is Button)
                {
                    string name = p.Name;
                    if (!name.Equals("addSubjectAttribute") && !name.Equals("addFromResourceAttribute") &&
                        !name.Equals("addToResourceAttribute"))
                    {
                        name = name.Replace("btn", "");
                        int index = int.Parse(name);
                        if (index < deletedIndex) continue;
                        layoutPanel.SetRow(p, index);
                        layoutPanel.SetColumn(p, 0);
                        index--;
                        p.Name = "btn" + (index);
                    }
                    else
                    {
                        if (count == 1)
                        {
                            p.Text = "+";
                        }
                    }
                }
            }
        }


        private static void SetTableLayoutRowSize(TableLayoutPanel layoutPanel, int rowHeight)
        {
            Log.Debug("Setting row height for " + layoutPanel.Name + " to " + rowHeight);
            int rowStyles = layoutPanel.RowStyles.Count;
            for (int i = 0; i < rowStyles; i++)
            {
                layoutPanel.RowStyles[i].Height = rowHeight;
            }
        }


        private IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }


        private void PolicyValidatorForm_Load(object sender, EventArgs e)
        {
            Log.Debug("Loading main form.");

            string logFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Nextlabs\\Logs");
            string rootFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Nextlabs\\Root");

            if (!Directory.Exists(logFolderPath))
                Directory.CreateDirectory(logFolderPath);

            if (!Directory.Exists(rootFolderPath))
                Directory.CreateDirectory(rootFolderPath);

            this.Size = new Size(900, 720);

            Util.PopulateTreeViewFromDatabase(treeView);
            treeView.SelectedNode = treeView.Nodes[0];

            Log.Debug("Node 0 of the tree is: " + treeView.Nodes[0].Tag.ToString());

            connectionStatusBackgroundWorker.RunWorkerAsync();

            ShowIntroPanel();
            introRichTextBox.LoadFile("Resources\\Readme.rtf");

            dirty = false;
            empty = false;
        }


        private void SaveForm()
        {
            try
            {
                ValidateForm();
                TestCase tc = GenerateTestCaseFromForm();

                var result = MongoDBUtil.UpdateTestCase(tc, tc.Name).Result;
                if (!result)
                {
                    throw new Exception("Failed to save test case");
                }

                dirty = false;
                empty = false;
            }

            catch (Exception ex)
            {
                Log.Error("An error occured while saving Test Case. ", ex);
                MessageBox.Show(ex.Message,
                    "Cannot Save Test Case", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void saveTestCaseButton_Click(object sender, EventArgs e)
        {
            SaveForm();
        }



        private void ValidateForm()
        {
            if (subjectUsernameTextbox.Text == string.Empty)
            {
                throw new Exception("Some of the mandatory fields are empty. Please fill in the mandatory fields and try again.");
            }

            if (subjectSIDTextbox.Text == string.Empty)
            {
                throw new Exception("Some of the mandatory fields are empty. Please fill in the mandatory fields and try again.");
            }

            if (subjectApplicationName.Text == string.Empty)
            {
                throw new Exception("Some of the mandatory fields are empty. Please fill in the mandatory fields and try again.");
            }

            if (subjectIpAddress.Text == string.Empty)
            {
                throw new Exception("Some of the mandatory fields are empty. Please fill in the mandatory fields and try again.");
            }

            if (actionCombobox.Text == string.Empty)
            {
                throw new Exception("Some of the mandatory fields are empty. Please fill in the mandatory fields and try again.");
            }

            if (fromResourceNameTextbox.Text == string.Empty)
            {
                throw new Exception("Some of the mandatory fields are empty. Please fill in the mandatory fields and try again.");
            }

            foreach (Control p in subjectDynamicAttributeTable.Controls)
            {
                if (p is ComboBox)
                {
                    string index = p.Name.Replace("combo", "").Trim();
                    string valueTextBoxName = "text" + index;

                    string key = p.Text;

                    if (string.IsNullOrEmpty(key))
                    {
                        throw new Exception("Some of the Subject Attribute fields are empty. Please fill in all the Subject Attribute fields and try again.");
                    }

                    Control[] controls = subjectDynamicAttributeTable.Controls.Find(valueTextBoxName, true);
                    if (controls != null)
                    {
                        TextBox valueTextBox = controls[0] as TextBox;
                        if (valueTextBox.Text == string.Empty)
                        {
                            throw new Exception("Value of the Subject Attribute '" + key + "'  is empty. Please fill in a suitable value and try again.");
                        }
                    }
                }
            }


            foreach (Control p in fromResourceDynamicAttributeTable.Controls)
            {
                if (p is ComboBox)
                {
                    string index = p.Name.Replace("combo", "").Trim();
                    string valueTextBoxName = "text" + index;

                    string key = p.Text;

                    if (string.IsNullOrEmpty(key))
                    {
                        throw new Exception("Some of the From Resource Attribute fields are empty. Please fill in all the From Resource Attribute fields and try again.");
                    }

                    foreach (Control t in fromResourceDynamicAttributeTable.Controls)
                    {
                        if (t is TextBox && t != null && t.Name == valueTextBoxName)
                        {
                            TextBox valueTextBox = t as TextBox;
                            if (valueTextBox.Text == string.Empty)
                            {
                                throw new Exception("Value for From Resource Attribute '" + key + "' is empty. Please fill in a suitable value and try again.");
                            }
                        }
                    }
                }
            }

            foreach (Control p in toResourceDynamicAttributeTable.Controls)
            {
                if (p is ComboBox)
                {
                    string index = p.Name.Replace("combo", "").Trim();
                    string valueTextBoxName = "text" + index;

                    string key = p.Text;

                    if (string.IsNullOrEmpty(key))
                    {
                        throw new Exception("Some of the To Resource Attribute fields are empty. Please fill in all the To Resource Attribute fields and try again.");
                    }

                    Control[] controls = subjectDynamicAttributeTable.Controls.Find(valueTextBoxName, true);
                    if (controls != null && controls.Count() > 0)
                    {
                        TextBox valueTextBox = controls[0] as TextBox;
                        if (valueTextBox.Text == string.Empty)
                        {
                            throw new Exception("Value for To Resource Attribute '" + key + "'  is empty. Please fill in a suitable value and try again.");
                        }
                    }
                }
            }
        }



        private void refreshButton_Click(object sender, EventArgs e)
        {
            Util.PopulateTreeViewFromDatabase(treeView);
            UpdateForm();
        }



        private void AddSubjectAttributeLine(string key, string value)
        {
            subjectDynamicAttributeTable.AutoScroll = false;
            subjectDynamicAttributeTable.SuspendLayout();

            var combo = returnNewCueComboBox("combo" + _subjectAttributeCount);

            combo.DropDown += subjectCombobox_DropDown;

            var text = returnNewCueTextBox("text" + _subjectAttributeCount);

            var btn = returnNewAddButton("btn" + _subjectAttributeCount);

            btn.Click += addSubjectAttributeHandler;
            addSubjectAttribute.Text = "-";

            subjectDynamicAttributeTable.Controls.Add(combo, 1, _subjectAttributeCount);
            subjectDynamicAttributeTable.Controls.Add(text, 2, _subjectAttributeCount);
            subjectDynamicAttributeTable.Controls.Add(btn, 0, _subjectAttributeCount + 1);

            subjectDynamicAttributeTable.RowCount = _subjectAttributeCount + 2;
            subjectDynamicAttributeTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 26));

            if (_subjectAttributeCount == 0)
            {
                addSubjectAttribute.Text = "-";
            }
            else
            {
                subjectDynamicAttributeTable.Controls.Find("btn" + (_subjectAttributeCount - 1), true)[0].Text = "-";
            }

            subjectDynamicAttributeTable.AutoScroll = true;
            subjectDynamicAttributeTable.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);

            subjectDynamicAttributeTable.ResumeLayout();

            _subjectAttributeCount++;
        }


        private void ClearSubjectAttributes()
        {
            subjectDynamicAttributeTable.AutoScroll = false;
            subjectDynamicAttributeTable.SuspendLayout();

            var list = new ArrayList(subjectDynamicAttributeTable.Controls);
            foreach (Control con in list)
            {
                if (con.Name.Equals("addSubjectAttribute"))
                {
                    con.Text = "+";
                }
                else
                {
                    subjectDynamicAttributeTable.Controls.Remove(con);
                    con.Dispose();
                }
            }

            _subjectAttributeCount = 0;
            subjectDynamicAttributeTable.AutoScroll = true;
            subjectDynamicAttributeTable.ResumeLayout();
        }


        private void AddFromResourceAttributeLine(string key, string value)
        {
            fromResourceDynamicAttributeTable.AutoScroll = false;
            fromResourceDynamicAttributeTable.SuspendLayout();

            var combo = returnNewCueComboBox("combo" + _fromResourceAttributeCount);

            combo.DropDown += resourceCombobox_DropDown;

            var text = returnNewCueTextBox("text" + _fromResourceAttributeCount);

            var btn = returnNewAddButton("btn" + _fromResourceAttributeCount);

            btn.Click += addFromResourceAttributeHandler;

            addFromResourceAttribute.Text = "-";

            fromResourceDynamicAttributeTable.Controls.Add(combo, 1, _fromResourceAttributeCount);
            fromResourceDynamicAttributeTable.Controls.Add(text, 2, _fromResourceAttributeCount);
            fromResourceDynamicAttributeTable.Controls.Add(btn, 0, _fromResourceAttributeCount + 1);

            fromResourceDynamicAttributeTable.RowCount = _fromResourceAttributeCount + 2;
            fromResourceDynamicAttributeTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 26));

            if (_fromResourceAttributeCount == 0)
            {
                addFromResourceAttribute.Text = "-";
            }
            else
            {
                fromResourceDynamicAttributeTable.Controls.Find("btn" + (_fromResourceAttributeCount - 1), true)[0].Text = "-";
            }

            fromResourceDynamicAttributeTable.AutoScroll = true;
            fromResourceDynamicAttributeTable.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);

            fromResourceDynamicAttributeTable.ResumeLayout();

            _fromResourceAttributeCount++;
        }


        private void ClearFromResourceAttributes()
        {
            fromResourceDynamicAttributeTable.AutoScroll = false;
            fromResourceDynamicAttributeTable.SuspendLayout();

            var list = new ArrayList(fromResourceDynamicAttributeTable.Controls);
            foreach (Control con in list)
            {
                if (con.Name.Equals("addFromResourceAttribute"))
                {
                    con.Text = "+";
                }
                else
                {
                    fromResourceDynamicAttributeTable.Controls.Remove(con);
                    con.Dispose();
                }
            }

            _fromResourceAttributeCount = 0;
            fromResourceDynamicAttributeTable.AutoScroll = true;
            fromResourceDynamicAttributeTable.ResumeLayout();
        }


        private void AddToResourceAttributeLine(string key, string value)
        {
            toResourceDynamicAttributeTable.AutoScroll = false;
            toResourceDynamicAttributeTable.SuspendLayout();

            var combo = returnNewCueComboBox("combo" + _toResourceAttributeCount);

            combo.DropDown += resourceCombobox_DropDown;

            var text = returnNewCueTextBox("text" + _toResourceAttributeCount);

            var btn = returnNewAddButton("btn" + _toResourceAttributeCount);
            btn.Click += addToResourceAttributeHandler;
            addToResourceAttribute.Text = "-";

            toResourceDynamicAttributeTable.Controls.Add(combo, 1, _toResourceAttributeCount);
            toResourceDynamicAttributeTable.Controls.Add(text, 2, _toResourceAttributeCount);
            toResourceDynamicAttributeTable.Controls.Add(btn, 0, _toResourceAttributeCount + 1);

            toResourceDynamicAttributeTable.RowCount = _toResourceAttributeCount + 2;
            toResourceDynamicAttributeTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 26));

            if (_toResourceAttributeCount == 0)
            {
                addToResourceAttribute.Text = "-";
            }
            else
            {
                toResourceDynamicAttributeTable.Controls.Find("btn" + (_toResourceAttributeCount - 1), true)[0].Text = "-";
            }

            toResourceDynamicAttributeTable.AutoScroll = true;
            toResourceDynamicAttributeTable.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);

            toResourceDynamicAttributeTable.ResumeLayout();

            _toResourceAttributeCount++;
        }



        private void ClearToResourceAttributes()
        {
            toResourceDynamicAttributeTable.AutoScroll = false;
            toResourceDynamicAttributeTable.SuspendLayout();

            var list = new ArrayList(toResourceDynamicAttributeTable.Controls);
            foreach (Control con in list)
            {
                if (con.Name.Equals("addToResourceAttribute"))
                {
                    con.Text = "+";
                }
                else
                {
                    toResourceDynamicAttributeTable.Controls.Remove(con);
                    con.Dispose();
                }
            }

            _toResourceAttributeCount = 0;
            toResourceDynamicAttributeTable.AutoScroll = true;
            toResourceDynamicAttributeTable.ResumeLayout();
        }

        private void HideRecipientsSection()
        {
            if (testCaseTableLayout.RowStyles[8].Height > 0)
            {
                testCaseTableLayout.Height -= 73;
            }
            testCaseTableLayout.RowStyles[8].Height = 0;
            testCaseTableLayout.RowStyles[9].Height = 0;
            recipientsHeaderLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            testCasePanel.Refresh();
            this.Refresh();
        }

        private void ShowRecipientsSection()
        {
            if (testCaseTableLayout.RowStyles[8].Height == 0)
            {
                testCaseTableLayout.Height += 73;
            }
            testCaseTableLayout.RowStyles[8].Height = 32;
            testCaseTableLayout.RowStyles[9].Height = 40;
            recipientsHeaderLabel.BackColor = System.Drawing.Color.SteelBlue;
            testCasePanel.Refresh();
            this.Refresh();
        }

        private void HideToResourceSection()
        {
            if (testCaseTableLayout.RowStyles[12].Height > 0)
            {
                testCaseTableLayout.Height -= 186;
            }
            testCaseTableLayout.RowStyles[12].Height = 0;
            testCaseTableLayout.RowStyles[13].Height = 0;
            toResourceHeaderLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            testCasePanel.Refresh();
            this.Refresh();
        }

        private void ShowToResourceSection()
        {
            if (testCaseTableLayout.RowStyles[12].Height == 0)
            {
                testCaseTableLayout.Height += 186;
            }
            testCaseTableLayout.RowStyles[12].Height = 32;
            testCaseTableLayout.RowStyles[13].Height = 154;
            toResourceHeaderLabel.BackColor = System.Drawing.Color.SteelBlue;
            testCasePanel.Refresh();
            this.Refresh();
        }

        private void HideEmailDetailsSection()
        {
            if (testCaseTableLayout.RowStyles[14].Height > 0)
            {
                testCaseTableLayout.Height -= 182;
            }
            testCaseTableLayout.RowStyles[14].Height = 0;
            testCaseTableLayout.RowStyles[15].Height = 0;
            emailDetailsHeaderLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            testCasePanel.Refresh();
            this.Refresh();
        }

        private void ShowEmailDetailsSection()
        {
            if (testCaseTableLayout.RowStyles[14].Height == 0)
            {
                testCaseTableLayout.Height += 182;
            }
            testCaseTableLayout.RowStyles[14].Height = 32;
            testCaseTableLayout.RowStyles[15].Height = 150;
            emailDetailsHeaderLabel.BackColor = System.Drawing.Color.SteelBlue;
            testCasePanel.Refresh();
            this.Refresh();
        }


        private void ClearTestSetTable()
        {
            testSetTablePanel.AutoScroll = false;
            testSetTablePanel.SuspendLayout();

            var list = new ArrayList(testSetTablePanel.Controls);

            foreach (
                Control con in
                    list.Cast<Control>()
                        .Where(
                            con =>
                                con.Name.StartsWith("lbl") || con.Name.StartsWith("res") ||
                                con.Name.StartsWith("expRes")))
            {
                testSetTablePanel.Controls.Remove(con);
                con.Dispose();
            }

            testSetTablePanel.AutoScroll = true;
            testSetTablePanel.ResumeLayout();

            testSetTablePanel.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
        }


        private void SetStateDirty(object sender, EventArgs e)
        {
            TextBox propertyContentTextBox = null;
            if (sender is TextBox)
            {
                propertyContentTextBox = sender as TextBox;
            }

            if (propertyContentTextBox != null)
            {
                if (propertyContentTextBox.SelectedText == propertyContentTextBox.Text && propertyContentTextBox.Text != "") return;
            }

            dirty = true;
        }



        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (changeSelectedNode)
            {
                treeView.SelectedNode = Util.LocateNode(previousTestCasePath, treeView.Nodes);
                changeSelectedNode = false;
            }

            if (IsSelectedNodeATestCase())
            {
                testCasePanel.Focus();
            }
            else if (IsSelectedNodeATestSet())
            {
                testSetPanel.Focus();
            }
        }

        private void treeView_Enter(object sender, EventArgs e)
        {
            if (IsSelectedNodeATestCase())
            {
                testCasePanel.Focus();
            }
            else if (IsSelectedNodeATestSet())
            {
                testSetPanel.Focus();
            }
        }


        public bool IsSelectedNodeRoot()
        {
            if (treeView.SelectedNode != null && treeView.SelectedNode == treeView.Nodes[0])
            {
                Log.Debug("Selected node is Root.");
                return true;
            }
            return false;
        }



        public bool IsSelectedNodeATestCase()
        {
            if (treeView.SelectedNode != null && treeView.SelectedNode.Tag.Equals("Test Case"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool IsSelectedNodeATestSet()
        {
            if (treeView.SelectedNode != null && treeView.SelectedNode != treeView.Nodes[0])
            {
                if (treeView.SelectedNode.Tag.Equals("Test Set"))
                {
                    return true;
                }
            }
            return false;
        }


        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Log.Debug("Mouse click registered on node : " + e.Node.FullPath);

            if (e.Button == MouseButtons.Right)
            {
                treeView.SelectedNode = treeView.GetNodeAt(e.X, e.Y);
            }

            if (previousTestCase != null && e.Node.FullPath == previousTestCasePath)
            {
                return;
            }

            bool cancel = false;

            try
            {
                if (!string.IsNullOrEmpty(previousTestCasePath) && previousTestCase != null && e.Node.FullPath != previousTestCasePath)
                {
                    // if the current node is a test case and the test case form contains some empty mandatory fields, shows confirm dialog to save the incompleted test case in the database
                    if (GenerateTestCaseFromForm().IsIncomplete())
                    {
                        DialogResult dr = MessageBox.Show("Some of the mandatory fields are empty. The incompleted test case will be saved but will not be validated when running test set. Do you want to continue?",
                            "Incomplete Test Case", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            TestCase tc = GenerateTestCaseFromForm();
                            var result = MongoDBUtil.UpdateTestCase(tc, tc.Name).Result;

                            if (!result)
                            {
                                throw new Exception("Failed to update test case in the database");
                            }
                            cancel = false;
                            dirty = false;
                        }
                        else
                        {
                            Log.Debug("Remain at " + previousTestCasePath);
                            changeSelectedNode = true;
                            treeView.SelectedNode = Util.LocateNode(previousTestCasePath, treeView.Nodes);
                            cancel = true;
                        }
                    }

                    // if the current node is a test case and the test case form contains some unsaved changes, shows confirm dialog to save the test case
                    else if (dirty)
                    {
                        DialogResult dr = MessageBox.Show("The current Test Case has some unsaved changes. Do you want to save? ", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            SaveForm();
                        }
                        cancel = false;
                        dirty = false;

                    }
                }

                testSetBackgroundWorker.CancelAsync();
                testSetLoader.CancelAsync();
                testCaseBackgroundWorker.CancelAsync();

                statusIndicatorLabel.BackColor = Color.Transparent;
                statusLabel.Text = "";

                runTestSetButton.Enabled = true;
                runTestSetButton.BackColor = System.Drawing.Color.MediumSeaGreen;
                validateTestCaseButton.Enabled = true;
                validateTestCaseButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
                validateTestCaseButton.BackColor = System.Drawing.Color.MediumSeaGreen;

                if (!cancel)
                {
                    if (!e.Node.Equals(treeView.Nodes[0]))
                    {
                        Log.Debug("Node is not root.");
                        string testCaseName = e.Node.Text;
                        string path = e.Node.FullPath;

                        if (e.Node.Tag.Equals("Test Case"))
                        {
                            Log.Debug("Node is a Test Case.");
                            resultRichTextField.Clear();
                            ResultrichTextBox.Clear();
                            ShowTestCasePanel();
                            ClearSubjectAttributes();
                            ClearFromResourceAttributes();
                            ClearToResourceAttributes();

                            //get test case from the database
                            TestCase tc = MongoDBUtil.GetTestCase(e.Node.Text, e.Node.Parent.Text).Result;

                            //save this test case as the previous test case for future switching
                            previousTestCase = tc;
                            previousTestCasePath = path;
                            UpdateFormWithTestCase(tc);
                            exportTestCaseResultButton.Enabled = false;
                            exportTestCaseResultButton.BackColor = System.Drawing.Color.LightBlue;
                            dirty = false;
                        }
                        else if (e.Node.Tag.Equals("Test Set"))
                        {
                            Log.Debug("Node is a Test Set.");

                            if (previousTestCase != null)
                            {
                                previousTestCase = null;
                            }

                            resultRichTextField.Clear();
                            ResultrichTextBox.Clear();
                            exportTestSetResultButton.Enabled = false;
                            exportTestSetResultButton.BackColor = System.Drawing.Color.LightBlue;

                            ShowTestSetPanel();
                            ClearTestSetTable();

                            // if testSetLoader is not working, run the loader for the selected test set
                            if (!testSetLoader.IsBusy)
                                testSetLoader.RunWorkerAsync(e.Node.Text);
                        }
                    }
                    else
                    {
                        ShowIntroPanel();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occured while selecting new item. ", ex);
                MessageBox.Show(ex.Message + " Please see the log for more details.",
                     "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        private void ShowIntroPanel()
        {
            introPanel.Visible = true;
            testCasePanel.Visible = false;
            testSetPanel.Visible = false;
        }



        private void ShowTestCasePanel()
        {
            introPanel.Visible = false;
            testCasePanel.Visible = true;
            testSetPanel.Visible = false;
        }



        private void ShowTestSetPanel()
        {
            introPanel.Visible = false;
            testCasePanel.Visible = false;
            testSetPanel.Visible = true;
        }



        private void newTestCaseButton_Click(object sender, EventArgs e)
        {
            Log.Debug("Creating new Test Case.");

            try
            {
                if (IsSelectedNodeATestCase())
                {
                    if (GenerateTestCaseFromForm().IsIncomplete())
                    {
                        DialogResult dr = MessageBox.Show("Some of the mandatory fields are empty. The incompleted test case will be saved but will not be validated when running test set. Do you want to continue?",
                            "Incomplete Test Case", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            TestCase tc = GenerateTestCaseFromForm();
                            var updateResult = MongoDBUtil.UpdateTestCase(tc, tc.Name).Result;

                            if (!updateResult)
                            {
                                throw new Exception("Failed to update test case in the database");
                            }
                            dirty = false;
                        }
                        else
                        {
                            Log.Debug("Remain at " + previousTestCasePath);
                            changeSelectedNode = true;
                            treeView.SelectedNode = Util.LocateNode(previousTestCasePath, treeView.Nodes);
                        }
                    }

                    else if (dirty)
                    {
                        DialogResult dr = MessageBox.Show("The current Test Case has some unsaved changes. Do you want to save? ", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            SaveForm();
                        }
                        dirty = false;
                    }
                }

                if (IsSelectedNodeRoot())
                {
                    Log.Error("Cannot create a Test Case under Root. Select a Test Set and try again.");
                    MessageBox.Show("Cannot create a Test Case under Root. Select a Test Set and try again.",
                        "Invalid Test Case Location", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                NewTestCase newTestCaseForm = new NewTestCase();

                var result = newTestCaseForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string testCasePath;
                    string testCaseName = newTestCaseForm.TestCaseName.Trim();
                    string testSetName;

                    if (IsSelectedNodeATestCase())
                    {
                        testSetName = treeView.SelectedNode.Parent.Text;
                        testCasePath = treeView.SelectedNode.FullPath;
                    }
                    else if (IsSelectedNodeATestSet())
                    {
                        testSetName = treeView.SelectedNode.Text;
                        testCasePath = Path.Combine(treeView.SelectedNode.FullPath, testCaseName);
                    }
                    else
                    {
                        throw new Exception("Invalid path to create Test Case.");
                    }

                    Log.Info("Test set of the newly created test case is \"" + testSetName + "\"");
                    Log.Debug("Test case name is : " + testCaseName);

                    var exist = MongoDBUtil.CheckTestCaseExistence(testCaseName, testSetName).Result;
                    if (exist)
                    {
                        throw new Exception("Test Case already exists under the selected Test Set.");
                    }

                    try
                    {
                        TestCase tc = new TestCase(testCaseName, testSetName,
                            (TargetSystem)Enum.Parse(typeof(TargetSystem), newTestCaseForm.TargetSystem, true),
                            (PolicyType)Enum.Parse(typeof(PolicyType), newTestCaseForm.PolicyType, true));

                        var success = MongoDBUtil.CreateNewTestCase(tc).Result;

                        if (!success)
                        {
                            throw new Exception("Failed to create new test case in the database.");
                        }

                        Util.PopulateTreeViewFromDatabase(treeView);

                        treeView.SelectedNode = Util.LocateNode(Path.Combine("root", testSetName, testCaseName), treeView.Nodes);
                        treeView.SelectedNode.Parent.Expand();

                        if (tc.IsIncomplete())
                            empty = true;
                        previousTestCase = tc;
                        previousTestCasePath = testCasePath;

                        ClearDynamicAttributes();
                        UpdateForm();
                    }
                    catch (Exception ex)
                    {
                        Log.Error("An error occured while creating new Test Case. ", ex);
                        MessageBox.Show("Error : " + ex.Message + " Please see the log for more details.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        empty = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occured while creating new Test Case. ", ex);
                MessageBox.Show(ex.Message + " Please see the log for more details.",
                     "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        private void newTestSetButton_Click(object sender, EventArgs e)
        {
            Log.Debug("Creating new Test Set.");

            if (IsSelectedNodeATestCase())
            {
                if (GenerateTestCaseFromForm().IsIncomplete())
                {
                    DialogResult dr = MessageBox.Show("Some of the mandatory fields are empty. The incompleted test case will be saved but will not be validated when running test set. Do you want to continue?",
                        "Incomplete Test Case", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        TestCase tc = GenerateTestCaseFromForm();
                        var updateResult = MongoDBUtil.UpdateTestCase(tc, tc.Name).Result;

                        if (!updateResult)
                        {
                            throw new Exception("Failed to update test case in the database");
                        }
                        dirty = false;
                    }
                    else
                    {
                        Log.Debug("Remain at " + previousTestCasePath);
                        changeSelectedNode = true;
                        treeView.SelectedNode = Util.LocateNode(previousTestCasePath, treeView.Nodes);
                    }
                }

                else if (dirty)
                {
                    DialogResult dr = MessageBox.Show("The current Test Case has some unsaved changes. Do you want to save? ", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        SaveForm();
                    }
                    dirty = false;
                }
            }

            try
            {
                NewTestSet newTestSetForm = new NewTestSet();
                var result = newTestSetForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (!newTestSetForm.TestSetName.contains("/") && !newTestSetForm.TestSetName.contains("\\"))
                    {

                        //Create new test set in the database

                        var exist = MongoDBUtil.CheckTestSetExistence(newTestSetForm.TestSetName).Result;

                        if (exist)
                        {
                            throw new Exception("Test Set already exists");
                        }

                        var success = MongoDBUtil.CreateNewTestSet(newTestSetForm.TestSetName).Result;

                        if (!success)
                        {
                            throw new Exception("Cannot create test set in the database");
                        }
                        Util.PopulateTreeViewFromDatabase(treeView);
                        treeView.Nodes[0].Expand();
                        treeView.SelectedNode = Util.LocateNode(Path.Combine("root", newTestSetForm.TestSetName), treeView.Nodes);
                        UpdateForm();
                    }
                    else
                    {
                        throw new Exception("Test Set name contains invalid characters.");
                    }
                }
            }

            catch (Exception ex)
            {
                Log.Error("An error occured while creating new Test Set. ", ex);
                MessageBox.Show(ex.Message + " Please see the log for more details.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            dirty = false;

        }



        private void ClearDynamicAttributes()
        {
            ClearSubjectAttributes();
            ClearFromResourceAttributes();
            ClearToResourceAttributes();
        }


        private void ResetStaticFields()
        {
            denyRadioButton.Checked = true;
            allowRadioButton.Checked = false;

            subjectUsernameTextbox.Text = string.Empty;
            subjectSIDTextbox.Text = string.Empty;
            subjectApplicationName.Text = string.Empty;
            subjectIpAddress.Text = string.Empty;

            foreach (Control c in subjectDynamicAttributeTable.Controls)
            {
                if (c is ComboBox)
                {
                    c.Text = string.Empty;
                }
                if (c is TextBox)
                {
                    c.Text = string.Empty;
                }
            }


            actionCombobox.Text = string.Empty;


            fromResourceNameTextbox.Text = string.Empty;
            foreach (Control c in fromResourceDynamicAttributeTable.Controls)
            {
                if (c is ComboBox)
                {
                    c.Text = string.Empty;
                }
                if (c is TextBox)
                {
                    c.Text = string.Empty;
                }
            }

            toResourceNameTextbox.Text = string.Empty;
            foreach (Control c in toResourceDynamicAttributeTable.Controls)
            {
                if (c is ComboBox)
                {
                    c.Text = string.Empty;
                }
                if (c is TextBox)
                {
                    c.Text = string.Empty;
                }
            }
        }


        private void clearTestCaseButton_Click(object sender, EventArgs e)
        {
            ClearDynamicAttributes();
            ResetStaticFields();
        }



        private void UpdateForm()
        {
            ClearDynamicAttributes();
            ResetStaticFields();

            if (IsSelectedNodeRoot())
            {
                ShowIntroPanel();
            }

            else if (IsSelectedNodeATestSet())
            {
                ShowTestSetPanel();
            }

            if (IsSelectedNodeATestCase())
            {
                ShowTestCasePanel();
                TestCase tc = MongoDBUtil.GetTestCase(treeView.SelectedNode.Text, treeView.SelectedNode.Parent.Text).Result;
                UpdateFormWithTestCase(tc);
            }
        }



        private void UpdateFormWithTestCase(TestCase tc)
        {
            documentPolicyHeaderLabel.Text = tc.PolicyType.ToString() + " Policy - " + tc.TargetSystem.ToString();

            if (tc.TargetSystem != TargetSystem.Filesystem)
            {
                HideToResourceSection();
                HideRecipientsSection();
                HideEmailDetailsSection();
                subjectHeaderLabel.Text = "SUBJECT";
                fromResourceHeaderLabel.Text = "FROM RESOURCE";
                this.MinimumSize = new Size(850, 720);
                //this.Size = new Size(850, 720);

            }
            else
            {
                if (tc.PolicyType == PolicyType.Document)
                {
                    ShowToResourceSection();
                    HideRecipientsSection();
                    HideEmailDetailsSection();
                    subjectHeaderLabel.Text = "SUBJECT";
                    fromResourceHeaderLabel.Text = "FROM RESOURCE";
                    this.MinimumSize = new Size(850, 720 + 140);
                }
                else
                {
                    HideToResourceSection();
                    ShowRecipientsSection();
                    ShowEmailDetailsSection();
                    subjectHeaderLabel.Text = "SENDER";
                    fromResourceHeaderLabel.Text = "ATTACHMENT";

                    this.MinimumSize = new Size(850, 720 + 55);
                }
            }

            if (tc.ExpectedResult == Decision.Deny)
            {
                denyRadioButton.Checked = true;
            }

            else
            {
                allowRadioButton.Checked = true;
            }

            subjectUsernameTextbox.Text = tc.Subject.Username;
            subjectSIDTextbox.Text = tc.Subject.WindowsSid;
            subjectApplicationName.Text = tc.Subject.ApplicationName;
            subjectIpAddress.Text = tc.Subject.IpAddress;

            for (int i = 0; i < tc.Subject.SubjectDynamicAttributes.Count(); i = i + 2)
            {
                AddSubjectAttributeLine(tc.Subject.SubjectDynamicAttributes[i], tc.Subject.SubjectDynamicAttributes[i + 1]);
            }

            SetTableLayoutRowSize(subjectDynamicAttributeTable, 25);
            actionCombobox.Text = tc.Action;
            if (tc.PolicyType.Equals(PolicyType.Communication))
            {
                actionCombobox.Text = "EMAIL";
                actionCombobox.Enabled = false;
            }
            else
            {
                actionCombobox.Enabled = true;

            }

            string recipients = "";
            for (int i = 0; i < tc.Recipients.Count; i++)
            {
                recipients += tc.Recipients.ElementAt(i).Username;
                if (i != tc.Recipients.Count - 1)
                {
                    recipients += ";";
                }
            }
            recipientsTextBox.Text = recipients;
            emailSubjectTextBox.Text = tc.EmailSubject;
            emailBodyRichTextBox.Text = tc.EmailBody;

            fromResourceNameTextbox.Text = tc.FromResource.ResourceName;
            for (int i = 0; i < tc.FromResource.ResourceDynamicAttributes.Count(); i = i + 2)
            {
                AddFromResourceAttributeLine(tc.FromResource.ResourceDynamicAttributes[i], tc.FromResource.ResourceDynamicAttributes[i + 1]);
            }

            SetTableLayoutRowSize(fromResourceDynamicAttributeTable, 25);
            toResourceNameTextbox.Text = tc.ToResource.ResourceName;

            for (int i = 0; i < tc.ToResource.ResourceDynamicAttributes.Count(); i = i + 2)
            {
                AddToResourceAttributeLine(tc.ToResource.ResourceDynamicAttributes[i], tc.ToResource.ResourceDynamicAttributes[i + 1]);
            }

            SetTableLayoutRowSize(toResourceDynamicAttributeTable, 25);
        }


        private TestCase GenerateTestCaseFromForm()
        {
            TestCase tc = new TestCase();

            tc.Name = treeView.SelectedNode.Text;
            tc.TestSet = treeView.SelectedNode.Parent.Text;

            string[] temp = documentPolicyHeaderLabel.Text.split(" Policy - ");
            tc.PolicyType = (PolicyType)Enum.Parse(typeof(PolicyType), temp[0]);
            tc.TargetSystem = (TargetSystem)Enum.Parse(typeof(TargetSystem), temp[1]);


            if (allowRadioButton.Checked)
            {
                tc.ExpectedResult = Decision.Allow;
            }

            else
            {
                tc.ExpectedResult = Decision.Deny;
            }

            tc.Subject.Username = subjectUsernameTextbox.Text;
            tc.Subject.WindowsSid = subjectSIDTextbox.Text;
            tc.Subject.ApplicationName = subjectApplicationName.Text;
            tc.Subject.IpAddress = subjectIpAddress.Text;
            tc.Subject.SubjectDynamicAttributes = new List<string>();
            tc.EmailSubject = emailSubjectTextBox.Text;
            tc.EmailBody = emailBodyRichTextBox.Text;

            string[] recipientsArray = recipientsTextBox.Text.split(";");
            tc.Recipients = new List<Subject>();

            foreach (string recipient in recipientsArray)
            {
                if (!recipient.Trim().isEmpty())
                {
                    tc.Recipients.Add(new Subject(recipient.trim(), "", "", "", new List<string>()));
                }
            }

            foreach (Control c in subjectDynamicAttributeTable.Controls)
            {
                if (c is ComboBox)
                {
                    string key = ((ComboBox)c).Text;

                    if (string.IsNullOrEmpty(key))
                        continue;


                    string index = ((ComboBox)c).Name.Replace("combo", "").Trim();
                    foreach (Control t in subjectDynamicAttributeTable.Controls.Find("text" + index, true))
                    {
                        if (t is TextBox)
                        {
                            string value = ((TextBox)t).Text;
                            if (string.IsNullOrEmpty(value))
                                throw new Exception("Value for Subject Attribute " + key + " is empty.");
                            tc.Subject.AddSubjectAttribute(key, value);
                        }
                    }
                }
            }

            tc.Action = actionCombobox.Text;

            tc.FromResource.ResourceName = fromResourceNameTextbox.Text;
            foreach (Control c in fromResourceDynamicAttributeTable.Controls)
            {
                if (c is ComboBox)
                {
                    string key = ((ComboBox)c).Text;
                    if (string.IsNullOrEmpty(key))
                        continue;

                    string index = ((ComboBox)c).Name.Replace("combo", "").Trim();
                    foreach (Control t in fromResourceDynamicAttributeTable.Controls.Find("text" + index, true))
                    {
                        if (t is TextBox)
                        {
                            string value = ((TextBox)t).Text;

                            if (string.IsNullOrEmpty(value))
                                throw new Exception("Value for From Resource Attribute " + key + " is empty.");

                            tc.FromResource.AddResourceAttribute(key, value);
                        }
                    }
                }
            }

            if (toResourceNameTextbox.Text != null)
            {
                tc.ToResource.ResourceName = toResourceNameTextbox.Text;
            }
            else
            {
                tc.ToResource.ResourceName = "";
            }

            foreach (Control c in toResourceDynamicAttributeTable.Controls)
            {
                if (c is ComboBox)
                {
                    string key = ((ComboBox)c).Text;

                    if (string.IsNullOrEmpty(key))
                        continue;

                    string index = ((ComboBox)c).Name.Replace("combo", "").Trim();
                    foreach (Control t in toResourceDynamicAttributeTable.Controls.Find("text" + index, true))
                    {
                        if (t is TextBox)
                        {
                            string value = ((TextBox)t).Text;

                            if (string.IsNullOrEmpty(value))
                                throw new Exception("Value for To Resource Attribute " + key + " is empty.");

                            tc.ToResource.AddResourceAttribute(key, value);
                        }
                    }
                }
            }
            return tc;
        }


        private void testSetLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument != null)
            {
                int i = 1;

                List<TestCase> testCases = MongoDBUtil.GetTestCasesByTestSet(e.Argument as string).Result;

                for (int j = 0; j < testCases.Count; j++)
                {
                    if ((sender as BackgroundWorker).CancellationPending)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        (sender as BackgroundWorker).ReportProgress(i, new object[] { testCases[j], i, testCases[j].Name });
                        i++;
                    }
                }
            }
        }


        private void testSetLoader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                object[] arg = e.UserState as object[];

                string file = (string)arg[2];
                int index = (int)arg[1];
                TestCase tc = (TestCase)arg[0];

                testSetTablePanel.SuspendLayout();
                testSetTablePanel.AutoScroll = false;

                testSetTablePanel.RowCount += 1;
                testSetTablePanel.RowStyles.Add(new RowStyle());

                string tcName = tc.Name;

                var nameLbl = new Label { Name = "lbl" + index, Text = tcName, Dock = DockStyle.Fill, Margin = new System.Windows.Forms.Padding(0, 1, 1, 0), };
                var typeLbl = new Label { Name = "lbl" + index + "type", Text = tc.PolicyType.ToString(), Dock = DockStyle.Fill, Margin = new System.Windows.Forms.Padding(0, 1, 1, 0), };
                var actionLbl = new Label { Name = "lbl" + index + "action", Text = tc.Action, Dock = DockStyle.Fill, Margin = new System.Windows.Forms.Padding(0, 1, 1, 0), };
                var res = new Label { Name = "res" + index, Text = "............", Dock = DockStyle.Fill, Margin = new System.Windows.Forms.Padding(0, 1, 1, 0), };
                Label expRes;
                if (tc.ExpectedResult == Decision.Allow)
                {
                    expRes = new Label { Name = "expRes" + index, Text = tc.ExpectedResult.toString(), ForeColor = Color.Green, Dock = DockStyle.Fill, Margin = new System.Windows.Forms.Padding(0, 1, 1, 0), };
                }
                else
                {
                    expRes = new Label { Name = "expRes" + index, Text = tc.ExpectedResult.toString(), ForeColor = Color.Red, Dock = DockStyle.Fill, Margin = new System.Windows.Forms.Padding(0, 1, 1, 0), };
                }

                testSetTablePanel.Controls.Add(nameLbl);
                testSetTablePanel.Controls.Add(typeLbl);
                testSetTablePanel.Controls.Add(actionLbl);
                testSetTablePanel.Controls.Add(expRes);
                testSetTablePanel.Controls.Add(res);
                SetTableLayoutRowSize(testSetTablePanel, 25);
                testSetTablePanel.AutoScroll = true;
                testSetTablePanel.ResumeLayout();
            }
        }


        private void testSetLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            /*EnforcementResult[] previousTestResults = null;

            if (!testSetResultTable.TryGetValue(treeView.SelectedNode.Text, out previousTestResults))
            {
                previousTestResults = null;
            }

            if (previousTestResults != null)
            {
                processTestSetEnforcement(previousTestResults);
            }*/

            if (closeRequested) this.Close();
        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }



        private void Delete()
        {
            try
            {
                if (IsSelectedNodeRoot())
                    throw new Exception("Cannot delete Root folder.");

                if (IsSelectedNodeATestSet())
                {
                    DialogResult dr = MessageBox.Show(
                        "Deleteing a Test Set would delete all the Test Cases under it. Do you want to continue?",
                        "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dr == DialogResult.Yes)
                    {
                        var result = MongoDBUtil.DeleteTestSet(treeView.SelectedNode.Text).Result;

                        if (!result)
                        {
                            throw new Exception("Failed to delete the test set in the database.");
                        }
                    }
                }
                if (IsSelectedNodeATestCase())
                {
                    var result = MongoDBUtil.DeleteTestCase(treeView.SelectedNode.Text, treeView.SelectedNode.Parent.Text).Result;

                    if (!result)
                    {
                        throw new Exception("Failed to delete to test case in the database");
                    }
                }
            }

            catch (Exception ex)
            {
                Log.Error("An error occured while deleting new Test Set. ", ex);
                MessageBox.Show(ex.Message + " Please see the log for more details.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                dirty = false;
                empty = false;
            }

            finally
            {
                Util.PopulateTreeViewFromDatabase(treeView);
                UpdateForm();

                dirty = false;
                empty = false;
            }
        }



        private void treeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Delete();
            }
            if (e.KeyCode == Keys.F2)
            {
                Rename();
            }
        }



        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rename();
        }



        private void Rename()
        {
            try
            {
                string currentPath = treeView.SelectedNode.FullPath;

                if (IsSelectedNodeRoot())
                    throw new Exception("Cannot rename Root folder.");

                RenameDialogBox renameDialog = new RenameDialogBox(treeView.SelectedNode.Text);
                System.Windows.Forms.DialogResult dr = renameDialog.ShowDialog();

                string newName = null;

                if (dr == DialogResult.OK && !string.IsNullOrEmpty(renameDialog.NewName))
                {
                    newName = renameDialog.NewName;

                    if (newName.contains("\\") || newName.Contains("/"))
                    {
                        throw new Exception("New name contains invalid characters.");
                    }

                    if (IsSelectedNodeATestSet())
                    {
                        var exist = MongoDBUtil.CheckTestSetExistence(newName).Result;
                        if (exist)
                        {
                            throw new Exception("Target Test Set already exists.");
                        }

                        var result = MongoDBUtil.UpdateTestSet(newName, treeView.SelectedNode.Text).Result;
                        if (!result)
                        {
                            throw new Exception("Cannot update Test Set in the database");
                        }
                    }
                    if (IsSelectedNodeATestCase())
                    {
                        var exist = MongoDBUtil.CheckTestCaseExistence(newName, treeView.SelectedNode.Parent.Text).Result;
                        if (exist)
                        {
                            throw new Exception("Target Test Case already exists.");
                        }

                        TestCase tc = MongoDBUtil.GetTestCase(treeView.SelectedNode.Text, treeView.SelectedNode.Parent.Text).Result;
                        string oldName = treeView.SelectedNode.Text;
                        tc.Name = newName;
                        var result = MongoDBUtil.UpdateTestCase(tc, oldName).Result;
                        if (!result)
                        {
                            throw new Exception("Cannot update Test Case in the database");
                        }
                    }
                }

                if (newName != null)
                {
                    var currentSelectedPath = Path.Combine(treeView.SelectedNode.Parent.FullPath, newName);
                    Util.PopulateTreeViewFromDatabase(treeView);
                    treeView.SelectedNode = Util.LocateNode(currentSelectedPath, treeView.Nodes);
                    UpdateForm();
                }

                dirty = false;
                empty = false;
            }
            catch (Exception ex)
            {
                Log.Error("An error occured while renaming selected node. ", ex);
                MessageBox.Show(ex.Message + " Please see the log for more details.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dirty = false;
                empty = false;
            }
        }



        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }


        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string currentItem = treeView.SelectedNode.Text;

                if (IsSelectedNodeRoot())
                    throw new Exception("Cannot duplicate Root folder.");

                DuplicateDialogBox duplicateDialog = new DuplicateDialogBox(treeView.SelectedNode.Text);
                System.Windows.Forms.DialogResult dr = duplicateDialog.ShowDialog();

                int count = 1, i = 1;

                if (dr == DialogResult.OK && !string.IsNullOrEmpty(duplicateDialog.BaseName) && duplicateDialog.Count > 0)
                {
                    while (count <= duplicateDialog.Count)
                    {
                        string formatString = "{0} - Copy ({1})";
                        string itemName = string.Format(formatString, duplicateDialog.BaseName.Trim(), i.ToString());
                        if (i == 1)
                        {
                            itemName = duplicateDialog.BaseName.Trim() + " - Copy";
                        }

                        string targetPath = Path.Combine(
                            Path.Combine(treeView.SelectedNode.Parent.FullPath, itemName));

                        if (IsSelectedNodeATestSet())
                        {
                            var result = MongoDBUtil.CheckTestSetExistence(itemName).Result;
                            if (!result)
                            {
                                var testSetResult = MongoDBUtil.CreateNewTestSet(itemName).Result;
                                if (!testSetResult)
                                {
                                    throw new Exception("Failed to duplicate test set " + itemName);
                                }

                                List<TestCase> toDuplicateTestCases = MongoDBUtil.GetTestCasesByTestSet(currentItem).Result;
                                foreach (TestCase tc in toDuplicateTestCases)
                                {
                                    tc.TestSet = itemName;
                                }

                                var testCaseResult = MongoDBUtil.CreateNewTestCases(toDuplicateTestCases).Result;
                                if (!testCaseResult)
                                {
                                    throw new Exception("Failed to duplicate test cases under test set " + itemName);
                                }
                            }
                            else
                            {
                                i++;
                                continue;
                            }
                        }

                        if (IsSelectedNodeATestCase())
                        {
                            var result = MongoDBUtil.CheckTestCaseExistence(itemName, treeView.SelectedNode.Parent.Text).Result;
                            if (!result)
                            {
                                TestCase tc = MongoDBUtil.GetTestCase(currentItem, treeView.SelectedNode.Parent.Text).Result;
                                tc.Name = itemName;
                                var testCaseResult = MongoDBUtil.UpdateTestCase(tc, currentItem).Result;
                                if (!testCaseResult)
                                {
                                    throw new Exception("Failed to duplicate test case " + itemName);
                                }
                            }
                            else
                            {
                                i++;
                                continue;
                            }
                        }

                        i++;
                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occured while duplicating item. ", ex);
                MessageBox.Show(ex.Message + " Please see the log for more details.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                dirty = false;
                empty = false;
            }

            Util.PopulateTreeViewFromDatabase(treeView);
            UpdateForm();
            dirty = false;
            empty = false;
        }



        private void treeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (!dirty && !empty)
            {
                if (Control.ModifierKeys == Keys.Control)
                {
                    DoDragDrop(e.Item, DragDropEffects.Copy);
                }
                else
                {
                    DoDragDrop(e.Item, DragDropEffects.Move);
                }
            }
        }



        private void treeView_DragEnter(object sender, DragEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.Move;
            }
        }


        private void treeView_DragDrop(object sender, DragEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.Move;
            }

            TreeNode selectedNode;

            try
            {
                if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
                {
                    selectedNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                    if (selectedNode.Tag.Equals("Test Case"))
                    {
                        Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                        TreeNode destinationNode = ((TreeView)sender).GetNodeAt(pt);

                        if (destinationNode == null)
                        {
                            Log.Error("Try to drag outside tree view");
                            throw new Exception("Invalid destination.");
                        }

                        string testSet = null;

                        if (destinationNode.Tag.Equals("Root"))
                        {
                            throw new Exception("Cannot drag item to root.");
                        }
                        else if (destinationNode.Tag.Equals("Test Set"))
                        {
                            testSet = destinationNode.Text;
                        }
                        else if (destinationNode.Tag.Equals("Test Case"))
                        {
                            testSet = destinationNode.Parent.Text;
                        }
                        else
                        {
                            throw new Exception("Invalid destination");
                        }

                        if (destinationNode != selectedNode.Parent)
                        {
                            {
                                var exist = MongoDBUtil.CheckTestCaseExistence(selectedNode.Text, testSet).Result;
                                if (!exist)
                                {
                                    TestCase tc = MongoDBUtil.GetTestCase(selectedNode.Text, selectedNode.Parent.Text).Result;

                                    //create new test case in the destination test set
                                    tc.TestSet = testSet;
                                    var moveResult = MongoDBUtil.CreateNewTestCase(tc).Result;
                                    if (!moveResult)
                                    {
                                        throw new Exception("Failed to create test case in the destination test set");
                                    }
                                    if (e.Effect == DragDropEffects.Copy)
                                    {
                                        //delete the test case in the source test set
                                        var deleteResult = MongoDBUtil.DeleteTestCase(tc.Name, selectedNode.Parent.Text).Result;
                                        if (!deleteResult)
                                        {
                                            throw new Exception("Failed to delete test case in the source test set");
                                        }
                                    }
                                }
                                else
                                {
                                    System.Windows.Forms.DialogResult dr =
                                        MessageBox.Show(
                                            "A Test Case with the same name already exists in the destination Test Set. Do you want to overwrite?",
                                            "Do you want to overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                    if (dr == DialogResult.Yes)
                                    {
                                        TestCase tc = MongoDBUtil.GetTestCase(selectedNode.Text, selectedNode.Parent.Text).Result;
                                        tc.TestSet = testSet;

                                        //overwrite test case
                                        var updateResult = MongoDBUtil.UpdateTestCase(tc, tc.Name).Result;
                                        if (!updateResult)
                                        {
                                            throw new Exception("Failed to overwrite test case");
                                        }

                                        if (e.Effect == DragDropEffects.Copy)
                                        {
                                            //delete test case in the source test set
                                            var deleteResult = MongoDBUtil.DeleteTestCase(tc.Name, selectedNode.Parent.Text).Result;
                                            if (!deleteResult)
                                            {
                                                throw new Exception("Failed to delete test case in the source test set");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (selectedNode.Tag.Equals("Test Set"))
                    {
                        Log.Debug("Try to drag test set");
                        throw new Exception("Cannot drag a test set.");
                    }
                    else
                    {
                        Log.Debug("Try to drag root");
                        throw new Exception("Cannot drag Root directory.");
                    }
                }

                Util.PopulateTreeViewFromDatabase(treeView);
                UpdateForm();
                dirty = false;
            }
            catch (Exception ex)
            {
                Log.Error("An error occured while draging item. ", ex);
                MessageBox.Show(ex.Message + " Please see the log for more details.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                dirty = false;
                empty = false;
            }
        }



        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.Debug("Showing Settings dialog box.");

            PCSettingsDialogBox pcSettingsDialog = new PCSettingsDialogBox();
            System.Windows.Forms.DialogResult dr = pcSettingsDialog.ShowDialog();

            if (dr == DialogResult.OK)
            {
                Settings.Default.PC_IP_Address = pcSettingsDialog.IpAddress;
                Settings.Default.PC_Port = pcSettingsDialog.Port;
                Settings.Default.Timeout_S = pcSettingsDialog.TimeoutS;
                Settings.Default.JavaPC = pcSettingsDialog.Type == PolicyControllerType.Java ? true : false;
            }

            Settings.Default.Save();

            Log.Debug("New Settings : ");
            Log.Debug("IP Address   : " + Settings.Default.PC_IP_Address);
            Log.Debug("PC Port      : " + Settings.Default.PC_Port);
            Log.Debug("Timeout (Sec): " + Settings.Default.Timeout_S);
            Log.Debug("Java PC      : " + Settings.Default.JavaPC);
        }


        private void actionAttributesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.Debug("Showing Action Attribute dialog box.");

            ActionAttributeDialogBox actionAttributeDialog = new ActionAttributeDialogBox();
            System.Windows.Forms.DialogResult dr = actionAttributeDialog.ShowDialog();

            if (dr == DialogResult.OK)
            {
                switch (actionAttributeDialog.TargetSystemType)
                {
                    case TargetSystem.Enovia:
                        Settings.Default.Enovia_Action_Attributes = actionAttributeDialog.AttributeList;
                        Log.Debug("Updated action attributes for " + actionAttributeDialog.TargetSystemType.ToString() + " to " + actionAttributeDialog.AttributeList);
                        break;

                    case TargetSystem.Sap:
                        Settings.Default.Sap_Action_Attributes = actionAttributeDialog.AttributeList;
                        Log.Debug("Updated action attributes for " + actionAttributeDialog.TargetSystemType.ToString() + " to " + actionAttributeDialog.AttributeList);
                        break;
                    case TargetSystem.Server:
                        Settings.Default.Server_Action_Attributes = actionAttributeDialog.AttributeList;
                        Log.Debug("Updated action attributes for " + actionAttributeDialog.TargetSystemType.ToString() + " to " + actionAttributeDialog.AttributeList);
                        break;
                    case TargetSystem.Portal:
                        Settings.Default.Portal_Action_Attributes = actionAttributeDialog.AttributeList;
                        Log.Debug("Updated action attributes for " + actionAttributeDialog.TargetSystemType.ToString() + " to " + actionAttributeDialog.AttributeList);
                        break;
                    case TargetSystem.Filesystem:
                        Settings.Default.Filesystem_Action_Attributes = actionAttributeDialog.AttributeList;
                        Log.Debug("Updated action attributes for " + actionAttributeDialog.TargetSystemType.ToString() + " to " + actionAttributeDialog.AttributeList);
                        break;
                }

                Settings.Default.Save();
            }
        }



        private void resourceAttributesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.Debug("Showing Resource Attribute dialog box.");

            ResourceAttributeDialogBox resourceAttributeDialog = new ResourceAttributeDialogBox();
            System.Windows.Forms.DialogResult dr = resourceAttributeDialog.ShowDialog();

            if (dr == DialogResult.OK)
            {
                switch (resourceAttributeDialog.TargetSystemType)
                {
                    case TargetSystem.Enovia:
                        Settings.Default.Enovia_Resource_Attributes = resourceAttributeDialog.AttributeList;
                        Log.Debug("Updated resource attributes for " + resourceAttributeDialog.TargetSystemType.ToString() + " to " + resourceAttributeDialog.AttributeList);
                        break;
                    case TargetSystem.Sap:
                        Settings.Default.Sap_Resource_Attributes = resourceAttributeDialog.AttributeList;
                        Log.Debug("Updated resource attributes for " + resourceAttributeDialog.TargetSystemType.ToString() + " to " + resourceAttributeDialog.AttributeList);
                        break;
                    case TargetSystem.Server:
                        Settings.Default.Server_Resource_Attributes = resourceAttributeDialog.AttributeList;
                        Log.Debug("Updated resource attributes for " + resourceAttributeDialog.TargetSystemType.ToString() + " to " + resourceAttributeDialog.AttributeList);
                        break;
                    case TargetSystem.Portal:
                        Settings.Default.Portal_Resource_Attributes = resourceAttributeDialog.AttributeList;
                        Log.Debug("Updated resource attributes for " + resourceAttributeDialog.TargetSystemType.ToString() + " to " + resourceAttributeDialog.AttributeList);
                        break;
                    case TargetSystem.Filesystem:
                        Settings.Default.Filesystem_Resource_Attributes = resourceAttributeDialog.AttributeList;
                        Log.Debug("Updated resource attributes for " + resourceAttributeDialog.TargetSystemType.ToString() + " to " + resourceAttributeDialog.AttributeList);
                        break;
                }

                Settings.Default.Save();
            }
        }


        private void subjectAttributesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.Debug("Showing Subject Attribute dialog box.");

            SubjectAttributeDialogBox subjectAttributeDialog = new SubjectAttributeDialogBox();
            System.Windows.Forms.DialogResult dr = subjectAttributeDialog.ShowDialog();

            if (dr == DialogResult.OK)
            {
                switch (subjectAttributeDialog.TargetSystemType)
                {
                    case TargetSystem.Enovia:
                        Settings.Default.Enovia_Subject_Attributes = subjectAttributeDialog.AttributeList;
                        Log.Debug("Updated subject attributes for " + subjectAttributeDialog.TargetSystemType.ToString() + " to " + subjectAttributeDialog.AttributeList);
                        break;
                    case TargetSystem.Sap:
                        Settings.Default.Sap_Subject_Attributes = subjectAttributeDialog.AttributeList;
                        Log.Debug("Updated subject attributes for " + subjectAttributeDialog.TargetSystemType.ToString() + " to " + subjectAttributeDialog.AttributeList);
                        break;
                    case TargetSystem.Server:
                        Settings.Default.Server_Subject_Attributes = subjectAttributeDialog.AttributeList;
                        Log.Debug("Updated subject attributes for " + subjectAttributeDialog.TargetSystemType.ToString() + " to " + subjectAttributeDialog.AttributeList);
                        break;
                    case TargetSystem.Portal:
                        Settings.Default.Portal_Subject_Attributes = subjectAttributeDialog.AttributeList;
                        Log.Debug("Updated subject attributes for " + subjectAttributeDialog.TargetSystemType.ToString() + " to " + subjectAttributeDialog.AttributeList);
                        break;
                    case TargetSystem.Filesystem:
                        Settings.Default.Filesystem_Subject_Attributes = subjectAttributeDialog.AttributeList;
                        Log.Debug("Updated subject attributes for " + subjectAttributeDialog.TargetSystemType.ToString() + " to " + subjectAttributeDialog.AttributeList);
                        break;
                }
            }

            Settings.Default.Save();
        }



        private void actionCombobox_DropDown(object sender, EventArgs e)
        {
            string[] temp = documentPolicyHeaderLabel.Text.split(" Policy - ");
            PolicyType pt = (PolicyType)Enum.Parse(typeof(PolicyType), temp[0]);
            TargetSystem ts = (TargetSystem)Enum.Parse(typeof(TargetSystem), temp[1]);

            string csvAttributes = "";

            switch (ts)
            {
                case TargetSystem.Enovia:
                    csvAttributes = Settings.Default.Enovia_Action_Attributes;
                    break;
                case TargetSystem.Sap:
                    csvAttributes = Settings.Default.Sap_Action_Attributes;
                    break;
                case TargetSystem.Server:
                    csvAttributes = Settings.Default.Server_Action_Attributes;
                    break;
                case TargetSystem.Portal:
                    csvAttributes = Settings.Default.Portal_Action_Attributes;
                    break;
                case TargetSystem.Filesystem:
                    csvAttributes = Settings.Default.Filesystem_Action_Attributes;
                    break;
            }

            actionCombobox.Items.Clear();

            foreach (string attribute in csvAttributes.Split(','))
            {
                if (!string.IsNullOrEmpty(attribute) && !actionCombobox.Items.Contains(attribute))
                {
                    actionCombobox.Items.Add(attribute);
                }
            }
        }


        private void subjectCombobox_DropDown(object sender, EventArgs e)
        {
            string[] temp = documentPolicyHeaderLabel.Text.split(" Policy - ");
            PolicyType pt = (PolicyType)Enum.Parse(typeof(PolicyType), temp[0]);
            TargetSystem ts = (TargetSystem)Enum.Parse(typeof(TargetSystem), temp[1]);

            string csvAttributes = "";

            switch (ts)
            {
                case TargetSystem.Enovia:
                    csvAttributes = Settings.Default.Enovia_Subject_Attributes;
                    break;
                case TargetSystem.Sap:
                    csvAttributes = Settings.Default.Sap_Subject_Attributes;
                    break;
                case TargetSystem.Server:
                    csvAttributes = Settings.Default.Server_Subject_Attributes;
                    break;
                case TargetSystem.Portal:
                    csvAttributes = Settings.Default.Portal_Subject_Attributes;
                    break;
                case TargetSystem.Filesystem:
                    csvAttributes = Settings.Default.Filesystem_Subject_Attributes;
                    break;
            }

            ComboBox subjectCombobox = sender as ComboBox;
            subjectCombobox.Items.Clear();

            foreach (string attribute in csvAttributes.Split(','))
            {
                if (!string.IsNullOrEmpty(attribute) && !subjectCombobox.Items.Contains(attribute))
                {
                    subjectCombobox.Items.Add(attribute);
                }
            }
        }



        private void resourceCombobox_DropDown(object sender, EventArgs e)
        {
            string[] temp = documentPolicyHeaderLabel.Text.split(" Policy - ");
            PolicyType pt = (PolicyType)Enum.Parse(typeof(PolicyType), temp[0]);
            TargetSystem ts = (TargetSystem)Enum.Parse(typeof(TargetSystem), temp[1]);

            string csvAttributes = "";

            switch (ts)
            {
                case TargetSystem.Enovia:
                    csvAttributes = Settings.Default.Enovia_Resource_Attributes;
                    break;
                case TargetSystem.Sap:
                    csvAttributes = Settings.Default.Sap_Resource_Attributes;
                    break;
                case TargetSystem.Server:
                    csvAttributes = Settings.Default.Server_Resource_Attributes;
                    break;
                case TargetSystem.Portal:
                    csvAttributes = Settings.Default.Portal_Resource_Attributes;
                    break;
                case TargetSystem.Filesystem:
                    csvAttributes = Settings.Default.Filesystem_Resource_Attributes;
                    break;
            }

            ComboBox resourceCombobox = sender as ComboBox;
            resourceCombobox.Items.Clear();

            foreach (string attribute in csvAttributes.Split(','))
            {
                if (!string.IsNullOrEmpty(attribute) && !resourceCombobox.Items.Contains(attribute))
                {
                    resourceCombobox.Items.Add(attribute);
                }
            }
        }


        private void connectionStatusBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                IValidate validator;

                if (Settings.Default.JavaPC)
                {
                    validator = new ValidateJava();
                }
                else
                {
                    validator = new ValidateWindows();
                }

                if (!string.IsNullOrEmpty(Settings.Default.PC_IP_Address) && Settings.Default.Timeout_S > 0)
                {
                    bool connected = validator.ConnectToPC("Policy Validator", "PV SID", "PV Username",
                        Settings.Default.PC_IP_Address, Settings.Default.PC_Port, Settings.Default.Timeout_S);

                    if (connected)
                    {
                        (sender as BackgroundWorker).ReportProgress(1);
                        bool disconnect = validator.DisconnectFromPC();
                    }
                    else
                    {
                        (sender as BackgroundWorker).ReportProgress(-1);

                    }
                }

                Thread.Sleep(Settings.Default.Connection_Check_Timeout_S * 1000);
            }
        }



        private void connectionStatusBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
            {
                statusConnectionLabel.ForeColor = Color.Green;
                statusConnectionLabel.Text = "PC : " + Settings.Default.PC_IP_Address;
            }
            else
            {
                statusConnectionLabel.ForeColor = Color.Red;
                statusConnectionLabel.Text = "PC : " + Settings.Default.PC_IP_Address;
            }
        }



        private Requests[] PrepareRequest(TestCase tc)
        {
            Log.Debug("Preparing Request");

            Requests[] results;

            if (tc.PolicyType.Equals(PolicyType.Communication))
            {
                Log.Debug("PrepareRequest() Preparing communication request");

                bool withAttachment = true;
                string fromResourceName = null;

                if (string.IsNullOrEmpty(tc.FromResource.ResourceName))
                {
                    withAttachment = false;
                }

                if (withAttachment)
                {
                    fromResourceName = tc.FromResource.ResourceName;
                }
                else
                {
                    fromResourceName = "C:/No_attachment.ice";
                }

                results = new Requests[tc.Recipients.Count * 3 + 3];
                int i = 0;

                while (i < results.Length)
                {
                    results[i] = new Requests();
                    CEResource srcRes;
                    CEResource destRes;

                    if (i == 0 || i == 1 || i == 2)
                    {
                        //Preparing requests for sender
                        for (int j = 0; j < tc.Subject.SubjectDynamicAttributes.Count(); j = j + 2)
                        {
                            results[i].UserAttributes.Add(tc.Subject.SubjectDynamicAttributes[j]);
                            results[i].UserAttributes.Add(tc.Subject.SubjectDynamicAttributes[j + 1]);
                            Log.Debug("Added subject attribute pair : " + tc.Subject.SubjectDynamicAttributes[j]
                                + " : " + tc.Subject.SubjectDynamicAttributes[j + 1]);
                        }
                        results[i].IpAddress = tc.Subject.IpAddress;
                        results[i].Username = tc.Subject.Username;
                        results[i].Sid = tc.Subject.WindowsSid;

                        if (i == 0)
                        {
                            //Preparing request for sender on resource as the attachment
                            srcRes = new CEResource(fromResourceName, Settings.Default.Filesystem_Resource_Type);
                            destRes = new CEResource(null, null);
                            Log.Debug("From resource name : " + fromResourceName);
                            Log.Debug("From resource type : " + Settings.Default.Filesystem_Resource_Type);

                            for (int j = 0; j < tc.FromResource.ResourceDynamicAttributes.Count(); j += 2)
                            {
                                results[i].SourceAttributes.Add(tc.FromResource.ResourceDynamicAttributes[j]);
                                results[i].SourceAttributes.Add(tc.FromResource.ResourceDynamicAttributes[j + 1]);
                                Log.Debug("Added from resource attribute pair : " + tc.FromResource.ResourceDynamicAttributes[j] + " : " + tc.FromResource.ResourceDynamicAttributes[j + 1]);
                            }
                        }
                        else if (i == 1)
                        {

                            //Preparing request for sender on resource as the email subject
                            string emailSubjectFile = Path.Combine(Util.GetBaseDirectory(), tc.TestSet, tc.Name, "EmailSubject.txt");
                            createTextFile(@emailSubjectFile);

                            System.IO.File.WriteAllText(@emailSubjectFile, tc.EmailSubject);
                            srcRes = new CEResource(emailSubjectFile, Settings.Default.Filesystem_Resource_Type);
                            destRes = new CEResource(null, null);

                            results[i].SourceAttributes.Add("contenttype");
                            results[i].SourceAttributes.Add("Email Subject");

                            Log.Debug("From resource name : " + emailSubjectFile);
                            Log.Debug("From resource type : " + Settings.Default.Filesystem_Resource_Type);
                        }
                        else
                        {
                            //Preparing request for sender on resource as the email subject
                            string emailBodyFile = Path.Combine(Util.GetBaseDirectory(), tc.TestSet, tc.Name, "EmailBody.txt");
                            createTextFile(@emailBodyFile);

                            System.IO.File.WriteAllText(emailBodyFile, tc.EmailBody);
                            srcRes = new CEResource(emailBodyFile, Settings.Default.Filesystem_Resource_Type);
                            destRes = new CEResource(null, null);

                            results[i].SourceAttributes.Add("contenttype");
                            results[i].SourceAttributes.Add("Email Body");

                            Log.Debug("From resource name : " + emailBodyFile);
                            Log.Debug("From resource type : " + Settings.Default.Filesystem_Resource_Type);
                        }
                    }
                    else
                    {
                        //Preparing requests for individual recipient
                        Subject recipient = tc.Recipients.ElementAt((i - 3) / 3);
                        results[i].IpAddress = recipient.IpAddress;
                        results[i].Username = recipient.Username;
                        results[i].Sid = recipient.Username;

                        for (int j = 0; j < recipient.SubjectDynamicAttributes.Count; j = j + 2)
                        {
                            results[i].UserAttributes.Add(recipient.SubjectDynamicAttributes[j]);
                            results[i].UserAttributes.Add(recipient.SubjectDynamicAttributes[j + 1]);
                            Log.Debug("Added subject attribute pair : " + recipient.SubjectDynamicAttributes[j]
                                + " : " + tc.Subject.SubjectDynamicAttributes[j + 1]);
                        }

                        if (i % 3 == 0)
                        {
                            //Preparing request for individual recipient on resource as the attachment
                            srcRes = new CEResource(fromResourceName, Settings.Default.Filesystem_Resource_Type);
                            destRes = new CEResource(null, null);
                            Log.Debug("From resource name : " + fromResourceName);
                            Log.Debug("From resource type : " + Settings.Default.Filesystem_Resource_Type);

                            for (int j = 0; j < tc.FromResource.ResourceDynamicAttributes.Count(); j += 2)
                            {
                                results[i].SourceAttributes.Add(tc.FromResource.ResourceDynamicAttributes[j]);
                                results[i].SourceAttributes.Add(tc.FromResource.ResourceDynamicAttributes[j + 1]);
                                Log.Debug("Added from resource attribute pair : " + tc.FromResource.ResourceDynamicAttributes[j] + " : " + tc.FromResource.ResourceDynamicAttributes[j + 1]);
                            }
                        }
                        else if (i % 3 == 1)
                        {

                            //Preparing request for recipient on resource as the email subject
                            string emailSubjectFile = Path.Combine(Util.GetBaseDirectory(), tc.TestSet, tc.Name, "EmailSubject.txt");
                            srcRes = new CEResource(emailSubjectFile, Settings.Default.Filesystem_Resource_Type);
                            destRes = new CEResource(null, null);

                            results[i].SourceAttributes.Add("contenttype");
                            results[i].SourceAttributes.Add("Email Subject");

                            Log.Debug("From resource name : " + emailSubjectFile);
                            Log.Debug("From resource type : " + Settings.Default.Filesystem_Resource_Type);
                        }
                        else
                        {
                            //Preparing request for recipient on resource as the email subject
                            string emailBodyFile = Path.Combine(Util.GetBaseDirectory(), tc.TestSet, tc.Name, "EmailBody.txt");
                            srcRes = new CEResource(emailBodyFile, Settings.Default.Filesystem_Resource_Type);
                            destRes = new CEResource(null, null);

                            results[i].SourceAttributes.Add("contenttype");
                            results[i].SourceAttributes.Add("Email Body");

                            Log.Debug("From resource name : " + emailBodyFile);
                            Log.Debug("From resource type : " + Settings.Default.Filesystem_Resource_Type);
                        }
                    }

                    foreach (Subject rep in tc.Recipients)
                    {
                        results[i].Recipients.Add(rep.Username);
                    }
                    results[i].AppName = tc.Subject.ApplicationName;
                    results[i].Operation = tc.Action;
                    results[i].SourceName = srcRes.name;
                    results[i].SourceType = srcRes.type;
                    results[i].TargetName = destRes.name;
                    results[i].TargetType = destRes.type;
                    results[i].SourceAttributes.Add("ce::nocache");
                    results[i].SourceAttributes.Add("yes");
                    results[i].PerformObligation = true;

                    i++;
                }
            }
            else
            {
                Requests req = new Requests();

                for (int j = 0; j < tc.Subject.SubjectDynamicAttributes.Count(); j = j + 2)
                {
                    req.UserAttributes.Add(tc.Subject.SubjectDynamicAttributes[j]);
                    req.UserAttributes.Add(tc.Subject.SubjectDynamicAttributes[j + 1]);
                    Log.Debug("Added subject attribute pair : " + tc.Subject.SubjectDynamicAttributes[j] + " : " + tc.Subject.SubjectDynamicAttributes[j + 1]);
                }

                for (int j = 0; j < tc.FromResource.ResourceDynamicAttributes.Count(); j += 2)
                {
                    req.SourceAttributes.Add(tc.FromResource.ResourceDynamicAttributes[j]);
                    req.SourceAttributes.Add(tc.FromResource.ResourceDynamicAttributes[j + 1]);
                    Log.Debug("Added from resource attribute pair : " + tc.FromResource.ResourceDynamicAttributes[j] + " : " + tc.FromResource.ResourceDynamicAttributes[j + 1]);
                }

                for (int j = 0; j < tc.ToResource.ResourceDynamicAttributes.Count(); j += 2)
                {
                    req.TargetAttributes.Add(tc.ToResource.ResourceDynamicAttributes[j]);
                    req.TargetAttributes.Add(tc.ToResource.ResourceDynamicAttributes[j + 1]);
                    Log.Debug("Added from resource attribute pair : " + tc.ToResource.ResourceDynamicAttributes[j] + " : " + tc.ToResource.ResourceDynamicAttributes[j + 1]);
                }

                CEResource srcRes;
                CEResource destRes;

                switch (tc.TargetSystem)
                {
                    case TargetSystem.Enovia:
                        srcRes = new CEResource(tc.FromResource.ResourceName, Settings.Default.Enovia_Resource_Type);
                        //destRes = null;
                        destRes = new CEResource(null, null);
                        Log.Debug("From resource name : " + tc.FromResource.ResourceName);
                        Log.Debug("From resource type : " + Settings.Default.Enovia_Resource_Type);
                        break;
                    case TargetSystem.Filesystem:
                        srcRes = new CEResource(tc.FromResource.ResourceName, Settings.Default.Filesystem_Resource_Type);
                        destRes = new CEResource(tc.ToResource.ResourceName, Settings.Default.Filesystem_Resource_Type);
                        Log.Debug("From resource name : " + tc.FromResource.ResourceName);
                        Log.Debug("From resource type : " + Settings.Default.Filesystem_Resource_Type);
                        Log.Debug("To resource name   : " + tc.ToResource.ResourceName);
                        Log.Debug("To resource type   : " + Settings.Default.Filesystem_Resource_Type);
                        break;
                    case TargetSystem.Portal:
                        srcRes = new CEResource(tc.FromResource.ResourceName, Settings.Default.Portal_Resource_Type);
                        //destRes = null;
                        destRes = new CEResource(null, null);
                        Log.Debug("From resource name : " + tc.FromResource.ResourceName);
                        Log.Debug("From resource type : " + Settings.Default.Portal_Resource_Type);
                        break;
                    case TargetSystem.Sap:
                        srcRes = new CEResource(tc.FromResource.ResourceName, Settings.Default.SAP_Resource_Type);
                        //destRes = null;
                        destRes = new CEResource(null, null);
                        Log.Debug("From resource name : " + tc.FromResource.ResourceName);
                        Log.Debug("From resource type : " + Settings.Default.SAP_Resource_Type);
                        break;
                    case TargetSystem.Server:
                        srcRes = new CEResource(tc.FromResource.ResourceName, Settings.Default.Server_Resource_Type);
                        //destRes = null;
                        destRes = new CEResource(null, null);
                        Log.Debug("From resource name : " + tc.FromResource.ResourceName);
                        Log.Debug("From resource type : " + Settings.Default.Server_Resource_Type);
                        break;
                    default:
                        srcRes = new CEResource(tc.FromResource.ResourceName, Settings.Default.Filesystem_Resource_Type);
                        //destRes = null;
                        destRes = new CEResource(null, null);
                        Log.Debug("From resource name : " + tc.FromResource.ResourceName);
                        Log.Debug("From resource type : " + Settings.Default.Filesystem_Resource_Type);
                        break;
                }

                req.AppName = tc.Subject.ApplicationName;
                req.Operation = tc.Action;
                req.SourceName = srcRes.name;
                req.SourceType = srcRes.type;
                req.TargetName = destRes.name;
                req.TargetType = destRes.type;
                req.SourceAttributes.Add("ce::nocache");
                req.SourceAttributes.Add("yes");
                req.Username = tc.Subject.Username;
                req.Sid = tc.Subject.WindowsSid;
                req.PerformObligation = true;
                req.IpAddress = tc.Subject.IpAddress;
                //req.AppAttributes.Add("App1");
                //req.AppAttributes.Add("test1");
                //req.AdditionalAttributes.Add("add");
                //req.AdditionalAttributes.Add("key1");
                //req.AdditionalAttributes.Add("value1"); 
                results = new Requests[1];
                results[0] = req;
            }

            return results;
        }


        private void createTextFile(string file)
        {
            string directory = Directory.GetParent(file).FullName;
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            if (!File.Exists(file))
            {
                File.CreateText(file).Close();
            }
        }


        private void appendTextToRichTextBox(string text, RichTextBox textBox)
        {
            var rtf = string.Format(@"{{\rtf1\ansi\ {0}}}", text);
            textBox.SelectionStart = textBox.TextLength;
            textBox.SelectedRtf = rtf;
        }


        private EnforcementResult printEnforcementResult(EnforcementResult[] result, RichTextBox textBox)
        {
            EnforcementResult finalResult = null;

            appendTextToRichTextBox(string.Format("\\fs23 Test Case \\b {0} \\b0 Evaluated on {1}.\\line\\line",
                result[0].SourceTestCase.Name, DateTime.Now.toString()), textBox);

            appendTextToRichTextBox(result[0].SourceTestCase.PrintToRichTextBox(), textBox);

            if (result[0].SourceTestCase.PolicyType == PolicyType.Document)
            {
                //handling result for document request -- only 1 enforcement result received  
                finalResult = result[0];
                appendTextToRichTextBox(finalResult.PrintToRichTextBoxDocument(), textBox);

                //for document request, only one policy message will be returned so can be shown in the UI
                if (finalResult.attributes != null)
                {
                    for (int i = 0; i < finalResult.attributes.Length; i = i + 1)
                    {
                        if (finalResult.attributes[i].value.equalsIgnoreCase("CE::NOTIFY"))
                        {
                            string obligationNumberString = finalResult.attributes[i].key.split(":")[finalResult.attributes[i].key.split(":").Count() - 1];
                            string notifyMessageKey = "CE_ATTR_OBLIGATION_VALUE:" + obligationNumberString;
                            for (int j = 0; j < finalResult.attributes.Length; j++)
                            {
                                if (finalResult.attributes[j].key == notifyMessageKey)
                                {
                                    finalResult.policyMessage = finalResult.attributes[j].value;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                //handling result for communication request - multiple results received
                Decision finalDecision = Decision.Allow;
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i].response == Decision.Error)
                    {
                        finalDecision = Decision.Error;
                        break;
                    }
                }

                if (finalDecision != Decision.Error)
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        if (result[i].response == Decision.Deny)
                        {
                            finalDecision = Decision.Deny;
                        }
                    }
                }

                finalResult = new EnforcementResult();
                finalResult.response = finalDecision;
                finalResult.attributes = result[0].attributes;
                finalResult.SourceTestCase = result[0].SourceTestCase;
                appendTextToRichTextBox("\\fs23\\b Enforcement Result: " + finalDecision.ToString() + "\\b0\\line", textBox);

                for (int i = 0; i < result.Length; i++)
                {
                    if (i == 0)
                    {
                        appendTextToRichTextBox("".PadLeft(4) + "\\fs21 Enforcement Result for SENDER \\b "
                            + result[0].SourceTestCase.Subject.Username + "\\b0:\\line", textBox);
                    }
                    else if (i % 3 == 0)
                    {
                        appendTextToRichTextBox("".PadLeft(4) + "\\fs21 Enforcement Result for RECIPIENT \\b "
                            + result[0].SourceTestCase.Recipients[(i - 3) / 3].Username + "\\b0:\\line", textBox);
                        //resultRichTextField.AppendText(result[i].toString());
                    }

                    if (i % 3 == 0)
                    {
                        appendTextToRichTextBox("".PadLeft(6) + "\\fs21 On \\b Attachment\\b0 :", textBox);
                        appendTextToRichTextBox(result[i].PrintToRichTextBoxCommunication(), textBox);
                    }
                    if (i % 3 == 1)
                    {
                        appendTextToRichTextBox("".PadLeft(6) + "\\fs21 On \\b Email Subject\\b0 :", textBox);
                        appendTextToRichTextBox(result[i].PrintToRichTextBoxCommunication(), textBox);
                    }
                    if (i % 3 == 2)
                    {
                        appendTextToRichTextBox("".PadLeft(6) + "\\fs21 On \\b Email Body\\b0 :", textBox);
                        appendTextToRichTextBox(result[i].PrintToRichTextBoxCommunication(), textBox);
                    }
                    //resultRichTextField.AppendText(result[i].toString());
                }
            }

            return finalResult;
        }


        private List<string> exportHeadings()
        {
            List<string> headings = new List<string>();
            headings.Add("Test Set");
            headings.Add("Test Case");
            headings.Add("Policy Type");
            headings.Add("Expected Result");
            headings.Add("Result");
            headings.Add("Subject Type");
            headings.Add("Username");
            headings.Add("Windows SID");
            headings.Add("Application Name");
            headings.Add("IP Address");
            headings.Add("[SDA]");
            headings.Add("Action");
            headings.Add("From Resource Type");
            headings.Add("From Resource");
            headings.Add("[FRDA]");
            headings.Add("To Resource");
            headings.Add("[TRDA]");
            headings.Add("Obligations");
            headings.Add("Timestamp");
            return headings;
        }


        private List<string> exportDataFromEnforcementResult(EnforcementResult result, List<string> headings, string subjectType, string subject, string fromResourceType)
        {
            List<string> content = new List<string>();
            var sb = new StringBuilder();
            TestCase testCase = result.SourceTestCase;
            foreach (string heading in headings)
            {
                switch (heading)
                {
                    case "Test Set":
                        content.Add(testCase.TestSet);
                        break;
                    case "Test Case":
                        content.Add(testCase.Name);
                        break;
                    case "Policy Type":
                        content.Add(testCase.PolicyType.ToString());
                        break;
                    case "Expected Result":
                        content.Add(testCase.ExpectedResult.toString());
                        break;
                    case "Result":
                        string actualResult;
                        if (result.response == Decision.Allow)
                        {
                            actualResult = "Allow";
                        }
                        else if (result.response == Decision.Deny)
                        {
                            actualResult = "Deny";
                        }
                        else
                        {
                            actualResult = "Error";
                        }
                        content.Add(actualResult);
                        break;
                    case "Subject Type":
                        content.Add(subjectType);
                        break;
                    case "Username":
                        content.Add(subject);
                        break;
                    case "Windows SID":
                        if (testCase.PolicyType.Equals(PolicyType.Document))
                        {
                            content.Add(testCase.Subject.WindowsSid);
                        }
                        else
                        {
                            content.Add("N.A.");
                        }
                        break;
                    case "Application Name":
                        if (testCase.PolicyType.Equals(PolicyType.Document))
                        {
                            content.Add(testCase.Subject.ApplicationName);
                        }
                        else
                        {
                            content.Add("N.A.");
                        }
                        break;
                    case "IP Address":
                        if (testCase.PolicyType.Equals(PolicyType.Document))
                        {
                            content.Add(testCase.Subject.IpAddress);
                        }
                        else
                        {
                            content.Add("N.A.");
                        }
                        break;
                    case "Action":
                        content.Add(testCase.Action);
                        break;
                    case "From Resource":
                        if (fromResourceType.equalsIgnoreCase("email subject"))
                        {
                            content.Add(testCase.EmailSubject);
                        }
                        else if (fromResourceType.equalsIgnoreCase("email body"))
                        {
                            content.Add(testCase.EmailBody);
                        }
                        else
                        {
                            content.Add(testCase.FromResource.ResourceName);
                        }
                        break;
                    case "From Resource Type":
                        content.Add(fromResourceType);
                        break;
                    case "[SDA]":
                        if (testCase.Subject.SubjectDynamicAttributes.Count() > 0)
                        {

                            StringBuilder builder = new StringBuilder();
                            for (int i = 0; i < testCase.Subject.SubjectDynamicAttributes.Count(); i = i + 2)
                            {
                                builder.Append(testCase.Subject.SubjectDynamicAttributes[i]);
                                builder.Append(":");
                                builder.Append(testCase.Subject.SubjectDynamicAttributes[i + 1]);
                                builder.Append("; ");
                            }
                            builder.Length -= 2;
                            content.Add(builder.toString());
                        }
                        else
                        {
                            content.Add("N.A.");
                        }
                        break;
                    case "[FRDA]":
                        if (testCase.FromResource.ResourceDynamicAttributes.Count() > 0)
                        {
                            StringBuilder builder1 = new StringBuilder();
                            for (int i = 0; i < testCase.FromResource.ResourceDynamicAttributes.Count(); i = i + 2)
                            {
                                builder1.Append(testCase.FromResource.ResourceDynamicAttributes[i]);
                                builder1.Append(":");
                                builder1.Append(testCase.FromResource.ResourceDynamicAttributes[i + 1]);
                                builder1.Append("; ");
                            }
                            builder1.Length -= 2;
                            content.Add(builder1.toString());
                        }
                        else
                        {
                            content.Add("N.A.");
                        }
                        break;
                    case "[TRDA]":
                        if (testCase.ToResource.ResourceDynamicAttributes.Count() > 0)
                        {
                            StringBuilder builder2 = new StringBuilder();
                            for (int i = 0; i < testCase.ToResource.ResourceDynamicAttributes.Count(); i = i + 2)
                            {
                                builder2.Append(testCase.ToResource.ResourceDynamicAttributes[i]);
                                builder2.Append(":");
                                builder2.Append(testCase.ToResource.ResourceDynamicAttributes[i + 1]);
                                builder2.Append("; ");
                            }
                            builder2.Length -= 2;
                            content.Add(builder2.toString());
                        }
                        else
                        {
                            content.Add("N.A.");
                        }
                        break;
                    case "To Resource":
                        if (string.IsNullOrEmpty(testCase.ToResource.ResourceName))
                        {
                            content.Add("N.A.");
                        }
                        else
                        {
                            content.Add(testCase.ToResource.ResourceName);
                        }
                        break;
                    default:
                        break;
                }

                if (heading.Equals("Obligations"))
                {
                    StringBuilder osb = new StringBuilder();
                    osb.Append("\"");
                    if (result.attributes != null)
                    {
                        for (int i = 0; i < result.attributes.Length; i++)
                        {
                            osb.AppendLine(result.attributes[i].key + ": " + result.attributes[i].value + "\n");
                        }
                    }
                    int index = osb.ToString().LastIndexOf("\n", StringComparison.Ordinal);
                    if (index >= 0)
                        osb.Remove(index, 1);
                    osb.Append("\"");
                    content.Add(osb.toString());
                }

                if (heading.Equals("Timestamp"))
                {
                    content.Add(DateTime.Now.ToString());
                }
            }
            return content;
        }


        private void validateTestCaseButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!testCaseBackgroundWorker.IsBusy)
                {
                    ValidateForm();
                    validateTestCaseButton.Enabled = false;
                    validateTestCaseButton.BackColor = System.Drawing.Color.DarkSeaGreen;
                    exportTestCaseResultButton.Enabled = false;
                    exportTestCaseResultButton.BackColor = System.Drawing.Color.LightBlue;
                    TestCase tc = GenerateTestCaseFromForm();
                    testCaseBackgroundWorker.RunWorkerAsync(tc);
                    treeView.Enabled = false;
                }
            }

            catch (Exception ex)
            {
                Log.Error("An error occured while validating Test Case. ", ex);
                MessageBox.Show(ex.Message,
                    "Cannot Validate Test Case", MessageBoxButtons.OK, MessageBoxIcon.Error);
                validateTestCaseButton.Enabled = true;
                validateTestCaseButton.BackColor = System.Drawing.Color.MediumSeaGreen;
                exportTestCaseResultButton.Enabled = false;
                exportTestCaseResultButton.BackColor = System.Drawing.Color.LightBlue;
            }
        }


        private EnforcementResult[] validateTestCaseResult(TestCase tc)
        {
            Log.Info("Evaluating test case.");
            EnforcementResult[] enforcement = null;
            IValidate validator;
            if (Settings.Default.JavaPC)
            {
                validator = new ValidateJava();
            }
            else
            {
                validator = new ValidateWindows();
            }

            try
            {
                Requests[] req = PrepareRequest(tc);
                enforcement = new EnforcementResult[req.Length];

                bool connected = validator.ConnectToPC(tc.Subject.ApplicationName, tc.Subject.WindowsSid, tc.Subject.Username, Settings.Default.PC_IP_Address,
                    Settings.Default.PC_Port, Settings.Default.Timeout_S);

                if (connected)
                {
                    Log.Info("Connected to PC.");

                    bool result = validator.Evaluate(req, null, false, out enforcement, (int)Settings.Default.Timeout_S);

                    if (!result)
                    {
                        enforcement[0].response = Decision.Error;
                    }

                    bool disconnect = validator.DisconnectFromPC();
                    if (disconnect)
                    {
                        Log.Info("Successfully disconnected from PC.");
                    }
                    else
                    {
                        Log.Info("Disconnecting failed.");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occured while validating Test Case. ", ex);
                MessageBox.Show(ex.getMessage() + ". Please see the log for more details.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return enforcement;
        }


        private void testCaseBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            if ((sender as BackgroundWorker).CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                if (e.Argument != null)
                {
                    TestCase tc = e.Argument as TestCase;
                    EnforcementResult[] result = validateTestCaseResult(tc);
                    if (result != null)
                    {
                        for (int i = 0; i < result.Length; i++)
                        {
                            result[i].SourceTestCase = tc;
                        }
                        e.Result = result;
                    }
                    else
                    {
                        e.Result = null;
                    }
                }
            }
        }



        private void testCaseBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            treeView.Enabled = true;
            EnforcementResult[] result = e.Result as EnforcementResult[];
            if (e.Result != null)
            {
                EnforcementResult finalResult = printEnforcementResult(result, resultRichTextField);
                finalResult.subResults = result;

                if (finalResult.response == Decision.Allow)
                {
                    statusIndicatorLabel.BackColor = Color.Green;
                    if (!string.IsNullOrEmpty(finalResult.policyMessage))
                    {
                        statusLabel.Text = "Allow (" + finalResult.policyMessage + ")";
                    }
                    else
                    {
                        statusLabel.Text = "Allow";
                    }
                }
                else if (finalResult.response == Decision.Deny)
                {
                    statusIndicatorLabel.BackColor = Color.Red;
                    if (!string.IsNullOrEmpty(finalResult.policyMessage))
                    {
                        statusLabel.Text = "Deny (" + finalResult.policyMessage + ")";
                    }
                    else
                    {
                        statusLabel.Text = "Deny";
                    }
                }
                else
                {
                    statusIndicatorLabel.BackColor = Color.Red;
                    if (!string.IsNullOrEmpty(finalResult.policyMessage))
                    {
                        statusLabel.Text = "Deny (" + finalResult.policyMessage + ")";
                    }
                    else
                    {
                        statusLabel.Text = "Deny";
                    }
                }

                string exportFilePath = Path.Combine(Environment.GetEnvironmentVariable("temp"), "NXL_TestCase_Export.csv");
                if (File.Exists(exportFilePath))
                {
                    File.Delete(exportFilePath);
                }

                using (StreamWriter writer = new StreamWriter(exportFilePath, true))
                {
                    writer.Write(TestCaseToCsv(finalResult, treeView.SelectedNode.FullPath, true));
                }

                exportTestCaseResultButton.Enabled = true;
                exportTestCaseResultButton.BackColor = System.Drawing.Color.SteelBlue;
            }
            else
            {
                statusIndicatorLabel.BackColor = Color.Maroon;
                statusLabel.Text = "Error";
            }

            validateTestCaseButton.Enabled = true;
            validateTestCaseButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            if (closeRequested) this.Close();
        }


        private string TestCaseToCsv(EnforcementResult result, string nodePath, bool withHeader)
        {
            StringBuilder csvBuilder = new StringBuilder();
            List<string> headings = this.exportHeadings();
            try
            {

                if (result.SourceTestCase.PolicyType.Equals(PolicyType.Document))
                {
                    List<string> content = this.exportDataFromEnforcementResult(result, headings, "User/Application",
                        result.SourceTestCase.Subject.Username, "File System Object");
                    if (withHeader)
                        csvBuilder.AppendLine(string.Join(",", headings.ToArray()));
                    csvBuilder.AppendLine(string.Join(",", content.ToArray()));
                }
                else
                {
                    List<List<string>> testCaseContent = new List<List<string>>();
                    for (int i = 0; i < result.subResults.Length; i++)
                    {
                        String subjectType;
                        String fromResourceType;
                        String subject;
                        if (i == 0 || i == 1 || i == 2)
                        {
                            subjectType = "SENDER";
                            subject = result.subResults[i].SourceTestCase.Subject.Username;
                        }
                        else
                        {
                            subjectType = "RECIPIENT";
                            subject = result.subResults[i].SourceTestCase.Recipients[(i - 3) / 3].Username;
                        }

                        if (i % 3 == 0)
                        {
                            fromResourceType = "Email Subject";
                        }
                        else if (i % 3 == 1)
                        {
                            fromResourceType = "Email Body";
                        }
                        else
                        {
                            fromResourceType = "Attachment";
                        }
                        testCaseContent.Add(this.exportDataFromEnforcementResult(result.subResults[i], headings, subjectType, subject, fromResourceType));
                    }
                    if (withHeader)
                        csvBuilder.AppendLine(string.Join(",", headings.ToArray()));
                    foreach (List<string> item in testCaseContent)
                    {
                        csvBuilder.AppendLine(string.Join(",", item.ToArray()));
                    }

                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occured while constructing test case result to csv. ", ex);
                MessageBox.Show(ex.Message + " Please see the log for more details.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return csvBuilder.toString();

        }


        private void ClearResult()
        {
            resultRichTextField.Clear();
            statusIndicatorLabel.BackColor = Color.Transparent;
            statusLabel.Text = "";
        }



        private void clearTestCaseResultButton_Click(object sender, EventArgs e)
        {
            ClearResult();

            exportTestCaseResultButton.Enabled = false;
            exportTestCaseResultButton.BackColor = System.Drawing.Color.LightBlue;
            validateTestCaseButton.Enabled = true;
            validateTestCaseButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            validateTestCaseButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            string exportFilePath = Path.Combine(Environment.GetEnvironmentVariable("temp"), "NXL_TestCase_Export.csv");

            if (File.Exists(exportFilePath))
                File.Delete(exportFilePath);
        }



        private void runTestSetButton_Click(object sender, EventArgs e)
        {
            try
            {
                exportTestSetResultButton.Enabled = false;
                exportTestSetResultButton.BackColor = System.Drawing.Color.LightBlue;
                runTestSetButton.Enabled = false;
                runTestSetButton.BackColor = System.Drawing.Color.DarkSeaGreen;
                treeView.Enabled = false;
                ResultrichTextBox.Text = "";

                if (!testSetBackgroundWorker.IsBusy)
                {
                    statusIndicatorLabel.BackColor = Color.Blue;
                    newTestCaseButton.Enabled = false;
                    newTestCaseButton.BackColor = System.Drawing.Color.Silver;
                    newTestSetButton.Enabled = false;
                    newTestSetButton.BackColor = System.Drawing.Color.Silver;
                    testSetBackgroundWorker.RunWorkerAsync(treeView.SelectedNode.Text);
                    exportTestSetResultButton.Enabled = false;
                    exportTestSetResultButton.BackColor = System.Drawing.Color.LightBlue;
                    runTestSetButton.Enabled = false;
                    runTestSetButton.BackColor = System.Drawing.Color.DarkSeaGreen;
                }
            }
            catch (Exception)
            {
                exportTestSetResultButton.Enabled = true;
                exportTestSetResultButton.BackColor = System.Drawing.Color.SteelBlue;
                runTestSetButton.Enabled = true;
                runTestSetButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            }
        }



        private EnforcementResult[] validateTestSetResult(List<TestCase> testCases)
        {
            List<EnforcementResult> finalEnforcement = new List<EnforcementResult>();

            IValidate validator;
            if (Settings.Default.JavaPC)
            {
                validator = new ValidateJava();
            }
            else
            {
                validator = new ValidateWindows();
            }

            bool connected = validator.ConnectToPC("Policy Validator", "PV Sid", "PV Username", Settings.Default.PC_IP_Address, Settings.Default.PC_Port, Settings.Default.Timeout_S);
            if (connected)
            {
                List<TestCase> communicationCases = new List<TestCase>();
                List<TestCase> documentCases = new List<TestCase>();



                for (int i = 0; i < testCases.Count; i++)
                {
                    if (testCases[i].PolicyType == PolicyType.Document)
                    {
                        documentCases.Add(testCases[i]);
                    }
                    else
                    {
                        communicationCases.Add(testCases[i]);
                    }
                }

                //evaluating document cases
                Requests[] documentRequests = new Requests[documentCases.Count];

                EnforcementResult[] documentEnforcement = new EnforcementResult[documentCases.Count];
                for (int i = 0; i < documentCases.Count; i++)
                {
                    EnforcementResult result;
                    TestCase tc = documentCases[i];

                    if (tc.IsIncomplete())
                    {
                        result = new EnforcementResult();
                        result.SourceTestCase = tc;
                        result.response = Decision.Error;
                    }

                    else
                    {
                        documentEnforcement[i] = new EnforcementResult();
                        documentEnforcement[i].SourceTestCase = tc;
                        documentRequests[i] = PrepareRequest(tc)[0];
                    }
                }
                bool documentResult = validator.Evaluate(documentRequests, null, true, out documentEnforcement, (int)Settings.Default.Timeout_S);
                for (int i = 0; i < documentCases.Count; i++)
                {
                    TestCase tc = documentCases[i];
                    documentEnforcement[i].SourceTestCase = tc;
                    finalEnforcement.Add(documentEnforcement[i]);
                }

                //evaluating communication cases
                for (int i = 0; i < communicationCases.Count; i++)
                {
                    TestCase tc = communicationCases[i];
                    EnforcementResult result = new EnforcementResult();
                    Requests[] communicationRequests = new Requests[tc.Recipients.Count + 3];
                    EnforcementResult[] communicationEnforcement = new EnforcementResult[communicationRequests.Length];

                    if (tc.IsIncomplete())
                    {
                        result = new EnforcementResult();
                        result.SourceTestCase = tc;
                        result.response = Decision.Error;
                    }

                    else
                    {
                        communicationRequests = PrepareRequest(tc);
                        bool communicationResult = validator.Evaluate(communicationRequests, null, true, out communicationEnforcement, (int)Settings.Default.Timeout_S);
                        if (!communicationResult)
                        {
                            result.response = Decision.Error;
                        }
                        else
                        {
                            result.attributes = communicationEnforcement[0].attributes;
                            result.SourceTestCase = tc;

                            for (int j = 0; j < communicationEnforcement.Length; j++)
                            {
                                communicationEnforcement[j].SourceTestCase = tc;
                            }

                            for (int j = 0; j < communicationEnforcement.Length; j++)
                            {
                                if (communicationEnforcement[j].response == Decision.Error)
                                {
                                    result.response = Decision.Error;
                                    break;
                                }
                            }

                            if (result.response != Decision.Error)
                            {
                                for (int j = 0; j < communicationEnforcement.Length; j++)
                                {
                                    if (communicationEnforcement[j].response == Decision.Deny)
                                    {
                                        result.response = Decision.Deny;
                                        break;
                                    }
                                }
                            }

                            result.subResults = communicationEnforcement;
                        }
                    }

                    finalEnforcement.Add(result);
                }

                validator.DisconnectFromPC();
            }
            else
            {
                Log.Debug("Not connected to Policy Controller");
            }

            return finalEnforcement.ToArray();
        }



        private void testSetBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            testCasesPassed = 0;
            statusLabel.Text = "Processing...";
            string exportFilePath = Path.Combine(Environment.GetEnvironmentVariable("temp"), "NXL_TestSet_Export.csv");

            if (File.Exists(exportFilePath))
            {
                File.Delete(exportFilePath);
            }

            if (e.Argument != null)
            {
                string testSet = e.Argument as string;
                List<TestCase> testCases = MongoDBUtil.GetTestCasesByTestSet(testSet).Result;
                int count = testCases.Count();
                List<TestCase> validTestCases = new List<TestCase>();

                List<int> incompleteCases = new List<int>();
                for (int i = 0; i < testCases.Count(); i++)
                {
                    if (testCases[i].IsIncomplete())
                    {
                        incompleteCases.Add(i);
                    }
                    else
                    {
                        validTestCases.Add(testCases[i]);
                    }
                }

                EnforcementResult[] result = validateTestSetResult(validTestCases);
                EnforcementResult[] totalResult = new EnforcementResult[count];

                if (count == result.Count())
                {
                    totalResult = result;
                }
                else
                {

                    int incompleteProgress = 0;
                    int resultProgress = 0;

                    for (int i = 0; i < count; i++)
                    {
                        if (incompleteProgress < incompleteCases.Count && i == incompleteCases[incompleteProgress])
                        {
                            totalResult[i] = new EnforcementResult();
                            totalResult[i].SourceTestCase = testCases.ElementAt(i);
                            totalResult[i].response = Decision.Error;
                            incompleteProgress++;
                        }
                        else
                        {
                            totalResult[i] = result[resultProgress];
                            resultProgress++;
                        }
                    }
                }

                for (int i = 0; i < totalResult.Length; i++)
                {
                    if (totalResult[i] != null)
                    {
                        e.Result = totalResult;
                    }
                    else
                    {
                        e.Result = null;
                    }
                }
            }
        }



        private void testSetBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            treeView.Enabled = true;
            newTestCaseButton.Enabled = true;
            newTestCaseButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            newTestSetButton.Enabled = true;
            newTestSetButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            EnforcementResult[] enforcement = e.Result as EnforcementResult[];
            processTestSetEnforcement(enforcement);
        }



        private void clearTestSetResultButton_Click(object sender, EventArgs e)
        {
            EnforcementResult[] result = null;

            if (!testSetResultTable.TryGetValue(treeView.SelectedNode.Text, out result))
            {
                result = null;
            }
            if (result != null)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    Label lblResult = testSetTablePanel.GetControlFromPosition(4, i + 2) as Label;
                    lblResult.Text = ".............";
                    lblResult.ForeColor = System.Drawing.SystemColors.ControlText;
                    if (lblResult.Cursor.Equals(Cursors.Hand))
                    {
                        lblResult.Cursor = Cursors.Default;
                        lblResult.Click -= new System.EventHandler(individualTestCaseResult_Click);
                    }
                }
            }
            ResultrichTextBox.Clear();
            exportTestSetResultButton.Enabled = false;
            exportTestSetResultButton.BackColor = System.Drawing.Color.LightBlue;
            runTestSetButton.Enabled = true;
            runTestSetButton.BackColor = System.Drawing.Color.MediumSeaGreen;
        }


        private void individualTestCaseResult_Click(object sender, EventArgs e)
        {
            try
            {
                Label clickedLabel = sender as Label;
                int position = testSetTablePanel.GetPositionFromControl(clickedLabel).Row;

                EnforcementResult[] results = null;
                testSetResultTable.TryGetValue(treeView.SelectedNode.Text, out results);

                if (results != null)
                {
                    TestCaseResult resultDialog = new TestCaseResult(results[position - 2]);
                    resultDialog.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                Log.Error("An error occured while loading individual test case result. ", ex);
                MessageBox.Show(ex.Message + " Please see the log for more details.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void processTestSetEnforcement(EnforcementResult[] enforcement)
        {
            if (enforcement != null)
            {
                appendTextToRichTextBox("\\fs23 Test Set \\b " + treeView.SelectedNode.Text + "\\b0  Evaluated on " + DateTime.Now.toString() + Environment.NewLine + "\\line", ResultrichTextBox);
                appendTextToRichTextBox("\\b ----------------------------------------------------------------------------------------\\b0\\line", ResultrichTextBox);

                testCasesPassed = 0;

                for (int i = 0; i < enforcement.Length; i++)
                {
                    Label lblResult = testSetTablePanel.GetControlFromPosition(4, i + 2) as Label;
                    Label lblExpResult = testSetTablePanel.GetControlFromPosition(3, i + 2) as Label;

                    if (enforcement[i].response == Decision.Allow)
                    {
                        lblResult.ForeColor = Color.Green;
                        lblResult.Text = "Allow";
                    }
                    else if (enforcement[i].response == Decision.Deny)
                    {
                        lblResult.ForeColor = Color.Red;
                        lblResult.Text = "Deny";
                    }
                    else
                    {
                        lblResult.ForeColor = Color.PaleVioletRed;
                        lblResult.Text = "Incomplete";
                    }

                    Label testNameLbl = testSetTablePanel.GetControlFromPosition(0, i + 2) as Label;

                    if (enforcement[i].SourceTestCase.IsIncomplete())
                    {
                        appendTextToRichTextBox("\\fs23 Test Case \\b " + enforcement[i].SourceTestCase.Name + "\\b0  is incomplete. Validation was skipped\\line", ResultrichTextBox);
                    }
                    else
                    {
                        if (enforcement[i].SourceTestCase.PolicyType.Equals(PolicyType.Document))
                        {
                            EnforcementResult[] temp = { enforcement[i] };
                            printEnforcementResult(temp, ResultrichTextBox);
                        }
                        else
                        {
                            printEnforcementResult(enforcement[i].subResults, ResultrichTextBox);
                        }
                    }
                    appendTextToRichTextBox("\\b ----------------------------------------------------------------------------------------\\b0\\line", ResultrichTextBox);
                    if (lblResult.Text.Trim() == lblExpResult.Text.Trim())
                    {
                        testCasesPassed++;
                    }

                    if (enforcement[i].SourceTestCase.PolicyType.Equals(PolicyType.Communication))
                    {
                        if (!lblResult.Cursor.Equals(Cursors.Hand))
                        {
                            lblResult.Cursor = Cursors.Hand;
                            lblResult.Text += " (More)";
                            lblResult.Click += new System.EventHandler(individualTestCaseResult_Click);
                        }
                    }
                }

                if (testSetResultTable.ContainsKey(treeView.SelectedNode.Text))
                {
                    testSetResultTable.Remove(treeView.SelectedNode.Text);
                }
                testSetResultTable.Add(treeView.SelectedNode.Text, enforcement);

                if (testCasesPassed == enforcement.Length)
                {
                    statusIndicatorLabel.BackColor = Color.Green;
                }
                else
                {
                    statusIndicatorLabel.BackColor = Color.Red;
                }

                statusLabel.Text = testCasesPassed.toString() + "/" + enforcement.Length.toString() + " test cases passed.";
                string exportFilePath = Path.Combine(Environment.GetEnvironmentVariable("temp"), "NXL_TestSet_Export.csv");

                if (File.Exists(exportFilePath))
                {
                    File.Delete(exportFilePath);
                }

                using (StreamWriter writer = new StreamWriter(exportFilePath, true))
                {
                    writer.Write(TestSetToCsv(enforcement, treeView.SelectedNode.FullPath, true));
                }
                exportTestSetResultButton.Enabled = true;
                exportTestSetResultButton.BackColor = System.Drawing.Color.SteelBlue;
            }
            else
            {
                statusIndicatorLabel.BackColor = Color.Maroon;
                statusLabel.Text = "Error (Error Connecting to PC.)";
            }

            runTestSetButton.Enabled = true;
            runTestSetButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            if (closeRequested) this.Close();
        }


        private string TestSetToCsv(EnforcementResult[] result, string nodePath, bool withHeader)
        {
            var sb = new StringBuilder();
            List<string> headings = this.exportHeadings();
            StringBuilder csvBuilder = new StringBuilder();

            List<List<string>> testSetContent = new List<List<string>>();

            try
            {
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i].SourceTestCase.PolicyType.Equals(PolicyType.Document))
                    {
                        testSetContent.Add(exportDataFromEnforcementResult(result[i], headings, "User/Application",
                            result[i].SourceTestCase.Subject.Username, "File System Object"));
                    }
                    else
                    {
                        for (int j = 0; j < result[i].subResults.Length; j++)
                        {
                            String subjectType;
                            String fromResourceType;
                            String subject;
                            if (j == 0 || j == 1 || j == 2)
                            {
                                subjectType = "SENDER";
                                subject = result[i].subResults[j].SourceTestCase.Subject.Username;
                            }
                            else
                            {
                                subjectType = "RECIPIENT";
                                subject = result[i].subResults[j].SourceTestCase.Recipients[(j - 3) / 3].Username;
                            }

                            if (j % 3 == 0)
                            {
                                fromResourceType = "Email Subject";
                            }
                            else if (j % 3 == 1)
                            {
                                fromResourceType = "Email Body";
                            }
                            else
                            {
                                fromResourceType = "Attachment";
                            }
                            testSetContent.Add(this.exportDataFromEnforcementResult(result[i].subResults[j], headings, subjectType, subject, fromResourceType));
                        }
                    }
                }

                if (withHeader)
                    csvBuilder.AppendLine(string.Join(",", headings.ToArray()));
                foreach (List<string> item in testSetContent)
                {
                    csvBuilder.AppendLine(string.Join(",", item.ToArray()));
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occured while constructing test set result to csv. ", ex);
                MessageBox.Show(ex.Message + " Please see the log for more details.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return csvBuilder.toString();
        }



        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (testSetBackgroundWorker.IsBusy)
            {
                testSetBackgroundWorker.CancelAsync();
                this.Enabled = false;
                e.Cancel = true;
                closeRequested = true;
                return;
            }
            if (testSetLoader.IsBusy)
            {
                testSetLoader.CancelAsync();
                this.Enabled = false;
                e.Cancel = true;
                closeRequested = true;
                return;
            }
            if (testCaseBackgroundWorker.IsBusy)
            {
                testCaseBackgroundWorker.CancelAsync();
                this.Enabled = false;
                e.Cancel = true;
                closeRequested = true;
                return;
            }
            base.OnFormClosing(e);
        }


        private void PolicyValidatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (IsSelectedNodeATestCase())
                {
                    TestCase tc = GenerateTestCaseFromForm();
                    if (tc.IsIncomplete())
                    {
                        DialogResult dr = MessageBox.Show("Some of the mandatory fields are empty. The incompleted test case will be saved but will not be validated when running test set. Do you want to continue?",
                            "Incomplete Test Case", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            var result = MongoDBUtil.UpdateTestCase(tc, tc.Name).Result;
                            if (!result)
                            {
                                throw new Exception("Failed to update test case in the database");
                            }
                            dirty = false;
                        }
                        else
                        {
                            treeView.SelectedNode = Util.LocateNode(previousTestCasePath, treeView.Nodes);
                            e.Cancel = true;
                        }
                    }
                    else if (dirty)
                    {
                        DialogResult dr = MessageBox.Show("The current Test Case has some unsaved changes. Do you want to save? ", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            SaveForm();
                        }
                        dirty = false;
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occured while closing form. ", ex);
                MessageBox.Show(ex.Message + " Please see the log for more details.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }


        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(resultRichTextField.SelectedText))
            {
                Clipboard.SetText(resultRichTextField.SelectedText);
            }
            else
            {
                Clipboard.SetText(resultRichTextField.Text);
            }
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }



        private void exportTestCaseResultButton_Click(object sender, EventArgs e)
        {
            string exportFilePath = Path.Combine(Environment.GetEnvironmentVariable("temp"), "NXL_TestCase_Export.csv");

            if (File.Exists(exportFilePath))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV File (.csv)|*.csv";
                DialogResult dr = sfd.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    File.Copy(exportFilePath, sfd.FileName, true);
                }
            }
        }


        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string testSet = treeView.SelectedNode.Text;
                List<TestCase> testCases = MongoDBUtil.GetTestCasesByTestSet(testSet).Result;
                Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
                dict.Add("Name", new List<string>());

                List<string> keys = new List<string>();
                foreach (TestCase tc in testCases)
                {
                    foreach (KeyValuePair<string, string> item in tc.ToDictionary())
                    {
                        if (!dict.ContainsKey(item.Key))
                            dict.Add(item.Key, new List<string>());
                    }
                }

                foreach (TestCase tc in testCases)
                {
                    foreach (KeyValuePair<string, List<string>> item in dict)
                    {
                        if (tc.ToDictionary().ContainsKey(item.Key))
                        {
                            item.Value.Add(tc.ToDictionary()[item.Key]);
                        }
                        else if (item.Key.equalsIgnoreCase("Name"))
                        {
                            item.Value.Add(tc.Name);
                        }
                        else
                        {
                            item.Value.Add("");
                        }
                    }
                }

                Dictionary<string, string[]> csvDict = new Dictionary<string, string[]>();
                foreach (KeyValuePair<string, List<string>> item in dict)
                {
                    Console.Write(item.Key + ":");
                    foreach (string s in item.Value)
                    {
                        Console.Write(s + ", ");
                    }
                    Console.WriteLine();
                    csvDict.Add(item.Key, item.Value.ToArray());
                }

                var names = csvDict.Keys.OrderBy(l => l).ToArray();
                int maxSize = csvDict.Values.Max(a => a != null ? a.Length : 0);

                StringBuilder csv = new StringBuilder();
                csv.AppendLine(String.Join(", ", names));

                for (int i = 0; i < maxSize; i++)
                {
                    foreach (string name in names)
                    {
                        string[] value = csvDict[name];
                        if ((value != null) && (i < value.Length))
                        {
                            csv.Append(value[i]);
                        }
                        if (name != names.Last())
                        {
                            csv.Append(",");
                        }
                    }
                    csv.AppendLine("");
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV File (.csv)|*.csv";
                DialogResult dr = sfd.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    using (StreamWriter outfile = new StreamWriter(sfd.FileName))
                    {
                        outfile.Write(csv.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                Log.Error("An error occured while exporting test set. ", ex);
                MessageBox.Show(ex.Message + " Please see the log for more details.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void testCaseContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (empty || dirty)
            {
                exportToolStripMenuItem.Enabled = false;
                duplicateToolStripMenuItem.Enabled = false;
                renameToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
            }
            else
            {
                exportToolStripMenuItem.Enabled = true;
                duplicateToolStripMenuItem.Enabled = true;
                renameToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
            }

            if (IsSelectedNodeRoot())
            {
                e.Cancel = true;
            }

            if (IsSelectedNodeATestCase())
            {
                exportToolStripMenuItem.Enabled = false;
                editToolStripMenuItem.Enabled = false;
            }
            else
            {
                exportToolStripMenuItem.Enabled = true;
                editToolStripMenuItem.Enabled = true;
            }
        }


        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "CSV File (.csv)|*.csv";
                DialogResult dr = ofd.ShowDialog();

                string line;
                bool header = true;

                List<string> headers = new List<string>();
                List<string> content = new List<string>();
                List<List<string>> contents = new List<List<string>>();

                if (dr == DialogResult.OK)
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(ofd.FileName);
                    while ((line = file.ReadLine()) != null)
                    {
                        if (header)
                        {
                            headers = line.split(",").ToList();
                            header = false;
                            continue;
                        }
                        contents.Add(line.Split(',').ToList());
                    }

                    file.Close();

                    NewTestSet newTestSet = new NewTestSet();
                    DialogResult dr1 = newTestSet.ShowDialog();

                    if (dr1 == DialogResult.OK)
                    {
                        string newTestSetName = newTestSet.TestSetName;
                        var exist = MongoDBUtil.CheckTestSetExistence(newTestSetName).Result;
                        if (exist)
                        {
                            throw new Exception("Test Set already exists.");
                        }
                        else
                        {
                            try
                            {
                                var result = MongoDBUtil.CreateNewTestSet(newTestSetName).Result;
                                if (!result)
                                {
                                    throw new Exception("Failed to create test set");
                                }

                                int lineNumber = 1;

                                foreach (List<string> record in contents)
                                {
                                    lineNumber++;

                                    TestCase tc = new TestCase();
                                    tc.TestSet = newTestSetName;
                                    tc.ToResource.ResourceName = "";

                                    for (int i = 0; i < headers.Count; i++)
                                    {
                                        if (record.Count >= i && !string.IsNullOrEmpty(record[i].trim()))
                                        {
                                            switch (headers[i].trim().toLowerCase())
                                            {
                                                case "expected result":
                                                    tc.ExpectedResult =
                                                        (Decision)Enum.Parse(typeof(Decision), record[i], true);
                                                    break;
                                                case "target system":
                                                    tc.TargetSystem =
                                                        (TargetSystem)Enum.Parse(typeof(TargetSystem), record[i], true);
                                                    break;
                                                case "policy type":
                                                    tc.PolicyType = (PolicyType)Enum.Parse(typeof(PolicyType), record[i], true);
                                                    break;
                                                case "name":
                                                    tc.Name = record[i];
                                                    break;
                                                case "username":
                                                    tc.Subject.Username = record[i];
                                                    break;
                                                case "windows sid":
                                                    tc.Subject.WindowsSid = record[i];
                                                    break;
                                                case "application name":
                                                    tc.Subject.ApplicationName = record[i];
                                                    break;
                                                case "ip address":
                                                    tc.Subject.IpAddress = record[i];
                                                    break;
                                                case "action":
                                                    tc.Action = record[i];
                                                    break;
                                                case "recipients":
                                                    if (!string.IsNullOrEmpty(record[i]))
                                                    {
                                                        string[] recipientArray = record[i].split(";");
                                                        foreach (string rep in recipientArray)
                                                        {
                                                            tc.Recipients.Add(new Subject(rep, rep, "", "", new List<string>()));
                                                        }
                                                    }
                                                    break;
                                                case "email subject":
                                                    tc.EmailSubject = record[i];
                                                    break;
                                                case "email body":
                                                    tc.EmailBody = record[i];
                                                    break;
                                                case "from resource name":
                                                    tc.FromResource.ResourceName = record[i];
                                                    break;
                                                case "to resource name":
                                                    tc.ToResource.ResourceName = record[i];
                                                    break;
                                                case "[sa]":
                                                    List<string> rec = record[i].Split(new Char[] { ';', ':' }).ToList();
                                                    for (int j = 0; j < rec.Count; j++)
                                                    {
                                                        tc.Subject.SubjectDynamicAttributes.Add(rec[j]);
                                                    }
                                                    break;
                                                case "[fra]":
                                                    List<string> rec1 = record[i].Split(new Char[] { ';', ':' }).ToList();
                                                    for (int j = 0; j < rec1.Count; j++)
                                                    {
                                                        tc.FromResource.ResourceDynamicAttributes.Add(rec1[j]);
                                                    }
                                                    break;
                                                case "[tra]":
                                                    List<string> rec2 = record[i].Split(new Char[] { ';', ':' }).ToList();
                                                    for (int j = 0; j < rec2.Count; j++)
                                                    {
                                                        tc.ToResource.ResourceDynamicAttributes.Add(rec2[j]);
                                                    }
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                    }

                                    if (string.IsNullOrEmpty(tc.Subject.Username))
                                    {
                                        throw new Exception("Required attribute (Username) is missing in one or more Test Cases [" + lineNumber + "]. Please verify and try again.");
                                    }

                                    if (string.IsNullOrEmpty(tc.Subject.WindowsSid))
                                    {
                                        throw new Exception("Required attribute (Windows SID) is missing in one or more Test Cases [" + lineNumber + "]. Please verify and try again.");
                                    }

                                    if (string.IsNullOrEmpty(tc.Subject.ApplicationName))
                                    {
                                        throw new Exception("Required attribute (Application Name) is missing in one or more Test Cases [" + lineNumber + "]. Please verify and try again.");
                                    }

                                    if (string.IsNullOrEmpty(tc.Subject.IpAddress))
                                    {
                                        throw new Exception("Required attribute (IP Address) is missing in one or more Test Cases [" + lineNumber + "]. Please verify and try again.");
                                    }

                                    if (string.IsNullOrEmpty(tc.Action))
                                    {
                                        throw new Exception("Required attribute (Action) is missing in one or more Test Cases [" + lineNumber + "]. Please verify and try again.");
                                    }

                                    if (string.IsNullOrEmpty(tc.FromResource.ResourceName))
                                    {
                                        throw new Exception("Required attribute (From Resource Name) is missing in one or more Test Cases [" + lineNumber + "]. Please verify and try again.");
                                    }

                                    if (tc.PolicyType.Equals(PolicyType.Communication))
                                    {
                                        if (tc.Recipients == null || tc.Recipients.Count() == 0)
                                        {
                                            throw new Exception("At least one recipient is required for one or more Communication Test Case [" + lineNumber + "]. Please verify and try again");
                                        }
                                    }

                                    var existCase = MongoDBUtil.CheckTestCaseExistence(tc.Name, tc.TestSet).Result;
                                    if (existCase)
                                    {
                                        throw new Exception("Duplicate test case names found. (" + tc.Name + ")");
                                    }

                                    var resultCase = MongoDBUtil.CreateNewTestCase(tc).Result;
                                    if (!resultCase)
                                    {
                                        throw new Exception("Failed to create new test case");
                                    }
                                    Util.PopulateTreeViewFromDatabase(treeView);
                                }
                            }

                            catch (Exception ex)
                            {
                                try
                                {
                                    var existSet = MongoDBUtil.CheckTestSetExistence(newTestSetName).Result;
                                    if (existSet)
                                    {
                                        var deleteResult = MongoDBUtil.DeleteTestSet(newTestSetName).Result;
                                        if (!deleteResult)
                                        {
                                            throw new Exception("Attempted to revert the import but failed to delete the newly created test set");
                                        }
                                    }
                                }
                                catch (Exception ex1)
                                {
                                    Log.Error("An error occured while importing Test Set. ", ex1);
                                    MessageBox.Show(ex.Message + " Please see the log for more details.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }

                                Util.PopulateTreeViewFromDatabase(treeView);

                                Log.Error("An error occured while importing Test Set. ", ex);
                                MessageBox.Show(ex.Message + " Please see the log for more details.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occured while importing Test Set. ", ex);
                MessageBox.Show(ex.Message + " Please see the log for more details.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        private void exportTestSetResultButton_Click(object sender, EventArgs e)
        {
            string exportFilePath = Path.Combine(Environment.GetEnvironmentVariable("temp"), "NXL_TestSet_Export.csv");

            if (File.Exists(exportFilePath))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV File (.csv)|*.csv";
                DialogResult dr = sfd.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    File.Copy(exportFilePath, sfd.FileName, true);
                }
            }
        }



        private void loggingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogLevel logLevelForm = new LogLevel();
            logLevelForm.ShowDialog();
        }



        private void testSetTablePanel_Paint(object sender, PaintEventArgs e)
        {
        }



        private void usernameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsSelectedNodeRoot())
                    throw new Exception("Cannot Edit Root folder.");

                UsernameEditDialogBox usernameEditDialog = new UsernameEditDialogBox();
                System.Windows.Forms.DialogResult dr = usernameEditDialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    var result = MongoDBUtil.BulkUpdateTestCasesOfTestSet(treeView.SelectedNode.Text, "subject.user_name", usernameEditDialog.Username).Result;
                    if (!result)
                    {
                        throw new Exception("Failed to bulk update test cases Username");
                    }

                    result = MongoDBUtil.BulkUpdateTestCasesOfTestSet(treeView.SelectedNode.Text, "subject.windows_sid", usernameEditDialog.Sid).Result;
                    if (!result)
                    {
                        throw new Exception("Failed to bulk update test cases Windows SID");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occured while bulk editing test case subject. ", ex);
                MessageBox.Show(ex.Message + " Please see the log for more details.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                dirty = false;
                empty = false;
            }
        }



        private void actionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsSelectedNodeRoot())
                    throw new Exception("Cannot Edit Root folder.");

                ActionEditDialogBox actionEditDialog = new ActionEditDialogBox();
                System.Windows.Forms.DialogResult dr = actionEditDialog.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    var result = MongoDBUtil.BulkUpdateTestCasesOfTestSet(treeView.SelectedNode.Text, "action", actionEditDialog.Action).Result;
                    if (!result)
                    {
                        throw new Exception("Failed to bulk update test cases");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error occured while bulk editing test case action. ", ex);
                MessageBox.Show(ex.Message + " Please see the log for more details.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                dirty = false;
                empty = false;
            }
        }

        private void databaseSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.Debug("Showing DB Settings dialog box.");

            DBSettingsDialogBox dbSettingsDialog = new DBSettingsDialogBox();
            System.Windows.Forms.DialogResult dr = dbSettingsDialog.ShowDialog();

            if (dr == DialogResult.OK)
            {
                Settings.Default.Database_Host = dbSettingsDialog.Host;
                Settings.Default.Database_Port = dbSettingsDialog.Port;
                Settings.Default.Database_User = dbSettingsDialog.User;
                Settings.Default.Database_Password = dbSettingsDialog.Password;
                Settings.Default.Database_Name = dbSettingsDialog.DatabaseName;
            }

            Settings.Default.Save();
        }

        private void actionHeaderLabel_Click(object sender, EventArgs e)
        {

        }

    }
}