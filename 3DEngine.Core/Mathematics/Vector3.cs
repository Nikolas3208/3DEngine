using System.Runtime.InteropServices;

namespace _3DEngine.Core.Mathematics
{
    /// <summary>
    /// Трехмерный вектор
    /// </summary>
    public struct Vector3
    {
        /// <summary>
        /// Размер вектора в байтах
        /// </summary>
        public static int Size => Marshal.SizeOf(typeof(Vector3));

        /// <summary>
        /// Координата вектора по горизонтали
        /// </summary>
        public float X { get; }

        /// <summary>
        /// Координата вектора по вертикале
        /// </summary>
        public float Y { get; }

        /// <summary>
        /// Координата вектора по глубине
        /// </summary>
        public float Z { get; }

        /// <summary>
        /// Все координаты вектра будут равны value
        /// </summary>
        /// <param name="value"> Значение </param>
        public Vector3(float value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        /// <summary>
        /// Задать каждой координат свое значение
        /// </summary>
        /// <param name="x"> Горизонталь </param>
        /// <param name="y"> Вертикаль </param>
        /// <param name="z"> Глубина </param>
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Все координаты равны единице
        /// </summary>
        public static Vector3 One = new Vector3(1, 1, 1);

        /// <summary>
        /// Все координаты равны нулю
        /// </summary>
        public static Vector3 Zero = new Vector3(0, 0, 0);

        /// <summary>
        /// Координата по горизонтали единица все остальные ноль
        /// </summary>
        public static Vector3 UnitX = new Vector3(1, 0, 0);

        /// <summary>
        /// Координата по вертикале единица все остальные ноль
        /// </summary>
        public static Vector3 UnitY = new Vector3(0, 1, 0);

        /// <summary>
        /// Координата по глубине единица все остальные ноль
        /// </summary>
        public static Vector3 UnitZ = new Vector3(0, 0, 1);

        /// <summary>
        /// Сложение двух векторов
        /// </summary>
        /// <param name="v1"> Вектор 1 </param>
        /// <param name="v2"> Вектор 2 </param>
        /// <returns> Новый вектор содержайший суму векторов <see cref="Vector3"/> </returns>
        public static Vector3 operator +(Vector3 v1, Vector3 v2) => 
            new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

        /// <summary>
        /// Вычитание двух векторов
        /// </summary>
        /// <param name="v1"> Вектор 1 </param>
        /// <param name="v2"> Вектор 2 </param>
        /// <returns> Новый вектор содежаший разницу векторов <see cref="Vector3"/> </returns>
        public static Vector3 operator -(Vector3 v1, Vector3 v2) =>
            new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);

        /// <summary>
        /// Умножение вектора на число
        /// </summary>
        /// <param name="v"> Вектор </param>
        /// <param name="value"> Число </param>
        /// <returns> Новый вектор содержаший умноженные координаты вектора <see cref="Vector3"/> на число </returns>
        public static Vector3 operator *(Vector3 v, float value) =>
            new Vector3(v.X * value, v.Y * value, v.Z * value);

        /// <summary>
        /// Умножение вектора на число
        /// </summary>
        /// <param name="value"> Число </param>
        /// <param name="v"> Вектор </param>
        /// <returns> Новый вектор содержаший умноженные координаты вектора <see cref="Vector3"/> на число </returns>
        public static Vector3 operator *(float value, Vector3 v) =>
            new Vector3(v.X * value, v.Y * value, v.Z * value);

        /// <summary>
        /// Деление вектора на число
        /// </summary>
        /// <param name="v"> вектор </param>
        /// <param name="value"> Число </param>
        /// <returns> Новый вектор координаты которого равны разделенным координатам вектора <paramref name="v"/> на число <paramref name="value"/> </returns>
        public static Vector3 operator /(Vector3 v, float value) =>
            new Vector3(v.X / value, v.Y / value, v.Z / value);
    }
}
