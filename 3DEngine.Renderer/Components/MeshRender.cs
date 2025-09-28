using _3DEngine.Core;
using _3DEngine.Renderer.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DEngine.Renderer.Components
{
    public class MeshRender : Component
    {
        public Mesh? Mesh { get; set; }
        public Material Material { get; set; }

        public MeshRender()
        {
            
        }

        public void Draw()
        {
            if (Mesh == null)
                return;

            var shader = Material.Shader;

            shader?.SetMatrix4("model", transform.Model);

            Mesh.Draw();
        }
    }
}
