using System.Runtime.InteropServices;

namespace _3DEngine.Core.Mathematics
{
    /// <summary>
    /// Структура, представляющая трёхмерный вектор (X, Y, Z).
    /// Используется для хранения и обработки координат, направлений, нормалей и других данных в 3D-пространстве.
    /// </summary>
    public struct Vector3
    {
        /// <summary>
        /// Вектор (1, 1, 1). Все координаты равны единице.
        /// </summary>
        public static Vector3 One => new Vector3(1, 1, 1);

        /// <summary>
        /// Вектор (0, 0, 0). Все координаты равны нулю.
        /// </summary>
        public static Vector3 Zero => new Vector3(0, 0, 0);

        /// <summary>
        /// Вектор (1, 0, 0). Единица по оси X, остальные координаты равны нулю.
        /// </summary>
        public static Vector3 UnitX => new Vector3(1, 0, 0);

        /// <summary>
        /// Вектор (0, 1, 0). Единица по оси Y, остальные координаты равны нулю.
        /// </summary>
        public static Vector3 UnitY => new Vector3(0, 1, 0);

        /// <summary>
        /// Вектор (0, 0, 1). Единица по оси Z, остальные координаты равны нулю.
        /// </summary>
        public static Vector3 UnitZ => new Vector3(0, 0, 1);

        /// <summary>
        /// Размер структуры Vector3 в байтах.
        /// </summary>
        public static int Size => Marshal.SizeOf(typeof(Vector3));

        /// <summary>
        /// Координата X (горизонталь).
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Координата Y (вертикаль).
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Координата Z (глубина).
        /// </summary>
        public float Z { get; set; }

        /// <summary>
        /// Длина (модуль) вектора.
        /// </summary>
        public float Length => MathF.Sqrt((X * X) + (Y * Y) + (Z * Z));

        /// <summary>
        /// Квадрат длины вектора (без извлечения корня).
        /// </summary>
        public float QuadraticLength => (X * X) + (Y * Y) + (Z * Z);

        /// <summary>
        /// Создаёт вектор, у которого все координаты равны value.
        /// </summary>
        /// <param name="value">Значение для всех координат.</param>
        public Vector3(float value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        /// <summary>
        /// Создаёт вектор с заданными координатами X, Y и Z.
        /// </summary>
        /// <param name="x">Значение по оси X.</param>
        /// <param name="y">Значение по оси Y.</param>
        /// <param name="z">Значение по оси Z.</param>
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Возвращает нормализованный вектор (длина равна 1, если исходный вектор не нулевой).
        /// </summary>
        /// <param name="vector">Исходный вектор.</param>
        /// <returns>Нормализованный вектор.</returns>
        public static Vector3 Normalize(Vector3 vector)
        {
            float scale = 1f / vector.Length;
            float x = vector.X * scale;
            float y = vector.Y * scale;
            float z = vector.Z * scale;

            return new Vector3(x, y, z);
        }

        /// <summary>
        /// Векторное произведение двух векторов.
        /// </summary>
        /// <param name="a">Первый вектор.</param>
        /// <param name="b">Второй вектор.</param>
        /// <returns>Вектор, являющийся результатом векторного произведения.</returns>
        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            Vector3 result = new Vector3();

            result.X = (a.Y * b.Z) - (a.Z * b.Y);
            result.Y = (a.Z * b.X) - (a.X * b.Z);
            result.Z = (a.X * b.Y) - (a.Y * b.X);

            return result;
        }

        /// <summary>
        /// Скалярное произведение двух векторов.
        /// </summary>
        /// <param name="a">Первый вектор.</param>
        /// <param name="b">Второй вектор.</param>
        /// <returns>Скалярное произведение.</returns>
        public static float Dot(Vector3 a, Vector3 b)
        {
            return (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z);
        }

        /// <summary>
        /// Сложение двух векторов.
        /// </summary>
        public static Vector3 operator +(Vector3 v1, Vector3 v2) =>
            new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

        /// <summary>
        /// Вычитание двух векторов.
        /// </summary>
        public static Vector3 operator -(Vector3 v1, Vector3 v2) =>
            new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);

        /// <summary>
        /// Умножение вектора на скаляр.
        /// </summary>
        public static Vector3 operator *(Vector3 v, float value) =>
            new Vector3(v.X * value, v.Y * value, v.Z * value);

        /// <summary>
        /// Умножение скаляра на вектор.
        /// </summary>
        public static Vector3 operator *(float value, Vector3 v) =>
            new Vector3(v.X * value, v.Y * value, v.Z * value);

        /// <summary>
        /// Деление вектора на скаляр.
        /// </summary>
        public static Vector3 operator /(Vector3 v, float value) =>
            new Vector3(v.X / value, v.Y / value, v.Z / value);

        public static Vector3 operator -(Vector3 v) =>
            new Vector3(-v.X, -v.Y, -v.Z);
    }
}
