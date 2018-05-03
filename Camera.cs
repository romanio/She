﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace She
{
    public class Camera
    {
        public Vector3 UpDirection;
        public Vector3 Position;
        public Vector3 Target;
        public Vector3 LookDirection;
        public Vector3 RightAxis;
        public float Sensitivity = 2f;
        public float ZoomSensitivity = 2f;
        public float RotationSensitivity = 0.02f;
        public float Scale = 1f;

        public float ScaleXY = 1.0f;
        public float ScaleZ = 0.1f;

        public Camera()
        {
            Position = new Vector3(0, 0, -6);
            Target = new Vector3(0, 0, 0);
            UpDirection = new Vector3(0, 1, 0);

            LookDirection = new Vector3(Target - Position);
            LookDirection.Normalize();

            RightAxis = Vector3.Cross(LookDirection, UpDirection);
            RightAxis.Normalize();
        }

        public void Zoom(int delta)
        {
            if (delta > 0)
            {
                // Приближать точку наблюдения к центру наблюдения
                Position.X = Position.X + ZoomSensitivity * LookDirection.X;
                Position.Y = Position.Y + ZoomSensitivity * LookDirection.Y;
                Position.Z = Position.Z + ZoomSensitivity * LookDirection.Z;
            }
            if (delta < 0)
            {
                // И также отдалять
                Position.X = Position.X - ZoomSensitivity * LookDirection.X;
                Position.Y = Position.Y - ZoomSensitivity * LookDirection.Y;
                Position.Z = Position.Z - ZoomSensitivity * LookDirection.Z;
            }
        }

        public void Pan(float dx, float dy)
        {
            // Двигаться вдоль вертикальной экрану координате
            Position.X = Position.X + Sensitivity * dy * UpDirection.X;
            Target.X = Target.X + Sensitivity * dy * UpDirection.X;

            Position.Y = Position.Y + Sensitivity * dy * UpDirection.Y;
            Target.Y = Target.Y + Sensitivity * dy * UpDirection.Y;

            Position.Z = Position.Z + Sensitivity * dy * UpDirection.Z;
            Target.Z = Target.Z + Sensitivity * dy * UpDirection.Z;
            // И вдоль горизонтальной экрану
            Position.X = Position.X - Sensitivity * dx * RightAxis.X;
            Target.X = Target.X - Sensitivity * dx * RightAxis.X;

            Position.Y = Position.Y - Sensitivity * dx * RightAxis.Y;
            Target.Y = Target.Y - Sensitivity * dx * RightAxis.Y;

            Position.Z = Position.Z - Sensitivity * dx * RightAxis.Z;
            Target.Z = Target.Z - Sensitivity * dx * RightAxis.Z;
            //
        }

        public void Rotate(float dx, float dy)
        {
            Vector3 UpModel = new Vector3(0, 0, 1);
            Quaternion q1 = Quaternion.FromAxisAngle(UpModel, -RotationSensitivity * dx);
            Quaternion q2 = Quaternion.FromAxisAngle(RightAxis, -RotationSensitivity * dy);
            Quaternion q = q1 * q2;

            // Вращать вокруг центра Target, для этого текущую Position
            //переносим в условный ноль
            Vector3 rPosition = Position - Target;
            rPosition = Vector3.Transform(rPosition, q);

            
            Position = Target + rPosition;
            //Target = Target - rTarget;

            UpDirection = Vector3.Transform(UpDirection, q);
            LookDirection = new Vector3(Target - Position);
            LookDirection.Normalize();
            /*
            Position = Vector3.Transform(Position, q);
            Target = Vector3.Transform(Target, q);

            */

            RightAxis = Vector3.Cross(LookDirection, UpDirection);
            RightAxis.Normalize();
        }
    }
}