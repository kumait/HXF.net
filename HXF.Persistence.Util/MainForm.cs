
using HXF.Persistence.Conf;
using HXF.Persistence.Descriptors;
using HXF.Persistence.Generators;
using HXF.Persistence.Generators.DataAccess;
using HXF.Persistence.Generators.Sql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HXF.Persistence.Util
{
    public partial class MainForm : Form
    {
        private Schema schema;


        public MainForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            connect();
        }

        private void buildView()
        {
            TreeBuilder treeBuilder = new TreeBuilder(this.schema);
            TreeNode node = treeBuilder.Build();
            treeView.Nodes.Add(node);
        }

        private void connect()
        {
            ConnectionForm cf = new ConnectionForm();
            DialogResult result = cf.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    this.schema = SchemaBuilder.CreateFromConnection(cf.ConnectionInfo);
                    textBox1.Text = this.schema.ToJson();
                    buildView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
        }

        private void open()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JSON files (*.json)|*.json";
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fn = dlg.FileName;
                StreamReader rdr = new StreamReader(fn);
                string json = rdr.ReadToEnd();
                this.schema = Schema.CreateFromJson(json);
                textBox1.Text = this.schema.ToJson();
                buildView();
            }
        }
        
        private void generateSql()
        {
            object selectedItem = treeView.SelectedNode != null ? treeView.SelectedNode.Tag : null;
            string sql = null;

            if (!(selectedItem is Schema))
            {
                MessageBox.Show("Invaild Selection");
                return;
            }
            
            ISqlGenerator gen = selectGenerator((Schema)selectedItem);
            if (gen == null)
            {
                return;
            }
            sql = gen.Generate((Schema)selectedItem);
            edtSql.Text = sql;
            tabControl.SelectedTab = tbSql;
        }

        private void generateDal()
        {
            object selectedItem = treeView.SelectedNode != null ? treeView.SelectedNode.Tag : null;

            if (!(selectedItem is Schema))
            {
                MessageBox.Show("Invaild Selection");
                return;
            }

            IDataAccessGenerator gen = selectDalGenerator((Schema)selectedItem);

            if (gen == null)
            {
                return;
            }

            string interfaceCode = gen.GenerateInterface((Schema)selectedItem);
            string classCode = gen.GenerateClass((Schema)selectedItem);
            string entitiesCode = gen.GenerateEntities((Schema)selectedItem);
            edtInterface.Text = interfaceCode;
            edtClass.Text = classCode;
            edtEntities.Text = entitiesCode;
            tabControl.SelectedTab = tbDAL;
        }

        

        private ISqlGenerator selectGenerator(Schema schema)
        {
            ISqlGenerator gen = null;
            DbGenOptionsDialog dlg = new DbGenOptionsDialog(schema);
            DialogResult r = dlg.ShowDialog();
            if (r == DialogResult.OK)
            {
                gen = dlg.SelectedGenerator;
            }
            return gen;
        }

        private IDataAccessGenerator selectDalGenerator(Schema schema)
        {
            IDataAccessGenerator gen = null;
            DalGenOptionsDialog dlg = new DalGenOptionsDialog(schema);
            DialogResult r = dlg.ShowDialog();
            if (r == DialogResult.OK)
            {
                gen = dlg.SelectedGenerator;
            }
            return gen;
        }
        

        

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            FrmAbout about = new FrmAbout();
            about.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            generateSql();
        }

        private void btnGenerateDAL_Click(object sender, EventArgs e)
        {
            generateDal();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            open();
        }
    }
}
