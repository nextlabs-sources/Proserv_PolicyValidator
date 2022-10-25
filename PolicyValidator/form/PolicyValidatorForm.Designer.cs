using System.Windows.Forms;
namespace PolicyValidator
{

    partial class PolicyValidatorForm
    {

        /// <summary>

        /// Required designer variable.

        /// </summary>

        private System.ComponentModel.IContainer components = null;



        /// <summary>

        /// Clean up any resources being used.

        /// </summary>

        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        protected override void Dispose(bool disposing)
        {

            if (disposing && (components != null))
            {

                components.Dispose();

            }

            base.Dispose(disposing);

        }



        #region Windows Form Designer generated code



        /// <summary>

        /// Required method for Designer support - do not modify

        /// the contents of this method with the code editor.

        /// </summary>

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PolicyValidatorForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectAttributesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionAttributesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resourceAttributesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusIndicatorLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBarSpacerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusConnectionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.tableLayoutLeft = new System.Windows.Forms.TableLayoutPanel();
            this.treeView = new PolicyValidator.NativeTreeView();
            this.testCaseContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usernameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.buttonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.innerButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.newTestCaseButton = new System.Windows.Forms.Button();
            this.newTestSetButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Label();
            this.testCasePanel = new System.Windows.Forms.Panel();
            this.testCaseTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.toResourceTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.toResourceDynamicAttributeTable = new System.Windows.Forms.TableLayoutPanel();
            this.addToResourceAttribute = new System.Windows.Forms.Button();
            this.toResourceStaticAttributeTable = new System.Windows.Forms.TableLayoutPanel();
            this.toResourceNameTextbox = new PolicyValidator.CueTextBox();
            this.toResourceNameLabel = new System.Windows.Forms.Label();
            this.resultHeaderTable = new System.Windows.Forms.TableLayoutPanel();
            this.underlineResultLabel = new System.Windows.Forms.Label();
            this.showResultLabel = new System.Windows.Forms.Label();
            this.toResourceHeaderTable = new System.Windows.Forms.TableLayoutPanel();
            this.toResourceHeaderLabel = new System.Windows.Forms.Label();
            this.underlineLabelToResource = new System.Windows.Forms.Label();
            this.subjectHeaderTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.subjectHeaderLabel = new System.Windows.Forms.Label();
            this.underlineLabel3 = new System.Windows.Forms.Label();
            this.subjectTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.subjectDynamicAttributeTable = new System.Windows.Forms.TableLayoutPanel();
            this.addSubjectAttribute = new System.Windows.Forms.Button();
            this.subjectStaticAttributeTable = new System.Windows.Forms.TableLayoutPanel();
            this.subjectSIDTextbox = new PolicyValidator.CueTextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.subjectUsernameTextbox = new PolicyValidator.CueTextBox();
            this.windowsSidLabel = new System.Windows.Forms.Label();
            this.applicationNameLabel = new System.Windows.Forms.Label();
            this.ipAddressLabel = new System.Windows.Forms.Label();
            this.subjectApplicationName = new PolicyValidator.CueTextBox();
            this.subjectIpAddress = new PolicyValidator.CueTextBox();
            this.actionHeaderTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.actionHeaderLabel = new System.Windows.Forms.Label();
            this.underlineLabel4 = new System.Windows.Forms.Label();
            this.actionTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.actionLabel = new System.Windows.Forms.Label();
            this.actionCombobox = new PolicyValidator.CueComboBox();
            this.fromResourceHeaderTable = new System.Windows.Forms.TableLayoutPanel();
            this.underlineLabel5 = new System.Windows.Forms.Label();
            this.fromResourceHeaderLabel = new System.Windows.Forms.Label();
            this.fromResourceTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.fromResourceDynamicAttributeTable = new System.Windows.Forms.TableLayoutPanel();
            this.addFromResourceAttribute = new System.Windows.Forms.Button();
            this.fromResourceStaticAttributeTable = new System.Windows.Forms.TableLayoutPanel();
            this.fromResourceNameTextbox = new PolicyValidator.CueTextBox();
            this.fromResourceLabel = new System.Windows.Forms.Label();
            this.formButtonsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.validateTestCaseButton = new System.Windows.Forms.Button();
            this.clearTestCaseButton = new System.Windows.Forms.Button();
            this.saveTestCaseButton = new System.Windows.Forms.Button();
            this.resultRichTextField = new System.Windows.Forms.RichTextBox();
            this.resultCopyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultButtonsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.clearTestCaseResultButton = new System.Windows.Forms.Button();
            this.exportTestCaseResultButton = new System.Windows.Forms.Button();
            this.documentPolicyHeaderLayout = new System.Windows.Forms.TableLayoutPanel();
            this.documentPolicyHeaderLabel = new System.Windows.Forms.Label();
            this.expectedResultHeaderLayout = new System.Windows.Forms.TableLayoutPanel();
            this.expectedResultHeaderLabel = new System.Windows.Forms.Label();
            this.underlineLabel6 = new System.Windows.Forms.Label();
            this.expectedResultTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.denyRadioButton = new System.Windows.Forms.RadioButton();
            this.allowRadioButton = new System.Windows.Forms.RadioButton();
            this.recipientsHeaderTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.underlineLabelRecipients = new System.Windows.Forms.Label();
            this.recipientsHeaderLabel = new System.Windows.Forms.Label();
            this.recipientsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.recipientsTextBox = new PolicyValidator.CueTextBox();
            this.emailAddressesLabel = new System.Windows.Forms.Label();
            this.emailDetailsHeaderTable = new System.Windows.Forms.TableLayoutPanel();
            this.emailDetailsHeaderLabel = new System.Windows.Forms.Label();
            this.underlineEmailDetailsLabel = new System.Windows.Forms.Label();
            this.emailDetailsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.emailBodyLabel = new System.Windows.Forms.Label();
            this.emailSubjectLabel = new System.Windows.Forms.Label();
            this.emailSubjectTextBox = new System.Windows.Forms.TextBox();
            this.emailBodyRichTextBox = new System.Windows.Forms.RichTextBox();
            this.testSetPanel = new System.Windows.Forms.Panel();
            this.testSetTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.testSetHeaderLabel = new System.Windows.Forms.Label();
            this.testSetTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.testCaseNameLabel = new System.Windows.Forms.Label();
            this.testCaseTypeLabel = new System.Windows.Forms.Label();
            this.testCaseActionLabel = new System.Windows.Forms.Label();
            this.expectedResultLabel = new System.Windows.Forms.Label();
            this.actualResultLabel = new System.Windows.Forms.Label();
            this.underlineLabel7 = new System.Windows.Forms.Label();
            this.underlineLabel8 = new System.Windows.Forms.Label();
            this.underlineLabel9 = new System.Windows.Forms.Label();
            this.underlineLabel20 = new System.Windows.Forms.Label();
            this.underlineLabel21 = new System.Windows.Forms.Label();
            this.testSetResultButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.exportTestSetResultButton = new System.Windows.Forms.Button();
            this.clearTestSetResultButton = new System.Windows.Forms.Button();
            this.resultTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.ResultrichTextBox = new System.Windows.Forms.RichTextBox();
            this.resultHeaderLayout = new System.Windows.Forms.TableLayoutPanel();
            this.resultHeaderLabel = new System.Windows.Forms.Label();
            this.underlineLabel10 = new System.Windows.Forms.Label();
            this.testSetButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.runTestSetButton = new System.Windows.Forms.Button();
            this.introPanel = new System.Windows.Forms.Panel();
            this.introRichTextBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new PolicyValidator.CueTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.button4 = new System.Windows.Forms.Button();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox2 = new PolicyValidator.CueTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRun = new System.Windows.Forms.Button();
            this.tableLayoutPanel23 = new System.Windows.Forms.TableLayoutPanel();
            this.label24 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.connectionStatusBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.testCaseBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.testSetBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.testSetLoader = new System.ComponentModel.BackgroundWorker();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.tableLayoutLeft.SuspendLayout();
            this.testCaseContextMenu.SuspendLayout();
            this.buttonLayout.SuspendLayout();
            this.innerButtonLayout.SuspendLayout();
            this.testCasePanel.SuspendLayout();
            this.testCaseTableLayout.SuspendLayout();
            this.toResourceTableLayout.SuspendLayout();
            this.toResourceDynamicAttributeTable.SuspendLayout();
            this.toResourceStaticAttributeTable.SuspendLayout();
            this.resultHeaderTable.SuspendLayout();
            this.toResourceHeaderTable.SuspendLayout();
            this.subjectHeaderTableLayout.SuspendLayout();
            this.subjectTableLayout.SuspendLayout();
            this.subjectDynamicAttributeTable.SuspendLayout();
            this.subjectStaticAttributeTable.SuspendLayout();
            this.actionHeaderTableLayout.SuspendLayout();
            this.actionTableLayout.SuspendLayout();
            this.fromResourceHeaderTable.SuspendLayout();
            this.fromResourceTableLayout.SuspendLayout();
            this.fromResourceDynamicAttributeTable.SuspendLayout();
            this.fromResourceStaticAttributeTable.SuspendLayout();
            this.formButtonsLayout.SuspendLayout();
            this.resultCopyContextMenu.SuspendLayout();
            this.resultButtonsLayout.SuspendLayout();
            this.documentPolicyHeaderLayout.SuspendLayout();
            this.expectedResultHeaderLayout.SuspendLayout();
            this.expectedResultTableLayout.SuspendLayout();
            this.recipientsHeaderTableLayout.SuspendLayout();
            this.recipientsTableLayout.SuspendLayout();
            this.emailDetailsHeaderTable.SuspendLayout();
            this.emailDetailsTableLayout.SuspendLayout();
            this.testSetPanel.SuspendLayout();
            this.testSetTableLayout.SuspendLayout();
            this.testSetTablePanel.SuspendLayout();
            this.testSetResultButtonLayout.SuspendLayout();
            this.resultTablePanel.SuspendLayout();
            this.resultHeaderLayout.SuspendLayout();
            this.testSetButtonLayout.SuspendLayout();
            this.introPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel23.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configureToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(863, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.fileMenuSeparator,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // fileMenuSeparator
            // 
            this.fileMenuSeparator.Name = "fileMenuSeparator";
            this.fileMenuSeparator.Size = new System.Drawing.Size(112, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // configureToolStripMenuItem
            // 
            this.configureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subjectAttributesToolStripMenuItem,
            this.actionAttributesToolStripMenuItem,
            this.resourceAttributesToolStripMenuItem,
            this.configureMenuSeparator,
            this.settingsToolStripMenuItem,
            this.databaseSettingsToolStripMenuItem,
            this.loggingToolStripMenuItem});
            this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            this.configureToolStripMenuItem.Size = new System.Drawing.Size(77, 21);
            this.configureToolStripMenuItem.Text = "&Configure";
            // 
            // subjectAttributesToolStripMenuItem
            // 
            this.subjectAttributesToolStripMenuItem.Name = "subjectAttributesToolStripMenuItem";
            this.subjectAttributesToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.subjectAttributesToolStripMenuItem.Text = "Subject Attributes";
            this.subjectAttributesToolStripMenuItem.Click += new System.EventHandler(this.subjectAttributesToolStripMenuItem_Click);
            // 
            // actionAttributesToolStripMenuItem
            // 
            this.actionAttributesToolStripMenuItem.Name = "actionAttributesToolStripMenuItem";
            this.actionAttributesToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.actionAttributesToolStripMenuItem.Text = "Actions";
            this.actionAttributesToolStripMenuItem.Click += new System.EventHandler(this.actionAttributesToolStripMenuItem_Click);
            // 
            // resourceAttributesToolStripMenuItem
            // 
            this.resourceAttributesToolStripMenuItem.Name = "resourceAttributesToolStripMenuItem";
            this.resourceAttributesToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.resourceAttributesToolStripMenuItem.Text = "Resource Attributes";
            this.resourceAttributesToolStripMenuItem.Click += new System.EventHandler(this.resourceAttributesToolStripMenuItem_Click);
            // 
            // configureMenuSeparator
            // 
            this.configureMenuSeparator.Name = "configureMenuSeparator";
            this.configureMenuSeparator.Size = new System.Drawing.Size(218, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.settingsToolStripMenuItem.Text = "Policy Controller Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // databaseSettingsToolStripMenuItem
            // 
            this.databaseSettingsToolStripMenuItem.Name = "databaseSettingsToolStripMenuItem";
            this.databaseSettingsToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.databaseSettingsToolStripMenuItem.Text = "Database Settings";
            this.databaseSettingsToolStripMenuItem.Click += new System.EventHandler(this.databaseSettingsToolStripMenuItem_Click);
            // 
            // loggingToolStripMenuItem
            // 
            this.loggingToolStripMenuItem.Name = "loggingToolStripMenuItem";
            this.loggingToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.loggingToolStripMenuItem.Text = "Logging";
            this.loggingToolStripMenuItem.Click += new System.EventHandler(this.loggingToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusIndicatorLabel,
            this.statusLabel,
            this.statusBarSpacerLabel,
            this.statusConnectionLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 784);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(863, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusIndicatorLabel
            // 
            this.statusIndicatorLabel.AutoSize = false;
            this.statusIndicatorLabel.Name = "statusIndicatorLabel";
            this.statusIndicatorLabel.Size = new System.Drawing.Size(17, 17);
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // statusBarSpacerLabel
            // 
            this.statusBarSpacerLabel.Name = "statusBarSpacerLabel";
            this.statusBarSpacerLabel.Size = new System.Drawing.Size(831, 17);
            this.statusBarSpacerLabel.Spring = true;
            // 
            // statusConnectionLabel
            // 
            this.statusConnectionLabel.Name = "statusConnectionLabel";
            this.statusConnectionLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer.Location = new System.Drawing.Point(0, 25);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.leftPanel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.testCasePanel);
            this.splitContainer.Panel2.Controls.Add(this.testSetPanel);
            this.splitContainer.Panel2.Controls.Add(this.introPanel);
            this.splitContainer.Size = new System.Drawing.Size(863, 759);
            this.splitContainer.SplitterDistance = 280;
            this.splitContainer.TabIndex = 2;
            // 
            // leftPanel
            // 
            this.leftPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftPanel.Controls.Add(this.tableLayoutLeft);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(280, 759);
            this.leftPanel.TabIndex = 0;
            // 
            // tableLayoutLeft
            // 
            this.tableLayoutLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutLeft.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutLeft.ColumnCount = 1;
            this.tableLayoutLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutLeft.Controls.Add(this.treeView, 0, 1);
            this.tableLayoutLeft.Controls.Add(this.buttonLayout, 0, 0);
            this.tableLayoutLeft.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutLeft.Name = "tableLayoutLeft";
            this.tableLayoutLeft.RowCount = 2;
            this.tableLayoutLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutLeft.Size = new System.Drawing.Size(277, 756);
            this.tableLayoutLeft.TabIndex = 2;
            // 
            // treeView
            // 
            this.treeView.AllowDrop = true;
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.ContextMenuStrip = this.testCaseContextMenu;
            this.treeView.HideSelection = false;
            this.treeView.ImageIndex = 1;
            this.treeView.ImageList = this.imageList;
            this.treeView.ItemHeight = 20;
            this.treeView.Location = new System.Drawing.Point(3, 54);
            this.treeView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 1;
            this.treeView.ShowNodeToolTips = true;
            this.treeView.Size = new System.Drawing.Size(271, 698);
            this.treeView.TabIndex = 2;
            this.treeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_ItemDrag);
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            this.treeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView_DragDrop);
            this.treeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView_DragEnter);
            this.treeView.Enter += new System.EventHandler(this.treeView_Enter);
            this.treeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView_KeyDown);
            // 
            // testCaseContextMenu
            // 
            this.testCaseContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.duplicateToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.contextMenuSeparator,
            this.deleteToolStripMenuItem});
            this.testCaseContextMenu.Name = "testCaseContextMenu";
            this.testCaseContextMenu.Size = new System.Drawing.Size(125, 120);
            this.testCaseContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.testCaseContextMenu_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usernameToolStripMenuItem,
            this.actionToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.editToolStripMenuItem.Text = "Bulk Edit";
            // 
            // usernameToolStripMenuItem
            // 
            this.usernameToolStripMenuItem.Name = "usernameToolStripMenuItem";
            this.usernameToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.usernameToolStripMenuItem.Text = "Username";
            this.usernameToolStripMenuItem.Click += new System.EventHandler(this.usernameToolStripMenuItem_Click);
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.actionToolStripMenuItem.Text = "Action";
            this.actionToolStripMenuItem.Click += new System.EventHandler(this.actionToolStripMenuItem_Click);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.duplicateToolStripMenuItem.Text = "Duplicate";
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // contextMenuSeparator
            // 
            this.contextMenuSeparator.Name = "contextMenuSeparator";
            this.contextMenuSeparator.Size = new System.Drawing.Size(121, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Generic_Document.ico");
            this.imageList.Images.SetKeyName(1, "folder_open.ico");
            // 
            // buttonLayout
            // 
            this.buttonLayout.BackColor = System.Drawing.SystemColors.Control;
            this.buttonLayout.ColumnCount = 1;
            this.buttonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonLayout.Controls.Add(this.innerButtonLayout, 0, 0);
            this.buttonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLayout.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLayout.Location = new System.Drawing.Point(3, 4);
            this.buttonLayout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonLayout.Name = "buttonLayout";
            this.buttonLayout.RowCount = 1;
            this.buttonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonLayout.Size = new System.Drawing.Size(271, 42);
            this.buttonLayout.TabIndex = 3;
            // 
            // innerButtonLayout
            // 
            this.innerButtonLayout.ColumnCount = 3;
            this.innerButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.44445F));
            this.innerButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.innerButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.innerButtonLayout.Controls.Add(this.newTestCaseButton, 0, 0);
            this.innerButtonLayout.Controls.Add(this.newTestSetButton, 0, 0);
            this.innerButtonLayout.Controls.Add(this.refreshButton, 2, 0);
            this.innerButtonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.innerButtonLayout.Location = new System.Drawing.Point(3, 4);
            this.innerButtonLayout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.innerButtonLayout.Name = "innerButtonLayout";
            this.innerButtonLayout.RowCount = 1;
            this.innerButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.innerButtonLayout.Size = new System.Drawing.Size(265, 34);
            this.innerButtonLayout.TabIndex = 1;
            // 
            // newTestCaseButton
            // 
            this.newTestCaseButton.AutoSize = true;
            this.newTestCaseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.newTestCaseButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.newTestCaseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newTestCaseButton.FlatAppearance.BorderSize = 0;
            this.newTestCaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newTestCaseButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newTestCaseButton.ForeColor = System.Drawing.Color.White;
            this.newTestCaseButton.Location = new System.Drawing.Point(120, 4);
            this.newTestCaseButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 9);
            this.newTestCaseButton.Name = "newTestCaseButton";
            this.newTestCaseButton.Size = new System.Drawing.Size(111, 27);
            this.newTestCaseButton.TabIndex = 4;
            this.newTestCaseButton.Text = "New Test Case";
            this.newTestCaseButton.UseVisualStyleBackColor = false;
            this.newTestCaseButton.Click += new System.EventHandler(this.newTestCaseButton_Click);
            // 
            // newTestSetButton
            // 
            this.newTestSetButton.AutoSize = true;
            this.newTestSetButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.newTestSetButton.BackColor = System.Drawing.Color.SteelBlue;
            this.newTestSetButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newTestSetButton.FlatAppearance.BorderSize = 0;
            this.newTestSetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newTestSetButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newTestSetButton.ForeColor = System.Drawing.Color.White;
            this.newTestSetButton.Location = new System.Drawing.Point(3, 4);
            this.newTestSetButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 9);
            this.newTestSetButton.Name = "newTestSetButton";
            this.newTestSetButton.Size = new System.Drawing.Size(111, 27);
            this.newTestSetButton.TabIndex = 3;
            this.newTestSetButton.Text = "New Test Set";
            this.newTestSetButton.UseVisualStyleBackColor = false;
            this.newTestSetButton.Click += new System.EventHandler(this.newTestSetButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.AutoSize = true;
            this.refreshButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.refreshButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshButton.Image")));
            this.refreshButton.Location = new System.Drawing.Point(237, 0);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(25, 32);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // testCasePanel
            // 
            this.testCasePanel.AutoScroll = true;
            this.testCasePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.testCasePanel.Controls.Add(this.testCaseTableLayout);
            this.testCasePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testCasePanel.Location = new System.Drawing.Point(0, 0);
            this.testCasePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.testCasePanel.MinimumSize = new System.Drawing.Size(4, 689);
            this.testCasePanel.Name = "testCasePanel";
            this.testCasePanel.Size = new System.Drawing.Size(579, 759);
            this.testCasePanel.TabIndex = 2;
            // 
            // testCaseTableLayout
            // 
            this.testCaseTableLayout.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.testCaseTableLayout.ColumnCount = 1;
            this.testCaseTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.testCaseTableLayout.Controls.Add(this.toResourceTableLayout, 0, 13);
            this.testCaseTableLayout.Controls.Add(this.resultHeaderTable, 0, 18);
            this.testCaseTableLayout.Controls.Add(this.toResourceHeaderTable, 0, 12);
            this.testCaseTableLayout.Controls.Add(this.subjectHeaderTableLayout, 0, 4);
            this.testCaseTableLayout.Controls.Add(this.subjectTableLayout, 0, 5);
            this.testCaseTableLayout.Controls.Add(this.actionHeaderTableLayout, 0, 6);
            this.testCaseTableLayout.Controls.Add(this.actionTableLayout, 0, 7);
            this.testCaseTableLayout.Controls.Add(this.fromResourceHeaderTable, 0, 10);
            this.testCaseTableLayout.Controls.Add(this.fromResourceTableLayout, 0, 11);
            this.testCaseTableLayout.Controls.Add(this.formButtonsLayout, 0, 17);
            this.testCaseTableLayout.Controls.Add(this.resultRichTextField, 0, 19);
            this.testCaseTableLayout.Controls.Add(this.resultButtonsLayout, 0, 20);
            this.testCaseTableLayout.Controls.Add(this.documentPolicyHeaderLayout, 0, 0);
            this.testCaseTableLayout.Controls.Add(this.expectedResultHeaderLayout, 0, 2);
            this.testCaseTableLayout.Controls.Add(this.expectedResultTableLayout, 0, 3);
            this.testCaseTableLayout.Controls.Add(this.recipientsHeaderTableLayout, 0, 8);
            this.testCaseTableLayout.Controls.Add(this.recipientsTableLayout, 0, 9);
            this.testCaseTableLayout.Controls.Add(this.emailDetailsHeaderTable, 0, 14);
            this.testCaseTableLayout.Controls.Add(this.emailDetailsTableLayout, 0, 15);
            this.testCaseTableLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.testCaseTableLayout.Location = new System.Drawing.Point(0, 0);
            this.testCaseTableLayout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.testCaseTableLayout.Name = "testCaseTableLayout";
            this.testCaseTableLayout.Padding = new System.Windows.Forms.Padding(5);
            this.testCaseTableLayout.RowCount = 21;
            this.testCaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.testCaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.testCaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.testCaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.testCaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.testCaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.testCaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.testCaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.testCaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.testCaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.testCaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.testCaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.testCaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.testCaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.testCaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.testCaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.testCaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.testCaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.testCaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.testCaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.testCaseTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.testCaseTableLayout.Size = new System.Drawing.Size(560, 1495);
            this.testCaseTableLayout.TabIndex = 1;
            // 
            // toResourceTableLayout
            // 
            this.toResourceTableLayout.ColumnCount = 1;
            this.toResourceTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.toResourceTableLayout.Controls.Add(this.toResourceDynamicAttributeTable, 0, 1);
            this.toResourceTableLayout.Controls.Add(this.toResourceStaticAttributeTable, 0, 0);
            this.toResourceTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toResourceTableLayout.Location = new System.Drawing.Point(8, 755);
            this.toResourceTableLayout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toResourceTableLayout.Name = "toResourceTableLayout";
            this.toResourceTableLayout.RowCount = 2;
            this.toResourceTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.toResourceTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.toResourceTableLayout.Size = new System.Drawing.Size(544, 147);
            this.toResourceTableLayout.TabIndex = 9;
            // 
            // toResourceDynamicAttributeTable
            // 
            this.toResourceDynamicAttributeTable.ColumnCount = 4;
            this.toResourceDynamicAttributeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.toResourceDynamicAttributeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.toResourceDynamicAttributeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.toResourceDynamicAttributeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.toResourceDynamicAttributeTable.Controls.Add(this.addToResourceAttribute, 0, 0);
            this.toResourceDynamicAttributeTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toResourceDynamicAttributeTable.Location = new System.Drawing.Point(0, 32);
            this.toResourceDynamicAttributeTable.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.toResourceDynamicAttributeTable.Name = "toResourceDynamicAttributeTable";
            this.toResourceDynamicAttributeTable.RowCount = 1;
            this.toResourceDynamicAttributeTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.toResourceDynamicAttributeTable.Size = new System.Drawing.Size(544, 117);
            this.toResourceDynamicAttributeTable.TabIndex = 2;
            // 
            // addToResourceAttribute
            // 
            this.addToResourceAttribute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addToResourceAttribute.BackColor = System.Drawing.SystemColors.ControlDark;
            this.addToResourceAttribute.FlatAppearance.BorderSize = 0;
            this.addToResourceAttribute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addToResourceAttribute.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addToResourceAttribute.Location = new System.Drawing.Point(116, 0);
            this.addToResourceAttribute.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.addToResourceAttribute.Name = "addToResourceAttribute";
            this.addToResourceAttribute.Size = new System.Drawing.Size(23, 23);
            this.addToResourceAttribute.TabIndex = 0;
            this.addToResourceAttribute.Text = "+";
            this.addToResourceAttribute.UseVisualStyleBackColor = false;
            this.addToResourceAttribute.Click += new System.EventHandler(this.addToResourceAttribute_Click);
            // 
            // toResourceStaticAttributeTable
            // 
            this.toResourceStaticAttributeTable.ColumnCount = 2;
            this.toResourceStaticAttributeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.toResourceStaticAttributeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.toResourceStaticAttributeTable.Controls.Add(this.toResourceNameTextbox, 1, 0);
            this.toResourceStaticAttributeTable.Controls.Add(this.toResourceNameLabel, 0, 0);
            this.toResourceStaticAttributeTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toResourceStaticAttributeTable.Location = new System.Drawing.Point(0, 0);
            this.toResourceStaticAttributeTable.Margin = new System.Windows.Forms.Padding(0);
            this.toResourceStaticAttributeTable.Name = "toResourceStaticAttributeTable";
            this.toResourceStaticAttributeTable.RowCount = 1;
            this.toResourceStaticAttributeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.toResourceStaticAttributeTable.Size = new System.Drawing.Size(544, 28);
            this.toResourceStaticAttributeTable.TabIndex = 0;
            // 
            // toResourceNameTextbox
            // 
            this.toResourceNameTextbox.Cue = "e.g. E:\\ITARDocument.docx";
            this.toResourceNameTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toResourceNameTextbox.Location = new System.Drawing.Point(143, 2);
            this.toResourceNameTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 4);
            this.toResourceNameTextbox.Name = "toResourceNameTextbox";
            this.toResourceNameTextbox.Size = new System.Drawing.Size(398, 25);
            this.toResourceNameTextbox.TabIndex = 4;
            this.toResourceNameTextbox.TextChanged += new System.EventHandler(this.SetStateDirty);
            // 
            // toResourceNameLabel
            // 
            this.toResourceNameLabel.AutoSize = true;
            this.toResourceNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toResourceNameLabel.Location = new System.Drawing.Point(3, 0);
            this.toResourceNameLabel.Name = "toResourceNameLabel";
            this.toResourceNameLabel.Size = new System.Drawing.Size(134, 28);
            this.toResourceNameLabel.TabIndex = 0;
            this.toResourceNameLabel.Text = "Resource Name";
            this.toResourceNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // resultHeaderTable
            // 
            this.resultHeaderTable.ColumnCount = 1;
            this.resultHeaderTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.resultHeaderTable.Controls.Add(this.underlineResultLabel, 0, 1);
            this.resultHeaderTable.Controls.Add(this.showResultLabel, 0, 0);
            this.resultHeaderTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultHeaderTable.Location = new System.Drawing.Point(6, 1129);
            this.resultHeaderTable.Margin = new System.Windows.Forms.Padding(1, 3, 1, 4);
            this.resultHeaderTable.Name = "resultHeaderTable";
            this.resultHeaderTable.RowCount = 2;
            this.resultHeaderTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.resultHeaderTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.resultHeaderTable.Size = new System.Drawing.Size(548, 25);
            this.resultHeaderTable.TabIndex = 11;
            // 
            // underlineResultLabel
            // 
            this.underlineResultLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.underlineResultLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.underlineResultLabel.Location = new System.Drawing.Point(2, 24);
            this.underlineResultLabel.Margin = new System.Windows.Forms.Padding(2, 0, 3, 0);
            this.underlineResultLabel.Name = "underlineResultLabel";
            this.underlineResultLabel.Size = new System.Drawing.Size(550, 1);
            this.underlineResultLabel.TabIndex = 4;
            // 
            // showResultLabel
            // 
            this.showResultLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.showResultLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showResultLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.showResultLabel.Location = new System.Drawing.Point(2, 0);
            this.showResultLabel.Margin = new System.Windows.Forms.Padding(2, 0, 3, 0);
            this.showResultLabel.Name = "showResultLabel";
            this.showResultLabel.Padding = new System.Windows.Forms.Padding(4, 3, 0, 0);
            this.showResultLabel.Size = new System.Drawing.Size(136, 24);
            this.showResultLabel.TabIndex = 3;
            this.showResultLabel.Text = "RESULT";
            this.showResultLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toResourceHeaderTable
            // 
            this.toResourceHeaderTable.ColumnCount = 1;
            this.toResourceHeaderTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.toResourceHeaderTable.Controls.Add(this.toResourceHeaderLabel, 0, 0);
            this.toResourceHeaderTable.Controls.Add(this.underlineLabelToResource, 0, 1);
            this.toResourceHeaderTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toResourceHeaderTable.Location = new System.Drawing.Point(6, 722);
            this.toResourceHeaderTable.Margin = new System.Windows.Forms.Padding(1, 3, 1, 4);
            this.toResourceHeaderTable.Name = "toResourceHeaderTable";
            this.toResourceHeaderTable.RowCount = 2;
            this.toResourceHeaderTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.toResourceHeaderTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.toResourceHeaderTable.Size = new System.Drawing.Size(548, 25);
            this.toResourceHeaderTable.TabIndex = 8;
            // 
            // toResourceHeaderLabel
            // 
            this.toResourceHeaderLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.toResourceHeaderLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toResourceHeaderLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toResourceHeaderLabel.Location = new System.Drawing.Point(3, 0);
            this.toResourceHeaderLabel.Name = "toResourceHeaderLabel";
            this.toResourceHeaderLabel.Padding = new System.Windows.Forms.Padding(4, 3, 0, 0);
            this.toResourceHeaderLabel.Size = new System.Drawing.Size(136, 24);
            this.toResourceHeaderLabel.TabIndex = 0;
            this.toResourceHeaderLabel.Text = "TO RESOURCE";
            this.toResourceHeaderLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // underlineLabelToResource
            // 
            this.underlineLabelToResource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.underlineLabelToResource.Dock = System.Windows.Forms.DockStyle.Top;
            this.underlineLabelToResource.Location = new System.Drawing.Point(2, 24);
            this.underlineLabelToResource.Margin = new System.Windows.Forms.Padding(2, 0, 3, 0);
            this.underlineLabelToResource.Name = "underlineLabelToResource";
            this.underlineLabelToResource.Size = new System.Drawing.Size(543, 1);
            this.underlineLabelToResource.TabIndex = 2;
            // 
            // subjectHeaderTableLayout
            // 
            this.subjectHeaderTableLayout.ColumnCount = 1;
            this.subjectHeaderTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.subjectHeaderTableLayout.Controls.Add(this.subjectHeaderLabel, 0, 0);
            this.subjectHeaderTableLayout.Controls.Add(this.underlineLabel3, 0, 1);
            this.subjectHeaderTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subjectHeaderTableLayout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.subjectHeaderTableLayout.Location = new System.Drawing.Point(6, 129);
            this.subjectHeaderTableLayout.Margin = new System.Windows.Forms.Padding(1, 3, 1, 4);
            this.subjectHeaderTableLayout.Name = "subjectHeaderTableLayout";
            this.subjectHeaderTableLayout.RowCount = 2;
            this.subjectHeaderTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.subjectHeaderTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.subjectHeaderTableLayout.Size = new System.Drawing.Size(548, 25);
            this.subjectHeaderTableLayout.TabIndex = 2;
            // 
            // subjectHeaderLabel
            // 
            this.subjectHeaderLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.subjectHeaderLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectHeaderLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.subjectHeaderLabel.Location = new System.Drawing.Point(3, 0);
            this.subjectHeaderLabel.Name = "subjectHeaderLabel";
            this.subjectHeaderLabel.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.subjectHeaderLabel.Size = new System.Drawing.Size(136, 24);
            this.subjectHeaderLabel.TabIndex = 0;
            this.subjectHeaderLabel.Text = "SUBJECT";
            this.subjectHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // underlineLabel3
            // 
            this.underlineLabel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.underlineLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.underlineLabel3.Location = new System.Drawing.Point(2, 24);
            this.underlineLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 3, 0);
            this.underlineLabel3.Name = "underlineLabel3";
            this.underlineLabel3.Size = new System.Drawing.Size(543, 1);
            this.underlineLabel3.TabIndex = 1;
            // 
            // subjectTableLayout
            // 
            this.subjectTableLayout.ColumnCount = 1;
            this.subjectTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.subjectTableLayout.Controls.Add(this.subjectDynamicAttributeTable, 0, 1);
            this.subjectTableLayout.Controls.Add(this.subjectStaticAttributeTable, 0, 0);
            this.subjectTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subjectTableLayout.Location = new System.Drawing.Point(8, 162);
            this.subjectTableLayout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.subjectTableLayout.Name = "subjectTableLayout";
            this.subjectTableLayout.RowCount = 2;
            this.subjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.subjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.subjectTableLayout.Size = new System.Drawing.Size(544, 222);
            this.subjectTableLayout.TabIndex = 3;
            // 
            // subjectDynamicAttributeTable
            // 
            this.subjectDynamicAttributeTable.AutoScroll = true;
            this.subjectDynamicAttributeTable.ColumnCount = 4;
            this.subjectDynamicAttributeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.subjectDynamicAttributeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.subjectDynamicAttributeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.subjectDynamicAttributeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.subjectDynamicAttributeTable.Controls.Add(this.addSubjectAttribute, 0, 0);
            this.subjectDynamicAttributeTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subjectDynamicAttributeTable.Location = new System.Drawing.Point(0, 118);
            this.subjectDynamicAttributeTable.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.subjectDynamicAttributeTable.Name = "subjectDynamicAttributeTable";
            this.subjectDynamicAttributeTable.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.subjectDynamicAttributeTable.RowCount = 1;
            this.subjectDynamicAttributeTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.subjectDynamicAttributeTable.Size = new System.Drawing.Size(544, 101);
            this.subjectDynamicAttributeTable.TabIndex = 3;
            // 
            // addSubjectAttribute
            // 
            this.addSubjectAttribute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addSubjectAttribute.BackColor = System.Drawing.SystemColors.ControlDark;
            this.addSubjectAttribute.FlatAppearance.BorderSize = 0;
            this.addSubjectAttribute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addSubjectAttribute.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSubjectAttribute.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addSubjectAttribute.Location = new System.Drawing.Point(116, 1);
            this.addSubjectAttribute.Margin = new System.Windows.Forms.Padding(0, 1, 1, 0);
            this.addSubjectAttribute.Name = "addSubjectAttribute";
            this.addSubjectAttribute.Size = new System.Drawing.Size(23, 23);
            this.addSubjectAttribute.TabIndex = 0;
            this.addSubjectAttribute.Text = "+";
            this.addSubjectAttribute.UseVisualStyleBackColor = false;
            this.addSubjectAttribute.Click += new System.EventHandler(this.addSubjectAttribute_Click);
            // 
            // subjectStaticAttributeTable
            // 
            this.subjectStaticAttributeTable.ColumnCount = 2;
            this.subjectStaticAttributeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.subjectStaticAttributeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.subjectStaticAttributeTable.Controls.Add(this.subjectSIDTextbox, 0, 1);
            this.subjectStaticAttributeTable.Controls.Add(this.usernameLabel, 0, 0);
            this.subjectStaticAttributeTable.Controls.Add(this.subjectUsernameTextbox, 1, 0);
            this.subjectStaticAttributeTable.Controls.Add(this.windowsSidLabel, 0, 1);
            this.subjectStaticAttributeTable.Controls.Add(this.applicationNameLabel, 0, 2);
            this.subjectStaticAttributeTable.Controls.Add(this.ipAddressLabel, 0, 3);
            this.subjectStaticAttributeTable.Controls.Add(this.subjectApplicationName, 1, 2);
            this.subjectStaticAttributeTable.Controls.Add(this.subjectIpAddress, 1, 3);
            this.subjectStaticAttributeTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subjectStaticAttributeTable.Location = new System.Drawing.Point(0, 0);
            this.subjectStaticAttributeTable.Margin = new System.Windows.Forms.Padding(0);
            this.subjectStaticAttributeTable.Name = "subjectStaticAttributeTable";
            this.subjectStaticAttributeTable.RowCount = 4;
            this.subjectStaticAttributeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.subjectStaticAttributeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.subjectStaticAttributeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.subjectStaticAttributeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.subjectStaticAttributeTable.Size = new System.Drawing.Size(544, 115);
            this.subjectStaticAttributeTable.TabIndex = 0;
            // 
            // subjectSIDTextbox
            // 
            this.subjectSIDTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.subjectSIDTextbox.Cue = "e.g. S-1-5-21-1180699209-877415012-3182924384-1004";
            this.subjectSIDTextbox.Location = new System.Drawing.Point(143, 32);
            this.subjectSIDTextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.subjectSIDTextbox.Name = "subjectSIDTextbox";
            this.subjectSIDTextbox.Size = new System.Drawing.Size(180, 25);
            this.subjectSIDTextbox.TabIndex = 3;
            this.subjectSIDTextbox.TextChanged += new System.EventHandler(this.SetStateDirty);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usernameLabel.Location = new System.Drawing.Point(3, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(134, 28);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username *";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // subjectUsernameTextbox
            // 
            this.subjectUsernameTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.subjectUsernameTextbox.Cue = "e.g. john.tyler";
            this.subjectUsernameTextbox.Location = new System.Drawing.Point(143, 4);
            this.subjectUsernameTextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.subjectUsernameTextbox.Name = "subjectUsernameTextbox";
            this.subjectUsernameTextbox.Size = new System.Drawing.Size(180, 25);
            this.subjectUsernameTextbox.TabIndex = 1;
            this.subjectUsernameTextbox.TextChanged += new System.EventHandler(this.SetStateDirty);
            // 
            // windowsSidLabel
            // 
            this.windowsSidLabel.AutoSize = true;
            this.windowsSidLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowsSidLabel.Location = new System.Drawing.Point(3, 28);
            this.windowsSidLabel.Name = "windowsSidLabel";
            this.windowsSidLabel.Size = new System.Drawing.Size(134, 28);
            this.windowsSidLabel.TabIndex = 2;
            this.windowsSidLabel.Text = "Windows SID *";
            this.windowsSidLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // applicationNameLabel
            // 
            this.applicationNameLabel.AutoSize = true;
            this.applicationNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.applicationNameLabel.Location = new System.Drawing.Point(3, 56);
            this.applicationNameLabel.Name = "applicationNameLabel";
            this.applicationNameLabel.Size = new System.Drawing.Size(134, 28);
            this.applicationNameLabel.TabIndex = 4;
            this.applicationNameLabel.Text = "Application Name *";
            this.applicationNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ipAddressLabel
            // 
            this.ipAddressLabel.AutoSize = true;
            this.ipAddressLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ipAddressLabel.Location = new System.Drawing.Point(3, 84);
            this.ipAddressLabel.Name = "ipAddressLabel";
            this.ipAddressLabel.Size = new System.Drawing.Size(134, 31);
            this.ipAddressLabel.TabIndex = 5;
            this.ipAddressLabel.Text = "IP Address *";
            this.ipAddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // subjectApplicationName
            // 
            this.subjectApplicationName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.subjectApplicationName.Cue = "e.g. Policy Validator";
            this.subjectApplicationName.Location = new System.Drawing.Point(143, 60);
            this.subjectApplicationName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.subjectApplicationName.Name = "subjectApplicationName";
            this.subjectApplicationName.Size = new System.Drawing.Size(180, 25);
            this.subjectApplicationName.TabIndex = 6;
            this.subjectApplicationName.TextChanged += new System.EventHandler(this.SetStateDirty);
            // 
            // subjectIpAddress
            // 
            this.subjectIpAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.subjectIpAddress.Cue = "e.g. 127.0.0.1, localhost";
            this.subjectIpAddress.Location = new System.Drawing.Point(143, 88);
            this.subjectIpAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.subjectIpAddress.Name = "subjectIpAddress";
            this.subjectIpAddress.Size = new System.Drawing.Size(180, 25);
            this.subjectIpAddress.TabIndex = 7;
            this.subjectIpAddress.TextChanged += new System.EventHandler(this.SetStateDirty);
            // 
            // actionHeaderTableLayout
            // 
            this.actionHeaderTableLayout.ColumnCount = 1;
            this.actionHeaderTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.actionHeaderTableLayout.Controls.Add(this.actionHeaderLabel, 0, 0);
            this.actionHeaderTableLayout.Controls.Add(this.underlineLabel4, 0, 1);
            this.actionHeaderTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionHeaderTableLayout.Location = new System.Drawing.Point(6, 391);
            this.actionHeaderTableLayout.Margin = new System.Windows.Forms.Padding(1, 3, 1, 4);
            this.actionHeaderTableLayout.Name = "actionHeaderTableLayout";
            this.actionHeaderTableLayout.RowCount = 2;
            this.actionHeaderTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.actionHeaderTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.actionHeaderTableLayout.Size = new System.Drawing.Size(548, 25);
            this.actionHeaderTableLayout.TabIndex = 4;
            // 
            // actionHeaderLabel
            // 
            this.actionHeaderLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.actionHeaderLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionHeaderLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.actionHeaderLabel.Location = new System.Drawing.Point(3, 0);
            this.actionHeaderLabel.Name = "actionHeaderLabel";
            this.actionHeaderLabel.Padding = new System.Windows.Forms.Padding(4, 3, 0, 0);
            this.actionHeaderLabel.Size = new System.Drawing.Size(136, 24);
            this.actionHeaderLabel.TabIndex = 5;
            this.actionHeaderLabel.Text = "ACTION";
            this.actionHeaderLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.actionHeaderLabel.Click += new System.EventHandler(this.actionHeaderLabel_Click);
            // 
            // underlineLabel4
            // 
            this.underlineLabel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.underlineLabel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.underlineLabel4.Location = new System.Drawing.Point(2, 24);
            this.underlineLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 3, 0);
            this.underlineLabel4.Name = "underlineLabel4";
            this.underlineLabel4.Size = new System.Drawing.Size(543, 1);
            this.underlineLabel4.TabIndex = 6;
            // 
            // actionTableLayout
            // 
            this.actionTableLayout.ColumnCount = 2;
            this.actionTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.actionTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.actionTableLayout.Controls.Add(this.actionLabel, 0, 0);
            this.actionTableLayout.Controls.Add(this.actionCombobox, 1, 0);
            this.actionTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionTableLayout.Location = new System.Drawing.Point(5, 420);
            this.actionTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.actionTableLayout.Name = "actionTableLayout";
            this.actionTableLayout.RowCount = 1;
            this.actionTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.actionTableLayout.Size = new System.Drawing.Size(550, 40);
            this.actionTableLayout.TabIndex = 5;
            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actionLabel.Location = new System.Drawing.Point(0, 0);
            this.actionLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(140, 37);
            this.actionLabel.TabIndex = 0;
            this.actionLabel.Text = "Action *";
            this.actionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // actionCombobox
            // 
            this.actionCombobox.Cue = "Type action or Select from list";
            this.actionCombobox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionCombobox.ForeColor = System.Drawing.Color.Black;
            this.actionCombobox.FormattingEnabled = true;
            this.actionCombobox.Location = new System.Drawing.Point(143, 7);
            this.actionCombobox.Margin = new System.Windows.Forms.Padding(3, 7, 3, 4);
            this.actionCombobox.Name = "actionCombobox";
            this.actionCombobox.Size = new System.Drawing.Size(180, 25);
            this.actionCombobox.TabIndex = 1;
            this.actionCombobox.DropDown += new System.EventHandler(this.actionCombobox_DropDown);
            this.actionCombobox.TextChanged += new System.EventHandler(this.SetStateDirty);
            // 
            // fromResourceHeaderTable
            // 
            this.fromResourceHeaderTable.ColumnCount = 1;
            this.fromResourceHeaderTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.fromResourceHeaderTable.Controls.Add(this.underlineLabel5, 0, 1);
            this.fromResourceHeaderTable.Controls.Add(this.fromResourceHeaderLabel, 0, 0);
            this.fromResourceHeaderTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fromResourceHeaderTable.Location = new System.Drawing.Point(6, 535);
            this.fromResourceHeaderTable.Margin = new System.Windows.Forms.Padding(1, 3, 1, 4);
            this.fromResourceHeaderTable.Name = "fromResourceHeaderTable";
            this.fromResourceHeaderTable.RowCount = 2;
            this.fromResourceHeaderTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.fromResourceHeaderTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.fromResourceHeaderTable.Size = new System.Drawing.Size(548, 25);
            this.fromResourceHeaderTable.TabIndex = 6;
            // 
            // underlineLabel5
            // 
            this.underlineLabel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.underlineLabel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.underlineLabel5.Location = new System.Drawing.Point(2, 24);
            this.underlineLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 3, 0);
            this.underlineLabel5.Name = "underlineLabel5";
            this.underlineLabel5.Size = new System.Drawing.Size(543, 1);
            this.underlineLabel5.TabIndex = 2;
            // 
            // fromResourceHeaderLabel
            // 
            this.fromResourceHeaderLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.fromResourceHeaderLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromResourceHeaderLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.fromResourceHeaderLabel.Location = new System.Drawing.Point(3, 0);
            this.fromResourceHeaderLabel.Name = "fromResourceHeaderLabel";
            this.fromResourceHeaderLabel.Padding = new System.Windows.Forms.Padding(4, 3, 0, 0);
            this.fromResourceHeaderLabel.Size = new System.Drawing.Size(136, 24);
            this.fromResourceHeaderLabel.TabIndex = 0;
            this.fromResourceHeaderLabel.Text = "ON RESOURCE";
            this.fromResourceHeaderLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // fromResourceTableLayout
            // 
            this.fromResourceTableLayout.ColumnCount = 1;
            this.fromResourceTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.fromResourceTableLayout.Controls.Add(this.fromResourceDynamicAttributeTable, 0, 1);
            this.fromResourceTableLayout.Controls.Add(this.fromResourceStaticAttributeTable, 0, 0);
            this.fromResourceTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fromResourceTableLayout.Location = new System.Drawing.Point(8, 568);
            this.fromResourceTableLayout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fromResourceTableLayout.Name = "fromResourceTableLayout";
            this.fromResourceTableLayout.RowCount = 2;
            this.fromResourceTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.fromResourceTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.fromResourceTableLayout.Size = new System.Drawing.Size(544, 147);
            this.fromResourceTableLayout.TabIndex = 7;
            // 
            // fromResourceDynamicAttributeTable
            // 
            this.fromResourceDynamicAttributeTable.ColumnCount = 4;
            this.fromResourceDynamicAttributeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.fromResourceDynamicAttributeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.fromResourceDynamicAttributeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.fromResourceDynamicAttributeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.fromResourceDynamicAttributeTable.Controls.Add(this.addFromResourceAttribute, 0, 0);
            this.fromResourceDynamicAttributeTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fromResourceDynamicAttributeTable.Location = new System.Drawing.Point(0, 32);
            this.fromResourceDynamicAttributeTable.Margin = new System.Windows.Forms.Padding(0, 4, 0, 3);
            this.fromResourceDynamicAttributeTable.Name = "fromResourceDynamicAttributeTable";
            this.fromResourceDynamicAttributeTable.RowCount = 1;
            this.fromResourceDynamicAttributeTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.fromResourceDynamicAttributeTable.Size = new System.Drawing.Size(544, 117);
            this.fromResourceDynamicAttributeTable.TabIndex = 2;
            // 
            // addFromResourceAttribute
            // 
            this.addFromResourceAttribute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addFromResourceAttribute.BackColor = System.Drawing.SystemColors.ControlDark;
            this.addFromResourceAttribute.Cursor = System.Windows.Forms.Cursors.Default;
            this.addFromResourceAttribute.FlatAppearance.BorderSize = 0;
            this.addFromResourceAttribute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addFromResourceAttribute.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addFromResourceAttribute.Location = new System.Drawing.Point(116, 0);
            this.addFromResourceAttribute.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.addFromResourceAttribute.Name = "addFromResourceAttribute";
            this.addFromResourceAttribute.Size = new System.Drawing.Size(23, 23);
            this.addFromResourceAttribute.TabIndex = 0;
            this.addFromResourceAttribute.Text = "+";
            this.addFromResourceAttribute.UseVisualStyleBackColor = false;
            this.addFromResourceAttribute.Click += new System.EventHandler(this.addFromResourceAttribute_Click);
            // 
            // fromResourceStaticAttributeTable
            // 
            this.fromResourceStaticAttributeTable.ColumnCount = 2;
            this.fromResourceStaticAttributeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.fromResourceStaticAttributeTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.fromResourceStaticAttributeTable.Controls.Add(this.fromResourceNameTextbox, 1, 0);
            this.fromResourceStaticAttributeTable.Controls.Add(this.fromResourceLabel, 0, 0);
            this.fromResourceStaticAttributeTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fromResourceStaticAttributeTable.Location = new System.Drawing.Point(0, 0);
            this.fromResourceStaticAttributeTable.Margin = new System.Windows.Forms.Padding(0);
            this.fromResourceStaticAttributeTable.Name = "fromResourceStaticAttributeTable";
            this.fromResourceStaticAttributeTable.RowCount = 1;
            this.fromResourceStaticAttributeTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.fromResourceStaticAttributeTable.Size = new System.Drawing.Size(544, 28);
            this.fromResourceStaticAttributeTable.TabIndex = 0;
            // 
            // fromResourceNameTextbox
            // 
            this.fromResourceNameTextbox.Cue = "e.g. C:\\ITARDocument.docx";
            this.fromResourceNameTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fromResourceNameTextbox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromResourceNameTextbox.Location = new System.Drawing.Point(143, 2);
            this.fromResourceNameTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 4);
            this.fromResourceNameTextbox.Name = "fromResourceNameTextbox";
            this.fromResourceNameTextbox.Size = new System.Drawing.Size(398, 25);
            this.fromResourceNameTextbox.TabIndex = 4;
            this.fromResourceNameTextbox.TextChanged += new System.EventHandler(this.SetStateDirty);
            // 
            // fromResourceLabel
            // 
            this.fromResourceLabel.AutoSize = true;
            this.fromResourceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fromResourceLabel.Location = new System.Drawing.Point(3, 0);
            this.fromResourceLabel.Name = "fromResourceLabel";
            this.fromResourceLabel.Size = new System.Drawing.Size(134, 28);
            this.fromResourceLabel.TabIndex = 0;
            this.fromResourceLabel.Text = "Resource Name *";
            this.fromResourceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // formButtonsLayout
            // 
            this.formButtonsLayout.ColumnCount = 4;
            this.formButtonsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formButtonsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.formButtonsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.formButtonsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.formButtonsLayout.Controls.Add(this.validateTestCaseButton, 3, 0);
            this.formButtonsLayout.Controls.Add(this.clearTestCaseButton, 2, 0);
            this.formButtonsLayout.Controls.Add(this.saveTestCaseButton, 1, 0);
            this.formButtonsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formButtonsLayout.Location = new System.Drawing.Point(5, 1093);
            this.formButtonsLayout.Margin = new System.Windows.Forms.Padding(0);
            this.formButtonsLayout.Name = "formButtonsLayout";
            this.formButtonsLayout.RowCount = 1;
            this.formButtonsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formButtonsLayout.Size = new System.Drawing.Size(550, 33);
            this.formButtonsLayout.TabIndex = 10;
            // 
            // validateTestCaseButton
            // 
            this.validateTestCaseButton.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.validateTestCaseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.validateTestCaseButton.FlatAppearance.BorderSize = 0;
            this.validateTestCaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.validateTestCaseButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.validateTestCaseButton.Location = new System.Drawing.Point(444, 2);
            this.validateTestCaseButton.Margin = new System.Windows.Forms.Padding(2);
            this.validateTestCaseButton.Name = "validateTestCaseButton";
            this.validateTestCaseButton.Size = new System.Drawing.Size(104, 29);
            this.validateTestCaseButton.TabIndex = 0;
            this.validateTestCaseButton.Text = "Validate";
            this.validateTestCaseButton.UseVisualStyleBackColor = false;
            this.validateTestCaseButton.Click += new System.EventHandler(this.validateTestCaseButton_Click);
            // 
            // clearTestCaseButton
            // 
            this.clearTestCaseButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.clearTestCaseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearTestCaseButton.FlatAppearance.BorderSize = 0;
            this.clearTestCaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearTestCaseButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.clearTestCaseButton.Location = new System.Drawing.Point(339, 2);
            this.clearTestCaseButton.Margin = new System.Windows.Forms.Padding(2);
            this.clearTestCaseButton.Name = "clearTestCaseButton";
            this.clearTestCaseButton.Size = new System.Drawing.Size(101, 29);
            this.clearTestCaseButton.TabIndex = 1;
            this.clearTestCaseButton.Text = "Clear Form";
            this.clearTestCaseButton.UseVisualStyleBackColor = false;
            this.clearTestCaseButton.Click += new System.EventHandler(this.clearTestCaseButton_Click);
            // 
            // saveTestCaseButton
            // 
            this.saveTestCaseButton.BackColor = System.Drawing.Color.SteelBlue;
            this.saveTestCaseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveTestCaseButton.FlatAppearance.BorderSize = 0;
            this.saveTestCaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveTestCaseButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.saveTestCaseButton.Location = new System.Drawing.Point(234, 2);
            this.saveTestCaseButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveTestCaseButton.Name = "saveTestCaseButton";
            this.saveTestCaseButton.Size = new System.Drawing.Size(101, 29);
            this.saveTestCaseButton.TabIndex = 2;
            this.saveTestCaseButton.Text = "Save Form";
            this.saveTestCaseButton.UseVisualStyleBackColor = false;
            this.saveTestCaseButton.Click += new System.EventHandler(this.saveTestCaseButton_Click);
            // 
            // resultRichTextField
            // 
            this.resultRichTextField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultRichTextField.BackColor = System.Drawing.Color.White;
            this.resultRichTextField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultRichTextField.ContextMenuStrip = this.resultCopyContextMenu;
            this.resultRichTextField.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultRichTextField.ForeColor = System.Drawing.SystemColors.ControlText;
            this.resultRichTextField.Location = new System.Drawing.Point(5, 1158);
            this.resultRichTextField.Margin = new System.Windows.Forms.Padding(0);
            this.resultRichTextField.Name = "resultRichTextField";
            this.resultRichTextField.ReadOnly = true;
            this.resultRichTextField.Size = new System.Drawing.Size(550, 300);
            this.resultRichTextField.TabIndex = 12;
            this.resultRichTextField.Text = "";
            // 
            // resultCopyContextMenu
            // 
            this.resultCopyContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyMenuItem});
            this.resultCopyContextMenu.Name = "resultCopyContextMenu";
            this.resultCopyContextMenu.Size = new System.Drawing.Size(103, 26);
            // 
            // copyMenuItem
            // 
            this.copyMenuItem.Name = "copyMenuItem";
            this.copyMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyMenuItem.Text = "Copy";
            this.copyMenuItem.Click += new System.EventHandler(this.copyMenuItem_Click);
            // 
            // resultButtonsLayout
            // 
            this.resultButtonsLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultButtonsLayout.ColumnCount = 3;
            this.resultButtonsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.resultButtonsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.resultButtonsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.resultButtonsLayout.Controls.Add(this.clearTestCaseResultButton, 2, 0);
            this.resultButtonsLayout.Controls.Add(this.exportTestCaseResultButton, 1, 0);
            this.resultButtonsLayout.Location = new System.Drawing.Point(5, 1458);
            this.resultButtonsLayout.Margin = new System.Windows.Forms.Padding(0);
            this.resultButtonsLayout.Name = "resultButtonsLayout";
            this.resultButtonsLayout.RowCount = 1;
            this.resultButtonsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.resultButtonsLayout.Size = new System.Drawing.Size(550, 33);
            this.resultButtonsLayout.TabIndex = 13;
            // 
            // clearTestCaseResultButton
            // 
            this.clearTestCaseResultButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.clearTestCaseResultButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearTestCaseResultButton.FlatAppearance.BorderSize = 0;
            this.clearTestCaseResultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearTestCaseResultButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.clearTestCaseResultButton.Location = new System.Drawing.Point(446, 2);
            this.clearTestCaseResultButton.Margin = new System.Windows.Forms.Padding(2);
            this.clearTestCaseResultButton.Name = "clearTestCaseResultButton";
            this.clearTestCaseResultButton.Size = new System.Drawing.Size(102, 29);
            this.clearTestCaseResultButton.TabIndex = 0;
            this.clearTestCaseResultButton.Text = "Clear Result";
            this.clearTestCaseResultButton.UseVisualStyleBackColor = false;
            this.clearTestCaseResultButton.Click += new System.EventHandler(this.clearTestCaseResultButton_Click);
            // 
            // exportTestCaseResultButton
            // 
            this.exportTestCaseResultButton.BackColor = System.Drawing.Color.LightBlue;
            this.exportTestCaseResultButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exportTestCaseResultButton.Enabled = false;
            this.exportTestCaseResultButton.FlatAppearance.BorderSize = 0;
            this.exportTestCaseResultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportTestCaseResultButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.exportTestCaseResultButton.Location = new System.Drawing.Point(322, 2);
            this.exportTestCaseResultButton.Margin = new System.Windows.Forms.Padding(2);
            this.exportTestCaseResultButton.Name = "exportTestCaseResultButton";
            this.exportTestCaseResultButton.Size = new System.Drawing.Size(120, 29);
            this.exportTestCaseResultButton.TabIndex = 1;
            this.exportTestCaseResultButton.Text = "Export Result";
            this.exportTestCaseResultButton.UseVisualStyleBackColor = false;
            this.exportTestCaseResultButton.Click += new System.EventHandler(this.exportTestCaseResultButton_Click);
            // 
            // documentPolicyHeaderLayout
            // 
            this.documentPolicyHeaderLayout.ColumnCount = 1;
            this.documentPolicyHeaderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.documentPolicyHeaderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.documentPolicyHeaderLayout.Controls.Add(this.documentPolicyHeaderLabel, 0, 0);
            this.documentPolicyHeaderLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentPolicyHeaderLayout.Location = new System.Drawing.Point(8, 9);
            this.documentPolicyHeaderLayout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.documentPolicyHeaderLayout.Name = "documentPolicyHeaderLayout";
            this.documentPolicyHeaderLayout.RowCount = 1;
            this.documentPolicyHeaderLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.documentPolicyHeaderLayout.Size = new System.Drawing.Size(544, 32);
            this.documentPolicyHeaderLayout.TabIndex = 14;
            // 
            // documentPolicyHeaderLabel
            // 
            this.documentPolicyHeaderLabel.AutoSize = true;
            this.documentPolicyHeaderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentPolicyHeaderLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentPolicyHeaderLabel.Location = new System.Drawing.Point(3, 0);
            this.documentPolicyHeaderLabel.Name = "documentPolicyHeaderLabel";
            this.documentPolicyHeaderLabel.Size = new System.Drawing.Size(538, 32);
            this.documentPolicyHeaderLabel.TabIndex = 1;
            this.documentPolicyHeaderLabel.Text = "Document Policy";
            this.documentPolicyHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // expectedResultHeaderLayout
            // 
            this.expectedResultHeaderLayout.ColumnCount = 1;
            this.expectedResultHeaderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.expectedResultHeaderLayout.Controls.Add(this.expectedResultHeaderLabel, 0, 0);
            this.expectedResultHeaderLayout.Controls.Add(this.underlineLabel6, 0, 1);
            this.expectedResultHeaderLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expectedResultHeaderLayout.Location = new System.Drawing.Point(6, 57);
            this.expectedResultHeaderLayout.Margin = new System.Windows.Forms.Padding(1, 3, 1, 4);
            this.expectedResultHeaderLayout.Name = "expectedResultHeaderLayout";
            this.expectedResultHeaderLayout.RowCount = 2;
            this.expectedResultHeaderLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.expectedResultHeaderLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.expectedResultHeaderLayout.Size = new System.Drawing.Size(548, 25);
            this.expectedResultHeaderLayout.TabIndex = 15;
            // 
            // expectedResultHeaderLabel
            // 
            this.expectedResultHeaderLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.expectedResultHeaderLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expectedResultHeaderLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.expectedResultHeaderLabel.Location = new System.Drawing.Point(3, 0);
            this.expectedResultHeaderLabel.Name = "expectedResultHeaderLabel";
            this.expectedResultHeaderLabel.Padding = new System.Windows.Forms.Padding(4, 3, 0, 0);
            this.expectedResultHeaderLabel.Size = new System.Drawing.Size(136, 24);
            this.expectedResultHeaderLabel.TabIndex = 0;
            this.expectedResultHeaderLabel.Text = "EXPECTED RESULT";
            this.expectedResultHeaderLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // underlineLabel6
            // 
            this.underlineLabel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.underlineLabel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.underlineLabel6.Location = new System.Drawing.Point(2, 24);
            this.underlineLabel6.Margin = new System.Windows.Forms.Padding(2, 0, 3, 0);
            this.underlineLabel6.Name = "underlineLabel6";
            this.underlineLabel6.Size = new System.Drawing.Size(543, 1);
            this.underlineLabel6.TabIndex = 1;
            // 
            // expectedResultTableLayout
            // 
            this.expectedResultTableLayout.ColumnCount = 3;
            this.expectedResultTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.expectedResultTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.expectedResultTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 453F));
            this.expectedResultTableLayout.Controls.Add(this.denyRadioButton, 1, 0);
            this.expectedResultTableLayout.Controls.Add(this.allowRadioButton, 2, 0);
            this.expectedResultTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expectedResultTableLayout.Location = new System.Drawing.Point(5, 86);
            this.expectedResultTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.expectedResultTableLayout.Name = "expectedResultTableLayout";
            this.expectedResultTableLayout.RowCount = 1;
            this.expectedResultTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.expectedResultTableLayout.Size = new System.Drawing.Size(550, 40);
            this.expectedResultTableLayout.TabIndex = 16;
            // 
            // denyRadioButton
            // 
            this.denyRadioButton.AutoSize = true;
            this.denyRadioButton.Checked = true;
            this.denyRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.denyRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.denyRadioButton.Location = new System.Drawing.Point(136, 4);
            this.denyRadioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.denyRadioButton.Name = "denyRadioButton";
            this.denyRadioButton.Size = new System.Drawing.Size(84, 32);
            this.denyRadioButton.TabIndex = 0;
            this.denyRadioButton.TabStop = true;
            this.denyRadioButton.Text = "Deny";
            this.denyRadioButton.UseVisualStyleBackColor = true;
            this.denyRadioButton.CheckedChanged += new System.EventHandler(this.SetStateDirty);
            // 
            // allowRadioButton
            // 
            this.allowRadioButton.AutoSize = true;
            this.allowRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allowRadioButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.allowRadioButton.Location = new System.Drawing.Point(226, 4);
            this.allowRadioButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.allowRadioButton.Name = "allowRadioButton";
            this.allowRadioButton.Size = new System.Drawing.Size(447, 32);
            this.allowRadioButton.TabIndex = 1;
            this.allowRadioButton.Text = "Allow";
            this.allowRadioButton.UseVisualStyleBackColor = true;
            this.allowRadioButton.CheckedChanged += new System.EventHandler(this.SetStateDirty);
            // 
            // recipientsHeaderTableLayout
            // 
            this.recipientsHeaderTableLayout.ColumnCount = 1;
            this.recipientsHeaderTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.recipientsHeaderTableLayout.Controls.Add(this.underlineLabelRecipients, 0, 1);
            this.recipientsHeaderTableLayout.Controls.Add(this.recipientsHeaderLabel, 0, 0);
            this.recipientsHeaderTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recipientsHeaderTableLayout.Location = new System.Drawing.Point(6, 463);
            this.recipientsHeaderTableLayout.Margin = new System.Windows.Forms.Padding(1, 3, 1, 4);
            this.recipientsHeaderTableLayout.Name = "recipientsHeaderTableLayout";
            this.recipientsHeaderTableLayout.RowCount = 2;
            this.recipientsHeaderTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.recipientsHeaderTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.recipientsHeaderTableLayout.Size = new System.Drawing.Size(548, 25);
            this.recipientsHeaderTableLayout.TabIndex = 17;
            // 
            // underlineLabelRecipients
            // 
            this.underlineLabelRecipients.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.underlineLabelRecipients.Dock = System.Windows.Forms.DockStyle.Top;
            this.underlineLabelRecipients.Location = new System.Drawing.Point(2, 24);
            this.underlineLabelRecipients.Margin = new System.Windows.Forms.Padding(2, 0, 3, 0);
            this.underlineLabelRecipients.Name = "underlineLabelRecipients";
            this.underlineLabelRecipients.Size = new System.Drawing.Size(543, 1);
            this.underlineLabelRecipients.TabIndex = 2;
            // 
            // recipientsHeaderLabel
            // 
            this.recipientsHeaderLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.recipientsHeaderLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipientsHeaderLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.recipientsHeaderLabel.Location = new System.Drawing.Point(3, 0);
            this.recipientsHeaderLabel.Name = "recipientsHeaderLabel";
            this.recipientsHeaderLabel.Padding = new System.Windows.Forms.Padding(4, 3, 0, 0);
            this.recipientsHeaderLabel.Size = new System.Drawing.Size(136, 24);
            this.recipientsHeaderLabel.TabIndex = 0;
            this.recipientsHeaderLabel.Text = "RECIPIENTS";
            this.recipientsHeaderLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // recipientsTableLayout
            // 
            this.recipientsTableLayout.ColumnCount = 2;
            this.recipientsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.recipientsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.recipientsTableLayout.Controls.Add(this.recipientsTextBox, 0, 0);
            this.recipientsTableLayout.Controls.Add(this.emailAddressesLabel, 0, 0);
            this.recipientsTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recipientsTableLayout.Location = new System.Drawing.Point(5, 492);
            this.recipientsTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.recipientsTableLayout.Name = "recipientsTableLayout";
            this.recipientsTableLayout.RowCount = 1;
            this.recipientsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.recipientsTableLayout.Size = new System.Drawing.Size(550, 40);
            this.recipientsTableLayout.TabIndex = 18;
            // 
            // recipientsTextBox
            // 
            this.recipientsTextBox.Cue = "e.g. manager@company.com;hr@company.com";
            this.recipientsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recipientsTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipientsTextBox.Location = new System.Drawing.Point(143, 7);
            this.recipientsTextBox.Margin = new System.Windows.Forms.Padding(3, 7, 3, 4);
            this.recipientsTextBox.Name = "recipientsTextBox";
            this.recipientsTextBox.Size = new System.Drawing.Size(414, 25);
            this.recipientsTextBox.TabIndex = 5;
            this.recipientsTextBox.TextChanged += new System.EventHandler(this.SetStateDirty);
            // 
            // emailAddressesLabel
            // 
            this.emailAddressesLabel.AutoSize = true;
            this.emailAddressesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailAddressesLabel.Location = new System.Drawing.Point(0, 0);
            this.emailAddressesLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.emailAddressesLabel.Name = "emailAddressesLabel";
            this.emailAddressesLabel.Size = new System.Drawing.Size(140, 37);
            this.emailAddressesLabel.TabIndex = 1;
            this.emailAddressesLabel.Text = "Email Addresses *";
            this.emailAddressesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // emailDetailsHeaderTable
            // 
            this.emailDetailsHeaderTable.ColumnCount = 1;
            this.emailDetailsHeaderTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.emailDetailsHeaderTable.Controls.Add(this.emailDetailsHeaderLabel, 0, 0);
            this.emailDetailsHeaderTable.Controls.Add(this.underlineEmailDetailsLabel, 0, 1);
            this.emailDetailsHeaderTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailDetailsHeaderTable.Location = new System.Drawing.Point(6, 909);
            this.emailDetailsHeaderTable.Margin = new System.Windows.Forms.Padding(1, 3, 1, 4);
            this.emailDetailsHeaderTable.Name = "emailDetailsHeaderTable";
            this.emailDetailsHeaderTable.RowCount = 2;
            this.emailDetailsHeaderTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.emailDetailsHeaderTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.emailDetailsHeaderTable.Size = new System.Drawing.Size(548, 25);
            this.emailDetailsHeaderTable.TabIndex = 19;
            // 
            // emailDetailsHeaderLabel
            // 
            this.emailDetailsHeaderLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.emailDetailsHeaderLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailDetailsHeaderLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.emailDetailsHeaderLabel.Location = new System.Drawing.Point(3, 0);
            this.emailDetailsHeaderLabel.Name = "emailDetailsHeaderLabel";
            this.emailDetailsHeaderLabel.Padding = new System.Windows.Forms.Padding(4, 3, 0, 0);
            this.emailDetailsHeaderLabel.Size = new System.Drawing.Size(136, 24);
            this.emailDetailsHeaderLabel.TabIndex = 1;
            this.emailDetailsHeaderLabel.Text = "EMAIL DETAILS";
            this.emailDetailsHeaderLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // underlineEmailDetailsLabel
            // 
            this.underlineEmailDetailsLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.underlineEmailDetailsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.underlineEmailDetailsLabel.Location = new System.Drawing.Point(2, 24);
            this.underlineEmailDetailsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 3, 0);
            this.underlineEmailDetailsLabel.Name = "underlineEmailDetailsLabel";
            this.underlineEmailDetailsLabel.Size = new System.Drawing.Size(543, 1);
            this.underlineEmailDetailsLabel.TabIndex = 3;
            // 
            // emailDetailsTableLayout
            // 
            this.emailDetailsTableLayout.ColumnCount = 2;
            this.emailDetailsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.emailDetailsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.emailDetailsTableLayout.Controls.Add(this.emailBodyLabel, 0, 1);
            this.emailDetailsTableLayout.Controls.Add(this.emailSubjectLabel, 0, 0);
            this.emailDetailsTableLayout.Controls.Add(this.emailSubjectTextBox, 1, 0);
            this.emailDetailsTableLayout.Controls.Add(this.emailBodyRichTextBox, 1, 1);
            this.emailDetailsTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailDetailsTableLayout.Location = new System.Drawing.Point(8, 941);
            this.emailDetailsTableLayout.Name = "emailDetailsTableLayout";
            this.emailDetailsTableLayout.RowCount = 2;
            this.emailDetailsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.emailDetailsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.emailDetailsTableLayout.Size = new System.Drawing.Size(544, 144);
            this.emailDetailsTableLayout.TabIndex = 20;
            // 
            // emailBodyLabel
            // 
            this.emailBodyLabel.AutoSize = true;
            this.emailBodyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailBodyLabel.Location = new System.Drawing.Point(3, 33);
            this.emailBodyLabel.Name = "emailBodyLabel";
            this.emailBodyLabel.Size = new System.Drawing.Size(134, 111);
            this.emailBodyLabel.TabIndex = 2;
            this.emailBodyLabel.Text = "Email Body";
            this.emailBodyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // emailSubjectLabel
            // 
            this.emailSubjectLabel.AutoSize = true;
            this.emailSubjectLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailSubjectLabel.Location = new System.Drawing.Point(3, 0);
            this.emailSubjectLabel.Name = "emailSubjectLabel";
            this.emailSubjectLabel.Size = new System.Drawing.Size(134, 33);
            this.emailSubjectLabel.TabIndex = 1;
            this.emailSubjectLabel.Text = "Email Subject";
            this.emailSubjectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // emailSubjectTextBox
            // 
            this.emailSubjectTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailSubjectTextBox.Location = new System.Drawing.Point(143, 3);
            this.emailSubjectTextBox.Name = "emailSubjectTextBox";
            this.emailSubjectTextBox.Size = new System.Drawing.Size(398, 25);
            this.emailSubjectTextBox.TabIndex = 3;
            this.emailSubjectTextBox.TextChanged += new System.EventHandler(this.SetStateDirty);
            // 
            // emailBodyRichTextBox
            // 
            this.emailBodyRichTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.emailBodyRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emailBodyRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailBodyRichTextBox.Location = new System.Drawing.Point(143, 36);
            this.emailBodyRichTextBox.Name = "emailBodyRichTextBox";
            this.emailBodyRichTextBox.Size = new System.Drawing.Size(398, 105);
            this.emailBodyRichTextBox.TabIndex = 4;
            this.emailBodyRichTextBox.Text = "";
            this.emailBodyRichTextBox.TextChanged += new System.EventHandler(this.SetStateDirty);
            // 
            // testSetPanel
            // 
            this.testSetPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.testSetPanel.Controls.Add(this.testSetTableLayout);
            this.testSetPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testSetPanel.Location = new System.Drawing.Point(0, 0);
            this.testSetPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.testSetPanel.Name = "testSetPanel";
            this.testSetPanel.Size = new System.Drawing.Size(579, 759);
            this.testSetPanel.TabIndex = 0;
            // 
            // testSetTableLayout
            // 
            this.testSetTableLayout.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.testSetTableLayout.ColumnCount = 1;
            this.testSetTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.testSetTableLayout.Controls.Add(this.testSetHeaderLabel, 0, 0);
            this.testSetTableLayout.Controls.Add(this.testSetTablePanel, 0, 1);
            this.testSetTableLayout.Controls.Add(this.testSetResultButtonLayout, 0, 4);
            this.testSetTableLayout.Controls.Add(this.resultTablePanel, 0, 3);
            this.testSetTableLayout.Controls.Add(this.testSetButtonLayout, 0, 2);
            this.testSetTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testSetTableLayout.Location = new System.Drawing.Point(0, 0);
            this.testSetTableLayout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.testSetTableLayout.Name = "testSetTableLayout";
            this.testSetTableLayout.Padding = new System.Windows.Forms.Padding(5);
            this.testSetTableLayout.RowCount = 5;
            this.testSetTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.testSetTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.testSetTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.testSetTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.testSetTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.testSetTableLayout.Size = new System.Drawing.Size(577, 757);
            this.testSetTableLayout.TabIndex = 0;
            // 
            // testSetHeaderLabel
            // 
            this.testSetHeaderLabel.AutoSize = true;
            this.testSetHeaderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testSetHeaderLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testSetHeaderLabel.Location = new System.Drawing.Point(8, 5);
            this.testSetHeaderLabel.Name = "testSetHeaderLabel";
            this.testSetHeaderLabel.Size = new System.Drawing.Size(561, 33);
            this.testSetHeaderLabel.TabIndex = 0;
            this.testSetHeaderLabel.Text = "Test Set";
            this.testSetHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // testSetTablePanel
            // 
            this.testSetTablePanel.BackColor = System.Drawing.Color.White;
            this.testSetTablePanel.ColumnCount = 5;
            this.testSetTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.testSetTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.testSetTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.testSetTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.testSetTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.testSetTablePanel.Controls.Add(this.testCaseNameLabel, 0, 0);
            this.testSetTablePanel.Controls.Add(this.testCaseTypeLabel, 1, 0);
            this.testSetTablePanel.Controls.Add(this.testCaseActionLabel, 2, 0);
            this.testSetTablePanel.Controls.Add(this.expectedResultLabel, 3, 0);
            this.testSetTablePanel.Controls.Add(this.actualResultLabel, 4, 0);
            this.testSetTablePanel.Controls.Add(this.underlineLabel7, 0, 1);
            this.testSetTablePanel.Controls.Add(this.underlineLabel8, 1, 1);
            this.testSetTablePanel.Controls.Add(this.underlineLabel9, 2, 1);
            this.testSetTablePanel.Controls.Add(this.underlineLabel20, 3, 1);
            this.testSetTablePanel.Controls.Add(this.underlineLabel21, 4, 1);
            this.testSetTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testSetTablePanel.Location = new System.Drawing.Point(8, 42);
            this.testSetTablePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.testSetTablePanel.Name = "testSetTablePanel";
            this.testSetTablePanel.Padding = new System.Windows.Forms.Padding(5);
            this.testSetTablePanel.RowCount = 3;
            this.testSetTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.testSetTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.testSetTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.testSetTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.testSetTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.testSetTablePanel.Size = new System.Drawing.Size(561, 445);
            this.testSetTablePanel.TabIndex = 1;
            this.testSetTablePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.testSetTablePanel_Paint);
            // 
            // testCaseNameLabel
            // 
            this.testCaseNameLabel.AutoSize = true;
            this.testCaseNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testCaseNameLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testCaseNameLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.testCaseNameLabel.Location = new System.Drawing.Point(8, 5);
            this.testCaseNameLabel.Name = "testCaseNameLabel";
            this.testCaseNameLabel.Size = new System.Drawing.Size(104, 30);
            this.testCaseNameLabel.TabIndex = 0;
            this.testCaseNameLabel.Text = "Test Case";
            this.testCaseNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // testCaseTypeLabel
            // 
            this.testCaseTypeLabel.AutoSize = true;
            this.testCaseTypeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testCaseTypeLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testCaseTypeLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.testCaseTypeLabel.Location = new System.Drawing.Point(118, 5);
            this.testCaseTypeLabel.Name = "testCaseTypeLabel";
            this.testCaseTypeLabel.Size = new System.Drawing.Size(104, 30);
            this.testCaseTypeLabel.TabIndex = 6;
            this.testCaseTypeLabel.Text = "Type";
            this.testCaseTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // testCaseActionLabel
            // 
            this.testCaseActionLabel.AutoSize = true;
            this.testCaseActionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testCaseActionLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testCaseActionLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.testCaseActionLabel.Location = new System.Drawing.Point(228, 5);
            this.testCaseActionLabel.Name = "testCaseActionLabel";
            this.testCaseActionLabel.Size = new System.Drawing.Size(104, 30);
            this.testCaseActionLabel.TabIndex = 7;
            this.testCaseActionLabel.Text = "Action";
            this.testCaseActionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // expectedResultLabel
            // 
            this.expectedResultLabel.AutoSize = true;
            this.expectedResultLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expectedResultLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expectedResultLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.expectedResultLabel.Location = new System.Drawing.Point(338, 5);
            this.expectedResultLabel.Name = "expectedResultLabel";
            this.expectedResultLabel.Size = new System.Drawing.Size(104, 30);
            this.expectedResultLabel.TabIndex = 1;
            this.expectedResultLabel.Text = "Expected Result";
            this.expectedResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // actualResultLabel
            // 
            this.actualResultLabel.AutoSize = true;
            this.actualResultLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actualResultLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actualResultLabel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.actualResultLabel.Location = new System.Drawing.Point(448, 5);
            this.actualResultLabel.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.actualResultLabel.Name = "actualResultLabel";
            this.actualResultLabel.Size = new System.Drawing.Size(98, 30);
            this.actualResultLabel.TabIndex = 2;
            this.actualResultLabel.Text = "Actual Result";
            this.actualResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // underlineLabel7
            // 
            this.underlineLabel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.underlineLabel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.underlineLabel7.Location = new System.Drawing.Point(8, 35);
            this.underlineLabel7.Name = "underlineLabel7";
            this.underlineLabel7.Size = new System.Drawing.Size(104, 2);
            this.underlineLabel7.TabIndex = 4;
            this.underlineLabel7.Text = "label33";
            // 
            // underlineLabel8
            // 
            this.underlineLabel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.underlineLabel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.underlineLabel8.Location = new System.Drawing.Point(118, 35);
            this.underlineLabel8.Name = "underlineLabel8";
            this.underlineLabel8.Size = new System.Drawing.Size(104, 2);
            this.underlineLabel8.TabIndex = 5;
            this.underlineLabel8.Text = "label34";
            // 
            // underlineLabel9
            // 
            this.underlineLabel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.underlineLabel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.underlineLabel9.Location = new System.Drawing.Point(228, 35);
            this.underlineLabel9.Name = "underlineLabel9";
            this.underlineLabel9.Size = new System.Drawing.Size(104, 2);
            this.underlineLabel9.TabIndex = 3;
            // 
            // underlineLabel20
            // 
            this.underlineLabel20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.underlineLabel20.Dock = System.Windows.Forms.DockStyle.Top;
            this.underlineLabel20.Location = new System.Drawing.Point(338, 35);
            this.underlineLabel20.Name = "underlineLabel20";
            this.underlineLabel20.Size = new System.Drawing.Size(104, 2);
            this.underlineLabel20.TabIndex = 8;
            // 
            // underlineLabel21
            // 
            this.underlineLabel21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.underlineLabel21.Dock = System.Windows.Forms.DockStyle.Top;
            this.underlineLabel21.Location = new System.Drawing.Point(448, 35);
            this.underlineLabel21.Name = "underlineLabel21";
            this.underlineLabel21.Size = new System.Drawing.Size(105, 2);
            this.underlineLabel21.TabIndex = 9;
            // 
            // testSetResultButtonLayout
            // 
            this.testSetResultButtonLayout.ColumnCount = 3;
            this.testSetResultButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.testSetResultButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.testSetResultButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.testSetResultButtonLayout.Controls.Add(this.exportTestSetResultButton, 1, 0);
            this.testSetResultButtonLayout.Controls.Add(this.clearTestSetResultButton, 2, 0);
            this.testSetResultButtonLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.testSetResultButtonLayout.Location = new System.Drawing.Point(5, 718);
            this.testSetResultButtonLayout.Margin = new System.Windows.Forms.Padding(0);
            this.testSetResultButtonLayout.Name = "testSetResultButtonLayout";
            this.testSetResultButtonLayout.RowCount = 1;
            this.testSetResultButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.testSetResultButtonLayout.Size = new System.Drawing.Size(567, 33);
            this.testSetResultButtonLayout.TabIndex = 3;
            // 
            // exportTestSetResultButton
            // 
            this.exportTestSetResultButton.AutoEllipsis = true;
            this.exportTestSetResultButton.BackColor = System.Drawing.Color.LightBlue;
            this.exportTestSetResultButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exportTestSetResultButton.Enabled = false;
            this.exportTestSetResultButton.FlatAppearance.BorderSize = 0;
            this.exportTestSetResultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportTestSetResultButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.exportTestSetResultButton.Location = new System.Drawing.Point(360, 1);
            this.exportTestSetResultButton.Margin = new System.Windows.Forms.Padding(1);
            this.exportTestSetResultButton.Name = "exportTestSetResultButton";
            this.exportTestSetResultButton.Size = new System.Drawing.Size(102, 31);
            this.exportTestSetResultButton.TabIndex = 4;
            this.exportTestSetResultButton.Text = "Export Result";
            this.exportTestSetResultButton.UseVisualStyleBackColor = false;
            this.exportTestSetResultButton.Click += new System.EventHandler(this.exportTestSetResultButton_Click);
            // 
            // clearTestSetResultButton
            // 
            this.clearTestSetResultButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.clearTestSetResultButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearTestSetResultButton.FlatAppearance.BorderSize = 0;
            this.clearTestSetResultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearTestSetResultButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.clearTestSetResultButton.Location = new System.Drawing.Point(464, 1);
            this.clearTestSetResultButton.Margin = new System.Windows.Forms.Padding(1);
            this.clearTestSetResultButton.Name = "clearTestSetResultButton";
            this.clearTestSetResultButton.Size = new System.Drawing.Size(102, 31);
            this.clearTestSetResultButton.TabIndex = 5;
            this.clearTestSetResultButton.Text = "Clear Result";
            this.clearTestSetResultButton.UseVisualStyleBackColor = false;
            this.clearTestSetResultButton.Click += new System.EventHandler(this.clearTestSetResultButton_Click);
            // 
            // resultTablePanel
            // 
            this.resultTablePanel.ColumnCount = 1;
            this.resultTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.resultTablePanel.Controls.Add(this.ResultrichTextBox, 0, 1);
            this.resultTablePanel.Controls.Add(this.resultHeaderLayout, 0, 0);
            this.resultTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultTablePanel.Location = new System.Drawing.Point(5, 524);
            this.resultTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.resultTablePanel.Name = "resultTablePanel";
            this.resultTablePanel.RowCount = 2;
            this.resultTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.resultTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.resultTablePanel.Size = new System.Drawing.Size(567, 194);
            this.resultTablePanel.TabIndex = 4;
            // 
            // ResultrichTextBox
            // 
            this.ResultrichTextBox.ContextMenuStrip = this.resultCopyContextMenu;
            this.ResultrichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultrichTextBox.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultrichTextBox.Location = new System.Drawing.Point(0, 40);
            this.ResultrichTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.ResultrichTextBox.Name = "ResultrichTextBox";
            this.ResultrichTextBox.Size = new System.Drawing.Size(567, 154);
            this.ResultrichTextBox.TabIndex = 5;
            this.ResultrichTextBox.Text = "";
            // 
            // resultHeaderLayout
            // 
            this.resultHeaderLayout.ColumnCount = 1;
            this.resultHeaderLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.resultHeaderLayout.Controls.Add(this.resultHeaderLabel, 0, 0);
            this.resultHeaderLayout.Controls.Add(this.underlineLabel10, 0, 1);
            this.resultHeaderLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultHeaderLayout.Location = new System.Drawing.Point(1, 3);
            this.resultHeaderLayout.Margin = new System.Windows.Forms.Padding(1, 3, 1, 4);
            this.resultHeaderLayout.Name = "resultHeaderLayout";
            this.resultHeaderLayout.RowCount = 2;
            this.resultHeaderLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.resultHeaderLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.resultHeaderLayout.Size = new System.Drawing.Size(565, 33);
            this.resultHeaderLayout.TabIndex = 6;
            // 
            // resultHeaderLabel
            // 
            this.resultHeaderLabel.BackColor = System.Drawing.Color.SteelBlue;
            this.resultHeaderLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.resultHeaderLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultHeaderLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.resultHeaderLabel.Location = new System.Drawing.Point(3, 0);
            this.resultHeaderLabel.Name = "resultHeaderLabel";
            this.resultHeaderLabel.Padding = new System.Windows.Forms.Padding(1, 3, 0, 0);
            this.resultHeaderLabel.Size = new System.Drawing.Size(138, 25);
            this.resultHeaderLabel.TabIndex = 0;
            this.resultHeaderLabel.Text = "RESULTS";
            this.resultHeaderLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // underlineLabel10
            // 
            this.underlineLabel10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.underlineLabel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.underlineLabel10.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.underlineLabel10.Location = new System.Drawing.Point(3, 25);
            this.underlineLabel10.Name = "underlineLabel10";
            this.underlineLabel10.Size = new System.Drawing.Size(559, 2);
            this.underlineLabel10.TabIndex = 1;
            // 
            // testSetButtonLayout
            // 
            this.testSetButtonLayout.ColumnCount = 2;
            this.testSetButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.testSetButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.testSetButtonLayout.Controls.Add(this.runTestSetButton, 1, 0);
            this.testSetButtonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testSetButtonLayout.Location = new System.Drawing.Point(5, 491);
            this.testSetButtonLayout.Margin = new System.Windows.Forms.Padding(0);
            this.testSetButtonLayout.Name = "testSetButtonLayout";
            this.testSetButtonLayout.RowCount = 1;
            this.testSetButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.testSetButtonLayout.Size = new System.Drawing.Size(567, 33);
            this.testSetButtonLayout.TabIndex = 5;
            // 
            // runTestSetButton
            // 
            this.runTestSetButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.runTestSetButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.runTestSetButton.FlatAppearance.BorderSize = 0;
            this.runTestSetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runTestSetButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.runTestSetButton.Location = new System.Drawing.Point(463, 1);
            this.runTestSetButton.Margin = new System.Windows.Forms.Padding(1);
            this.runTestSetButton.Name = "runTestSetButton";
            this.runTestSetButton.Size = new System.Drawing.Size(103, 31);
            this.runTestSetButton.TabIndex = 3;
            this.runTestSetButton.Text = "Run All";
            this.runTestSetButton.UseVisualStyleBackColor = false;
            this.runTestSetButton.Click += new System.EventHandler(this.runTestSetButton_Click);
            // 
            // introPanel
            // 
            this.introPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.introPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.introPanel.Controls.Add(this.introRichTextBox);
            this.introPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.introPanel.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.introPanel.Location = new System.Drawing.Point(0, 0);
            this.introPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.introPanel.Name = "introPanel";
            this.introPanel.Padding = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.introPanel.Size = new System.Drawing.Size(579, 759);
            this.introPanel.TabIndex = 2;
            // 
            // introRichTextBox
            // 
            this.introRichTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.introRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.introRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.introRichTextBox.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.introRichTextBox.Location = new System.Drawing.Point(10, 9);
            this.introRichTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.introRichTextBox.Name = "introRichTextBox";
            this.introRichTextBox.ReadOnly = true;
            this.introRichTextBox.Size = new System.Drawing.Size(557, 739);
            this.introRichTextBox.TabIndex = 0;
            this.introRichTextBox.Text = "";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.button3, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(194, 74);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(85, 3);
            this.button3.Margin = new System.Windows.Forms.Padding(85, 3, 3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(23, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "+";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83F));
            this.tableLayoutPanel4.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label15, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(194, 24);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Cue = null;
            this.textBox1.Location = new System.Drawing.Point(35, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(156, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(3, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(26, 24);
            this.label15.TabIndex = 0;
            this.label15.Text = "Resource Name : ";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 4;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.button4, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 23);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(194, 74);
            this.tableLayoutPanel6.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(85, 3);
            this.button4.Margin = new System.Windows.Forms.Padding(85, 3, 3, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(23, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "+";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83F));
            this.tableLayoutPanel7.Controls.Add(this.textBox2, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.label16, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(194, 24);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Cue = null;
            this.textBox2.Location = new System.Drawing.Point(35, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(156, 20);
            this.textBox2.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 24);
            this.label16.TabIndex = 0;
            this.label16.Text = "Resource Name : ";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Controls.Add(this.label18, 0, 1);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 2;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label18.Dock = System.Windows.Forms.DockStyle.Top;
            this.label18.Location = new System.Drawing.Point(3, 25);
            this.label18.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(194, 2);
            this.label18.TabIndex = 2;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label19.Location = new System.Drawing.Point(3, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "On resource";
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 4;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel12.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(85, 3, 3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 4;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 1;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel13.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(85, 3);
            this.button2.Margin = new System.Windows.Forms.Padding(85, 3, 3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(23, 8);
            this.button2.TabIndex = 0;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.ColumnCount = 2;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.14019F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.85981F));
            this.tableLayoutPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel18.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 1;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel18.TabIndex = 0;
            // 
            // btnRun
            // 
            this.btnRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRun.Location = new System.Drawing.Point(407, 5);
            this.btnRun.Margin = new System.Windows.Forms.Padding(5);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(123, 4);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel23
            // 
            this.tableLayoutPanel23.ColumnCount = 1;
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel23.Controls.Add(this.label24, 0, 0);
            this.tableLayoutPanel23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel23.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel23.Name = "tableLayoutPanel23";
            this.tableLayoutPanel23.RowCount = 2;
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel23.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel23.TabIndex = 0;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label24.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label24.Location = new System.Drawing.Point(3, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(194, 20);
            this.label24.TabIndex = 0;
            this.label24.Text = "Subject";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label28.Dock = System.Windows.Forms.DockStyle.Top;
            this.label28.Location = new System.Drawing.Point(0, 13);
            this.label28.Margin = new System.Windows.Forms.Padding(0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(470, 3);
            this.label28.TabIndex = 1;
            // 
            // connectionStatusBackgroundWorker
            // 
            this.connectionStatusBackgroundWorker.WorkerReportsProgress = true;
            this.connectionStatusBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.connectionStatusBackgroundWorker_DoWork);
            this.connectionStatusBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.connectionStatusBackgroundWorker_ProgressChanged);
            // 
            // testCaseBackgroundWorker
            // 
            this.testCaseBackgroundWorker.WorkerSupportsCancellation = true;
            this.testCaseBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.testCaseBackgroundWorker_DoWork);
            this.testCaseBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.testCaseBackgroundWorker_RunWorkerCompleted);
            // 
            // testSetBackgroundWorker
            // 
            this.testSetBackgroundWorker.WorkerReportsProgress = true;
            this.testSetBackgroundWorker.WorkerSupportsCancellation = true;
            this.testSetBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.testSetBackgroundWorker_DoWork);
            this.testSetBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.testSetBackgroundWorker_RunWorkerCompleted);
            // 
            // testSetLoader
            // 
            this.testSetLoader.WorkerReportsProgress = true;
            this.testSetLoader.WorkerSupportsCancellation = true;
            this.testSetLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.testSetLoader_DoWork);
            this.testSetLoader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.testSetLoader_ProgressChanged);
            this.testSetLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.testSetLoader_RunWorkerCompleted);
            // 
            // PolicyValidatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(863, 806);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(879, 844);
            this.Name = "PolicyValidatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Policy Validator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PolicyValidatorForm_FormClosing);
            this.Load += new System.EventHandler(this.PolicyValidatorForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.tableLayoutLeft.ResumeLayout(false);
            this.testCaseContextMenu.ResumeLayout(false);
            this.buttonLayout.ResumeLayout(false);
            this.innerButtonLayout.ResumeLayout(false);
            this.innerButtonLayout.PerformLayout();
            this.testCasePanel.ResumeLayout(false);
            this.testCaseTableLayout.ResumeLayout(false);
            this.toResourceTableLayout.ResumeLayout(false);
            this.toResourceDynamicAttributeTable.ResumeLayout(false);
            this.toResourceStaticAttributeTable.ResumeLayout(false);
            this.toResourceStaticAttributeTable.PerformLayout();
            this.resultHeaderTable.ResumeLayout(false);
            this.toResourceHeaderTable.ResumeLayout(false);
            this.subjectHeaderTableLayout.ResumeLayout(false);
            this.subjectTableLayout.ResumeLayout(false);
            this.subjectDynamicAttributeTable.ResumeLayout(false);
            this.subjectStaticAttributeTable.ResumeLayout(false);
            this.subjectStaticAttributeTable.PerformLayout();
            this.actionHeaderTableLayout.ResumeLayout(false);
            this.actionTableLayout.ResumeLayout(false);
            this.actionTableLayout.PerformLayout();
            this.fromResourceHeaderTable.ResumeLayout(false);
            this.fromResourceTableLayout.ResumeLayout(false);
            this.fromResourceDynamicAttributeTable.ResumeLayout(false);
            this.fromResourceStaticAttributeTable.ResumeLayout(false);
            this.fromResourceStaticAttributeTable.PerformLayout();
            this.formButtonsLayout.ResumeLayout(false);
            this.resultCopyContextMenu.ResumeLayout(false);
            this.resultButtonsLayout.ResumeLayout(false);
            this.documentPolicyHeaderLayout.ResumeLayout(false);
            this.documentPolicyHeaderLayout.PerformLayout();
            this.expectedResultHeaderLayout.ResumeLayout(false);
            this.expectedResultTableLayout.ResumeLayout(false);
            this.expectedResultTableLayout.PerformLayout();
            this.recipientsHeaderTableLayout.ResumeLayout(false);
            this.recipientsTableLayout.ResumeLayout(false);
            this.recipientsTableLayout.PerformLayout();
            this.emailDetailsHeaderTable.ResumeLayout(false);
            this.emailDetailsTableLayout.ResumeLayout(false);
            this.emailDetailsTableLayout.PerformLayout();
            this.testSetPanel.ResumeLayout(false);
            this.testSetTableLayout.ResumeLayout(false);
            this.testSetTableLayout.PerformLayout();
            this.testSetTablePanel.ResumeLayout(false);
            this.testSetTablePanel.PerformLayout();
            this.testSetResultButtonLayout.ResumeLayout(false);
            this.resultTablePanel.ResumeLayout(false);
            this.resultHeaderLayout.ResumeLayout(false);
            this.testSetButtonLayout.ResumeLayout(false);
            this.introPanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel23.ResumeLayout(false);
            this.tableLayoutPanel23.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion



        private System.Windows.Forms.MenuStrip menuStrip;

        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;

        private System.Windows.Forms.StatusStrip statusStrip;

        private System.Windows.Forms.SplitContainer splitContainer;

        private System.Windows.Forms.ToolStripSeparator configureMenuSeparator;

        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem loggingToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;

        private System.Windows.Forms.Button button3;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;

        private System.Windows.Forms.Label label15;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;

        private System.Windows.Forms.Button button4;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;

        private System.Windows.Forms.Label label16;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;

        private System.Windows.Forms.Label label18;

        private System.Windows.Forms.Label label19;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.ImageList imageList;

        private System.Windows.Forms.ContextMenuStrip testCaseContextMenu;

        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem actionAttributesToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem subjectAttributesToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem resourceAttributesToolStripMenuItem;

        private System.Windows.Forms.Panel leftPanel;

        private System.Windows.Forms.TableLayoutPanel tableLayoutLeft;

        private NativeTreeView treeView;

        private System.Windows.Forms.TableLayoutPanel buttonLayout;

        private System.Windows.Forms.TableLayoutPanel innerButtonLayout;

        private System.Windows.Forms.Label refreshButton;

        private System.Windows.Forms.Panel testCasePanel;

        private System.Windows.Forms.TableLayoutPanel testCaseTableLayout;

        private System.Windows.Forms.TableLayoutPanel resultHeaderTable;

        private System.Windows.Forms.TableLayoutPanel toResourceTableLayout;

        private System.Windows.Forms.TableLayoutPanel toResourceDynamicAttributeTable;

        private System.Windows.Forms.Button addToResourceAttribute;

        private System.Windows.Forms.TableLayoutPanel toResourceStaticAttributeTable;

        private System.Windows.Forms.Label toResourceNameLabel;

        private System.Windows.Forms.TableLayoutPanel toResourceHeaderTable;

        private System.Windows.Forms.Label toResourceHeaderLabel;

        private System.Windows.Forms.TableLayoutPanel subjectHeaderTableLayout;

        private System.Windows.Forms.Label subjectHeaderLabel;

        private System.Windows.Forms.TableLayoutPanel subjectTableLayout;

        private System.Windows.Forms.TableLayoutPanel subjectDynamicAttributeTable;

        private System.Windows.Forms.Button addSubjectAttribute;

        private System.Windows.Forms.TableLayoutPanel subjectStaticAttributeTable;

        private System.Windows.Forms.Label usernameLabel;

        private System.Windows.Forms.TableLayoutPanel actionHeaderTableLayout;

        private System.Windows.Forms.Label actionHeaderLabel;

        private System.Windows.Forms.Label underlineLabel4;

        private System.Windows.Forms.TableLayoutPanel actionTableLayout;

        private System.Windows.Forms.Label actionLabel;

        private System.Windows.Forms.TableLayoutPanel fromResourceTableLayout;

        private System.Windows.Forms.TableLayoutPanel fromResourceDynamicAttributeTable;

        private System.Windows.Forms.Button addFromResourceAttribute;

        private System.Windows.Forms.TableLayoutPanel fromResourceStaticAttributeTable;

        private System.Windows.Forms.Label fromResourceLabel;

        private System.Windows.Forms.TableLayoutPanel formButtonsLayout;

        private System.Windows.Forms.Button validateTestCaseButton;

        private System.Windows.Forms.Button clearTestCaseButton;

        private System.Windows.Forms.Button saveTestCaseButton;

        private System.Windows.Forms.RichTextBox resultRichTextField;

        private System.Windows.Forms.TableLayoutPanel resultButtonsLayout;

        private System.Windows.Forms.Button clearTestCaseResultButton;

        private System.Windows.Forms.Panel testSetPanel;

        private System.Windows.Forms.TableLayoutPanel testSetTableLayout;

        private System.Windows.Forms.Label testSetHeaderLabel;

        private System.Windows.Forms.TableLayoutPanel testSetTablePanel;

        private System.Windows.Forms.Label expectedResultLabel;

        private System.Windows.Forms.TableLayoutPanel testSetResultButtonLayout;

        private System.Windows.Forms.Button runTestSetButton;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel18;

        private System.Windows.Forms.Button btnRun;

        private System.Windows.Forms.TableLayoutPanel resultTablePanel;

        private System.Windows.Forms.RichTextBox ResultrichTextBox;

        private System.Windows.Forms.Label resultHeaderLabel;

        private System.Windows.Forms.Label underlineLabel10;

        private System.Windows.Forms.Panel introPanel;

        private System.Windows.Forms.RichTextBox introRichTextBox;

        private System.Windows.Forms.ToolStripStatusLabel statusIndicatorLabel;

        private System.Windows.Forms.ToolStripStatusLabel statusLabel;

        private System.Windows.Forms.ContextMenuStrip resultCopyContextMenu;

        private System.Windows.Forms.ToolStripMenuItem copyMenuItem;

        private System.Windows.Forms.Button exportTestSetResultButton;

        private System.Windows.Forms.Button exportTestCaseResultButton;

        private System.Windows.Forms.TableLayoutPanel testSetButtonLayout;

        private System.Windows.Forms.ToolStripStatusLabel statusBarSpacerLabel;

        private System.Windows.Forms.ToolStripStatusLabel statusConnectionLabel;

        private System.Windows.Forms.Label testCaseNameLabel;

        private System.Windows.Forms.ToolStripSeparator contextMenuSeparator;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel23;

        private System.Windows.Forms.Label label24;

        private System.Windows.Forms.Label label28;

        private System.Windows.Forms.Label actualResultLabel;

        private System.Windows.Forms.Label underlineLabel7;

        private System.Windows.Forms.Label underlineLabel8;

        private System.Windows.Forms.Label underlineLabel9;

        private System.Windows.Forms.TableLayoutPanel documentPolicyHeaderLayout;

        private System.Windows.Forms.Label documentPolicyHeaderLabel;

        private System.Windows.Forms.TableLayoutPanel expectedResultHeaderLayout;

        private System.Windows.Forms.Label expectedResultHeaderLabel;

        private System.Windows.Forms.TableLayoutPanel expectedResultTableLayout;

        private System.Windows.Forms.RadioButton denyRadioButton;

        private System.Windows.Forms.RadioButton allowRadioButton;

        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;

        private System.Windows.Forms.ToolStripSeparator fileMenuSeparator;

        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;

        private System.Windows.Forms.Label windowsSidLabel;

        private System.Windows.Forms.Label applicationNameLabel;

        private System.Windows.Forms.Label ipAddressLabel;

        private CueTextBox subjectUsernameTextbox;

        private CueTextBox textBox1;

        private CueTextBox textBox2;

        private CueTextBox toResourceNameTextbox;

        private CueTextBox fromResourceNameTextbox;

        private CueTextBox subjectSIDTextbox;

        private CueTextBox subjectApplicationName;

        private CueTextBox subjectIpAddress;

        private CueComboBox actionCombobox;

        private System.ComponentModel.BackgroundWorker connectionStatusBackgroundWorker;

        private System.ComponentModel.BackgroundWorker testCaseBackgroundWorker;

        private System.ComponentModel.BackgroundWorker testSetBackgroundWorker;

        private System.ComponentModel.BackgroundWorker testSetLoader;

        private System.Windows.Forms.Label showResultLabel;

        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem usernameToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.Button newTestCaseButton;
        private System.Windows.Forms.Button newTestSetButton;
        private System.Windows.Forms.TableLayoutPanel fromResourceHeaderTable;
        private System.Windows.Forms.Label underlineLabel5;
        private System.Windows.Forms.Label fromResourceHeaderLabel;
        private System.Windows.Forms.TableLayoutPanel recipientsHeaderTableLayout;
        private System.Windows.Forms.Label recipientsHeaderLabel;
        private System.Windows.Forms.TableLayoutPanel recipientsTableLayout;
        private System.Windows.Forms.Label emailAddressesLabel;
        private CueTextBox recipientsTextBox;
        private System.Windows.Forms.ToolStripMenuItem databaseSettingsToolStripMenuItem;
        private System.Windows.Forms.Label underlineLabelRecipients;
        private Label underlineLabelToResource;
        private Button clearTestSetResultButton;
        private TableLayoutPanel emailDetailsHeaderTable;
        private Label emailDetailsHeaderLabel;
        private Label underlineEmailDetailsLabel;
        private TableLayoutPanel emailDetailsTableLayout;
        private Label emailBodyLabel;
        private Label emailSubjectLabel;
        private TextBox emailSubjectTextBox;
        private RichTextBox emailBodyRichTextBox;
        private Label underlineResultLabel;
        internal TableLayoutPanel resultHeaderLayout;
        private Label testCaseTypeLabel;
        private Label testCaseActionLabel;
        private Label underlineLabel20;
        private Label underlineLabel21;
        private Label underlineLabel3;
        private Label underlineLabel6;

    }

}



