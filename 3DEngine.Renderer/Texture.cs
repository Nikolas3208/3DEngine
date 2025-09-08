using OpenTK.Graphics.OpenGL4;
using StbImageSharp;

namespace _3DEngine.Renderer
{
    public class Texture
    {
        private bool smooth;
        private bool repeat;

        public int Handle { get; }

        public int Width { get; }
        public int Height { get; }

        public bool Smooth { get => smooth; set { SetSmooth(value); } }
        public bool Repeat { get => repeat; set { SetRepeat(value); } }
        public bool Mipmaps { get; }

        private Texture(int handle, int width, int height, bool smooth, bool repeat, bool mipmaps)
        {
            Handle = handle;
            Width = width;
            Height = height;
            Smooth = smooth;
            Repeat = repeat;
            Mipmaps = mipmaps;
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

        public static Texture LoadFromFile(string path, bool smooth= false, bool repeat = false, bool mipmaps = false)
        {
            int width, height;

            int handle = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, handle);

            StbImage.stbi_set_flip_vertically_on_load(1);

            using (Stream stream = File.OpenRead(path))
            {
                ImageResult image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, image.Data);
                width = image.Width;
                height = image.Height;
            }


            // Set texture parameters
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, smooth ? (int)TextureMinFilter.Linear : (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, smooth ? (int)TextureMagFilter.Linear : (int)TextureMagFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, repeat ? (int)TextureWrapMode.Repeat : (int)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, repeat ? (int)TextureWrapMode.Repeat : (int)TextureWrapMode.ClampToEdge);

            if (mipmaps)
            {
                GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            }

            GL.BindTexture(TextureTarget.Texture2D, 0);

            return new Texture(handle, width, height, smooth, repeat, mipmaps);
        }

        ~Texture()
        {
            GL.DeleteTexture(Handle);
        }
    }
}
