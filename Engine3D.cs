using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace She
{
    public class Engine3D
    {
        Camera camera = new Camera();
        Grid3D m_grid = null;

        int VBO, EBO;

        public void Load()
        {
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.PolygonOffsetFill);
            GL.Enable(EnableCap.CullFace);
            GL.FrontFace(FrontFaceDirection.Ccw);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color.White);

            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.ColorArray);

            VBO = GL.GenBuffer();
            EBO = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);

           // GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
        }

        public void UnLoad()
        {
            GL.DeleteBuffer(VBO);
            GL.DeleteBuffer(EBO);
        }

        Vector3 m_start_vector = new Vector3();
        Vector3 m_end_vector = new Vector3();
        Vector3 m_delta_vector = new Vector3();

        bool IsLeftDrag = false;
        bool IsMidDrag = false;
        bool IsRightDrag = false;

        public void MouseMove(MouseEventArgs e)
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

                    Paint();

                    m_start_vector = m_end_vector;
                }
            }
            else
            {
                if (IsMidDrag) // ...end panning
                {
                    IsMidDrag = false;
                    UpdateModelView();

                    Paint();
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

                    Paint();
                    m_start_vector = m_end_vector;
                }
            }
            else
            {
                if (IsRightDrag)  //.. end rotation
                {
                    IsRightDrag = false;
                    UpdateModelView();
                    Paint();
                }
            }
        }

        public void MouseWheel(MouseEventArgs e)
        {
            camera.Zoom(e.Delta);
            UpdateModelView();
        }

        public void MouseClick(MouseEventArgs e)
        {

        }

        TextRender txt_render;
        Font Serif = new Font("Segoe Pro Cond", 14, FontStyle.Regular);


        public void Paint()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.PointSize(4);
            GL.Begin(PrimitiveType.Points);
            GL.Color3(Color.Black);
            GL.Vertex3(camera.Target);

            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0);
            GL.End();

            GL.PushMatrix();

            if (IsLoaded)
            {
                GL.Scale(camera.Scale, camera.Scale, camera.Scale * 4);
                GL.Translate(-m_grid.XC, -m_grid.YC, -m_grid.ZC);
                Render();
            }
            else
            {
                RenderEasyCube();
            }

            GL.PopMatrix();

            // Switch to 2D projection
            GL.MatrixMode(MatrixMode.Projection);
            GL.PushMatrix();

            GL.LoadIdentity();
            GL.Ortho(0, _width,  _height, 0, -1, +1);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.LoadIdentity();
            GL.PointSize(4);

            //
            txt_render.Clear(Color.Transparent);
            txt_render.DrawString("Hello", Serif, Brushes.Black, new PointF(20, 20));
            txt_render.DrawString("Hello", Serif, Brushes.Black, new PointF(0, 0));
            txt_render.DrawString("Hello", Serif, Brushes.Black, new PointF(40, 40));

            Vector2 pos_coord = ConvertWorldToScreen(new Vector3(0, 0, 0));
            //System.Diagnostics.Debug.WriteLine("X = " + pos_coord.X + "  Y = " + pos_coord.Y);
            if (pos_coord.X > 0 && pos_coord.Y > 0)
            {
                txt_render.DrawString("(0, 0, 0)", Serif, Brushes.Black, new PointF(pos_coord.X, pos_coord.Y));
            }

            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, txt_render.Texture);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.One, BlendingFactorDest.OneMinusSrcAlpha);

            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.White);
            GL.TexCoord2(0, 0);
            GL.Vertex3(0, 0, 0);
            GL.TexCoord2(1, 0);
            GL.Vertex3(200, 0, 0);
            GL.TexCoord2(1, 1);
            GL.Vertex3(200, 200, 0);
            GL.TexCoord2(0, 1);
            GL.Vertex3(0, 200, 0);

            GL.End();
            GL.Disable(EnableCap.Blend);
            GL.Disable(EnableCap.Texture2D);
            //

            GL.PopMatrix();
            GL.MatrixMode(MatrixMode.Projection);
            GL.PopMatrix();

            GL.MatrixMode(MatrixMode.Modelview);

            // Switch to 3D 

        }

        public void RenderEasyCube()
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
        }

        public void Render()
        {
            // Отрисовка ячеек

            //GL.PolygonOffset(+1, +1);
            GL.EnableClientState(ArrayCap.ColorArray);
            GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
            GL.DrawElements(PrimitiveType.Quads, m_grid.ElementCount, DrawElementsType.UnsignedInt, 0);

            // Отрисовка границ
  
            /*
            GL.PolygonOffset(0, 0);
            GL.DisableClientState(ArrayCap.ColorArray);
            GL.Color3(Color.Black);
            GL.PolygonMode(MaterialFace.Front, PolygonMode.Line);
            GL.DrawElements(PrimitiveType.Quads, m_grid.ElementCount, DrawElementsType.UnsignedInt, 0);
           */
            }


        bool IsLoaded = false;
        public void SetGridModel(Grid3D grid)
        {
            m_grid = grid;
            camera.Scale = 0.004f;
            IsLoaded = true;
        }

        Vector2 ConvertWorldToScreen(Vector3 point)
        {
            point = Vector3.Transform(point, modelview);
            point = Vector3.Transform(point, projection);
            point.X /= point.Z;
            point.Y /= point.Z;

            point.X = (point.X + 1) * _width / 2;
            point.Y = _height - (point.Y + 1) * _height / 2;

            return new Vector2(point.X, point.Y);
        }

        /*
        void WellRender()
        {
            if (IsLoaded == false) return;

            ECLStructure.Cell CELL;

            for (int iw = 0; iw < ecl_ref.RESTART.NWELLS; ++iw)
            {
                for (int ic = 0; ic < ecl_ref.RESTART.NCWMAX; ++ic)
                {
                    // Если перфорация активная
                    int cell_active = ecl_ref.RESTART.ICON[iw * ecl_ref.RESTART.NICONZ * ecl_ref.RESTART.NCWMAX + ic * ecl_ref.RESTART.NICONZ + 0];
                    int cell_X = ecl_ref.RESTART.ICON[iw * ecl_ref.RESTART.NICONZ * ecl_ref.RESTART.NCWMAX + ic * ecl_ref.RESTART.NICONZ + 1];
                    int cell_Y = ecl_ref.RESTART.ICON[iw * ecl_ref.RESTART.NICONZ * ecl_ref.RESTART.NCWMAX + ic * ecl_ref.RESTART.NICONZ + 2];
                    int cell_Z = ecl_ref.RESTART.ICON[iw * ecl_ref.RESTART.NICONZ * ecl_ref.RESTART.NCWMAX + ic * ecl_ref.RESTART.NICONZ + 3];

                    if (cell_active != 0)
                    {
                        CELL = ecl_ref.EGRID.GetCell(cell_X, cell_Y, cell_Z);

                        GL.LineWidth(3);

                        GL.Begin(PrimitiveType.Lines);
                        GL.Color3(Color.Red);
                        GL.Vertex3((CELL.TNE.X + CELL.BSW.X) * 0.5, (CELL.TNE.Y + CELL.BSW.Y) * 0.5, ecl_ref.EGRID.ZMAXCOORD);

                        GL.Vertex3((CELL.TNE.X + CELL.BSW.X) * 0.5, (CELL.TNE.Y + CELL.BSW.Y) * 0.5, (CELL.TNE.Z + CELL.BSW.Z) * 0.5);

                        GL.End();

                        continue;
                    }
                }
            }
            GL.LineWidth(1);
        }
        */

        ECLStructure.ECL ecl_ref = null;

        /*
        public void GenerateGraphics(ECLStructure.ECL ecl)
        {
            IsLoaded = true;
            ecl_ref = ecl;
            ecl.ReadRestart(4);
            ecl.RESTART.ReadRestartGrid("PRESSURE");
            camera.Scale = 0.004f;
            grid.GenerateGraphics(ecl);

        }
        */

        Matrix4 projection;

        float _width;
        float _height;

        public void Resize(int width, int height)
        {
            float aspect = (float)width / (float)height;
            GL.Viewport(0, 0, width, height);
            _width = width;
            _height = height;

            projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver6, aspect, 0.1f, 1000f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            GL.MatrixMode(MatrixMode.Modelview);
            UpdateModelView();

            //
            if (txt_render != null) txt_render.Dispose();
            txt_render = new TextRender((int)_width, (int)_height);
        }

        Matrix4 modelview = new Matrix4();

        void UpdateModelView()
        {
            modelview = Matrix4.LookAt(camera.Position, camera.Target, camera.UpDirection);
            GL.LoadMatrix(ref modelview);
        }
    }
}
