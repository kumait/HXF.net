namespace HXF.Util
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigurationAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.updToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateDALToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUpdateProxy = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMinimizeToSysTray = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUpdateAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUpdateDatabase = new System.Windows.Forms.ToolStripButton();
            this.btnUpdateDAL = new System.Windows.Forms.ToolStripButton();
            this.btnGenerateProxy = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.edtCN = new System.Windows.Forms.TextBox();
            this.btnSelectDatabase = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.edtDALPath = new System.Windows.Forms.TextBox();
            this.btnSelectDALFolder = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuUpdateAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUpdateDB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUpdateDAL = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.chkUseCSNaming = new System.Windows.Forms.CheckBox();
            this.edtSchema = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSelectProxyLocation = new System.Windows.Forms.Button();
            this.edtProxyLocation = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edtServiceUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.operationsToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(626, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openConfigurationToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveConfigurationAsToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openConfigurationToolStripMenuItem
            // 
            this.openConfigurationToolStripMenuItem.Image = global::HXF.Util.Properties.Resources.NewDocument;
            this.openConfigurationToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.openConfigurationToolStripMenuItem.Name = "openConfigurationToolStripMenuItem";
            this.openConfigurationToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openConfigurationToolStripMenuItem.Text = "&New";
            this.openConfigurationToolStripMenuItem.Click += new System.EventHandler(this.openConfigurationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::HXF.Util.Properties.Resources.OpenFolder;
            this.toolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.toolStripMenuItem1.Text = "&Open";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // saveConfigurationAsToolStripMenuItem
            // 
            this.saveConfigurationAsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.saveConfigurationAsToolStripMenuItem.Name = "saveConfigurationAsToolStripMenuItem";
            this.saveConfigurationAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveConfigurationAsToolStripMenuItem.Text = "Save &As";
            this.saveConfigurationAsToolStripMenuItem.Click += new System.EventHandler(this.saveConfigurationAsToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::HXF.Util.Properties.Resources.Save;
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(111, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateAllToolStripMenuItem,
            this.toolStripSeparator3,
            this.updToolStripMenuItem,
            this.updateDALToolStripMenuItem,
            this.mnuUpdateProxy});
            this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            this.operationsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.operationsToolStripMenuItem.Text = "Operations";
            // 
            // updateAllToolStripMenuItem
            // 
            this.updateAllToolStripMenuItem.Image = global::HXF.Util.Properties.Resources.update;
            this.updateAllToolStripMenuItem.Name = "updateAllToolStripMenuItem";
            this.updateAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.updateAllToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.updateAllToolStripMenuItem.Text = "Update All";
            this.updateAllToolStripMenuItem.Click += new System.EventHandler(this.btnUpdateAll_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(206, 6);
            // 
            // updToolStripMenuItem
            // 
            this.updToolStripMenuItem.Image = global::HXF.Util.Properties.Resources.db2;
            this.updToolStripMenuItem.Name = "updToolStripMenuItem";
            this.updToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F2)));
            this.updToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.updToolStripMenuItem.Text = "Update Database";
            this.updToolStripMenuItem.Click += new System.EventHandler(this.btnUpdateDatabase_Click);
            // 
            // updateDALToolStripMenuItem
            // 
            this.updateDALToolStripMenuItem.Image = global::HXF.Util.Properties.Resources.dal;
            this.updateDALToolStripMenuItem.Name = "updateDALToolStripMenuItem";
            this.updateDALToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3)));
            this.updateDALToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.updateDALToolStripMenuItem.Text = "Update DAL";
            this.updateDALToolStripMenuItem.Click += new System.EventHandler(this.btnUpdateDatabase_Click);
            // 
            // mnuUpdateProxy
            // 
            this.mnuUpdateProxy.Image = global::HXF.Util.Properties.Resources._1410958437_Earth;
            this.mnuUpdateProxy.Name = "mnuUpdateProxy";
            this.mnuUpdateProxy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
            this.mnuUpdateProxy.Size = new System.Drawing.Size(209, 22);
            this.mnuUpdateProxy.Text = "Update Proxy";
            this.mnuUpdateProxy.Click += new System.EventHandler(this.mnuUpdateProxy_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMinimizeToSysTray});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // mnuMinimizeToSysTray
            // 
            this.mnuMinimizeToSysTray.Checked = true;
            this.mnuMinimizeToSysTray.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuMinimizeToSysTray.Name = "mnuMinimizeToSysTray";
            this.mnuMinimizeToSysTray.Size = new System.Drawing.Size(205, 22);
            this.mnuMinimizeToSysTray.Text = "Minimize to Syatem Tray";
            this.mnuMinimizeToSysTray.Click += new System.EventHandler(this.mnuMinimizeToSysTray_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 329);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(626, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.toolStripSeparator1,
            this.btnUpdateAll,
            this.toolStripSeparator2,
            this.btnUpdateDatabase,
            this.btnUpdateDAL,
            this.btnGenerateProxy});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(626, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = global::HXF.Util.Properties.Resources.NewDocument;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(23, 22);
            this.btnNew.Text = "toolStripButton1";
            this.btnNew.ToolTipText = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = global::HXF.Util.Properties.Resources.OpenFolder;
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(23, 22);
            this.btnOpen.Text = "toolStripButton2";
            this.btnOpen.ToolTipText = "Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::HXF.Util.Properties.Resources.Save;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "toolStripButton4";
            this.btnSave.ToolTipText = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnUpdateAll
            // 
            this.btnUpdateAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateAll.Image = global::HXF.Util.Properties.Resources.update;
            this.btnUpdateAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateAll.Name = "btnUpdateAll";
            this.btnUpdateAll.Size = new System.Drawing.Size(23, 22);
            this.btnUpdateAll.Text = "toolStripButton1";
            this.btnUpdateAll.ToolTipText = "Update All";
            this.btnUpdateAll.Click += new System.EventHandler(this.btnUpdateAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnUpdateDatabase
            // 
            this.btnUpdateDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateDatabase.Image = global::HXF.Util.Properties.Resources.db2;
            this.btnUpdateDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateDatabase.Name = "btnUpdateDatabase";
            this.btnUpdateDatabase.Size = new System.Drawing.Size(23, 22);
            this.btnUpdateDatabase.Text = "toolStripButton2";
            this.btnUpdateDatabase.ToolTipText = "Update Database";
            this.btnUpdateDatabase.Click += new System.EventHandler(this.btnUpdateDatabase_Click);
            // 
            // btnUpdateDAL
            // 
            this.btnUpdateDAL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUpdateDAL.Image = global::HXF.Util.Properties.Resources.dal;
            this.btnUpdateDAL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateDAL.Name = "btnUpdateDAL";
            this.btnUpdateDAL.Size = new System.Drawing.Size(23, 22);
            this.btnUpdateDAL.Text = "toolStripButton3";
            this.btnUpdateDAL.ToolTipText = "Update DAL";
            this.btnUpdateDAL.Click += new System.EventHandler(this.btnUpdateDAL_Click);
            // 
            // btnGenerateProxy
            // 
            this.btnGenerateProxy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGenerateProxy.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerateProxy.Image")));
            this.btnGenerateProxy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGenerateProxy.Name = "btnGenerateProxy";
            this.btnGenerateProxy.Size = new System.Drawing.Size(23, 22);
            this.btnGenerateProxy.Text = "toolStripButton1";
            this.btnGenerateProxy.ToolTipText = "Update Proxy";
            this.btnGenerateProxy.Click += new System.EventHandler(this.btnGenerateProxy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Database:";
            // 
            // edtCN
            // 
            this.edtCN.Location = new System.Drawing.Point(101, 22);
            this.edtCN.Name = "edtCN";
            this.edtCN.Size = new System.Drawing.Size(438, 23);
            this.edtCN.TabIndex = 12;
            // 
            // btnSelectDatabase
            // 
            this.btnSelectDatabase.Location = new System.Drawing.Point(545, 21);
            this.btnSelectDatabase.Name = "btnSelectDatabase";
            this.btnSelectDatabase.Size = new System.Drawing.Size(37, 27);
            this.btnSelectDatabase.TabIndex = 13;
            this.btnSelectDatabase.Text = "...";
            this.btnSelectDatabase.UseVisualStyleBackColor = true;
            this.btnSelectDatabase.Click += new System.EventHandler(this.btnSelectDatabase_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "DAL Location:";
            // 
            // edtDALPath
            // 
            this.edtDALPath.Location = new System.Drawing.Point(101, 81);
            this.edtDALPath.Name = "edtDALPath";
            this.edtDALPath.Size = new System.Drawing.Size(438, 23);
            this.edtDALPath.TabIndex = 15;
            // 
            // btnSelectDALFolder
            // 
            this.btnSelectDALFolder.Location = new System.Drawing.Point(545, 78);
            this.btnSelectDALFolder.Name = "btnSelectDALFolder";
            this.btnSelectDALFolder.Size = new System.Drawing.Size(37, 27);
            this.btnSelectDALFolder.TabIndex = 16;
            this.btnSelectDALFolder.Text = "...";
            this.btnSelectDALFolder.UseVisualStyleBackColor = true;
            this.btnSelectDALFolder.Click += new System.EventHandler(this.btnSelectDALFolder_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "asdad";
            this.notifyIcon.BalloonTipTitle = "dasdasd";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "FDAL 1.1";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUpdateAll,
            this.mnuUpdateDB,
            this.mnuUpdateDAL,
            this.toolStripMenuItem4,
            this.mnuShow,
            this.toolStripMenuItem3,
            this.mnuExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(164, 164);
            // 
            // mnuUpdateAll
            // 
            this.mnuUpdateAll.Name = "mnuUpdateAll";
            this.mnuUpdateAll.Size = new System.Drawing.Size(163, 22);
            this.mnuUpdateAll.Text = "Update All";
            this.mnuUpdateAll.Click += new System.EventHandler(this.mnuUpdateAll_Click);
            // 
            // mnuUpdateDB
            // 
            this.mnuUpdateDB.Name = "mnuUpdateDB";
            this.mnuUpdateDB.Size = new System.Drawing.Size(163, 22);
            this.mnuUpdateDB.Text = "Update Database";
            this.mnuUpdateDB.Click += new System.EventHandler(this.mnuUpdateDB_Click);
            // 
            // mnuUpdateDAL
            // 
            this.mnuUpdateDAL.Name = "mnuUpdateDAL";
            this.mnuUpdateDAL.Size = new System.Drawing.Size(163, 22);
            this.mnuUpdateDAL.Text = "Update DAL";
            this.mnuUpdateDAL.Click += new System.EventHandler(this.mnuUpdateDAL_Click);
            // 
            // mnuShow
            // 
            this.mnuShow.Name = "mnuShow";
            this.mnuShow.Size = new System.Drawing.Size(163, 22);
            this.mnuShow.Text = "Show";
            this.mnuShow.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(160, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(163, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // chkUseCSNaming
            // 
            this.chkUseCSNaming.AutoSize = true;
            this.chkUseCSNaming.Location = new System.Drawing.Point(101, 110);
            this.chkUseCSNaming.Name = "chkUseCSNaming";
            this.chkUseCSNaming.Size = new System.Drawing.Size(188, 19);
            this.chkUseCSNaming.TabIndex = 18;
            this.chkUseCSNaming.Text = "Apply C# Naming Conventions";
            this.chkUseCSNaming.UseVisualStyleBackColor = true;
            // 
            // edtSchema
            // 
            this.edtSchema.Location = new System.Drawing.Point(101, 52);
            this.edtSchema.Name = "edtSchema";
            this.edtSchema.Size = new System.Drawing.Size(196, 23);
            this.edtSchema.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "Schema:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edtDALPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.edtSchema);
            this.groupBox1.Controls.Add(this.edtCN);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSelectDatabase);
            this.groupBox1.Controls.Add(this.chkUseCSNaming);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSelectDALFolder);
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 143);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Access";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSelectProxyLocation);
            this.groupBox2.Controls.Add(this.edtProxyLocation);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cmbLanguage);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.edtServiceUrl);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(602, 118);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Web Service";
            // 
            // btnSelectProxyLocation
            // 
            this.btnSelectProxyLocation.Location = new System.Drawing.Point(545, 78);
            this.btnSelectProxyLocation.Name = "btnSelectProxyLocation";
            this.btnSelectProxyLocation.Size = new System.Drawing.Size(37, 27);
            this.btnSelectProxyLocation.TabIndex = 17;
            this.btnSelectProxyLocation.Text = "...";
            this.btnSelectProxyLocation.UseVisualStyleBackColor = true;
            this.btnSelectProxyLocation.Click += new System.EventHandler(this.btnSelectProxyLocation_Click);
            // 
            // edtProxyLocation
            // 
            this.edtProxyLocation.Location = new System.Drawing.Point(101, 81);
            this.edtProxyLocation.Name = "edtProxyLocation";
            this.edtProxyLocation.Size = new System.Drawing.Size(438, 23);
            this.edtProxyLocation.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Proxy Location:";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(101, 51);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(196, 23);
            this.cmbLanguage.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Language:";
            // 
            // edtServiceUrl
            // 
            this.edtServiceUrl.Location = new System.Drawing.Point(101, 22);
            this.edtServiceUrl.Name = "edtServiceUrl";
            this.edtServiceUrl.Size = new System.Drawing.Size(481, 23);
            this.edtServiceUrl.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Service URL:";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItem4.Text = "Update Proxy";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 351);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HXF Util 1.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveConfigurationAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox edtCN;
        private System.Windows.Forms.Button btnSelectDatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edtDALPath;
        private System.Windows.Forms.Button btnSelectDALFolder;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuUpdateAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuShow;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuUpdateDAL;
        private System.Windows.Forms.ToolStripMenuItem mnuUpdateDB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnUpdateAll;
        private System.Windows.Forms.ToolStripButton btnUpdateDatabase;
        private System.Windows.Forms.ToolStripButton btnUpdateDAL;
        private System.Windows.Forms.ToolStripMenuItem operationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateDALToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkUseCSNaming;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuMinimizeToSysTray;
        private System.Windows.Forms.TextBox edtSchema;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox edtServiceUrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnGenerateProxy;
        private System.Windows.Forms.TextBox edtProxyLocation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem mnuUpdateProxy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Button btnSelectProxyLocation;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
    }
}

