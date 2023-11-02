using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SNT_POS_Common.Entity;
using SNT_POS_Common.Controller;



namespace SNT_POS_Single_Management
{
    public partial class RoleForm : Form
    {
        Role role; RoleController rolecontrol = new RoleController(); 
        FormMenuController formmenu = new FormMenuController();
        FormMenuControl_Controller formmenucontrol = new FormMenuControl_Controller();

        List<TreeNode> nodelist;
        public RoleForm()
        {
            InitializeComponent();
            add_menu_treenodes();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSave.Text == "Update" && role != null)
                {

                    role.Name = txtRoleName.Text;
                    rolecontrol.update(role);
                    updateAllTreeNodes(treeView1.Nodes);

                    MessageBox.Show("Role updated");
                    btnSave.Text = "Save";
                }
                else
                {
                    role = new Role(txtRoleName.Text);
                    role.ID = rolecontrol.save2(role);

                    saveAllTreeNodes(treeView1.Nodes);

                    MessageBox.Show("New Role added");


                }

                // test();
                if (nodelist != null)
                    nodelist.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void setData(Role role)
        {
            txtRoleName.Text = role.Name;
        }

        private void test()
        {
            SearchForm sf = new SearchForm();
            
                sf.addData(formmenucontrol.getAll());
                sf.Show();
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           
            using (SearchForm sf = new SearchForm())
            {
                sf.addData(rolecontrol.getAll());
                //sf.MdiParent = this.MdiParent;
                if (sf.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    if (sf.getID() != -1)
                    {
                        role = rolecontrol.getById(sf.getID());
                        setData(role);
                        setAllTreeNodes(treeView1.Nodes);
                        btnSave.Text = "Update";
                        

                    }
                }

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (role != null)
            {
                rolecontrol.delete((int)role.ID);
            }
        }

        private void add_menu_treenodes()
        {
            DataTable menutable = formmenu.getWithoutParentID();
            foreach (DataRow row in menutable.Rows)
            {
                TreeNode node = new TreeNode();
                node.Text = row["MenuName"].ToString();
                node.Name = row["ID"].ToString();
                //you can affect the node.NavigateUrl

                add_menu_childnodes(node);
                treeView1.Nodes.Add(node);
            }
        }
        private void add_menu_childnodes(TreeNode parentNode)
        {
            DataTable menuitemtable = formmenu.getByParentID(int.Parse(parentNode.Name));
            foreach (DataRow row in menuitemtable.Rows)
            {
                TreeNode childnode = new TreeNode();
                childnode.Text = row["MenuName"].ToString();
                childnode.Name = row["ID"].ToString();
               
                parentNode.Nodes.Add(childnode);

                add_menu_childnodes(childnode);
            }
        }

     

        private List<TreeNode> getcheckedTreeNodes(TreeNodeCollection NodeCollections)
        {
            nodelist = new List<TreeNode>();
            foreach (TreeNode node in NodeCollections)
            {
                if (node.Checked == true)
                    nodelist.Add(node);

                getcheckedTreeNodes(node.Nodes);
            }

            return nodelist;

        }
        private void setAllTreeNodes(TreeNodeCollection NodeCollections)
        {
            
            foreach (TreeNode node in NodeCollections)
            {
                //if (formmenucontrol.isAuthorize(role.ID, int.Parse(node.Name)) != null)
                    node.Checked = (bool)formmenucontrol.isAuthorize((int)role.ID, int.Parse(node.Name));
               
                setAllTreeNodes(node.Nodes);
            }

            

        }

        private void saveAllTreeNodes(TreeNodeCollection NodeCollections)
        {
            foreach (TreeNode node in NodeCollections)
            {
                formmenucontrol.save((int)role.ID, int.Parse(node.Name),node.Checked);

                saveAllTreeNodes(node.Nodes);
            }
        }
        private void updateAllTreeNodes(TreeNodeCollection NodeCollections)
        {
            foreach (TreeNode node in NodeCollections)
            {
                formmenucontrol.update((int)role.ID, int.Parse(node.Name), node.Checked);
                //MessageBox.Show(role.ID+""+node.Name+node.Checked,"update");
               updateAllTreeNodes(node.Nodes);
            }
        }


    }
}
