using HXF.WebServices.Descriptors;
using HXF.WebServices.Generators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HXF.WebServices.Util
{
    public partial class MainForm : Form
    {
        Service testService;
        
        public MainForm()
        {
            InitializeComponent();
            initTestService();
        }

        private void initTestService()
        {
            InterfaceConfiguration iconf1 = new InterfaceConfiguration("SimpleInterface", "Simple Interface",
                new RuntimeInfo(typeof(ISimpleInterface), typeof(SimpleInterfaceImpl)));

            InterfaceConfiguration iconf2 = new InterfaceConfiguration("TestInterface", "Test Interface",
                new RuntimeInfo(typeof(ITestInterface), typeof(TestInterfaceImpl)));

            ServiceConfig sconf = new ServiceConfig("hxf_service", "HXF Service");
            sconf.InterfaceConfigs.Add(iconf1);
            sconf.InterfaceConfigs.Add(iconf2);
            

            testService = ServiceBuilder.BuildFromServiceConf(sconf);
            TreeBuilder builder = new TreeBuilder(testService);
            TreeNode rootNode = builder.Build();
            treeView.Nodes.Add(rootNode);
            edtJson.Text = testService.ToJson();
            
        }

        private IProxyGenerator selectGenerator(Service service)
        {
            IProxyGenerator gen = null;
            GenOptionsDialog dlg = new GenOptionsDialog(service);
            DialogResult r = dlg.ShowDialog();
            if (r == DialogResult.OK)
            {
                gen = dlg.SelectedGenerator;
            }
            return gen;
        }

        private void generateCode() {
            object selectedItem = treeView.SelectedNode != null ? treeView.SelectedNode.Tag : null;
            if (!(selectedItem is Service))
            {
                MessageBox.Show("Invaild Selection");
                return;
            }

            Service service = (Service)selectedItem;
            IProxyGenerator gen = selectGenerator((Service)selectedItem);
            if (gen == null)
            {
                return;
            }

            IDictionary<string, string> files = gen.Generate(service);

            lstFiles.Clear();
            foreach (var key in files.Keys)
            {
                ListViewItem item = new ListViewItem(key, 0);
                item.Tag = files[key];
                lstFiles.Items.Add(item);
            }
            tabControl.SelectedTab = tbProxy;
        }

        private void addServiceFromUrl(string url)
        {
            try
            {
                WebClient client = new WebClient();
                string serviceDesc = client.DownloadString(url);
                Service service = Service.CreateFromJson(serviceDesc);
                TreeBuilder builder = new TreeBuilder(service);
                TreeNode rootNode = builder.Build();
                treeView.Nodes.Add(rootNode);
                edtJson.Text = testService.ToJson();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItems.Count > 0)
            {
                ListViewItem item = lstFiles.SelectedItems[0];
                string code = item.Tag.ToString();
                edtCode.Text = code;
            }
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            generateCode();
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            string url = edtUrl.Text.ToLower();
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Please enter service URL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!url.EndsWith("?action=sd"))
            {
                url += "?action=sd";
            }

            addServiceFromUrl(url);

        }

        
        
    }
}
