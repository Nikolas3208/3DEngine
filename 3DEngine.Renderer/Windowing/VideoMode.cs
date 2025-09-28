using _3DEngine.Core.Mathematics;
using OpenTK.Windowing.Desktop;


namespace _3DEngine.Renderer.Windowing
{
    /// <summary>
    /// Структура, описывающая режим видеовывода (разрешение экрана).
    /// Используется для задания размеров окна или рендер-таргета.
    /// </summary>
    public struct VideoMode
    {
        /// <summary>
        /// Ширина экрана или окна в пикселях.
        /// </summary>
        public int Width;

        /// <summary>
        /// Высота экрана или окна в пикселях.
        /// </summary>
        public int Height;

        /// <summary>
        /// Создаёт новый режим видеовывода на основе двумерного вектора.
        /// </summary>
        /// <param name="size">Вектор с шириной и высотой.</param>
        public VideoMode(Vector2i size)
        {
            Width = size.X;
            Height = size.Y;
        }

        /// <summary>
        /// Создаёт новый режим видеовывода с заданной шириной и высотой.
        /// </summary>
        /// <param name="width">Ширина в пикселях.</param>
        /// <param name="height">Высота в пикселях.</param>
        public VideoMode(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Возвращает режим видеовывода для основного монитора по умолчанию (текущее разрешение экрана).
        /// </summary>
        public static VideoMode Default
        {
            get
            {
                var primaryMonitorMode = Monitors.GetMonitors().First().CurrentVideoMode;
                return new VideoMode(primaryMonitorMode.Width, primaryMonitorMode.Height);
            }
        }
    }
}
