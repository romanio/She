using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using WeifenLuo.WinFormsUI.Docking;

namespace She
{
    public partial class MainForm : Form
    {
        MainFormView view = new MainFormView();

        bool editRestartDates = false;

        public MainForm()
        {
            InitializeComponent();
            glControl.MouseWheel += GlControlOnMouseWheel;
        }

        private void GlControlOnMouseWheel(object sender, MouseEventArgs e)
        {
            view.engine.MouseWheel(e);
            GlControlPaint(null, null);
        }

        void UpdateVisualData()
        {
            editRestartDates = true;

            boxRestartDate.Items.Clear();
            boxRestartDate.Items.AddRange(view.RestartDates.ToArray());

            editRestartDates = false;

            boxRestartDate.SelectedIndex = 0;


            // Получить имена статики

            treeProperties.Nodes[0].Nodes.Clear();
            for (int iw = 0; iw < view.StaticProperties.Count; ++iw)
                treeProperties.Nodes[0].Nodes.Add(view.StaticProperties[iw]);
        }


        private void openModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                view.OpenNewModel(fileDialog.FileName);
                UpdateVisualData();
            }
        }

        private void GlControlPaint(object sender, PaintEventArgs e)
        {
            view.engine.Paint();
            glControl.SwapBuffers();
        }

        private void GlControlResize(object sender, EventArgs e)
        {
            view.engine.Resize(glControl.Width, glControl.Height);
            GlControlPaint(null, null);
        }

        private void GlControlOnMouseMove(object sender, MouseEventArgs e)
        {
            view.engine.MouseMove(e);
            GlControlPaint(null, null);
        }

        private void GlControlLoad(object sender, EventArgs e)
        {
            view.engine.Load();
            GlControlResize(null, null);
            GlControlPaint(null, null);
        }


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            view.engine.UnLoad();
        }

        private void treeProperties_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent.Index == 0) // Выбрать статическое имя
            {
                view.SetStaticProperty(e.Node.Text);
                GlControlPaint(null, null);
            }
            if (e.Node.Parent.Index == 1) // Выбрать динамическое имя
            {
                view.SetDynamicProperty(e.Node.Text);
                GlControlPaint(null, null);
            }
        }

        private void boxRestartDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (editRestartDates) return;

            if (boxRestartDate.SelectedIndex == -1) return;

            view.ReadRestartFile(boxRestartDate.SelectedIndex);

            // Получить динамические имена свойств

            treeProperties.Nodes[1].Nodes.Clear();
            for (int iw = 0; iw < view.DynamicProperties.Count; ++iw)
                treeProperties.Nodes[1].Nodes.Add(view.DynamicProperties[iw]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VisualFilter filter = new VisualFilter();
            filter.I.First = chkICoord.Checked;
            filter.I.Second = (int)(numIcoord.Value);
            filter.J.First = chkJCoord.Checked;
            filter.J.Second = (int)(numJcoord.Value);
            filter.K.First = chkKCoord.Checked;
            filter.K.Second = (int)(numKcoord.Value);

            view.SetVisualFilter(filter);
            /*
            f.min.First = chkMinimum.Checked;
            f.min.Second = (int)(numKcoord.Value);
            f.max.First = chkMaximum.Checked;
            f.max.Second = (int)(numKcoord.Value);
            */
        }
    }
}
