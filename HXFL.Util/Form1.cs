using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Microsoft.SqlServer.Management.Common;
using System.Reflection;
using Newtonsoft.Json.Linq;
using HXF.Persistence;
using HXF.Persistence.Conf;
using HXF.Persistence.Naming;
using HXF.Persistence.Descriptors;
using HXF.Persistence.Generators.DataAccess;
using HXF.Persistence.Generators;
using HXF.Persistence.Generators.Sql;
using HXF.Util.Operations;

namespace HXF.Util
{
    public partial class Form1 : Form
    {
        private string openedConfPath;
        private JObject settings;
        private const string BASE_TITLE = "HXF Util 1.2";
        private WebServicesViewController webServicesController = new WebServicesViewController();
        
       
        public Form1()
        {
            InitializeComponent();
        }

        private void loadSettings()
        {
            settings = SettingsMan.Load();
            if (settings == null)
            {
                settings = new JObject();
            }

            JToken token = null;
            if (settings.TryGetValue("last_conf", out token))
            {
                string lastConf = token.Value<string>();
                if (!string.IsNullOrEmpty(lastConf))
                {
                    openConf(lastConf);
                }
            }

            if (settings.TryGetValue("min_to_tray", out token))
            {
                mnuMinimizeToSysTray.Checked = token.Value<bool>();
            }
        }

