using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using She.ECLStructure;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace She
{
    public class Grid3D
    {
        public float XC, YC, ZC; // Центр модели
        Colorizer Colorizer = new Colorizer();
        public int ElementCount;

        public void GenerateGraphics(ECL ecl, Func<int, float> GetValue, VisualFilter filter)
        {
            Cell CELL;

            Colorizer.SetMinimum(0);
            Colorizer.SetMaximum(1);

            // Центрирование 

            XC = (ecl.EGRID.XMINCOORD + ecl.EGRID.XMAXCOORD) * 0.5f;
            YC = (ecl.EGRID.YMINCOORD + ecl.EGRID.YMAXCOORD) * 0.5f;
            ZC = (ecl.EGRID.ZMINCOORD + ecl.EGRID.ZMAXCOORD) * 0.5f;
            
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

            // Применить индексные фильтры

            HashSet<int> XSet = new HashSet<int>();
            HashSet<int> YSet = new HashSet<int>();
            HashSet<int> ZSet = new HashSet<int>();

            if (filter != null)
            {
                int X_start = (filter.ICfrom.First) ? filter.ICfrom.Second - 1 : 0;
                int X_end = (filter.ICto.First) ? filter.ICto.Second - 1 : ecl.INIT.NX;

                int Y_start = (filter.JCfrom.First) ? filter.JCfrom.Second - 1 : 0;
                int Y_end = (filter.JCto.First) ? filter.JCto.Second - 1 : ecl.INIT.NY;

                int Z_start = (filter.KCfrom.First) ? filter.KCfrom.Second - 1 : 0;
                int Z_end = (filter.KCto.First) ? filter.KCto.Second - 1 : ecl.INIT.NZ;

                for (int X = X_start; X < X_end; ++X)
                    XSet.Add(X);

                for (int Y = Y_start; Y < Y_end; ++Y)
                    YSet.Add(Y);

                for (int Z = Z_start; Z < Z_end; ++Z)
                    ZSet.Add(Z);

            }
            else // Если не используется фильтр, обычное индексирование
            {
                for (int X = 0; X < ecl.INIT.NX; ++X)
                {
                    XSet.Add(X);
                }

                for (int Y = 0; Y < ecl.INIT.NY; ++Y)
                {
                    YSet.Add(Y);
                }

                for (int Z = 0; Z < ecl.INIT.NZ; ++Z)
                {
                    ZSet.Add(Z);
                }
            }

            //
            
            unsafe
            {
                float* vertex_mem = (float*)VertexPtr;
                int* index_mem = (int*)ElementPtr;
                byte* color_mem = (byte*)(VertexPtr + ecl.INIT.NACTIV * sizeof(float) * 3 * 8);

                foreach (int Z in ZSet)
                {
                    foreach (int Y in YSet)
                    {
                        foreach (int X in XSet)
                        {
                            cell_index = ecl.INIT.GetActive(X, Y, Z);

                            if (cell_index > 0)
                            {
                                CELL = ecl.EGRID.GetCell(X, Y, Z);

                                value = GetValue(cell_index - 1);
                                color = Colorizer.ColorByValue(value);

                                // Check next X-neightbore

                                skip_right_face = false;

                                if (X < ecl.INIT.NX - 1)
                                {
                                    cell_index = ecl.INIT.GetActive(X + 1, Y, Z);
                                    if (cell_index > 0)
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
                                    cell_index = ecl.INIT.GetActive(X, Y, Z + 1);
                                    if (cell_index > 0)
                                    {
                                        var NCELL = ecl.EGRID.GetCell(X, Y, Z + 1);

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

                                // Debug

                                skip_right_face = false;
                                skip_top_face = false;

                                skip_back_face = false;
                                skip_front_face = false;

                                skip_left_face = false;
                                skip_bottom_face = false;
                                
                                // top face 

                                if (!skip_top_face)
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
    }
}
