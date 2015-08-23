using HXF.Persistence.Descriptors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HXF.Persistence.Util
{
    public partial class ConnectionForm : Form
    {
        private ConnectionInfo conInfo;
        private ConnectionType[] conTypes = { ConnectionType.SqlServer, ConnectionType.MySql };

        public ConnectionForm()
        {
            InitializeComponent();
            cmbDBType.SelectedIndex = 0;
        }

        public ConnectionInfo ConnectionInfo
        {
            get { return conInfo; }
        }

        private void TestConnection()
        {
            readUI();
            Exception ex = null;
            bool succ = ConnectionTester.TestConnection(conInfo, out ex);
            if (succ)
            {
                MessageBox.Show("Connection Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string msg = "Connection Failed. \n\n" + ex.Message;
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void readUI()
        {
            conInfo.Type = conTypes[cmbDBType.SelectedIndex];
            conInfo.Server = cmbServer.Text;
            conInfo.User = edtUser.Text;
            conInfo.Password = edtPassword.Text;
            conInfo.Catalog = edtDatabase.Text;
            conInfo.Schema = edtSchema.Text;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            TestConnection();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            readUI();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmbDBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            edtSchema.Enabled = cmbDBType.SelectedIndex == 0;
            if (cmbDBType.SelectedIndex != 0)
            {
                edtSchema.Text = edtDatabase.Text;
            }
        }

        private void edtDatabase_TextChanged(object sender, EventArgs e)
        {
            if (cmbDBType.SelectedIndex != 0)
            {
                edtSchema.Text = edtDatabase.Text;
            }
        }
    }
}
