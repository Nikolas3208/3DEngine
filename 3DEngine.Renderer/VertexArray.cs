using _3DEngine.Core.Mathematics;
using _3DEngine.Renderer.Buffers;
using OpenTK.Graphics.OpenGL4;

namespace _3DEngine.Renderer
{
    /// <summary>
    /// Класс для управления массивом вершин и индексов в OpenGL.
    /// Инкапсулирует работу с VAO (Vertex Array Object), VBO (Vertex Buffer Object) и IBO (Index Buffer Object).
    /// Используется для хранения и организации данных о геометрии, необходимых для рендеринга.
    /// </summary>
    public class VertexArray
    {
        /// <summary>
        /// Буфер вершин (VBO), содержащий массив вершин.
        /// </summary>
        private VertexBuffer vertexBuffer;

        /// <summary>
        /// Буфер индексов (IBO), содержащий массив индексов.
        /// </summary>
        private IndexBuffer indexBuffer;

        /// <summary>
        /// Дескриптор VAO (Vertex Array Object) в OpenGL.
        /// </summary>
        public int Handle { get; }

        /// <summary>
        /// Количество элементов (индексов) в массиве.
        /// </summary>
        public int ElementCount => indexBuffer.Count;

        /// <summary>
        /// Создаёт объект VertexArray на основе уже существующих буферов вершин и индексов.
        /// </summary>
        /// <param name="vertexBuffer">Буфер вершин.</param>
        /// <param name="indexBuffer">Буфер индексов.</param>
        public VertexArray(VertexBuffer vertexBuffer, IndexBuffer indexBuffer)
        {
            this.vertexBuffer = vertexBuffer;
            this.indexBuffer = indexBuffer;

            Handle = GL.GenVertexArray();

            Initialize();
        }

        /// <summary>
        /// Создаёт объект VertexArray на основе массивов вершин и индексов.
        /// Внутри создаются соответствующие буферы.
        /// </summary>
        /// <param name="vertices">Массив вершин.</param>
        /// <param name="indices">Массив индексов.</param>
        public VertexArray(Vertex[] vertices, uint[] indices)
        {
            vertexBuffer = new VertexBuffer(vertices);
            indexBuffer = new IndexBuffer(indices);

            Handle = GL.GenVertexArray();

            Initialize();
        }

        /// <summary>
        /// Инициализация VAO: связывает буферы, настраивает атрибуты вершин.
        /// </summary>
        private void Initialize()
        {
            GL.BindVertexArray(Handle);

            vertexBuffer.Bind();
            indexBuffer.Bind();

            // Атрибут 0: позиция (3 float)
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, Vertex.Size, 0);

            // Атрибут 1: нормаль (3 float)
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, Vertex.Size, Vector3.Size);

            // Атрибут 2: текстурные координаты (2 float)
            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 2, VertexAttribPointerType.Float, false, Vertex.Size, Vector3.Size * 2);

            indexBuffer.Unbind();
            vertexBuffer.Unbind();
            GL.BindVertexArray(0);

            GL.DisableVertexAttribArray(0);
            GL.DisableVertexAttribArray(1);
            GL.DisableVertexAttribArray(2);
        }

        /// <summary>
        /// Активирует (связывает) VAO и связанные буферы для рендеринга.
        /// </summary>
        public void Bind()
        {
            GL.BindVertexArray(Handle);
            vertexBuffer.Bind();
            indexBuffer.Bind();
        }

        /// <summary>
        /// Деактивирует (отвязывает) VAO и связанные буферы.
        /// </summary>
        public void Unbind()
        {
            indexBuffer.Unbind();
            vertexBuffer.Unbind();
            GL.BindVertexArray(0);
        }

        /// <summary>
        /// Освобождает ресурсы VAO при уничтожении объекта.
        /// </summary>
        ~VertexArray()
        {
            GL.DeleteVertexArray(Handle);
        }
    }
}
