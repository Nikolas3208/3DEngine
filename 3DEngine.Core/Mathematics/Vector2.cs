using System.Runtime.InteropServices;

namespace _3DEngine.Core.Mathematics
{
    /// <summary>
    /// Двумерный вектор
    /// </summary>
    public struct Vector2
    {
        /// <summary>
        /// Размер вектора в байтах
        /// </summary>
        public static int Size => Marshal.SizeOf(typeof(Vector2));

        /// <summary>
        /// Координата вектора по горизонтали
        /// </summary>
        public float X { get; }

        /// <summary>
        /// Координата вектора по вертикале
        /// </summary>
        public float Y { get; }


        /// <summary>
        /// Все координаты вектра будут равны value
        /// </summary>
        /// <param name="value"> Значение </param>
        public Vector2(float value)
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
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Все координаты равны единице
        /// </summary>
        public static Vector2 One = new Vector2(1, 1);

        /// <summary>
        /// Все координаты равны нулю
        /// </summary>
        public static Vector2 Zero = new Vector2(0, 0);

        /// <summary>
        /// Координата по горизонтали единица все остальные ноль
        /// </summary>
        public static Vector2 UnitX = new Vector2(1, 0);

        /// <summary>
        /// Координата по вертикале единица все остальные ноль
        /// </summary>
        public static Vector2 UnitY = new Vector2(0, 1);

        /// <summary>
        /// Сложение двух векторов
        /// </summary>
        /// <param name="v1"> Вектор 1 </param>
        /// <param name="v2"> Вектор 2 </param>
        /// <returns> Новый вектор содержайший суму векторов <see cref="Vector2"/> </returns>
        public static Vector2 operator +(Vector2 v1, Vector2 v2) =>
            new Vector2(v1.X + v2.X, v1.Y + v2.Y);

        /// <summary>
        /// Вычитание двух векторов
        /// </summary>
        /// <param name="v1"> Вектор 1 </param>
        /// <param name="v2"> Вектор 2 </param>
        /// <returns> Новый вектор содежаший разницу векторов <see cref="Vector2"/> </returns>
        public static Vector2 operator -(Vector2 v1, Vector2 v2) =>
            new Vector2(v1.X - v2.X, v1.Y - v2.Y);

        /// <summary>
        /// Умножение вектора на число
        /// </summary>
        /// <param name="v"> Вектор </param>
        /// <param name="value"> Число </param>
        /// <returns> Новый вектор содержаший умноженные координаты вектора <see cref="Vector2"/> на число </returns>
        public static Vector2 operator *(Vector2 v, float value) =>
            new Vector2(v.X * value, v.Y * value);

        /// <summary>
        /// Умножение вектора на число
        /// </summary>
        /// <param name="value"> Число </param>
        /// <param name="v"> Вектор </param>
        /// <returns> Новый вектор содержаший умноженные координаты вектора <see cref="Vector2"/> на число </returns>
        public static Vector2 operator *(float value, Vector2 v) =>
            new Vector2(v.X * value, v.Y * value);

        /// <summary>
        /// Деление вектора на число
        /// </summary>
        /// <param name="v"> вектор </param>
        /// <param name="value"> Число </param>
        /// <returns> Новый вектор координаты которого равны разделенным координатам вектора <paramref name="v"/> на число <paramref name="value"/> </returns>
        public static Vector2 operator /(Vector2 v, float value) =>
            new Vector2(v.X / value, v.Y / value);
    }
}
