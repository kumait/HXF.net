using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using HXF.Persistence;
using HXF.Persistence.Descriptors;
using HXF.Persistence.Conf;

namespace HXF.Util
{
    public partial class FrmConnection : Form
    {
        private ConnectionInfo connectionInfo;
        
        
        public FrmConnection()
        {
            InitializeComponent();
        }

        private void testConnection()
        {
            Exception err = null;
            bool succ = ConnectionTester.TestConnection(getConInfo(), out err);
            if (succ)
            {
                MessageBox.Show("Connection Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(err.Message, "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

   
        private ConnectionInfo getConInfo()
        {
            ConnectionInfo ci = new ConnectionInfo();
            ci.User = cmbAuth.SelectedIndex == 1 ? cmbUser.Text : null;
            ci.Password = cmbAuth.SelectedIndex == 1 ? edtPassword.Text : null;
            ci.Server = cmbServer.Text;
            ci.Catalog = cmbDatabase.Text;
            ci.Schema = edtSchema.Text;
            return ci;            
        }

        private void cmbAuth_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool en = cmbAuth.SelectedIndex == 1;
            cmbUser.Enabled = en;
            edtPassword.Enabled = en;
            lblUser.Enabled = en;
            lblPassword.Enabled = en;
        }

        public ConnectionInfo ConnectionInfo
        {
            get
            {
                return connectionInfo;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            testConnection();
        }

        private void FrmConnection_Load(object sender, EventArgs e)
        {
            cmbAuth.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Exception err = null;
            bool succ = ConnectionTester.TestConnection(getConInfo(), out err);
            if (!succ)
            {
                MessageBox.Show(err.Message, "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.connectionInfo = getConInfo();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmbDatabase_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbDatabase.DataSource = null;
                SqlServerConnectionFactory fac = new SqlServerConnectionFactory();
                using (IDbConnection conn = fac.CreateConnection(getConInfo()))
                {
                    IDatabaseExplorer exp = new DatabaseExplorer(conn, new SQLServerDefaultConf());
                    conn.Open();
                    List<Catalog> catalogs = exp.GetCatalogs().ToList<Catalog>();
                    cmbDatabase.DataSource = catalogs;
                    cmbDatabase.DisplayMember = "Name";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
