using _3DEngine.Core.Mathematics;

namespace _3DEngine.Renderer
{
    public struct Material
    {
        private Shader shader;

        private List<Texture> textures;

        public Vector3 Ambient { get; set; }

        public Vector3 Diffuse { get; set; }

        public Vector3 Specular { get; set; }

        public float Sheniness { get; set; }

        public Material(Shader shader, Vector3 ambient, Vector3 diffuse, Vector3 specular)
        {
            this.shader = shader;

            Ambient = ambient;
            Diffuse = diffuse;
            Specular = specular;

            textures = new List<Texture>();
        }

        public Material(Shader shader, Vector3 ambient, Vector3 diffuse, Vector3 specular, List<Texture> textures) : this(shader, ambient, diffuse, specular)
        {
            this.textures = textures;
        }
    }
}
