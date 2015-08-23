namespace HXF.Persistence.Util
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnGenerateDAL = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tbDescriptor = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbSql = new System.Windows.Forms.TabPage();
            this.edtSql = new System.Windows.Forms.TextBox();
            this.tbDAL = new System.Windows.Forms.TabPage();
            this.tbEntities = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.edtInterface = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.edtClass = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.edtEntities = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tbDescriptor.SuspendLayout();
            this.tbSql.SuspendLayout();
            this.tbDAL.SuspendLayout();
            this.tbEntities.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(772, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(100, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(107, 22);
            this.mnuAbout.Text = "About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConnect,
            this.btnOpen,
            this.btnSave,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.btnGenerateDAL});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(772, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnConnect
            // 
            this.btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.Image")));
            this.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(72, 22);
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(56, 22);
            this.btnOpen.Text = "Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(51, 22);
            this.btnSave.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(98, 22);
            this.toolStripButton1.Text = "Generate SQL";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnGenerateDAL
            // 
            this.btnGenerateDAL.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerateDAL.Image")));
            this.btnGenerateDAL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGenerateDAL.Name = "btnGenerateDAL";
            this.btnGenerateDAL.Size = new System.Drawing.Size(99, 22);
            this.btnGenerateDAL.Text = "Generate DAL";
            this.btnGenerateDAL.Click += new System.EventHandler(this.btnGenerateDAL_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 543);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(772, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "database.png");
            this.imageList1.Images.SetKeyName(1, "folder.png");
            this.imageList1.Images.SetKeyName(2, "table.png");
            this.imageList1.Images.SetKeyName(3, "column.png");
            this.imageList1.Images.SetKeyName(4, "constraint.png");
            this.imageList1.Images.SetKeyName(5, "sp.png");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(772, 494);
            this.panel2.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl);
            this.splitContainer1.Size = new System.Drawing.Size(772, 494);
            this.splitContainer1.SplitterDistance = 257;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList1;
            this.treeView.ItemHeight = 18;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(257, 494);
            this.treeView.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tbDescriptor);
            this.tabControl.Controls.Add(this.tbSql);
            this.tabControl.Controls.Add(this.tbDAL);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(511, 494);
            this.tabControl.TabIndex = 0;
            // 
            // tbDescriptor
            // 
            this.tbDescriptor.Controls.Add(this.textBox1);
            this.tbDescriptor.Location = new System.Drawing.Point(4, 22);
            this.tbDescriptor.Name = "tbDescriptor";
            this.tbDescriptor.Padding = new System.Windows.Forms.Padding(3);
            this.tbDescriptor.Size = new System.Drawing.Size(503, 468);
            this.tbDescriptor.TabIndex = 0;
            this.tbDescriptor.Text = "Schema Descriptor";
            this.tbDescriptor.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(497, 462);
            this.textBox1.TabIndex = 0;
            this.textBox1.WordWrap = false;
            // 
            // tbSql
            // 
            this.tbSql.Controls.Add(this.edtSql);
            this.tbSql.Location = new System.Drawing.Point(4, 22);
            this.tbSql.Name = "tbSql";
            this.tbSql.Padding = new System.Windows.Forms.Padding(3);
            this.tbSql.Size = new System.Drawing.Size(503, 468);
            this.tbSql.TabIndex = 1;
            this.tbSql.Text = "SQL";
            this.tbSql.UseVisualStyleBackColor = true;
            // 
            // edtSql
            // 
            this.edtSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtSql.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtSql.Location = new System.Drawing.Point(3, 3);
            this.edtSql.Multiline = true;
            this.edtSql.Name = "edtSql";
            this.edtSql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.edtSql.Size = new System.Drawing.Size(497, 462);
            this.edtSql.TabIndex = 0;
            this.edtSql.WordWrap = false;
            // 
            // tbDAL
            // 
            this.tbDAL.Controls.Add(this.tbEntities);
            this.tbDAL.Location = new System.Drawing.Point(4, 22);
            this.tbDAL.Name = "tbDAL";
            this.tbDAL.Padding = new System.Windows.Forms.Padding(3);
            this.tbDAL.Size = new System.Drawing.Size(503, 468);
            this.tbDAL.TabIndex = 2;
            this.tbDAL.Text = "DAL";
            this.tbDAL.UseVisualStyleBackColor = true;
            // 
            // tbEntities
            // 
            this.tbEntities.Controls.Add(this.tabPage1);
            this.tbEntities.Controls.Add(this.tabPage2);
            this.tbEntities.Controls.Add(this.tabPage3);
            this.tbEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEntities.Location = new System.Drawing.Point(3, 3);
            this.tbEntities.Name = "tbEntities";
            this.tbEntities.SelectedIndex = 0;
            this.tbEntities.Size = new System.Drawing.Size(497, 462);
            this.tbEntities.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.edtInterface);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(489, 436);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Interface";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // edtInterface
            // 
            this.edtInterface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtInterface.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtInterface.Location = new System.Drawing.Point(3, 3);
            this.edtInterface.Multiline = true;
            this.edtInterface.Name = "edtInterface";
            this.edtInterface.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.edtInterface.Size = new System.Drawing.Size(483, 430);
            this.edtInterface.TabIndex = 0;
            this.edtInterface.WordWrap = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.edtClass);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(489, 436);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Class";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // edtClass
            // 
            this.edtClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtClass.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtClass.Location = new System.Drawing.Point(3, 3);
            this.edtClass.Multiline = true;
            this.edtClass.Name = "edtClass";
            this.edtClass.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.edtClass.Size = new System.Drawing.Size(483, 430);
            this.edtClass.TabIndex = 0;
            this.edtClass.WordWrap = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.edtEntities);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(489, 436);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Entity Classes";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // edtEntities
            // 
            this.edtEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtEntities.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtEntities.Location = new System.Drawing.Point(3, 3);
            this.edtEntities.Multiline = true;
            this.edtEntities.Name = "edtEntities";
            this.edtEntities.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.edtEntities.Size = new System.Drawing.Size(483, 430);
            this.edtEntities.TabIndex = 0;
            this.edtEntities.WordWrap = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 565);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "HXF Schema Explorer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tbDescriptor.ResumeLayout(false);
            this.tbDescriptor.PerformLayout();
            this.tbSql.ResumeLayout(false);
            this.tbSql.PerformLayout();
            this.tbDAL.ResumeLayout(false);
            this.tbEntities.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton btnConnect;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tbDescriptor;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabPage tbSql;
        private System.Windows.Forms.TextBox edtSql;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btnGenerateDAL;
        private System.Windows.Forms.TabPage tbDAL;
        private System.Windows.Forms.TabControl tbEntities;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox edtInterface;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox edtClass;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox edtEntities;
    }
}