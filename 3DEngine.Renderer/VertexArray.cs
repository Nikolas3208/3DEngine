using _3DEngine.Core.Mathematics;
using _3DEngine.Renderer.Buffers;
using OpenTK.Graphics.OpenGL4;

namespace _3DEngine.Renderer
{
    /// <summary>
    /// Массив вершин и индексов
    /// </summary>
    public class VertexArray
    {
        /// <summary>
        /// Буффер вершин
        /// </summary>
        private VertexBuffer vertexBuffer;

        /// <summary>
        /// Буффер индексов
        /// </summary>
        private IndexBuffer indexBuffer;

        /// <summary>
        /// Програма ( буффер )
        /// </summary>
        public int Handle { get; }

        /// <summary>
        /// Количество елементов
        /// </summary>
        public int ElementCount => indexBuffer.Count;

        /// <summary>
        /// Массив вершин и индексов
        /// </summary>
        /// <param name="vertexBuffer"> Буфер вершин </param>
        /// <param name="indexBuffer"> Буфер индексов </param>
        public VertexArray(VertexBuffer vertexBuffer, IndexBuffer indexBuffer)
        {
            this.vertexBuffer = vertexBuffer;
            this.indexBuffer = indexBuffer;

            Handle = GL.GenVertexArray();

            Initialize();
        }

        /// <summary>
        /// Инициализация вершин и индексов
        /// </summary>
        private void Initialize()
        {
            GL.BindVertexArray(Handle);

            vertexBuffer.Bind();
            indexBuffer.Bind();

            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, Vertex.Size, 0);

            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, Vertex.Size, Vector3.Size);

            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, Vertex.Size, Vector3.Size * 2);

            indexBuffer.Unbind();
            vertexBuffer.Unbind();
            GL.BindVertexArray(0);

            GL.DisableVertexAttribArray(0);
            GL.DisableVertexAttribArray(1);
            GL.DisableVertexAttribArray(2);
        }

        /// <summary>
        /// Приязать массив вершин
        /// </summary>
        public void Bind()
        {
            GL.BindVertexArray(Handle);
            vertexBuffer.Bind();
            indexBuffer.Bind();
        }

        /// <summary>
        /// Отвязать массив вершин
        /// </summary>
        public void Unbind()
        {
            indexBuffer.Unbind();
            vertexBuffer.Unbind();
            GL.BindVertexArray(0);
        }

        /// <summary>
        /// Удалить массив вершин
        /// </summary>
        ~VertexArray()
        {
            GL.DeleteVertexArray(Handle);
        }
    }
}
