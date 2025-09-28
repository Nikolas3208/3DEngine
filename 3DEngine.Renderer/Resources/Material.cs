using _3DEngine.Core.Mathematics;
using _3DEngine.Core.Resources;
using OpenTK.Graphics.OpenGL4;

namespace _3DEngine.Renderer.Resources
{
    public class Material : Asset
    {
        public Shader Shader;

        public Vector3 Ambient { get; set; }
        public Texture? AmbientTex {  get; set; }

        public Vector3 Diffuse { get; set; }
        public Texture? DiffuseTex {  get; set; }

        public Vector3 Specular { get; set; }
        public Texture? SpecularTex { get; set; }

        public float Shininess { get; set; }

        public Texture? NormalTex {  get; set; }

        public Material()
        {
            
        }

        public Material(Shader shader, Vector3 ambient, Vector3 diffuse, Vector3 specular, float sheniness)
        {
            this.Shader = shader;

            Ambient = ambient;
            Diffuse = diffuse;
            Specular = specular;

            Shininess = sheniness;
        }

        public Material(Shader shader, Texture ambient, Texture diffuse, Texture specular, float sheniness)
        {
            this.Shader = shader;

            AmbientTex = ambient;
            DiffuseTex = diffuse;
            SpecularTex = specular;

            Shininess = sheniness;
        }

        public Material(Shader shader, Vector3 ambient, Texture? ambientTex, Vector3 diffuse, Texture? diffuseTex, Vector3 specular, Texture? specularTex, float shininess, Texture? normalTex)
        {
            this.Shader = shader;
            Ambient = ambient;
            AmbientTex = ambientTex;
            Diffuse = diffuse;
            DiffuseTex = diffuseTex;
            Specular = specular;
            SpecularTex = specularTex;
            Shininess = shininess;
            NormalTex = normalTex;
        }

        public Material(MetaData metaData) : base(metaData)
        {

        }

        public void Bind()
        {
            if (Shader == null)
                return;

            Shader.Use();
            Shader.SetVector3("material.ambient", Ambient);
            Shader.SetVector3("material.diffuse", Diffuse);
            Shader.SetVector3("material.specular", Specular);

            Shader.SetFloat("material.shininess", Shininess);

            Shader.SetBool("material.useAmbientTex", AmbientTex != null);
            Shader.SetBool("material.useDiffuseTex", DiffuseTex != null);
            Shader.SetBool("material.useSpecularTex", SpecularTex != null);
            Shader.SetBool("material.useNormalTex", NormalTex != null);

            if (AmbientTex != null)
            {
                AmbientTex.Bind(TextureUnit.Texture0);
                Shader.SetInt("material.ambientTex", 0);
            }
            if(DiffuseTex != null)
            {
                DiffuseTex.Bind(TextureUnit.Texture1);
                Shader.SetInt("material.diffuseTex", 1);
            }
            if(SpecularTex != null)
            {
                SpecularTex.Bind(TextureUnit.Texture2);
                Shader.SetInt("material.specularTex", 2);
            }
            if(NormalTex != null)
            {
                NormalTex.Bind(TextureUnit.Texture3);
                Shader.SetInt("material.normalTex", 3);
            }
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
