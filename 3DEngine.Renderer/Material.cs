using _3DEngine.Core.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace _3DEngine.Renderer
{
    public class Material
    {
        private Shader shader;

        public Vector3 Ambient { get; set; }
        public Texture? AmbientTex {  get; set; }

        public Vector3 Diffuse { get; set; }
        public Texture? DiffuseTex {  get; set; }

        public Vector3 Specular { get; set; }
        public Texture? SpecularTex { get; set; }

        public float Shininess { get; set; }

        public Texture? NormalTex {  get; set; }

        public Material(Shader shader, Vector3 ambient, Vector3 diffuse, Vector3 specular, float sheniness)
        {
            this.shader = shader;

            Ambient = ambient;
            Diffuse = diffuse;
            Specular = specular;

            Shininess = sheniness;
        }

        public Material(Shader shader, Texture ambient, Texture diffuse, Texture specular, float sheniness)
        {
            this.shader = shader;

            AmbientTex = ambient;
            DiffuseTex = diffuse;
            SpecularTex = specular;

            Shininess = sheniness;
        }

        public void Bind()
        {
            if (shader == null)
                return;

            shader.SetVector3("material.ambient", Ambient);
            shader.SetVector3("material.diffuse", Diffuse);
            shader.SetVector3("material.specular", Specular);

            shader.SetFloat("material.shininess", Shininess);

            shader.SetBool("material.useAmbientTex", AmbientTex != null);
            shader.SetBool("material.useDiffuseTex", DiffuseTex != null);
            shader.SetBool("material.useSpecularTex", SpecularTex != null);
            shader.SetBool("material.useNormalTex", NormalTex != null);

            if (AmbientTex != null)
            {
                AmbientTex.Bind(TextureUnit.Texture0);
                shader.SetInt("material.ambientTex", 0);
            }
            if(DiffuseTex != null)
            {
                DiffuseTex.Bind(TextureUnit.Texture1);
                shader.SetInt("material.diffuseTex", 1);
            }
            if(SpecularTex != null)
            {
                SpecularTex.Bind(TextureUnit.Texture2);
                shader.SetInt("material.specularTex", 2);
            }
            if(NormalTex != null)
            {
                NormalTex.Bind(TextureUnit.Texture3);
                shader.SetInt("material.normalTex", 3);
            }

            shader.Use();
        }

        public void Unbind()
        {
            AmbientTex?.Unbind();
            DiffuseTex?.Unbind();
            SpecularTex?.Unbind();
            NormalTex?.Unbind();
        }
    }
}
