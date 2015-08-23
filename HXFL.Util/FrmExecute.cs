using HXF.Util.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HXF.Util
{
    public partial class FrmExecute : Form
    {
        private List<IOperation> operations;
        public FrmExecute(List<IOperation> operations)
        {
            InitializeComponent();
            this.operations = operations;
            
        }

        private void FrmExecute_Load(object sender, EventArgs e)
        {
            this.btnOK.Enabled = false;
            this.exec();
        }

        private void exec()
        {
            IDictionary<string, object> scope = new Dictionary<string, object>();
            OperationManager om = new OperationManager(listView1, this.operations);
            om.StatusChanged += (op) =>
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    lblOperationStatus.Text = op.Status.ToString();
                    btnOK.Enabled = (op.Status == OperationStatus.COMPLETED || op.Status == OperationStatus.FAILED);
                }));
            };
            om.Execute(scope);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
