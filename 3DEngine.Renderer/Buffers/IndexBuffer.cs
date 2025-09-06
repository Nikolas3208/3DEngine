using OpenTK.Graphics.OpenGL4;

namespace _3DEngine.Renderer.Buffers
{
    /// <summary>
    /// БУфер индексов
    /// </summary>
    public class IndexBuffer
    {
        /// <summary>
        /// Массив индексов
        /// </summary>
        private uint[] indices;

        /// <summary>
        /// Программа ( буфер )
        /// </summary>
        public int Handle { get; }

        /// <summary>
        /// Количество индексов
        /// </summary>
        public int Count => indices.Length;

        /// <summary>
        /// Бефер индексов
        /// </summary>
        /// <param name="indices"> Массив индексов </param>
        public IndexBuffer(uint[] indices)
        {
            this.indices = indices;

            Handle = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, Handle);
            GL.BufferData(BufferTarget.ElementArrayBuffer, sizeof(uint) * indices.Length, indices, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        /// <summary>
        /// Связать буфер
        /// </summary>
        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, Handle);
        }

        /// <summary>
        /// Отвязать буфер
        /// </summary>
        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        /// <summary>
        /// Удалить буфер
        /// </summary>
        ~IndexBuffer()
        {
            GL.DeleteBuffer(Handle);
        }
    }
}
