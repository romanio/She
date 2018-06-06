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
    public partial class MainForm : Form
    {
        public int currentWindow2D_id;
        public int currentWindow3D_id;
        public int currentChartForm_id;

        public ModelViewForm modelView;
        public WindowListForm windowsList;

        public bool windowsListShow = true;
        public bool modelViewShow = true;

        public List<Form2D> listForm2D;
        public List<Form3D> listForm3D;
        public List<ChartForm> listChartForm;

        public string form2Dstring = "Form 2D";
        public string form3Dstring = "Form 3D";
        public string chartString = "Chart";

        public MainForm()
        {
            InitializeComponent();
            InitializeStandardForms();
            currentWindow2D_id = 0;
            currentWindow3D_id = 0;
            currentChartForm_id = 0;
            dockPanel.Theme.Extender.FloatWindowFactory = new customFloatWindowFactory();
            listForm2D = new List<Form2D>();
            listForm3D = new List<Form3D>();
            listChartForm = new List<ChartForm>();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InitializeStandardForms()
        {
            modelView = new ModelViewForm();
            windowsList = new WindowListForm();
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                modelView.MdiParent = this;
                modelView.Show();
                windowsList.MdiParent = this;
                windowsList.Show();

            }
            else
            {
                modelView.Show(dockPanel, DockState.DockLeft);
                windowsList.Show(modelView.Pane, DockAlignment.Bottom, 0.45);

            }
        }

        private void new2DWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewForm(form2Dstring);
        }

        public void CreateNewForm(string type)
        {
            if (type == form2Dstring)
            {
                Form2D form2D = new Form2D();

                if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                {
                    form2D.MdiParent = this;
                    form2D.Show();
                }
                else
                {
                    form2D.Show(dockPanel, DockState.Document);

                }
                form2D.id = currentWindow2D_id;
                form2D.Text = form2Dstring + ":" + form2D.id;

                listForm2D.Add(form2D);

                bool f = false;
                foreach (TreeNode tn in windowsList.treeView1.Nodes)
                {
                    if (tn.Text == form2Dstring)
                    {
                        windowsList.treeView1.SelectedNode = tn;
                        f = true;
                    }
                }
                if (f == false)
                {
                    TreeNode node = new TreeNode();
                    node.Text = form2Dstring;
                    windowsList.treeView1.Nodes.Add(node);
                    windowsList.treeView1.SelectedNode = node;
                }
                TreeNode child = new TreeNode();
                child.Text = form2Dstring + ":" + currentWindow2D_id;
                child.Checked = true;
                windowsList.treeView1.SelectedNode.Nodes.Add(child);
                windowsList.treeView1.SelectedNode.Expand();
                windowsList.treeView1.SelectedNode = child;
                currentWindow2D_id++;
            }

            if (type == form3Dstring)
            {
                Form3D form3D = new Form3D();

                if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                {
                    form3D.MdiParent = this;
                    form3D.Show();
                }
                else
                {
                    form3D.Show(dockPanel, DockState.Document);

                }
                form3D.id = currentWindow3D_id;
                form3D.Text = form3Dstring + ":" + form3D.id;

                listForm3D.Add(form3D);

                bool f = false;
                foreach (TreeNode tn in windowsList.treeView1.Nodes)
                {
                    if (tn.Text == form3Dstring)
                    {
                        windowsList.treeView1.SelectedNode = tn;
                        f = true;
                    }
                }
                if (f == false)
                {
                    TreeNode node = new TreeNode();
                    node.Text = form3Dstring;
                    windowsList.treeView1.Nodes.Add(node);
                    windowsList.treeView1.SelectedNode = node;
                }
                TreeNode child = new TreeNode();
                child.Text = form3Dstring + ":" + currentWindow3D_id;
                child.Checked = true;
                windowsList.treeView1.SelectedNode.Nodes.Add(child);
                windowsList.treeView1.SelectedNode.Expand();
                windowsList.treeView1.SelectedNode = child;
                currentWindow3D_id++;
            }
            if (type == chartString)
            {
                ChartForm chart = new ChartForm();

                if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                {
                    chart.MdiParent = this;
                    chart.Show();
                }
                else
                {
                    chart.Show(dockPanel, DockState.Document);

                }
                chart.id = currentChartForm_id;
                chart.Text = chartString + ":" + chart.id;

                listChartForm.Add(chart);

                bool f = false;
                foreach (TreeNode tn in windowsList.treeView1.Nodes)
                {
                    if (tn.Text == chartString)
                    {
                        windowsList.treeView1.SelectedNode = tn;
                        f = true;
                    }
                }
                if (f == false)
                {
                    TreeNode node = new TreeNode();
                    node.Text = chartString;
                    windowsList.treeView1.Nodes.Add(node);
                    windowsList.treeView1.SelectedNode = node;
                }
                TreeNode child = new TreeNode();
                child.Text = chartString + ":" + currentChartForm_id;
                child.Checked = true;
                windowsList.treeView1.SelectedNode.Nodes.Add(child);
                windowsList.treeView1.SelectedNode.Expand();
                windowsList.treeView1.SelectedNode = child;
                currentChartForm_id++;
            }
        }

        private void modelViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!modelViewShow) modelView.Show();
            else modelView.Hide();
            modelViewShow = !modelViewShow;
        }

        private void windowsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!windowsListShow) windowsList.Show();
            else windowsList.Hide();
            windowsListShow = !windowsListShow;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CreateNewForm(form2Dstring);
        }

        private void new3DWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewForm(form3Dstring);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CreateNewForm(form3Dstring);
        }

        private void newGraphWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewForm(chartString);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            CreateNewForm(chartString);
        }
    }
}
