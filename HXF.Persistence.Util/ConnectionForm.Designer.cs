namespace HXF.Persistence.Util
{
    partial class ConnectionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDBType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.edtUser = new System.Windows.Forms.TextBox();
            this.edtPassword = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.edtDatabase = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.edtSchema = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database Type";
            // 
            // cmbDBType
            // 
            this.cmbDBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDBType.FormattingEnabled = true;
            this.cmbDBType.Items.AddRange(new object[] {
            "SQL Server",
            "My SQL"});
            this.cmbDBType.Location = new System.Drawing.Point(134, 9);
            this.cmbDBType.Name = "cmbDBType";
            this.cmbDBType.Size = new System.Drawing.Size(174, 21);
            this.cmbDBType.TabIndex = 1;
            this.cmbDBType.SelectedIndexChanged += new System.EventHandler(this.cmbDBType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "User";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Catalog (Database)";
            // 
            // cmbServer
            // 
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(134, 39);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(174, 21);
            this.cmbServer.TabIndex = 6;
            this.cmbServer.Text = "alkumait.net";
            // 
            // edtUser
            // 
            this.edtUser.Location = new System.Drawing.Point(134, 71);
            this.edtUser.Name = "edtUser";
            this.edtUser.Size = new System.Drawing.Size(174, 20);
            this.edtUser.TabIndex = 7;
            this.edtUser.Text = "hxf";
            // 
            // edtPassword
            // 
            this.edtPassword.Location = new System.Drawing.Point(134, 101);
            this.edtPassword.Name = "edtPassword";
            this.edtPassword.Size = new System.Drawing.Size(174, 20);
            this.edtPassword.TabIndex = 8;
            this.edtPassword.Text = "12345";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(12, 196);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(121, 23);
            this.btnTest.TabIndex = 10;
            this.btnTest.Text = "Test Connection";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(151, 196);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(233, 196);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // edtDatabase
            // 
            this.edtDatabase.Location = new System.Drawing.Point(134, 130);
            this.edtDatabase.Name = "edtDatabase";
            this.edtDatabase.Size = new System.Drawing.Size(174, 20);
            this.edtDatabase.TabIndex = 13;
            this.edtDatabase.Text = "HXF_TEST";
            this.edtDatabase.TextChanged += new System.EventHandler(this.edtDatabase_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(73, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Schema";
            // 
            // edtSchema
            // 
            this.edtSchema.Location = new System.Drawing.Point(134, 159);
            this.edtSchema.Name = "edtSchema";
            this.edtSchema.Size = new System.Drawing.Size(174, 20);
            this.edtSchema.TabIndex = 15;
            this.edtSchema.Text = "dbo";
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 225);
            this.Controls.Add(this.edtSchema);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.edtDatabase);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.edtPassword);
            this.Controls.Add(this.edtUser);
            this.Controls.Add(this.cmbServer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDBType);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDBType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.TextBox edtUser;
        private System.Windows.Forms.TextBox edtPassword;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox edtDatabase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edtSchema;
    }
}