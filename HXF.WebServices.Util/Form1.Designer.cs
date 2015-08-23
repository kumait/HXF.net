namespace HXF.WebServices.Util
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.edtUrl = new System.Windows.Forms.ToolStripTextBox();
            this.btnAddService = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tbDesc = new System.Windows.Forms.TabPage();
            this.edtJson = new System.Windows.Forms.TextBox();
            this.tbProxy = new System.Windows.Forms.TabPage();
            this.edtCode = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstFiles = new System.Windows.Forms.ListView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tbDesc.SuspendLayout();
            this.tbProxy.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(724, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.edtUrl,
            this.btnAddService,
            this.toolStripSeparator1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(724, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Enabled = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(28, 22);
            this.toolStripLabel1.Text = "Url: ";
            // 
            // edtUrl
            // 
            this.edtUrl.Name = "edtUrl";
            this.edtUrl.Size = new System.Drawing.Size(350, 25);
            // 
            // btnAddService
            // 
            this.btnAddService.Image = ((System.Drawing.Image)(resources.GetObject("btnAddService.Image")));
            this.btnAddService.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(116, 22);
            this.btnAddService.Text = "Add Web Service";
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
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
            this.toolStripButton1.Size = new System.Drawing.Size(137, 22);
            this.toolStripButton1.Text = "Generate Proxy Code";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 561);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(724, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl);
            this.splitContainer1.Size = new System.Drawing.Size(724, 512);
            this.splitContainer1.SplitterDistance = 241;
            this.splitContainer1.TabIndex = 3;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList1;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(241, 512);
            this.treeView.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1398662122_web-management.png");
            this.imageList1.Images.SetKeyName(1, "1398662773_folder.png");
            this.imageList1.Images.SetKeyName(2, "1398662868_Web.png");
            this.imageList1.Images.SetKeyName(3, "1398662831_function.png");
            this.imageList1.Images.SetKeyName(4, "1398663403_document-attribute-p.png");
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tbDesc);
            this.tabControl.Controls.Add(this.tbProxy);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(479, 512);
            this.tabControl.TabIndex = 0;
            // 
            // tbDesc
            // 
            this.tbDesc.Controls.Add(this.edtJson);
            this.tbDesc.Location = new System.Drawing.Point(4, 22);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Padding = new System.Windows.Forms.Padding(3);
            this.tbDesc.Size = new System.Drawing.Size(471, 486);
            this.tbDesc.TabIndex = 0;
            this.tbDesc.Text = "Service Descriptor";
            this.tbDesc.UseVisualStyleBackColor = true;
            // 
            // edtJson
            // 
            this.edtJson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtJson.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtJson.Location = new System.Drawing.Point(3, 3);
            this.edtJson.Multiline = true;
            this.edtJson.Name = "edtJson";
            this.edtJson.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.edtJson.Size = new System.Drawing.Size(465, 480);
            this.edtJson.TabIndex = 1;
            this.edtJson.WordWrap = false;
            // 
            // tbProxy
            // 
            this.tbProxy.Controls.Add(this.edtCode);
            this.tbProxy.Controls.Add(this.panel1);
            this.tbProxy.Location = new System.Drawing.Point(4, 22);
            this.tbProxy.Name = "tbProxy";
            this.tbProxy.Padding = new System.Windows.Forms.Padding(3);
            this.tbProxy.Size = new System.Drawing.Size(471, 486);
            this.tbProxy.TabIndex = 1;
            this.tbProxy.Text = "Proxy Code";
            this.tbProxy.UseVisualStyleBackColor = true;
            // 
            // edtCode
            // 
            this.edtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtCode.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtCode.Location = new System.Drawing.Point(3, 58);
            this.edtCode.Multiline = true;
            this.edtCode.Name = "edtCode";
            this.edtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.edtCode.Size = new System.Drawing.Size(465, 425);
            this.edtCode.TabIndex = 1;
            this.edtCode.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lstFiles);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 55);
            this.panel1.TabIndex = 0;
            // 
            // lstFiles
            // 
            this.lstFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFiles.Location = new System.Drawing.Point(0, 0);
            this.lstFiles.MultiSelect = false;
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(465, 55);
            this.lstFiles.SmallImageList = this.imageList2;
            this.lstFiles.TabIndex = 0;
            this.lstFiles.UseCompatibleStateImageBehavior = false;
            this.lstFiles.View = System.Windows.Forms.View.Tile;
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "1398690756_text-x-generic.png");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 583);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "HXF Web Service Explorer";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tbDesc.ResumeLayout(false);
            this.tbDesc.PerformLayout();
            this.tbProxy.ResumeLayout(false);
            this.tbProxy.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tbDesc;
        private System.Windows.Forms.TextBox edtJson;
        private System.Windows.Forms.TabPage tbProxy;
        private System.Windows.Forms.ToolStripTextBox edtUrl;
        private System.Windows.Forms.ToolStripButton btnAddService;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lstFiles;
        private System.Windows.Forms.TextBox edtCode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ImageList imageList2;
    }
}

