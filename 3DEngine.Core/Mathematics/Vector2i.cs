using System.Runtime.InteropServices;

namespace _3DEngine.Core.Mathematics
{
    /// <summary>
    /// Структура, представляющая двумерный целочисленный вектор (X, Y).
    /// Используется для хранения и обработки координат, размеров, смещений и других целочисленных данных в 2D-пространстве.
    /// </summary>
    public struct Vector2i
    {
        /// <summary>
        /// Вектор (1, 1). Все координаты равны единице.
        /// </summary>
        public static Vector2i One => new Vector2i(1, 1);

        /// <summary>
        /// Вектор (0, 0). Все координаты равны нулю.
        /// </summary>
        public static Vector2i Zero => new Vector2i(0, 0);

        /// <summary>
        /// Вектор (1, 0). Единица по оси X, остальные координаты равны нулю.
        /// </summary>
        public static Vector2i UnitX => new Vector2i(1, 0);

        /// <summary>
        /// Вектор (0, 1). Единица по оси Y, остальные координаты равны нулю.
        /// </summary>
        public static Vector2i UnitY => new Vector2i(0, 1);

        /// <summary>
        /// Размер структуры Vector2i в байтах.
        /// </summary>
        public static int SizeInBytes => Marshal.SizeOf(typeof(Vector2i));

        /// <summary>
        /// Координата X (горизонталь).
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Координата Y (вертикаль).
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Длина (модуль) вектора.
        /// </summary>
        public float Length => MathF.Sqrt((X * X) + (Y * Y));

        /// <summary>
        /// Квадрат длины вектора (без извлечения корня).
        /// </summary>
        public float QuadraticLength => (X * X) + (Y * Y);

        /// <summary>
        /// Создаёт вектор, у которого обе координаты равны value.
        /// </summary>
        /// <param name="value">Значение для обеих координат.</param>
        public Vector2i(int value)
        {
            X = value;
            Y = value;
        }

        /// <summary>
        /// Создаёт вектор с заданными координатами X и Y.
        /// </summary>
        /// <param name="x">Значение по оси X.</param>
        /// <param name="y">Значение по оси Y.</param>
        public Vector2i(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Возвращает нормализованный вектор (длина равна 1, если исходный вектор не нулевой).
        /// </summary>
        /// <param name="vector">Исходный вектор.</param>
        /// <returns>Нормализованный вектор.</returns>
        public static Vector2i Normalize(Vector2i vector)
        {
            float scale = 1f / vector.Length;
            int x = (int)(vector.X * scale);
            int y = (int)(vector.Y * scale);

            return new Vector2i(x, y);
        }

        /// <summary>
        /// Векторное произведение (псевдоскаляр) двух векторов.
        /// </summary>
        public static float Cross(Vector2i a, Vector2i b)
        {
            return (a.X * b.Y) - (a.Y * b.X);
        }

        /// <summary>
        /// Скалярное произведение двух векторов.
        /// </summary>
        public static float Dot(Vector2i a, Vector2i b)
        {
            return (a.X * b.X) + (a.Y * b.Y);
        }

        /// <summary>
        /// Сложение двух векторов.
        /// </summary>
        public static Vector2i operator +(Vector2i v1, Vector2i v2) =>
            new Vector2i(v1.X + v2.X, v1.Y + v2.Y);

        /// <summary>
        /// Вычитание двух векторов.
        /// </summary>
        public static Vector2i operator -(Vector2i v1, Vector2i v2) =>
            new Vector2i(v1.X - v2.X, v1.Y - v2.Y);

        /// <summary>
        /// Умножение вектора на скаляр.
        /// </summary>
        public static Vector2i operator *(Vector2i v, int value) =>
            new Vector2i(v.X * value, v.Y * value);

        /// <summary>
        /// Умножение скаляра на вектор.
        /// </summary>
        public static Vector2i operator *(int value, Vector2i v) =>
            new Vector2i(v.X * value, v.Y * value);

        /// <summary>
        /// Деление вектора на скаляр.
        /// </summary>
        public static Vector2i operator /(Vector2i v, int value) =>
            new Vector2i(v.X / value, v.Y / value);

        public static Vector2i operator -(Vector2i v) =>
            new Vector2i(-v.X, -v.Y);
    }
}
