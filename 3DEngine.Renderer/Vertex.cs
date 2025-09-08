using _3DEngine.Core.Mathematics;
using System.Runtime.InteropServices;

namespace _3DEngine.Renderer
{
    /// <summary>
    /// Вершина
    /// </summary>
    public struct Vertex
    {
        /// <summary>
        /// Размер вершины в байтах
        /// </summary>
        public static int Size => Marshal.SizeOf(typeof(Vertex));

        /// <summary>
        /// Позиция вершины
        /// </summary>
        public Vector3 Position { get; set; }

        /// <summary>
        /// Нормаль вершины
        /// </summary>
        public Vector3 Normal { get; set; }

        /// <summary>
        /// Текстурные координаты вершины
        /// </summary>
        public Vector2 TexCoord { get; set; }

        /// <summary>
        /// Вершина у которой указана только позиция
        /// </summary>
        /// <param name="position"> Позиция вершины <see cref="Vector3"/> </param>
        public Vertex(Vector3 position)
        {
            Position = position;
        }

        /// <summary>
        /// Вершина с позицией и текстурными координатами
        /// </summary>
        /// <param name="position"> Позиция вершины <see cref="Vector3"/> </param>
        /// <param name="texCoord"> Тектсурные координаты вершины <see cref="Vector2"/> </param>
        public Vertex(Vector3 position, Vector2 texCoord)
        {
            Position = position;
            TexCoord = texCoord;
        }

        /// <summary>
        /// Вершина с позицией, текстурными координатами и нормалью
        /// </summary>
        /// <param name="position"> Позиция вершины <see cref="Vector3"/> </param>
        /// <param name="texCoord"> Тектсурные координаты вершины <see cref="Vector2"/> </param>
        /// <param name="normal"> Нормаль вершины <see cref="Vector3"/> </param>
        public Vertex(Vector3 position, Vector2 texCoord, Vector3 normal)
        {
            Position = position;
            TexCoord = texCoord;
            Normal = normal;
        }
    }
}
