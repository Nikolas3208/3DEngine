using _3DEngine.Core.Resources;
using _3DEngine.Renderer.Resources.Loaders;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DEngine.Renderer.Resources
{
    public class Mesh : Asset
    {
        private List<VertexArray> vertexArrays;

        public Mesh(List<VertexArray> vertexArrays)
        {
            this.vertexArrays = vertexArrays;
        }

        public Mesh(MetaData metaData) : base(metaData)
        {
            vertexArrays = MeshLoader.LoadFromFile(metaData.FilePath).vertexArrays;
        }

        public void Draw()
        {
            for(int i = 0; i < vertexArrays.Count; i++)
            {
                var va = vertexArrays[i];
                va.Bind();
                GL.DrawElements(PrimitiveType.Triangles, va.ElementCount, DrawElementsType.UnsignedInt, 0);
                va.Unbind();
            }
        }
    }
}
