using System.Runtime.InteropServices;

namespace _3DEngine.Core.Mathematics
{
    /// <summary>
    /// Структура, представляющая двумерный вектор (X, Y) с координатами типа float.
    /// Используется для хранения и обработки координат, направлений, смещений и других данных в 2D-пространстве.
    /// </summary>
    public struct Vector2
    {
        /// <summary>
        /// Вектор (1, 1). Все координаты равны единице.
        /// </summary>
        public static Vector2 One => new Vector2(1, 1);

        /// <summary>
        /// Вектор (0, 0). Все координаты равны нулю.
        /// </summary>
        public static Vector2 Zero => new Vector2(0, 0);

        /// <summary>
        /// Вектор (1, 0). Единица по оси X, остальные координаты равны нулю.
        /// </summary>
        public static Vector2 UnitX => new Vector2(1, 0);

        /// <summary>
        /// Вектор (0, 1). Единица по оси Y, остальные координаты равны нулю.
        /// </summary>
        public static Vector2 UnitY => new Vector2(0, 1);

        /// <summary>
        /// Размер структуры Vector2 в байтах.
        /// </summary>
        public static int SizeInBytes => Marshal.SizeOf(typeof(Vector2));

        /// <summary>
        /// Координата X (горизонталь).
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Координата Y (вертикаль).
        /// </summary>
        public float Y { get; set; }

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
        public Vector2(float value)
        {
            X = value;
            Y = value;
        }

        /// <summary>
        /// Создаёт вектор с заданными координатами X и Y.
        /// </summary>
        /// <param name="x">Значение по оси X.</param>
        /// <param name="y">Значение по оси Y.</param>
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Возвращает нормализованный вектор (длина равна 1, если исходный вектор не нулевой).
        /// </summary>
        /// <param name="vector">Исходный вектор.</param>
        /// <returns>Нормализованный вектор.</returns>
        public static Vector2 Normalize(Vector2 vector)
        {
            float scale = 1f / vector.Length;
            float x = vector.X * scale;
            float y = vector.Y * scale;

            return new Vector2(x, y);
        }

        /// <summary>
        /// Векторное произведение (псевдоскаляр) двух векторов.
        /// </summary>
        /// <param name="a">Первый вектор.</param>
        /// <param name="b">Второй вектор.</param>
        /// <returns>Псевдоскалярное произведение.</returns>
        public static float Cross(Vector2 a, Vector2 b)
        {
            return (a.X * b.Y) - (a.Y * b.X);
        }

        /// <summary>
        /// Скалярное произведение двух векторов.
        /// </summary>
        /// <param name="a">Первый вектор.</param>
        /// <param name="b">Второй вектор.</param>
        /// <returns>Скалярное произведение.</returns>
        public static float Dot(Vector2 a, Vector2 b)
        {
            return (a.X * b.X) + (a.Y * b.Y);
        }

        /// <summary>
        /// Сложение двух векторов.
        /// </summary>
        public static Vector2 operator +(Vector2 v1, Vector2 v2) =>
            new Vector2(v1.X + v2.X, v1.Y + v2.Y);

        /// <summary>
        /// Вычитание двух векторов.
        /// </summary>
        public static Vector2 operator -(Vector2 v1, Vector2 v2) =>
            new Vector2(v1.X - v2.X, v1.Y - v2.Y);

        /// <summary>
        /// Умножение вектора на скаляр.
        /// </summary>
        public static Vector2 operator *(Vector2 v, float value) =>
            new Vector2(v.X * value, v.Y * value);

        /// <summary>
        /// Умножение скаляра на вектор.
        /// </summary>
        public static Vector2 operator *(float value, Vector2 v) =>
            new Vector2(v.X * value, v.Y * value);

        /// <summary>
        /// Деление вектора на скаляр.
        /// </summary>
        public static Vector2 operator /(Vector2 v, float value) =>
            new Vector2(v.X / value, v.Y / value);

        public static Vector2 operator -(Vector2 v) =>
            new Vector2(-v.X, -v.Y);
    }
}
