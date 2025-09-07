namespace _3DEngine.Core.Mathematics
{
    /// <summary>
    /// Структура, представляющая цвет в формате RGBA с компонентами в виде чисел с плавающей точкой.
    /// Используется для хранения и передачи информации о цвете в графических приложениях.
    /// </summary>
    public struct Color4
    {
        /// <summary>
        /// Красная компонента цвета (R).
        /// </summary>
        public float R;

        /// <summary>
        /// Зелёная компонента цвета (G).
        /// </summary>
        public float G;

        /// <summary>
        /// Синяя компонента цвета (B).
        /// </summary>
        public float B;

        /// <summary>
        /// Альфа-компонента (прозрачность) цвета (A).
        /// </summary>
        public float A;

        /// <summary>
        /// Создаёт новый цвет с заданными компонентами RGBA.
        /// </summary>
        /// <param name="r">Красная компонента.</param>
        /// <param name="g">Зелёная компонента.</param>
        /// <param name="b">Синяя компонента.</param>
        /// <param name="a">Альфа-компонента.</param>
        public Color4(float r, float g, float b, float a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        /// <summary>
        /// Чёрный цвет (0, 0, 0, 255).
        /// </summary>
        public static Color4 Black => new Color4(0, 0, 0, byte.MaxValue);

        /// <summary>
        /// Белый цвет (255, 255, 255, 255).
        /// </summary>
        public static Color4 White => new Color4(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

        /// <summary>
        /// Красный цвет (255, 0, 0, 255).
        /// </summary>
        public static Color4 Red => new Color4(byte.MaxValue, 0, 0, byte.MaxValue);

        /// <summary>
        /// Зелёный цвет (0, 255, 0, 255).
        /// </summary>
        public static Color4 Green => new Color4(0, byte.MaxValue, 0, byte.MaxValue);

        /// <summary>
        /// Синий цвет (0, 0, 255, 255).
        /// </summary>
        public static Color4 Blue => new Color4(0, 0, byte.MaxValue, byte.MaxValue);

        /// <summary>
        /// Бирюзовый цвет (0, 255, 255, 255).
        /// </summary>
        public static Color4 Cyan => new Color4(0, byte.MaxValue, byte.MaxValue, byte.MaxValue);

        /// <summary>
        /// Пурпурный цвет (255, 0, 255, 255).
        /// </summary>
        public static Color4 Magenta => new Color4(byte.MaxValue, 0, byte.MaxValue, byte.MaxValue);
    }
}
