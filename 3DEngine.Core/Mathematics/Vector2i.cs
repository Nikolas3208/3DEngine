using System.Runtime.InteropServices;

namespace _3DEngine.Core.Mathematics
{
    /// <summary>
    /// Двумерный вектор
    /// </summary>
    public struct Vector2i
    {
        /// <summary>
        /// Все координаты равны единице
        /// </summary>
        public static Vector2i One => new Vector2i(1, 1);

        /// <summary>
        /// Все координаты равны нулю
        /// </summary>
        public static Vector2i Zero => new Vector2i(0, 0);

        /// <summary>
        /// Координата по горизонтали единица все остальные ноль
        /// </summary>
        public static Vector2i UnitX => new Vector2i(1, 0);

        /// <summary>
        /// Координата по вертикале единица все остальные ноль
        /// </summary>
        public static Vector2i UnitY => new Vector2i(0, 1);

        /// <summary>
        /// Размер вектора в байтах
        /// </summary>
        public static int Size => Marshal.SizeOf(typeof(Vector2i));

        /// <summary>
        /// Координата вектора по горизонтали
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Координата вектора по вертикале
        /// </summary>
        public int Y { get; set; }

        public float Length => MathF.Sqrt((X * X) + (Y * Y));

        public float QuadraticLength => (X * X) + (Y * Y);


        /// <summary>
        /// Все координаты вектра будут равны value
        /// </summary>
        /// <param name="value"> Значение </param>
        public Vector2i(int value)
        {
            X = value;
            Y = value;
        }

        /// <summary>
        /// Задать каждой координат свое значение
        /// </summary>
        /// <param name="x"> Горизонталь </param>
        /// <param name="y"> Вертикаль </param>
        /// <param name="z"> Глубина </param>
        public Vector2i(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector2i Normalize(Vector2i vector)
        {
            float scale = 1f / vector.Length;
            int x = (int)(vector.X * scale);
            int y = (int)(vector.Y * scale);

            return new Vector2i(x, y);
        }

        public static float Cross(Vector2i a, Vector2i b)
        {
            return (a.X * b.Y) - (a.Y * b.X);
        }

        public static float Dot(Vector2i a, Vector2i b)
        {
            return (a.X * b.X) + (a.Y * b.Y);
        }

        /// <summary>
        /// Сложение двух векторов
        /// </summary>
        /// <param name="v1"> Вектор 1 </param>
        /// <param name="v2"> Вектор 2 </param>
        /// <returns> Новый вектор содержайший суму векторов <see cref="Vector2i"/> </returns>
        public static Vector2i operator +(Vector2i v1, Vector2i v2) =>
            new Vector2i(v1.X + v2.X, v1.Y + v2.Y);

        /// <summary>
        /// Вычитание двух векторов
        /// </summary>
        /// <param name="v1"> Вектор 1 </param>
        /// <param name="v2"> Вектор 2 </param>
        /// <returns> Новый вектор содежаший разницу векторов <see cref="Vector2i"/> </returns>
        public static Vector2i operator -(Vector2i v1, Vector2i v2) =>
            new Vector2i(v1.X - v2.X, v1.Y - v2.Y);

        /// <summary>
        /// Умножение вектора на число
        /// </summary>
        /// <param name="v"> Вектор </param>
        /// <param name="value"> Число </param>
        /// <returns> Новый вектор содержаший умноженные координаты вектора <see cref="Vector2i"/> на число </returns>
        public static Vector2i operator *(Vector2i v, int value) =>
            new Vector2i(v.X * value, v.Y * value);

        /// <summary>
        /// Умножение вектора на число
        /// </summary>
        /// <param name="value"> Число </param>
        /// <param name="v"> Вектор </param>
        /// <returns> Новый вектор содержаший умноженные координаты вектора <see cref="Vector2i"/> на число </returns>
        public static Vector2i operator *(int value, Vector2i v) =>
            new Vector2i(v.X * value, v.Y * value);

        /// <summary>
        /// Деление вектора на число
        /// </summary>
        /// <param name="v"> вектор </param>
        /// <param name="value"> Число </param>
        /// <returns> Новый вектор координаты которого равны разделенным координатам вектора <paramref name="v"/> на число <paramref name="value"/> </returns>
        public static Vector2i operator /(Vector2i v, int value) =>
            new Vector2i(v.X / value, v.Y / value);
    }
}
