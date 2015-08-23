using HXF.Persistence.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HXF.Persistence.Util
{
    public class TreeBuilder
    {
        private Schema schema;

        public TreeBuilder(Schema schema)
        {
            this.schema = schema;
        }

        public TreeNode Build()
        {
            TreeNode rootNode = new TreeNode(schema.Name + " [" + schema.Platform + "]", 0, 0);
            rootNode.Tag = schema;
            TreeNode tablesNode = new TreeNode("Tables", 1, 1);
            TreeNode storedProceduresNode = new TreeNode("Stored Procedures", 1, 1);
            
            buildTablesNode(tablesNode);
            buildStoredProceduresNode(storedProceduresNode);

            rootNode.Nodes.Add(tablesNode);
            rootNode.Nodes.Add(storedProceduresNode);
            return rootNode;
        }

        private void buildTablesNode(TreeNode parentNode)
        {
            foreach (Table table in schema.Tables)
            {
                TreeNode tableNode = new TreeNode(table.Name, 2, 2);
                tableNode.Tag = table;
                TreeNode colsNode = new TreeNode("Columns", 1, 1);
                tableNode.Nodes.Add(colsNode);
                TreeNode consNode = new TreeNode("Constraints", 1, 1);
                buildColumnsNode(table, colsNode);
                buildConstraintsNode(table, consNode);
                tableNode.Nodes.Add(consNode);
                parentNode.Nodes.Add(tableNode);
                
            }
        }

        private void buildColumnsNode(Table table, TreeNode parentNode)
        {
            foreach (Column col in table.Columns)
            {
                string s = col.Name + " [" +  col.DataType.FullName + "]";
                TreeNode node = new TreeNode(s, 3, 3);
                node.Tag = col;
                parentNode.Nodes.Add(node);
            }
        }

        private void buildConstraintsNode(Table table, TreeNode parentNode)
        {
            foreach (TableConstraint con in table.Constraints)
            {
                string s = con.Name + " [" + con.Type + "]";
                TreeNode node = new TreeNode(s, 4, 4);
                node.Tag = con;
                TreeNode conColumns = new TreeNode("Columns", 1, 1);
                TreeNode conDetails = new TreeNode("Details", 1, 1);
                node.Nodes.Add(conColumns);
                node.Nodes.Add(conDetails);
                buildConstraintColumnsNode(con, conColumns);
                buildConstraintDetailsNode(con, conDetails);
                
                parentNode.Nodes.Add(node);
            }
        }

        private void buildConstraintColumnsNode(TableConstraint constraint, TreeNode parentNode)
        {
            foreach (string s in constraint.Columns) {
                TreeNode node = new TreeNode(s, 3, 3);
                parentNode.Nodes.Add(node);
            }
        }

        private void buildConstraintDetailsNode(TableConstraint constraint, TreeNode parentNode)
        {
            if (constraint is CheckConstraint)
            {
                string clause = ((CheckConstraint)constraint).Clause;
                TreeNode n = new TreeNode("Clause: " + clause, 3, 3);
                parentNode.Nodes.Add(n);
            }

            if (constraint is HXF.Persistence.Descriptors.ForeignKeyConstraint)
            {
                HXF.Persistence.Descriptors.ForeignKeyConstraint fk = (HXF.Persistence.Descriptors.ForeignKeyConstraint)constraint;
               
                parentNode.Nodes.Add(new TreeNode("Referenced Table: " + fk.ReferencedTable, 3, 3));
                parentNode.Nodes.Add(new TreeNode("Unique Constraint: " + fk.UniqueConstraint, 3, 3));


                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < fk.ReferencedColumns.Count; i++)
                {
                    string cc = fk.ReferencedColumns[i];
                    sb.Append(cc);
                    if (i < constraint.Columns.Count - 1)
                    {
                        sb.Append(", ");
                    }
                }

                TreeNode conRefColumns = new TreeNode("Refrenced Columns: " + "(" + sb.ToString() + ")", 3, 3);
                parentNode.Nodes.Add(conRefColumns);

                string updateRule = fk.UpdateRule;
                parentNode.Nodes.Add(new TreeNode("Update Rule: " + updateRule, 3, 3));

                string deleteRule = fk.DeleteRule;
                parentNode.Nodes.Add(new TreeNode("Delete Rule: " + deleteRule, 3, 3));

            }
        }

        private void buildStoredProceduresNode(TreeNode parentNode)
        {
            foreach (StoredProcedure sp in schema.StoredProcedures)
            {
                TreeNode n = new TreeNode(sp.Name, 5, 5);
                n.Tag = sp;
                parentNode.Nodes.Add(n);
                TreeNode pn = new TreeNode("Paramaters", 1, 1);
                n.Nodes.Add(pn);
                buildParamsNode(sp, pn);
            }
        }

        private void buildParamsNode(StoredProcedure storedProcedure, TreeNode parentNode)
        {
            foreach (Parameter p in storedProcedure.Parameters)
            {
                string s = p.Name + " [" + p.DataType.FullName + "] [" + p.Mode + "]"; 
                TreeNode n = new TreeNode(s, 3, 3);
                n.Tag = p;
                parentNode.Nodes.Add(n);
            }
        }

        
    }
}
