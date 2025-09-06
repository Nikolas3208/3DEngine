using OpenTK.Graphics.OpenGL4;

namespace _3DEngine.Renderer.Buffers
{
    /// <summary>
    /// Буфер вершин
    /// </summary>
    public class VertexBuffer
    {
        /// <summary>
        /// Массив вершин
        /// </summary>
        private Vertex[] vertices;

        /// <summary>
        /// Программа ( буфер )
        /// </summary>
        public int Handle { get; }

        /// <summary>
        /// Количество вершин
        /// </summary>
        public int Count => vertices.Length;

        /// <summary>
        /// Буфер вершин
        /// </summary>
        /// <param name="vertices"> Массив вершин </param>
        public VertexBuffer(Vertex[] vertices)
        {
            this.vertices = vertices;

            Handle = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, Handle);
            GL.BufferData(BufferTarget.ArrayBuffer, Vertex.Size * vertices.Length, vertices, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        /// <summary>
        /// Связать буфер
        /// </summary>
        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, Handle);
        }

        /// <summary>
        /// Отвязать буфер
        /// </summary>
        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        /// <summary>
        /// Удаление буфера
        /// </summary>
        ~VertexBuffer()
        {
            GL.DeleteBuffer(Handle);
        }
    }
}
