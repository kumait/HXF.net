using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HXF.Util.Operations
{
    public class OperationManager: Operation
    {
        private ListView view;
        private List<IOperation> operations;

        public OperationManager(ListView view, List<IOperation> operations)
        {
            this.view = view;
            this.view.MouseUp += view_MouseUp;
            this.operations = operations;
        }

        void view_MouseUp(object sender, MouseEventArgs e)
        {
            var info = view.HitTest(new Point(e.X, e.Y));
            Exception ex = info.SubItem == null? null: info.SubItem.Tag as Exception;
            if (ex != null)
            {
                string message = ex.Message;
                message += ex.InnerException != null ? "\n" + ex.InnerException.Message : "";
                MessageBox.Show(message);

            }
        }

        private void buildView()
        {
            view.Items.Clear();
            
            foreach (IOperation op in operations)
            {
                op.StatusChanged += OpStatusChanged;
                ListViewItem item = new ListViewItem(op.Name);
                item.Tag = op;
                item.UseItemStyleForSubItems = false;
                item.SubItems.Add(op.Status.ToString());
                view.Items.Add(item);
            }
        }

        private void updateView(IOperation op)
        {
            view.Invoke(new MethodInvoker(() =>
            {
                foreach (ListViewItem item in view.Items)
                {
                    if (item.Tag == op)
                    {
                        ListViewItem.ListViewSubItem subItem = item.SubItems[1];
                        subItem.Text = op.Status.ToString();
                        if (op.Status == OperationStatus.WAITING)
                        {
                            Font subItemFont = new Font(subItem.Font, FontStyle.Regular);
                            Font itemFont = new Font(item.Font, FontStyle.Regular);
                            item.Font = itemFont;
                            subItem.Font = subItemFont;
                            subItem.ForeColor = Color.Black;
                            subItem.Tag = null;
                        }
                        else if (op.Status == OperationStatus.RUNNING)
                        {
                            Font subItemFont = new Font(subItem.Font, FontStyle.Bold);
                            Font itemFont = new Font(item.Font, FontStyle.Bold);
                            item.Font = itemFont;
                            subItem.Font = subItemFont;
                            subItem.ForeColor = Color.Black;
                            subItem.Tag = null;
                        } else if (op.Status == OperationStatus.COMPLETED)
                        {
                            Font subItemFont = new Font(subItem.Font, FontStyle.Regular);
                            Font itemFont = new Font(item.Font, FontStyle.Regular);
                            item.Font = itemFont;
                            subItem.Font = subItemFont;
                            subItem.ForeColor = Color.Green;
                            subItem.Tag = null;
                        }
                        else if (op.Status == OperationStatus.FAILED)
                        {
                            Font subItemFont = new Font(subItem.Font, FontStyle.Underline);
                            Font itemFont = new Font(item.Font, FontStyle.Regular);
                            item.Font = itemFont;
                            subItem.Font = subItemFont;
                            subItem.ForeColor = Color.Red;
                            subItem.Tag = op.Exception;
                        }
                        break;
                    }
                }
            }));
        }

        void OpStatusChanged(IOperation op)
        {
            updateView(op);
        }

        public override void Execute(IDictionary<string, object> scope)
        {
            buildView();
            Thread t = new Thread(new ThreadStart(() => {
                foreach (IOperation op in this.operations)
                {
                    try
                    {
                        this.Status = OperationStatus.RUNNING;
                        op.Execute(scope);
                        this.Status = OperationStatus.COMPLETED;
                    }
                    catch (Exception ex)
                    {
                        this.Exception = ex;
                        this.Status = OperationStatus.FAILED;
                        break;
                    }
                }
            }));
            t.Start();
        }

        public override void Clean(IDictionary<string, object> scope)
        {
            foreach (IOperation op in this.operations)
            {
                op.Clean(scope);
            }
        }
    }
}
