using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace She
{
    public partial class MainForm : Form
    {
        MainFormView view = new MainFormView();
        Engine3D engine = new Engine3D();

        public MainForm()
        {
            InitializeComponent();
            glControl.MouseWheel += GlControlOnMouseWheel;
        }

        private void GlControlOnMouseWheel(object sender, MouseEventArgs e)
        {
            engine.MouseWheel(e);
            GlControlPaint(null, null);
        }

        private void openModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                view.OpenNewModel(fileDialog.FileName);

                boxRestartDate.Items.Clear();
                boxRestartDate.Items.AddRange(view.RestartDates.ToArray());

                // Получить имена статики

                treeProperties.Nodes[0].Nodes.Clear();
                for (int iw = 0; iw < view.StaticProperties.Count; ++iw)
                    treeProperties.Nodes[0].Nodes.Add(view.StaticProperties[iw]);

                engine.GenerateGraphics(view.ecl);
            }
        }

        private void GlControlPaint(object sender, PaintEventArgs e)
        {
            engine.Paint();
            glControl.SwapBuffers();

            Text = engine.ElementCount.ToString();
        }

        private void GlControlResize(object sender, EventArgs e)
        {
            engine.Resize(glControl.Width, glControl.Height);
            GlControlPaint(null, null);
        }

        private void GlControlOnMouseMove(object sender, MouseEventArgs e)
        {
            engine.MouseMove(e);
            GlControlPaint(null, null);
        }

        private void GlControlLoad(object sender, EventArgs e)
        {
            engine.Load();
            GlControlResize(null, null);
            GlControlPaint(null, null);
        }


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            engine.UnLoad();
        }

        private void treeProperties_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent.Index == 0) // Static 
            {
                view.SetStaticProperty(e.Node.Text);
                //engine.GenerateGraphics()
            }
        }

        private void boxRestartDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxRestartDate.SelectedIndex == -1) return;

            view.ReadRestartFile(boxRestartDate.SelectedIndex);

            // Получить динамические имена свойств

            treeProperties.Nodes[1].Nodes.Clear();
            for (int iw = 0; iw < view.DynamicProperties.Count; ++iw)
                treeProperties.Nodes[1].Nodes.Add(view.DynamicProperties[iw]);

            engine.GenerateGraphics(view.ecl);
        }

        /*
        void GlControl1Paint(object sender, PaintEventArgs e)
        {
            if (view.ecl == null)
            {
            }
            else
            {
                // Отрисовать куб вокруг границ модели
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);

                GL.Begin(PrimitiveType.Quads);
                GL.Color3(Color.Green); // Задняя стенка
                GL.Vertex3(view.ecl.EGRID.XMAXCOORD * 1.1, view.ecl.EGRID.YMAXCOORD * 1.1, view.ecl.EGRID.ZMINCOORD * 0.9);
                GL.Vertex3(view.ecl.EGRID.XMINCOORD * 0.9, view.ecl.EGRID.YMAXCOORD * 1.1, view.ecl.EGRID.ZMINCOORD * 0.9);
                GL.Vertex3(view.ecl.EGRID.XMINCOORD * 0.9, view.ecl.EGRID.YMAXCOORD * 1.1, view.ecl.EGRID.ZMAXCOORD * 1.1);
                GL.Vertex3(view.ecl.EGRID.XMAXCOORD * 1.1, view.ecl.EGRID.YMAXCOORD * 1.1, view.ecl.EGRID.ZMAXCOORD * 1.1);

                GL.Color3(1.0, 0.5, 0.0);

                GL.Vertex3(view.ecl.EGRID.XMAXCOORD * 1.1, view.ecl.EGRID.YMINCOORD * 0.9, view.ecl.EGRID.ZMAXCOORD * 1.1);
                GL.Vertex3(view.ecl.EGRID.XMINCOORD * 0.9, view.ecl.EGRID.YMINCOORD * 0.9, view.ecl.EGRID.ZMAXCOORD * 1.1);
                GL.Vertex3(view.ecl.EGRID.XMINCOORD * 0.9, view.ecl.EGRID.YMINCOORD * 0.9, view.ecl.EGRID.ZMINCOORD * 0.9);
                GL.Vertex3(view.ecl.EGRID.XMAXCOORD * 1.1, view.ecl.EGRID.YMINCOORD * 0.9, view.ecl.EGRID.ZMINCOORD * 0.9);


                GL.Color3(1.0, 0.0, 0.0);

                GL.Vertex3(view.ecl.EGRID.XMAXCOORD * 1.1, view.ecl.EGRID.YMAXCOORD * 1.1, view.ecl.EGRID.ZMAXCOORD * 1.1);
                GL.Vertex3(view.ecl.EGRID.XMINCOORD * 0.9, view.ecl.EGRID.YMAXCOORD * 1.1, view.ecl.EGRID.ZMAXCOORD * 1.1);
                GL.Vertex3(view.ecl.EGRID.XMINCOORD * 0.9, view.ecl.EGRID.YMINCOORD * 0.9, view.ecl.EGRID.ZMAXCOORD * 1.1);
                GL.Vertex3(view.ecl.EGRID.XMAXCOORD * 1.1, view.ecl.EGRID.YMINCOORD * 0.9, view.ecl.EGRID.ZMAXCOORD * 1.1);

                GL.Color3(1.0, 1.0, 0.0);

                GL.Vertex3(view.ecl.EGRID.XMAXCOORD * 1.1, view.ecl.EGRID.YMINCOORD * 0.9, view.ecl.EGRID.ZMINCOORD * 0.9);
                GL.Vertex3(view.ecl.EGRID.XMINCOORD * 0.9, view.ecl.EGRID.YMINCOORD * 0.9, view.ecl.EGRID.ZMINCOORD * 0.9);
                GL.Vertex3(view.ecl.EGRID.XMINCOORD * 0.9, view.ecl.EGRID.YMAXCOORD * 1.1, view.ecl.EGRID.ZMINCOORD * 0.9);
                GL.Vertex3(view.ecl.EGRID.XMAXCOORD * 1.1, view.ecl.EGRID.YMAXCOORD * 1.1, view.ecl.EGRID.ZMINCOORD * 0.9);

                GL.Color3(0.0, 0.0, 1.0);

                GL.Vertex3(view.ecl.EGRID.XMINCOORD * 0.9, view.ecl.EGRID.YMAXCOORD * 1.1, view.ecl.EGRID.ZMAXCOORD * 1.1);
                GL.Vertex3(view.ecl.EGRID.XMINCOORD * 0.9, view.ecl.EGRID.YMAXCOORD * 1.1, view.ecl.EGRID.ZMINCOORD * 0.9);
                GL.Vertex3(view.ecl.EGRID.XMINCOORD * 0.9, view.ecl.EGRID.YMINCOORD * 0.9, view.ecl.EGRID.ZMINCOORD * 0.9);
                GL.Vertex3(view.ecl.EGRID.XMINCOORD * 0.9, view.ecl.EGRID.YMINCOORD * 0.9, view.ecl.EGRID.ZMAXCOORD * 1.1);

                GL.Color3(1.0, 0.0, 1.0);

                GL.Vertex3(view.ecl.EGRID.XMAXCOORD * 1.1, view.ecl.EGRID.YMAXCOORD * 1.1, view.ecl.EGRID.ZMINCOORD * 0.9);
                GL.Vertex3(view.ecl.EGRID.XMAXCOORD * 1.1, view.ecl.EGRID.YMAXCOORD * 1.1, view.ecl.EGRID.ZMAXCOORD * 1.1);
                GL.Vertex3(view.ecl.EGRID.XMAXCOORD * 1.1, view.ecl.EGRID.YMINCOORD * 0.9, view.ecl.EGRID.ZMAXCOORD * 1.1);
                GL.Vertex3(view.ecl.EGRID.XMAXCOORD * 1.1, view.ecl.EGRID.YMINCOORD * 0.9, view.ecl.EGRID.ZMINCOORD * 0.9);

                GL.End();

                // Отрисовка ячеек
                GL.PolygonOffset(+1, +1);
                GL.EnableClientState(ArrayCap.ColorArray);
                GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
                GL.DrawElements(PrimitiveType.Quads, ElementCount, DrawElementsType.UnsignedInt, 0);


                // Отрисовка границ

                GL.PolygonOffset(0, 0);
                GL.DisableClientState(ArrayCap.ColorArray);
                GL.Color3(Color.Black);
                GL.PolygonMode(MaterialFace.Front, PolygonMode.Line);
                GL.DrawElements(PrimitiveType.Quads, ElementCount, DrawElementsType.UnsignedInt, 0);
            }

            GL.PopMatrix();
            glControl.SwapBuffers();
        }
        */
    }
}
