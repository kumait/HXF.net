﻿using HXF.Common;
using HXF.Persistence.Descriptors;
using HXF.Persistence.Generators;
using HXF.Persistence.Generators.DataAccess;
using HXF.Persistence.Generators.Sql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HXF.Persistence.Util
{
    public partial class DalGenOptionsDialog : Form
    {
        private Schema schema;
        private TypeMap selectedTypeMap;
        public IDataAccessGenerator SelectedGenerator { get; set; }

        public DalGenOptionsDialog(Schema schema)
        {
            InitializeComponent();
            this.schema = schema;
            lblPlatform.Text = schema.Platform;
        }

        private void populateLists() {
            GeneratorOptions options = new GeneratorOptions() { SupportsReturnValue = schema.Platform == "SQLSERVER" };
            IDataAccessGenerator gen1 = new CSharpDataAccessGenerator(null, options);
            cmbGenerator.Items.Add(new DalGeneratorItem(gen1.GetName(), gen1));
            
            
            cmbTypeMap.Items.Add(new TypeMapItem("No Type Map", null));
            ResourceManager resMan = new ResourceManager();
            foreach (TypeMap tm in resMan.GetDataAccessTypeMaps())
            {
                TypeMapItem item = new TypeMapItem(tm.Name, tm);
                cmbTypeMap.Items.Add(item);
            }
            cmbTypeMap.Items.Add(new TypeMapItem("Custom", null));
        }

        private void DbGenOptionsDialog_Load(object sender, EventArgs e)
        {
            populateLists();
            cmbTypeMap.SelectedIndex = 0;
            cmbGenerator.SelectedIndex = 0;
        }

        private void readUI()
        {
            SelectedGenerator = ((DalGeneratorItem)cmbGenerator.SelectedItem).Generator;
            selectedTypeMap = ((TypeMapItem)cmbTypeMap.SelectedItem).TypeMap;
            SelectedGenerator.TypeMap = selectedTypeMap;
        }

        private void analyze()
        {
            readUI();
            if (selectedTypeMap != null)
            {
                if (schema.Platform == SelectedGenerator.GetPlatform())
                {
                    MessageBox.Show("Schema and selected generator has the same platform, no type map is needed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } 
                else if (schema.Platform != selectedTypeMap.SourcePlatform)
                {
                    MessageBox.Show("Schema platform is different from selcted type map source platform", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } 
                else if (selectedTypeMap.TargetPlatform != SelectedGenerator.GetPlatform())
                {
                    MessageBox.Show("Selected type map target platform is dieffernt from selected generator platform ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Everything is fine", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (schema.Platform != SelectedGenerator.GetPlatform())
                {
                    MessageBox.Show("Schema platform is different from selected generator platform, please select a suitable type map", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } 
                else
                {
                    MessageBox.Show("Everything is fine", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnAnalyse_Click(object sender, EventArgs e)
        {
            analyze();
        }

        private void cmbTypeMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTypeMap.SelectedIndex == cmbTypeMap.Items.Count - 1)
            {
                TypeMapItem item = (TypeMapItem)cmbTypeMap.SelectedItem;
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Type Map Files(*.typemap)|*.typemap";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        item.TypeMap = TypeMap.FromFile(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unable to read type map file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            readUI();
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
