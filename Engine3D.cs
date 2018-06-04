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

        int VBO, EBO;
        public void Load()
        {
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.PolygonOffsetFill);
            GL.Enable(EnableCap.CullFace);
           // GL.FrontFace(FrontFaceDirection.Cw);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color.White);

            GL.EnableClientState(ArrayCap.VertexArray);
            GL.EnableClientState(ArrayCap.ColorArray);

            VBO = GL.GenBuffer();
            EBO = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);

            GL.PolygonMode(MaterialFace.Front, PolygonMode.Line);
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

        float XC, YC, ZC;
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

            GL.Scale(camera.Scale, camera.Scale, camera.Scale * 24);
            GL.Translate(-XC, -YC, -ZC);

            if (IsLoaded)
            {
                Render();
            }
            else
            {
                RenderEasyCube();
            }

            GL.PopMatrix();
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

        public int ElementCount;
        ECLStructure.Colorizer Colorizer = new ECLStructure.Colorizer();

        public void Render()
        {
            // Отрисовка ячеек

            GL.PolygonOffset(+1, +1);
            GL.EnableClientState(ArrayCap.ColorArray);
            GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
            GL.DrawElements(PrimitiveType.Quads, ElementCount, DrawElementsType.UnsignedInt, 0);

            // Отрисовка границ

           // System.Diagnostics.Debug.WriteLine(ElementCount);

            GL.PolygonOffset(0, 0);
            GL.DisableClientState(ArrayCap.ColorArray);
            GL.Color3(Color.Black);
            GL.PolygonMode(MaterialFace.Front, PolygonMode.Line);
            GL.DrawElements(PrimitiveType.Quads, ElementCount, DrawElementsType.UnsignedInt, 0);
        }


        bool IsLoaded = false;

        public void GenerateGraphics(ECLStructure.ECL ecl)
        {
            IsLoaded = true;

            ecl.ReadRestart(0);
            ecl.RESTART.ReadRestartGrid("PRESSURE");

            // Центрирование 

            XC = (ecl.EGRID.XMINCOORD + ecl.EGRID.XMAXCOORD) * 0.5f;
            YC = (ecl.EGRID.YMINCOORD + ecl.EGRID.YMAXCOORD) * 0.5f;
            ZC = (ecl.EGRID.ZMINCOORD + ecl.EGRID.ZMAXCOORD) * 0.5f;

            camera.Scale = 0.004f;

            Colorizer.SetMinimum(200);
            Colorizer.SetMaximum(300);

            // 
            GL.BufferData(
                BufferTarget.ArrayBuffer,
                (IntPtr)((ulong)ecl.INIT.NACTIV * sizeof(float) * 3 * 8 + (ulong)ecl.INIT.NACTIV * sizeof(byte) * 3 * 8), // Три координаты по float, 8 вершин и 
                IntPtr.Zero,
                BufferUsageHint.StaticDraw);

            IntPtr VertexPtr = GL.MapBuffer(BufferTarget.ArrayBuffer, BufferAccess.WriteOnly);

            GL.BufferData(
                BufferTarget.ElementArrayBuffer,
                (IntPtr)((ulong)ecl.INIT.NACTIV * sizeof(float) * 3 * 24),
                IntPtr.Zero,
                BufferUsageHint.StaticDraw);

            System.Diagnostics.Debug.WriteLine(GL.GetError().ToString());
            IntPtr ElementPtr = GL.MapBuffer(BufferTarget.ElementArrayBuffer, BufferAccess.WriteOnly);

            GL.VertexPointer(3, VertexPointerType.Float, 0, 0);
            GL.ColorPointer(3, ColorPointerType.UnsignedByte, 0, ecl.INIT.NACTIV * sizeof(float) * 3 * 8);


            ECLStructure.Cell CELL;

            int index = 0;
            float value = 0;
            int count = 0;
            int cell_index = 0;
            Color color;

            bool skip_right_face = false;
            bool skip_front_face = false;
            bool skip_bottom_face = false;
            bool skip_left_face = false;
            bool skip_top_face = false;
            bool skip_back_face = false;

            unsafe
            {
                float* vertex_mem = (float*)VertexPtr;
                int* index_mem = (int*)ElementPtr;
                byte* color_mem = (byte*)(VertexPtr + ecl.INIT.NACTIV * sizeof(float) * 3 * 8);

               for (int Z = 0; Z < ecl.INIT.NZ; ++Z)
                {
                    for (int Y = 0; Y < ecl.INIT.NY; ++Y)
                    {
                        for (int X = 0; X < ecl.INIT.NX; ++X)
                        {
                            cell_index = ecl.INIT.GetActive(X, Y, Z);

                            if (cell_index > 0)
                            {
                                CELL = ecl.EGRID.GetCell(X, Y, Z);

                                value = ecl.RESTART.GetValue(cell_index - 1);
                                color = Colorizer.ColorByValue(value);

                                // Check next X-neightbore

                                skip_right_face = false;

                                if (X < ecl.INIT.NX - 1)
                                {
                                    cell_index = ecl.INIT.GetActive(X + 1, Y, Z);
                                    if  (cell_index > 0)
                                    {
                                        var NCELL = ecl.EGRID.GetCell(X + 1, Y, Z);

                                        if ((CELL.TNE == NCELL.TNW) &&
                                            (CELL.TSE == NCELL.TSW) &&
                                            (CELL.BNE == NCELL.BNW) &&
                                            (CELL.BSE == NCELL.BSW)) // Если правая грань по X совпадает с левой гранью по X+1, не надо ничего рисовать
                                        {
                                            skip_right_face = true;
                                        }
                                    }
                                }

                                // Check next Y-neightbore

                                skip_front_face = false;

                                if (Y < ecl.INIT.NY - 1)
                                {
                                    cell_index = ecl.INIT.GetActive(X, Y + 1, Z);
                                    if (cell_index > 0)
                                    {
                                        var NCELL = ecl.EGRID.GetCell(X, Y + 1, Z);

                                        if ((CELL.TSW == NCELL.TNW) &&
                                            (CELL.TSE == NCELL.TNE) &&
                                            (CELL.BSW == NCELL.BNW) &&
                                            (CELL.BSE == NCELL.BNE)) // Если правая грань по X совпадает с левой гранью по X+1, не надо ничего рисовать
                                        {
                                            skip_front_face = true;
                                        }
                                    }
                                }

                                // Check next Z-neightbore

                                skip_bottom_face = false;

                                if (Z < ecl.INIT.NZ - 1)
                                {
                                    cell_index = ecl.INIT.GetActive(X, Y, Z+1);
                                    if (cell_index > 0)
                                    {
                                        var NCELL = ecl.EGRID.GetCell(X, Y, Z+1);

                                        if ((CELL.BNW == NCELL.TNW) &&
                                            (CELL.BNE == NCELL.TNE) &&
                                            (CELL.BSW == NCELL.TSW) &&
                                            (CELL.BSE == NCELL.TSE)) // Если правая грань по X совпадает с левой гранью по X+1, не надо ничего рисовать
                                        {
                                            skip_bottom_face = true;
                                        }
                                    }
                                }

                                // Check prev X-neightbore

                                skip_left_face = false;

                                if (X > 1)
                                {
                                    cell_index = ecl.INIT.GetActive(X - 1, Y, Z);
                                    if (cell_index > 0)
                                    {
                            
                                        var NCELL = ecl.EGRID.GetCell(X - 1, Y, Z);

                                        if ((CELL.TNW == NCELL.TNE) &&
                                            (CELL.TSW == NCELL.TSE) &&
                                            (CELL.BNW == NCELL.BNE) &&
                                            (CELL.BSW == NCELL.BSE)) 
                                        {
                                            skip_left_face = true;
                                        }
                                    }
                                }

                                // Check prev Y-neightbore

                                skip_back_face = false;

                                if (Y > 1)
                                {
                                    cell_index = ecl.INIT.GetActive(X, Y - 1, Z);
                                    if (cell_index > 0)
                                    {
                                        var NCELL = ecl.EGRID.GetCell(X, Y - 1, Z);

                                        if ((CELL.TNW == NCELL.TSW) &&
                                            (CELL.TNE == NCELL.TSE) &&
                                            (CELL.BNW == NCELL.BSW) &&
                                            (CELL.BNE == NCELL.BSE))
                                        {
                                            skip_back_face = true;
                                        }
                                    }
                                }

                                // Check prev Z-neightbore

                                skip_top_face = false;

                                if (Z > 1)
                                {
                                    cell_index = ecl.INIT.GetActive(X, Y, Z - 1);
                                    if (cell_index > 0)
                                    {
                                        var NCELL = ecl.EGRID.GetCell(X, Y, Z - 1);

                                        if ((CELL.TNW == NCELL.BNW) &&
                                            (CELL.TNE == NCELL.BNE) &&
                                            (CELL.TSW == NCELL.BSW) &&
                                            (CELL.TSE == NCELL.BSE))
                                        {
                                            skip_top_face = true;
                                        }
                                    }
                                }

                                int pos = 0;

                                // top face 

                                if (skip_top_face)
                                {
                                    index_mem[count + (pos++)] = index + 0;
                                    index_mem[count + (pos++)] = index + 1;
                                    index_mem[count + (pos++)] = index + 2;
                                    index_mem[count + (pos++)] = index + 3;
                                }

                                // bottom face

                                if (!skip_bottom_face)
                                {
                                    index_mem[count + (pos++)] = index + 5;
                                    index_mem[count + (pos++)] = index + 4;
                                    index_mem[count + (pos++)] = index + 7;
                                    index_mem[count + (pos++)] = index + 6;
                                }

                                // left face TNW(0) TSW(1) BNW(4) BSW(5)

                                if (!skip_left_face)
                                {
                                    index_mem[count + (pos++)] = index + 0;
                                    index_mem[count + (pos++)] = index + 4;
                                    index_mem[count + (pos++)] = index + 5;
                                    index_mem[count + (pos++)] = index + 1;
                                }

                                // front face

                                if (!skip_front_face)
                                {
                                    index_mem[count + (pos++)] = index + 5;
                                    index_mem[count + (pos++)] = index + 6;
                                    index_mem[count + (pos++)] = index + 2;
                                    index_mem[count + (pos++)] = index + 1;
                                }

                                // right face

                                if (!skip_right_face)
                                {
                                    index_mem[count + (pos++)] = index + 6;
                                    index_mem[count + (pos++)] = index + 7;
                                    index_mem[count + (pos++)] = index + 3;
                                    index_mem[count + (pos++)] = index + 2;
                                }

                                // back face TNW(0) TNE(3) BNW(4) BNE(7)

                                if (!skip_back_face)
                                {
                                    index_mem[count + (pos++)] = index + 0;
                                    index_mem[count + (pos++)] = index + 3;
                                    index_mem[count + (pos++)] = index + 7;
                                    index_mem[count + (pos++)] = index + 4;
                                }

                                count = count + pos;

                                vertex_mem[index * 3 + 0] = CELL.TNW.X;
                                vertex_mem[index * 3 + 1] = CELL.TNW.Y;
                                vertex_mem[index * 3 + 2] = CELL.TNW.Z;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                vertex_mem[index * 3 + 0] = CELL.TSW.X;
                                vertex_mem[index * 3 + 1] = CELL.TSW.Y;
                                vertex_mem[index * 3 + 2] = CELL.TSW.Z;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                vertex_mem[index * 3 + 0] = CELL.TSE.X;
                                vertex_mem[index * 3 + 1] = CELL.TSE.Y;
                                vertex_mem[index * 3 + 2] = CELL.TSE.Z;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                vertex_mem[index * 3 + 0] = CELL.TNE.X;
                                vertex_mem[index * 3 + 1] = CELL.TNE.Y;
                                vertex_mem[index * 3 + 2] = CELL.TNE.Z;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                vertex_mem[index * 3 + 0] = CELL.BNW.X;
                                vertex_mem[index * 3 + 1] = CELL.BNW.Y;
                                vertex_mem[index * 3 + 2] = CELL.BNW.Z;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                vertex_mem[index * 3 + 0] = CELL.BSW.X;
                                vertex_mem[index * 3 + 1] = CELL.BSW.Y;
                                vertex_mem[index * 3 + 2] = CELL.BSW.Z;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                vertex_mem[index * 3 + 0] = CELL.BSE.X;
                                vertex_mem[index * 3 + 1] = CELL.BSE.Y;
                                vertex_mem[index * 3 + 2] = CELL.BSE.Z;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;

                                vertex_mem[index * 3 + 0] = CELL.BNE.X;
                                vertex_mem[index * 3 + 1] = CELL.BNE.Y;
                                vertex_mem[index * 3 + 2] = CELL.BNE.Z;

                                color_mem[index * 3 + 0] = color.R;
                                color_mem[index * 3 + 1] = color.G;
                                color_mem[index * 3 + 2] = color.B;

                                index++;
                                //
                            }
                        }
                    }
                }
            }

            ElementCount = count;
            GL.UnmapBuffer(BufferTarget.ArrayBuffer);
            GL.UnmapBuffer(BufferTarget.ElementArrayBuffer);
        }

        public void Resize(int width, int height)
        {
            float aspect = (float)width / (float)height;
            GL.Viewport(0, 0, width, height);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver6, aspect, 0.1f, 1000f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            GL.MatrixMode(MatrixMode.Modelview);
            UpdateModelView();
        }

        Matrix4 modelview = new Matrix4();
        void UpdateModelView()
        {
            modelview = Matrix4.LookAt(camera.Position, camera.Target, camera.UpDirection);
            GL.LoadMatrix(ref modelview);
        }
    }
}
