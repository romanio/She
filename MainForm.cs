﻿using System;
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
                engine.GenerateGraphics(view.ecl);
            }
        }

        private void GlControlPaint(object sender, PaintEventArgs e)
        {
            engine.Paint();
            glControl.SwapBuffers();
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
