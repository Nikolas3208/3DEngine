namespace _3DEngine.Core.Mathematics
{
    public struct Matrix4
    {
        public static Matrix4 Identity => new Matrix4(Vector4.UnitX, Vector4.UnitY, Vector4.UnitZ, Vector4.UnitW);
        public static Matrix4 Zero => new Matrix4(Vector4.Zero, Vector4.Zero, Vector4.Zero, Vector4.Zero);

        public Vector4 Row0;
        public Vector4 Row1;
        public Vector4 Row2;
        public Vector4 Row3;

        public float M00
        {
            readonly get => Row0.X;
            set => Row0.X = value;
        }

        public float M01
        {
            readonly get => Row0.Y;
            set => Row0.Y = value;
        }

        public float M02
        {
            readonly get => Row0.Z;
            set => Row0.Z = value;
        }

        public float M03
        {
            readonly get => Row0.W;
            set => Row0.W = value;
        }

        public float M10
        {
            readonly get => Row1.X;
            set => Row1.X = value;
        }

        public float M11
        {
            readonly get => Row1.Y;
            set => Row1.Y = value;
        }

        public float M12
        {
            readonly get => Row1.Z;
            set => Row1.Z = value;
        }

        public float M13
        {
            readonly get => Row1.W;
            set => Row1.W = value;
        }

        public float M20
        {
            readonly get => Row2.X;
            set => Row2.X = value;
        }

        public float M21
        {
            readonly get => Row2.Y;
            set => Row2.Y = value;
        }

        public float M22
        {
            readonly get => Row2.Z;
            set => Row2.Z = value;
        }

        public float M23
        {
            readonly get => Row2.W;
            set => Row2.W = value;
        }

        public float M30
        {
            readonly get => Row3.X;
            set => Row3.X = value;
        }

        public float M31
        {
            readonly get => Row3.Y;
            set => Row3.Y = value;
        }

        public float M32
        {
            readonly get => Row3.Z;
            set => Row3.Z = value;
        }

        public float M33
        {
            readonly get => Row3.W;
            set => Row3.W = value;
        }

        public Matrix4(Vector4 row0, Vector4 row1, Vector4 row2, Vector4 row3)
        {
            Row0 = row0;
            Row1 = row1;
            Row2 = row2;
            Row3 = row3;
        }

        public Matrix4
        (
            float m00, float m01, float m02, float m03,
            float m10, float m11, float m12, float m13,
            float m20, float m21, float m22, float m23,
            float m30, float m31, float m32, float m33
        )
        {
            Row0 = new Vector4(m00, m01, m02, m03);
            Row1 = new Vector4(m10, m11, m12, m13);
            Row2 = new Vector4(m20, m21, m22, m23);
            Row3 = new Vector4(m30, m31, m32, m33);
        }

        public float[] GetValues()
        {
            return new float[]
            {
                M00, M10, M20, M30,
                M01, M11, M21, M31,
                M02, M12, M22, M32,
                M03, M13, M23, M33
            };
        }
        public static Matrix4 CreateRotationX(float angle)
        {
            var cos = MathF.Cos(angle);
            var sin = MathF.Sin(angle);

            Matrix4 result = Matrix4.Identity;

            result.Row1.Y = cos;
            result.Row1.Z = sin;
            result.Row2.Y = -sin;
            result.Row2.Z = cos;

            return result;
        }

        public static Matrix4 CreateRotationY(float angle)
        {
            var cos = MathF.Cos(angle);
            var sin = MathF.Sin(angle);

            Matrix4 result = Matrix4.Identity;

            result.Row0.X = cos;
            result.Row0.Z = -sin;
            result.Row2.X = sin;
            result.Row2.Z = cos;

            return result;
        }

        public static Matrix4 CreateRotationZ(float angle)
        {
            var cos = MathF.Cos(angle);
            var sin = MathF.Sin(angle);

            Matrix4 result = Matrix4.Identity;

            result.Row0.X = cos;
            result.Row0.Y = sin;
            result.Row1.X = -sin;
            result.Row1.Y = cos;

            return result;
        }

        public static Matrix4 CreateTranslation(Vector3 translation)
        {
            Matrix4 result = Matrix4.Identity;

            result.Row3.X = translation.X;
            result.Row3.Y = translation.Y;
            result.Row3.Z = translation.Z;

            return result;
        }

        public static Matrix4 CreateScale(float scale)
        {
            Matrix4 result = Matrix4.Identity;

            result.Row0.X = scale;
            result.Row1.Y = scale;
            result.Row2.Z = scale;

            return result;
        }

        public static Matrix4 CreateScale(Vector3 scale)
        {
            Matrix4 result = Matrix4.Identity;

            result.Row0.X = scale.X;
            result.Row1.Y = scale.Y;
            result.Row2.Z = scale.Z;

            return result;
        }


        public static Matrix4 CreateOrthographic(float width, float height, float depthNear, float depthFar)
        {
            return CreateOrthographicOffCenter(-width / 2, width / 2, -height / 2, height / 2, depthNear, depthFar);
        }

        public static Matrix4 CreateOrthographicOffCenter
        (
            float left,
            float right,
            float bottom,
            float top,
            float depthNear,
            float depthFar
        )
        {
            Matrix4 result = Matrix4.Identity;

            var invRL = 1.0f / (right - left);
            var invTB = 1.0f / (top - bottom);
            var invFN = 1.0f / (depthFar - depthNear);

            result.Row0.X = 2 * invRL;
            result.Row1.Y = 2 * invTB;
            result.Row2.Z = -2 * invFN;

            result.Row3.X = -(right + left) * invRL;
            result.Row3.Y = -(top + bottom) * invTB;
            result.Row3.Z = -(depthFar + depthNear) * invFN;

            return result;
        }

        public static Matrix4 CreatePerspectiveFieldOfView
        (
            float fovy,
            float aspect,
            float depthNear,
            float depthFar
        )
        {
            if (fovy <= 0 || fovy > MathF.PI)
            {
                throw new ArgumentOutOfRangeException(nameof(fovy), fovy, "Fovy must be in the range [0, PI].");
            }

            if (aspect <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(aspect), aspect, "Aspect cannot be negative.");
            }

            if (depthNear <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(depthNear), depthNear, "depthNear cannot be negative.");
            }

            if (depthFar <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(depthFar), depthFar, "depthFar cannot be negative.");
            }

            float maxY = depthNear * MathF.Tan(0.5f * fovy);
            float minY = -maxY;
            float minX = minY * aspect;
            float maxX = maxY * aspect;

            return CreatePerspectiveOffCenter(minX, maxX, minY, maxY, depthNear, depthFar);
        }

        public static Matrix4 CreatePerspectiveOffCenter
        (
            float left,
            float right,
            float bottom,
            float top,
            float depthNear,
            float depthFar
        )
        {
            if (depthNear <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(depthNear));
            }

            if (depthFar <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(depthFar));
            }

            if (depthNear >= depthFar)
            {
                throw new ArgumentOutOfRangeException(nameof(depthNear));
            }

            var x = 2.0f * depthNear / (right - left);
            var y = 2.0f * depthNear / (top - bottom);
            var a = (right + left) / (right - left);
            var b = (top + bottom) / (top - bottom);
            var c = -(depthFar + depthNear) / (depthFar - depthNear);
            var d = -(2.0f * depthFar * depthNear) / (depthFar - depthNear);

            Matrix4 result = Matrix4.Identity;

            result.Row0.X = x;
            result.Row0.Y = 0;
            result.Row0.Z = 0;
            result.Row0.W = 0;
            result.Row1.X = 0;
            result.Row1.Y = y;
            result.Row1.Z = 0;
            result.Row1.W = 0;
            result.Row2.X = a;
            result.Row2.Y = b;
            result.Row2.Z = c;
            result.Row2.W = -1;
            result.Row3.X = 0;
            result.Row3.Y = 0;
            result.Row3.Z = d;
            result.Row3.W = 0;

            return result;
        }

        public static Matrix4 LookAt(Vector3 eye, Vector3 target, Vector3 up)
        {
            var z = Vector3.Normalize(eye - target);
            var x = Vector3.Normalize(Vector3.Cross(up, z));
            var y = Vector3.Normalize(Vector3.Cross(z, x));

            Matrix4 result = Matrix4.Identity;

            result.Row0.X = x.X;
            result.Row0.Y = y.X;
            result.Row0.Z = z.X;
            result.Row0.W = 0;
            result.Row1.X = x.Y;
            result.Row1.Y = y.Y;
            result.Row1.Z = z.Y;
            result.Row1.W = 0;
            result.Row2.X = x.Z;
            result.Row2.Y = y.Z;
            result.Row2.Z = z.Z;
            result.Row2.W = 0;
            result.Row3.X = -((x.X * eye.X) + (x.Y * eye.Y) + (x.Z * eye.Z));
            result.Row3.Y = -((y.X * eye.X) + (y.Y * eye.Y) + (y.Z * eye.Z));
            result.Row3.Z = -((z.X * eye.X) + (z.Y * eye.Y) + (z.Z * eye.Z));
            result.Row3.W = 1;

            return result;
        }

        public static Matrix4 Transpose(Matrix4 m)
        {
            return new Matrix4(
                new Vector4(m.Row0.X, m.Row1.X, m.Row2.X, m.Row3.X),
                new Vector4(m.Row0.Y, m.Row1.Y, m.Row2.Y, m.Row3.Y),
                new Vector4(m.Row0.Z, m.Row1.Z, m.Row2.Z, m.Row3.Z),
                new Vector4(m.Row0.W, m.Row1.W, m.Row2.W, m.Row3.W)
            );
        }

        public static Matrix4 Mult(Matrix4 left, Matrix4 right)
        {
            Matrix4 result = Matrix4.Identity;

            float leftM11 = left.Row0.X;
            float leftM12 = left.Row0.Y;
            float leftM13 = left.Row0.Z;
            float leftM14 = left.Row0.W;
            float leftM21 = left.Row1.X;
            float leftM22 = left.Row1.Y;
            float leftM23 = left.Row1.Z;
            float leftM24 = left.Row1.W;
            float leftM31 = left.Row2.X;
            float leftM32 = left.Row2.Y;
            float leftM33 = left.Row2.Z;
            float leftM34 = left.Row2.W;
            float leftM41 = left.Row3.X;
            float leftM42 = left.Row3.Y;
            float leftM43 = left.Row3.Z;
            float leftM44 = left.Row3.W;
            float rightM11 = right.Row0.X;
            float rightM12 = right.Row0.Y;
            float rightM13 = right.Row0.Z;
            float rightM14 = right.Row0.W;
            float rightM21 = right.Row1.X;
            float rightM22 = right.Row1.Y;
            float rightM23 = right.Row1.Z;
            float rightM24 = right.Row1.W;
            float rightM31 = right.Row2.X;
            float rightM32 = right.Row2.Y;
            float rightM33 = right.Row2.Z;
            float rightM34 = right.Row2.W;
            float rightM41 = right.Row3.X;
            float rightM42 = right.Row3.Y;
            float rightM43 = right.Row3.Z;
            float rightM44 = right.Row3.W;

            result.Row0.X = (leftM11 * rightM11) + (leftM12 * rightM21) + (leftM13 * rightM31) + (leftM14 * rightM41);
            result.Row0.Y = (leftM11 * rightM12) + (leftM12 * rightM22) + (leftM13 * rightM32) + (leftM14 * rightM42);
            result.Row0.Z = (leftM11 * rightM13) + (leftM12 * rightM23) + (leftM13 * rightM33) + (leftM14 * rightM43);
            result.Row0.W = (leftM11 * rightM14) + (leftM12 * rightM24) + (leftM13 * rightM34) + (leftM14 * rightM44);
            result.Row1.X = (leftM21 * rightM11) + (leftM22 * rightM21) + (leftM23 * rightM31) + (leftM24 * rightM41);
            result.Row1.Y = (leftM21 * rightM12) + (leftM22 * rightM22) + (leftM23 * rightM32) + (leftM24 * rightM42);
            result.Row1.Z = (leftM21 * rightM13) + (leftM22 * rightM23) + (leftM23 * rightM33) + (leftM24 * rightM43);
            result.Row1.W = (leftM21 * rightM14) + (leftM22 * rightM24) + (leftM23 * rightM34) + (leftM24 * rightM44);
            result.Row2.X = (leftM31 * rightM11) + (leftM32 * rightM21) + (leftM33 * rightM31) + (leftM34 * rightM41);
            result.Row2.Y = (leftM31 * rightM12) + (leftM32 * rightM22) + (leftM33 * rightM32) + (leftM34 * rightM42);
            result.Row2.Z = (leftM31 * rightM13) + (leftM32 * rightM23) + (leftM33 * rightM33) + (leftM34 * rightM43);
            result.Row2.W = (leftM31 * rightM14) + (leftM32 * rightM24) + (leftM33 * rightM34) + (leftM34 * rightM44);
            result.Row3.X = (leftM41 * rightM11) + (leftM42 * rightM21) + (leftM43 * rightM31) + (leftM44 * rightM41);
            result.Row3.Y = (leftM41 * rightM12) + (leftM42 * rightM22) + (leftM43 * rightM32) + (leftM44 * rightM42);
            result.Row3.Z = (leftM41 * rightM13) + (leftM42 * rightM23) + (leftM43 * rightM33) + (leftM44 * rightM43);
            result.Row3.W = (leftM41 * rightM14) + (leftM42 * rightM24) + (leftM43 * rightM34) + (leftM44 * rightM44);

            return result;
        }

        public static Matrix4 operator *(Matrix4 left, Matrix4 right)
            => Mult(left, right);

        public static Vector4 Mult(Matrix4 mat, Vector4 vec)
        {
            return new Vector4(
                mat.Row0.X * vec.X + mat.Row0.Y * vec.Y + mat.Row0.Z * vec.Z + mat.Row0.W * vec.W,
                mat.Row1.X * vec.X + mat.Row1.Y * vec.Y + mat.Row1.Z * vec.Z + mat.Row1.W * vec.W,
                mat.Row2.X * vec.X + mat.Row2.Y * vec.Y + mat.Row2.Z * vec.Z + mat.Row2.W * vec.W,
                mat.Row3.X * vec.X + mat.Row3.Y * vec.Y + mat.Row3.Z * vec.Z + mat.Row3.W * vec.W
            );
        }

        public static Vector4 operator *(Matrix4 mat, Vector4 vec)
            => Mult(mat, vec);

        public static Vector4 operator *(Vector4 vec, Matrix4 mat)
            => Mult(mat, vec);
    }
}
