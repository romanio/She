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
        Camera camera = new Camera();
        MainFormView view = new MainFormView();

        ECLStructure.Colorizer Colorizer = new ECLStructure.Colorizer();
       
        public MainForm()
        {
            InitializeComponent();

            IsMidDrag = false;
            IsLeftDrag = false;
            IsRightDrag = false;

            glControl1.MouseWheel += GlControl1_MouseWheel;
        }

        private void GlControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            camera.Zoom(e.Delta);
            UpdateModelView();
            GlControl1Paint(null, null);
        }

        void GlControl1Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            if (view.ecl == null)
            {
                GL.Begin(PrimitiveType.Quads);
                GL.Color3(Color.Green);
                GL.Vertex3(1.0, 1.0, -1.0);
                GL.Vertex3(-1.0, 1.0, -1.0);
                GL.Vertex3(-1.0, 1.0, 1.0);
                GL.Vertex3(1.0, 1.0, 1.0);

                GL.Color3(1.0, 0.5, 0.0);

                GL.Vertex3(1.0, -1.0, 1.0);
                GL.Vertex3(-1.0, -1.0, 1.0);
                GL.Vertex3(-1.0, -1.0, -1.0);
                GL.Vertex3(1.0, -1.0, -1.0);

                GL.Color3(1.0, 0.0, 0.0);
                GL.Vertex3(1.0, 1.0, 1.0);
                GL.Vertex3(-1.0, 1.0, 1.0);
                GL.Vertex3(-1.0, -1.0, 1.0);
                GL.Vertex3(1.0, -1.0, 1.0);

                GL.Color3(1.0, 1.0, 0.0);
                GL.Vertex3(1.0, -1.0, -1.0);
                GL.Vertex3(-1.0, -1.0, -1.0);
                GL.Vertex3(-1.0, 1.0, -1.0);
                GL.Vertex3(1.0, 1.0, -1.0);

                GL.Color3(0.0, 0.0, 1.0);
                GL.Vertex3(-1.0, 1.0, 1.0);
                GL.Vertex3(-1.0, 1.0, -1.0);
                GL.Vertex3(-1.0, -1.0, -1.0);
                GL.Vertex3(-1.0, -1.0, 1.0);

                GL.Color3(1.0, 0.0, 1.0);
                GL.Vertex3(1.0, 1.0, -1.0);
                GL.Vertex3(1.0, 1.0, 1.0);
                GL.Vertex3(1.0, -1.0, 1.0);
                GL.Vertex3(1.0, -1.0, -1.0);

                GL.End();

                GL.Begin(PrimitiveType.Quads);
                GL.Color3(Color.Green);
                GL.Vertex3(1.0, 1.0, 2.0);
                GL.Vertex3(-1.0, 1.0, 2.0);
                GL.Vertex3(-1.0, 1.0, 3.0);
                GL.Vertex3(1.0, 1.0, 3.0);

                GL.Color3(1.0, 0.5, 0.0);

                GL.Vertex3(1.0, -1.0, 3.0);
                GL.Vertex3(-1.0, -1.0, 3.0);
                GL.Vertex3(-1.0, -1.0, 2.0);
                GL.Vertex3(1.0, -1.0, 2.0);

                GL.Color3(1.0, 0.0, 0.0);
                GL.Vertex3(1.0, 1.0, 3.0);
                GL.Vertex3(-1.0, 1.0, 3.0);
                GL.Vertex3(-1.0, -1.0, 3.0);
                GL.Vertex3(1.0, -1.0, 3.0);

                GL.Color3(1.0, 1.0, 0.0);
                GL.Vertex3(1.0, -1.0, 2.0);
                GL.Vertex3(-1.0, -1.0, 2.0);
                GL.Vertex3(-1.0, 1.0, 2.0);
                GL.Vertex3(1.0, 1.0, 2.0);

                GL.Color3(0.0, 0.0, 1.0);
                GL.Vertex3(-1.0, 1.0, 3.0);
                GL.Vertex3(-1.0, 1.0, 2.0);
                GL.Vertex3(-1.0, -1.0, 2.0);
                GL.Vertex3(-1.0, -1.0, 3.0);

                GL.Color3(1.0, 0.0, 1.0);
                GL.Vertex3(1.0, 1.0, 2.0);
                GL.Vertex3(1.0, 1.0, 3.0);
                GL.Vertex3(1.0, -1.0, 3.0);
                GL.Vertex3(1.0, -1.0, 2.0);

                GL.End();
                GL.PointSize(4);
                GL.Begin(PrimitiveType.Points);
                GL.Color3(Color.Black);
                
                GL.Vertex3(camera.Target);

                GL.Color3(Color.Green);
                GL.Vertex3(0, 0, 0);
                GL.End();

                /*
                GL.LineWidth(4);
                GL.Begin(PrimitiveType.Lines);
                GL.Vertex3(camera.Target);
                GL.Vertex3(camera.Target + camera.RightAxis);
                GL.Vertex3(camera.Target);
                GL.Vertex3(camera.Target + camera.UpDirection);
                GL.End();
                GL.LineWidth(1);
                */
            }
            else
            {
                int index = 0;
                float value = 0;
                int count = 0;
                ECLStructure.Cell CELL;

                GL.Begin(PrimitiveType.Quads);


                for (int X = 0; X < view.ecl.INIT.NX; ++X)
                {
                    for (int Y = 0; Y < view.ecl.INIT.NY; ++Y)
                    {
                        int Z = 0;

                        index = view.ecl.INIT.GetActive(X, Y, Z);
                        if (index > 0)
                        {
                            CELL = view.ecl.EGRID.GetCell(X, Y, Z);

                            value = view.ecl.RESTART.GetValue(index);
                            count++;
                            GL.Color3(Colorizer.ColorByValue(value));

                            GL.Vertex3(CELL.TNW);
                            GL.Vertex3(CELL.TNE);
                            GL.Vertex3(CELL.TSE);
                            GL.Vertex3(CELL.TSW);
                      }
                    }
                }

                GL.End();
            }
            GL.PointSize(4);
            GL.Begin(PrimitiveType.Points);
            GL.Color3(Color.Black);

            GL.Vertex3(camera.Target);
            GL.End();
            glControl1.SwapBuffers();
        }

        void GlControl1Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.White);
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            GL.FrontFace(FrontFaceDirection.Ccw);
            GlControl1Resize(null, null);
        }

        Matrix4 modelview = new Matrix4();

        void GlControl1Resize(object sender, EventArgs e)
        {
            float aspect = (float)glControl1.Width / (float)glControl1.Height;
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspect, 1f, 10000f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            GL.MatrixMode(MatrixMode.Modelview);
            UpdateModelView();
        }

        void UpdateModelView()
        {
            modelview = Matrix4.LookAt(camera.Position, camera.Target, camera.UpDirection);
            GL.LoadMatrix(ref modelview);
        }

        Vector3 m_start_vector = new Vector3();
        Vector3 m_end_vector = new Vector3();
        Vector3 m_delta_vector = new Vector3();

        bool IsLeftDrag = false;
        bool IsMidDrag = false;
        bool IsRightDrag = false;

        void GlControl1MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                if (!IsMidDrag) // begin panning
                {
                    m_start_vector = new Vector3(e.X, e.Y, 0f);
                    IsMidDrag = true;
                }
                else // ...continue panning
                {
                    m_end_vector = new Vector3(e.X, e.Y, 0f);
                    m_delta_vector = m_end_vector - m_start_vector;

                    camera.Pan(m_delta_vector.X, m_delta_vector.Y);
                    UpdateModelView();

                    GlControl1Paint(null, null);

                    m_start_vector = m_end_vector;
                }
            }
            else
            {
                if (IsMidDrag) // ...end panning
                {
                    IsMidDrag = false;
                    GlControl1Paint(null, null);
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                if (!IsRightDrag) // begin rotation
                {
                    m_start_vector = new Vector3(e.X, e.Y, 0f);
                    IsRightDrag = true;
                }
                else  // ...continue rotation
                {
                    m_end_vector = new Vector3(e.X, e.Y, 0f);
                    m_delta_vector = m_end_vector - m_start_vector;

                    camera.Rotate(m_delta_vector.X, m_delta_vector.Y);
                    UpdateModelView();

                    GlControl1Paint(null, null);
                    m_start_vector = m_end_vector;
                }
            }
            else
            {
                if (IsRightDrag)  //.. end rotation
                {
                    IsRightDrag = false;
                    GlControl1Paint(null, null);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GlControl1Paint(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            camera.Rotate(0, 1);
            UpdateModelView();
            GlControl1Paint(null, null);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            camera.Rotate(1, 0);
            UpdateModelView();
            GlControl1Paint(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            camera.Rotate(-1, 0);
            UpdateModelView();
            GlControl1Paint(null, null);
        }

        private void openModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                view.OpenNewModel(fileDialog.FileName);
                GenerateGraphics();
            }
        }

        void GenerateGraphics()
        {
            view.ecl.ReadRestart(6);
            view.ecl.RESTART.ReadRestartGrid("SWAT");

            // Центрирование 

            float XC = (view.ecl.EGRID.XMINCOORD + view.ecl.EGRID.XMAXCOORD) * 0.5f;
            float YC = (view.ecl.EGRID.YMINCOORD + view.ecl.EGRID.YMAXCOORD) * 0.5f;
            float ZC = (view.ecl.EGRID.ZMINCOORD + view.ecl.EGRID.ZMAXCOORD) * 0.5f;

            camera.Position = new Vector3(XC, YC, ZC - 200);
            camera.Target = new Vector3(XC, YC, ZC);
            camera.UpDirection = new Vector3(0, 1, 0);

            camera.LookDirection = new Vector3(camera.Target - camera.Position);
            camera.LookDirection.Normalize();

            camera.RightAxis = Vector3.Cross(camera.LookDirection, camera.UpDirection);
            camera.RightAxis.Normalize();

            UpdateModelView();
            GlControl1Paint(null, null);
            
        }
    }
}
