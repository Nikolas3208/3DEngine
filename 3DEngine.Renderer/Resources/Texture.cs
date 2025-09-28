using _3DEngine.Core.Resources;
using _3DEngine.Core.Serialize;
using _3DEngine.Renderer.Resources.Loaders;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DEngine.Renderer.Resources
{
    public enum TextureType
    {
        Texture,
        MultipleTexture,
        NormalMap
    }

    public class Texture : Asset
    {
        private bool smooth;
        private bool repeat;

        public int Width { get; set; }
        public int Height { get; set; }
        public int Handle { get; }

        public bool Smooth { get => smooth; set { SetSmooth(value); } }
        public bool Repeat { get => repeat; set { SetRepeat(value); } }

        public TextureType TextureType { get; set; }

        public Texture(int handle, int width, int height, string name, string filePath) : base(name, filePath)
        {
            Handle = handle;
            Width = width;
            Height = height;

            Type = AssetType.Texture;
        }

        public Texture(MetaData metaData) : base(metaData)
        {
            Handle = TextureLoader.LoadFromFile(FilePath).Handle;
        }

        private void SetSmooth(bool smooth)
        {
            if (this.smooth == smooth)
                return;

            GL.BindTexture(TextureTarget.Texture2D, Handle);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, smooth ? (int)TextureMinFilter.Linear : (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, smooth ? (int)TextureMagFilter.Linear : (int)TextureMagFilter.Nearest);
            GL.BindTexture(TextureTarget.Texture2D, 0);

            this.smooth = smooth;
        }

        private void SetRepeat(bool repeat)
        {
            if (this.repeat == repeat)
                return;

            GL.BindTexture(TextureTarget.Texture2D, Handle);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, repeat ? (int)TextureWrapMode.Repeat : (int)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, repeat ? (int)TextureWrapMode.Repeat : (int)TextureWrapMode.ClampToEdge);
            GL.BindTexture(TextureTarget.Texture2D, 0);

            this.repeat = repeat;
        }

        public void Bind(TextureUnit unit)
        {
            GL.ActiveTexture(unit);
            GL.BindTexture(TextureTarget.Texture2D, Handle);
        }

        public void Unbind()
        {
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }
    }
}
