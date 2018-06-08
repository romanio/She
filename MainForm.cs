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
            VisualFilter m_filter = new VisualFilter();

            m_filter.ICfrom.First = chkICoord.Checked;
            m_filter.ICfrom.Second = (int)(numICfrom.Value);
            m_filter.ICto.First = chkICoord.Checked;
            m_filter.ICto.Second = (int)(numICto.Value);

            m_filter.JCfrom.First = chkJCoord.Checked;
            m_filter.JCfrom.Second = (int)(numJCfrom.Value);
            m_filter.JCto.First = chkJCoord.Checked;
            m_filter.JCto.Second = (int)(numJCto.Value);

            m_filter.KCfrom.First = chkKCoord.Checked;
            m_filter.KCfrom.Second = (int)(numKCfrom.Value);
            m_filter.KCto.First = chkKCoord.Checked;
            m_filter.KCto.Second = (int)(numKCto.Value);

            view.SetVisualFilter(m_filter);
        }
    }
}
