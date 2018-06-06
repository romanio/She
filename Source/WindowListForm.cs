using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace MWI
{
    public partial class WindowListForm : DockContent
    {
        public WindowListForm()
        {
            InitializeComponent();
            this.DockAreas = DockAreas.Float | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.DockBottom;
        }

        private void WindowListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            Program.mainform.windowsListShow = false;
            Program.mainform.windowsListToolStripMenuItem.Checked = false;
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
            if (treeView1.Nodes.Count > 0 && treeView1.SelectedNode != null)
            {
                TreeNode t = treeView1.SelectedNode;
                if (t.Checked && t.Text.Contains(":") && t.Parent.Text == Program.mainform.form2Dstring)
                {
                    int cid = Convert.ToInt32(t.Text.Split(':').ToList()[1]);
                    foreach (Form2D view in Program.mainform.listForm2D)
                    {
                        if (cid == view.id)
                        {
                            view.Activate();
                        }
                    }
                }
                if (t.Checked && t.Text.Contains(":") && t.Parent.Text == Program.mainform.form3Dstring)
                {
                    int cid = Convert.ToInt32(t.Text.Split(':').ToList()[1]);
                    foreach (Form3D view in Program.mainform.listForm3D)
                    {
                        if (cid == view.id)
                        {
                            view.Activate();
                        }
                    }
                }
                if (t.Checked && t.Text.Contains(":") && t.Parent.Text == Program.mainform.chartString)
                {
                    int cid = Convert.ToInt32(t.Text.Split(':').ToList()[1]);
                    foreach (ChartForm view in Program.mainform.listChartForm)
                    {
                        if (cid == view.id)
                        {
                            view.Activate();
                        }
                    }
                }

            }
            treeView1.Focus();
        }
        private void SetVisibility(string text, bool visibility)
        {
            string window_type = text.Split(':').ToList<string>()[0];
            int cid = Convert.ToInt32(text.Split(':').ToList<string>()[1]);
            if (window_type == Program.mainform.form2Dstring)
            {
                foreach (Form2D view in Program.mainform.listForm2D)
                {
                    if (cid == view.id)
                    {
                        if (visibility) view.Show(Program.mainform.dockPanel);
                        else view.Hide();
                    }
                }
            }
            if (window_type == Program.mainform.form3Dstring)
            {
                foreach (Form3D view in Program.mainform.listForm3D)
                {
                    if (cid == view.id)
                    {
                        if (visibility) view.Show(Program.mainform.dockPanel);
                        else view.Hide();
                    }
                }
            }
            if (window_type == Program.mainform.chartString)
            {
                foreach (ChartForm view in Program.mainform.listChartForm)
                {
                    if (cid == view.id)
                    {
                        if (visibility) view.Show(Program.mainform.dockPanel);
                        else view.Hide();
                    }
                }
            }

        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (treeView1.Nodes.Count > 0)
            {
                foreach (TreeNode node in treeView1.Nodes)
                {
                    if (node.Parent == null && node.Nodes.Count > 0)
                    {
                        foreach (TreeNode child in node.Nodes)
                        {
                            SetVisibility(child.Text, child.Checked);
                        }
                    }
                }
            }
        }

        public void SetCheckedState(int id, bool check, string type)
        {
            foreach (TreeNode node in treeView1.Nodes)
            {
                if (node.Parent == null && node.Nodes.Count > 0)
                {
                    foreach (TreeNode child in node.Nodes)
                    {
                        int cid = Convert.ToInt32(child.Text.Split(':').ToList<string>()[1]);
                        string window_type = child.Text.Split(':').ToList<string>()[0];
                        if (cid == id && window_type == type)
                        {
                            child.Checked = check;
                        }
                    }
                }
            }
        }

        private void form2DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.mainform.CreateNewForm(Program.mainform.form2Dstring);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                TreeNode t = treeView1.SelectedNode;
                if (t.Parent != null)
                {
                    TreeNode parent = t.Parent;
                    int index = parent.Nodes.IndexOf(t);
                    int cid = Convert.ToInt32(t.Text.Split(':').ToList<string>()[1]);
                    string window_type = t.Text.Split(':').ToList<string>()[0];
                    int i = 0;
                    int ind = -1;
                    if (window_type == Program.mainform.form2Dstring)
                    {
                        ind = -1;
                        foreach (Form2D view in Program.mainform.listForm2D)
                        {
                            if (view.id == cid)
                            {
                                view.userClosing = true;
                                view.Close();
                                ind = i;
                            }
                            i++;
                        }
                        if (ind > -1) Program.mainform.listForm2D.RemoveAt(ind);
                    }
                    if (window_type == Program.mainform.form3Dstring)
                    {
                        ind = -1;
                        foreach (Form3D view in Program.mainform.listForm3D)
                        {
                            if (view.id == cid)
                            {
                                view.userClosing = true;
                                view.Close();
                                ind = i;
                            }
                            i++;
                        }
                        if (ind > -1) Program.mainform.listForm3D.RemoveAt(ind);
                    }
                    if (window_type == Program.mainform.chartString)
                    {
                        ind = -1;
                        foreach (ChartForm view in Program.mainform.listChartForm)
                        {
                            if (view.id == cid)
                            {
                                view.userClosing = true;
                                view.Close();
                                ind = i;
                            }
                            i++;
                        }
                        if (ind > -1) Program.mainform.listChartForm.RemoveAt(ind);
                    }
                    parent.Nodes.RemoveAt(index);
                    treeView1.Invalidate();
                    treeView1.Refresh();
                }
            }
        }

        private void form3DToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Program.mainform.CreateNewForm(Program.mainform.form3Dstring);
        }

        private void chartToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Program.mainform.CreateNewForm(Program.mainform.chartString);
        }
    }
}