        private void updateDatabase()
        {
            if (edtCN.Text.Trim().Length == 0)
            {
                MessageBox.Show("No database is selected", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (edtSchema.Text.Trim().Length == 0)
            {
                MessageBox.Show("No schema is selected", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<IOperation> operations = new List<IOperation>();
            operations.Add(new ConnectOperation(edtCN.Text));
            operations.Add(new BuildSchemaOperation(edtSchema.Text));
            operations.Add(new UpdateDatabaseOperation(edtSchema.Name));

            FrmExecute frmExecute = new FrmExecute(operations);
            frmExecute.ShowDialog(this);
        }

        private void saveToFile(string file, string content)
        {
            FileStream fs = new FileStream(file, FileMode.Create);
            StreamWriter writer = new StreamWriter(fs);
            writer.Write(content);
            writer.Flush();
            writer.Close();
        }

        private void updateDalFiles()
        {
            if (edtCN.Text.Trim().Length == 0)
            {
                MessageBox.Show("No database is selected", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (edtDALPath.Text.Trim().Length == 0)
            {
                MessageBox.Show("No folder for DAL files is selected", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (edtSchema.Text.Trim().Length == 0)
            {
                MessageBox.Show("No schema is selected", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<IOperation> operations = new List<IOperation>();
            operations.Add(new ConnectOperation(edtCN.Text));
            operations.Add(new BuildSchemaOperation(edtSchema.Text));
            operations.Add(new UpdateDalOperation(edtDALPath.Text, chkUseCSNaming.Checked));

            FrmExecute frmExecute = new FrmExecute(operations);
            frmExecute.ShowDialog(this);
        }

        private void saveConf(bool saveAs)
        {
            string path = openedConfPath;

            if (saveAs || openedConfPath == null)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Conf Files (*.*) | *.conf";
                dlg.DefaultExt = "conf";
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                path = dlg.FileName;
            }

            try
            {
                Conf conf = loadConfFromUI();
                ConfMan.Save(conf, path);
                openedConfPath = path;
                this.Text = string.Format("{0} - {1}", Path.GetFileNameWithoutExtension(openedConfPath), BASE_TITLE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Conf loadConfFromUI()
        {
            Conf conf = new Conf();
            conf.ConnectionString = edtCN.Text;
            conf.DALPath = edtDALPath.Text;
            conf.Schema = edtSchema.Text;
            conf.UseCSNaming = chkUseCSNaming.Checked;
            conf.ServiceUrl = edtServiceUrl.Text;
            conf.ProxyLocation = edtProxyLocation.Text;            
            conf.Platform =  cmbLanguage.SelectedItem == null? null: ((PlatformInfo)cmbLanguage.SelectedItem).Id;
            return conf;
        }

        private void openConf(string path)
        {
            if (path == null)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Conf Files (*.*) | *.conf";
                dlg.DefaultExt = "conf";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    path = dlg.FileName;
                }
            }

            Conf conf = ConfMan.Load(path);
            edtCN.Text = conf.ConnectionString;
            edtDALPath.Text = conf.DALPath;
            edtSchema.Text = conf.Schema;
            chkUseCSNaming.Checked = conf.UseCSNaming;

            edtServiceUrl.Text = conf.ServiceUrl;
            edtProxyLocation.Text = conf.ProxyLocation;

            
            List<PlatformInfo> ds = (List<PlatformInfo>)cmbLanguage.DataSource;
            PlatformInfo platform = ds.Where<PlatformInfo>(p => p.Id == conf.Platform).FirstOrDefault<PlatformInfo>();
            cmbLanguage.SelectedItem = platform;

            
            openedConfPath = path;
            this.Text = string.Format("{0} - {1}", Path.GetFileNameWithoutExtension(openedConfPath), BASE_TITLE);
            
        }

        private void btnUpdateDAL_Click(object sender, EventArgs e)
        {
            updateDalFiles();
        }

        private void btnUpdateDatabase_Click(object sender, EventArgs e)
        {
            updateDalFiles();
        }

        private void btnUpdateAll_Click(object sender, EventArgs e)
        {
            updateAll();
        }

        private void updateProxy()
        {
            if (edtServiceUrl.Text.Trim().Length == 0)
            {
                MessageBox.Show("No service is selected", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (edtProxyLocation.Text.Trim().Length == 0)
            {
                MessageBox.Show("No location for generated proxy code is selected", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<IOperation> operations = new List<IOperation>();
            PlatformInfo platform = cmbLanguage.SelectedItem as PlatformInfo;
            operations.Add(new UpdateProxyOperation(edtServiceUrl.Text, platform.Id, edtProxyLocation.Text));
            FrmExecute frmExecute = new FrmExecute(operations);
            frmExecute.ShowDialog(this);
        }

        private void updateAll()
        {
            List<IOperation> operations = new List<IOperation>();

            if (edtCN.Text.Trim().Length > 0)
            {
                if (edtDALPath.Text.Trim().Length == 0)
                {
                    MessageBox.Show("No folder for DAL files is selected", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (edtSchema.Text.Trim().Length == 0)
                {
                    MessageBox.Show("No schema is selected", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                operations.Add(new ConnectOperation(edtCN.Text));
                operations.Add(new BuildSchemaOperation(edtSchema.Text));
                operations.Add(new UpdateDatabaseOperation(edtSchema.Name));
                operations.Add(new UpdateDalOperation(edtDALPath.Text, chkUseCSNaming.Checked));
            }

            if (edtServiceUrl.Text.Trim().Length > 0)
            {
                if (edtDALPath.Text.Trim().Length == 0)
                {
                    MessageBox.Show("No location for generated proxy code is selected", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbLanguage.SelectedItem == null)
                {
                    MessageBox.Show("No language is selected", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PlatformInfo platform = cmbLanguage.SelectedItem as PlatformInfo;
                operations.Add(new UpdateProxyOperation(edtServiceUrl.Text, platform.Id, edtDALPath.Text));
            }

            if (operations.Count > 0)
            {
                FrmExecute frmExecute = new FrmExecute(operations);
                frmExecute.ShowDialog(this);
            }
        }

        private void btnSelectDatabase_Click(object sender, EventArgs e)
        {
            FrmConnection connectionForm = new FrmConnection();
            DialogResult dr = connectionForm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                SqlServerConnectionFactory fac = new SqlServerConnectionFactory();
                edtCN.Text = fac.CreateConnectionString(connectionForm.ConnectionInfo);
                edtSchema.Text = connectionForm.ConnectionInfo.Schema;
            }
        }

        private void btnSelectDALFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                edtDALPath.Text = dlg.SelectedPath;
            }
        }

        private void openConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newConf();
        }

        private void newConf()
        {
            edtCN.Text = "";
            edtDALPath.Text = "";
            edtSchema.Text = "";
            edtProxyLocation.Text = "";
            edtServiceUrl.Text = "";
            cmbLanguage.SelectedItem = null;
            openedConfPath = null;
            this.Text = BASE_TITLE;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openConf(null);
        }

        private void saveConfigurationAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveConf(true);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveConf(false);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveConf(false);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openConf(null);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            newConf();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conf conf = loadConfFromUI();
            bool needsSave = ! conf.isEmpty() && (this.openedConfPath == null || ! conf.Equals(ConfMan.Load(openedConfPath)));
            if (needsSave)
            {
                DialogResult r = MessageBox.Show("Save Changes?", "Changes detected", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    saveConf(false);
                }
            }

            settings["last_conf"] = openedConfPath;
            settings["min_to_tray"] = mnuMinimizeToSysTray.Checked;
            SettingsMan.Save(settings);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbLanguage.DisplayMember = "Name";
            cmbLanguage.DataSource = webServicesController.Platforms;
            cmbLanguage.SelectedItem = null;
            loadSettings();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void mnuUpdateAll_Click(object sender, EventArgs e)
        {
            updateAll();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuUpdateDAL_Click(object sender, EventArgs e)
        {
            updateDalFiles();
        }

        private void mnuUpdateDB_Click(object sender, EventArgs e)
        {
            updateDatabase();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                if (mnuMinimizeToSysTray.Checked)
                {
                    this.notifyIcon.Visible = true;
                    this.Hide();
                }
            }
            else
            {
                this.notifyIcon.Visible = false;
            }
        }

        private void mnuMinimizeToSysTray_Click(object sender, EventArgs e)
        {
            mnuMinimizeToSysTray.Checked = !mnuMinimizeToSysTray.Checked;
        }

        private void btnGenerateProxy_Click(object sender, EventArgs e)
        {
            updateProxy();
        }

        private void btnSelectProxyLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                edtProxyLocation.Text = dlg.SelectedPath;
            }
        }

        private void mnuUpdateProxy_Click(object sender, EventArgs e)
        {
            updateProxy();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            updateProxy();
        }

        
    }
}
