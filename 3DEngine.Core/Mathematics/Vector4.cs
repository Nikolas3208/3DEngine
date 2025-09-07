using System.Runtime.InteropServices;

namespace _3DEngine.Core.Mathematics
{
    /// <summary>
    /// Структура, представляющая четырёхмерный вектор (X, Y, Z, W).
    /// Используется для математических операций в 3D/4D графике и вычислениях.
    /// </summary>
    public struct Vector4
    {
        /// <summary>
        /// Вектор (0, 0, 0, 0). Все компоненты равны нулю.
        /// Используется для представления нулевого вектора.
        /// </summary>
        public static Vector4 Zero => new Vector4(0, 0, 0, 0);
        /// <summary>
        /// Вектор (1, 1, 1, 1). Все компоненты равны единице.
        /// Удобен для инициализации или сравнения.
        /// </summary>
        public static Vector4 One => new Vector4(1, 1, 1, 1);
        /// <summary>
        /// Единичный вектор вдоль оси X: (1, 0, 0, 0).
        /// Используется для выделения или работы только с X-компонентой.
        /// </summary>
        public static Vector4 UnitX => new Vector4(1, 0, 0, 0);
        /// <summary>
        /// Единичный вектор вдоль оси Y: (0, 1, 0, 0).
        /// Используется для выделения или работы только с Y-компонентой.
        /// </summary>
        public static Vector4 UnitY => new Vector4(0, 1, 0, 0);
        /// <summary>
        /// Единичный вектор вдоль оси Z: (0, 0, 1, 0).
        /// Используется для выделения или работы только с Z-компонентой.
        /// </summary>
        public static Vector4 UnitZ => new Vector4(0, 0, 1, 0);
        /// <summary>
        /// Единичный вектор вдоль оси W: (0, 0, 0, 1).
        /// Используется для выделения или работы только с W-компонентой.
        /// </summary>
        public static Vector4 UnitW => new Vector4(0, 0, 0, 1);

        /// <summary>
        /// Размер структуры Vector4 в байтах.
        /// </summary>
        public static int Size = Marshal.SizeOf(typeof(Vector4));

        /// <summary>
        /// X-компонента вектора.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Y-компонента вектора.
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Z-компонента вектора.
        /// </summary>
        public float Z { get; set; }

        /// <summary>
        /// W-компонента вектора.
        /// </summary>
        public float W { get; set; }

        public float Length => MathF.Sqrt((X * X) + (Y * Y) + (Z * Z) + (W * W));

        public float QuadraticLength => (X * X) + (Y * Y) + (Z * Z) + (W * W);

        /// <summary>
        /// Создаёт новый вектор, все компоненты которого равны value.
        /// </summary>
        /// <param name="value">Значение для всех компонентов.</param>
        public Vector4(float value)
        {
            X = value;
            Y = value;
            Z = value;
            W = value;
        }

        /// <summary>
        /// Создаёт новый вектор с заданными компонентами.
        /// </summary>
        /// <param name="x">X-компонента.</param>
        /// <param name="y">Y-компонента.</param>
        /// <param name="z">Z-компонента.</param>
        /// <param name="w">W-компонента.</param>
        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public static Vector4 Normalize(Vector4 vector)
        {
            float scale = 1f / vector.Length;
            float x = vector.X * scale;
            float y = vector.Y * scale;
            float z = vector.Z * scale;
            float w = vector.W * scale;

            return new Vector4(x, y, z, w);
        }

        public static Vector4 Cross(Vector4 a, Vector4 b)
        {
            Vector4 result = new Vector4();

            result.X = (a.Y * b.Z) - (a.Z * b.Y);
            result.Y = (a.Z * b.X) - (a.X * b.Z);
            result.Z = (a.X * b.Y) - (a.Y * b.X);
            result.W = 0;

            return result;
        }

        public static float Dot(Vector4 a, Vector4 b)
        {
            return (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z) + (a.W * b.W);
        }

        /// <summary>
        /// Сложение двух векторов.
        /// </summary>
        public static Vector4 operator +(Vector4 v1, Vector4 v2) =>
            new Vector4(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z, v1.W + v2.W);

        /// <summary>
        /// Вычитание одного вектора из другого.
        /// </summary>
        public static Vector4 operator -(Vector4 v1, Vector4 v2) =>
            new Vector4(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z, v1.W - v2.W);

        /// <summary>
        /// Умножение вектора на скаляр.
        /// </summary>
        public static Vector4 operator *(Vector4 v, float value) =>
            new Vector4(v.X * value, v.Y * value, v.Z * value, v.W * value);

        /// <summary>
        /// Умножение скаляра на вектор.
        /// </summary>
        public static Vector4 operator *(float value, Vector4 v) =>
            new Vector4(v.X * value, v.Y * value, v.Z * value, v.W * value);

        /// <summary>
        /// Деление вектора на скаляр.
        /// </summary>
        public static Vector4 operator /(Vector4 v, float value) =>
            new Vector4(v.X / value, v.Y / value, v.Z / value, v.W / value);

        public static Vector4 operator -(Vector4 v) =>
            new Vector4(-v.X, -v.Y, -v.Z, -v.W);
    }
}
