using _3DEngine.Core.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace _3DEngine.Renderer.Buffers
{
    /// <summary>
    /// Настойки буфера кадров
    /// </summary>
    public struct FrameBufferSpecification
    {
        /// <summary>
        /// Ширина
        /// </summary>
        public readonly int Width;

        /// <summary>
        /// Высота
        /// </summary>
        public readonly int Height;

        public readonly int Samples;

        /// <summary>
        /// Цуль буфера
        /// </summary>
        public readonly FramebufferTarget Target;

        /// <summary>
        /// Список привязок
        /// </summary>
        public readonly List<FrameBufferAttachmentSpecification> AttachmentSpecifications;

        /// <summary>
        /// Спецификация буфера
        /// </summary>
        /// <param name="width"> Ширина </param>
        /// <param name="height"> Высота </param>
        /// <param name="samples"></param>
        /// <param name="target"> Цель </param>
        public FrameBufferSpecification(int width, int height, int samples, FramebufferTarget target)
        {
            Width = width;
            Height = height;
            Samples = samples;

            Target = target;

            AttachmentSpecifications = new List<FrameBufferAttachmentSpecification>();
        }

        /// <summary>
        /// Спецификаия буфера
        /// </summary>
        /// <param name="width"> Ширина </param>
        /// <param name="height"> Высота </param>
        /// <param name="samples"></param>
        /// <param name="target"> Цель </param>
        /// <param name="attachmentSpecifications"> Привязки </param>
        public FrameBufferSpecification(int width, int height, int samples, FramebufferTarget target, List<FrameBufferAttachmentSpecification> attachmentSpecifications)
        {
            Width = width;
            Height = height;
            Samples = samples;

            Target = target;

            AttachmentSpecifications = attachmentSpecifications;
        }

        /// <summary>
        /// Добавить привязку
        /// </summary>
        /// <param name="attachment"></param>
        public void AddAttachment(FrameBufferAttachmentSpecification attachment) => AttachmentSpecifications.Add(attachment);

        /// <summary>
        /// Стандартный буфер (800, 600, 1, Framebuffer, { ColorAttachment, DepthAttachment })
        /// </summary>
        public static FrameBufferSpecification Default => new FrameBufferSpecification(800, 600, 1, FramebufferTarget.Framebuffer, new() { FrameBufferAttachmentSpecification.ColorAttachment, FrameBufferAttachmentSpecification.DepthAttachment });
    }

    /// <summary>
    /// Тип приязываемого обекта
    /// </summary>
    public enum FrameBufferAttachmentType
    {
        Texture = 0,
        RenderBuffer = 1
    }

    /// <summary>
    /// Спецификация привязываемого обекта
    /// </summary>
    public struct FrameBufferAttachmentSpecification
    {
        /// <summary>
        /// Спецификация обекта текстуры
        /// </summary>
        public readonly FrameBufferTextureSpecification TextureSpecification;

        /// <summary>
        /// Спеификация бефера рисования
        /// </summary>
        public readonly FrameBufferRenderBufferSpecification RenderBufferSpecification;

        /// <summary>
        /// Тип привязки
        /// </summary>
        public readonly FramebufferAttachment Attachment;

        /// <summary>
        /// Тип привязываемого обекта
        /// </summary>
        public readonly FrameBufferAttachmentType AttachmentType;

        /// <summary>
        /// Спецификация привязки
        /// </summary>
        /// <param name="textureSpecification"> Спецификаия привязываемой текстуры </param>
        /// <param name="attachment"> Тип привязки </param>
        public FrameBufferAttachmentSpecification(FrameBufferTextureSpecification textureSpecification,
            FramebufferAttachment attachment)
        {
            TextureSpecification = textureSpecification;
            Attachment = attachment;

            AttachmentType = FrameBufferAttachmentType.Texture;
        }

        /// <summary>
        /// Спецификация привязки
        /// </summary>
        /// <param name="renderBufferSpecification"> Спецификация привязываемого буфера рисования </param>
        /// <param name="attachment"> Тип привязки </param>
        public FrameBufferAttachmentSpecification(FrameBufferRenderBufferSpecification renderBufferSpecification,
            FramebufferAttachment attachment)
        {
            RenderBufferSpecification = renderBufferSpecification;
            Attachment = attachment;

            AttachmentType = FrameBufferAttachmentType.RenderBuffer;
        }

        /// <summary>
        /// Привязка цветовая текстура
        /// </summary>
        public static FrameBufferAttachmentSpecification ColorAttachment => new FrameBufferAttachmentSpecification(
            FrameBufferTextureSpecification.ColorAttachment, FramebufferAttachment.ColorAttachment0);

        /// <summary>
        /// Привязка текстура глубины
        /// </summary>
        public static FrameBufferAttachmentSpecification DepthAttachment => new FrameBufferAttachmentSpecification(
            FrameBufferTextureSpecification.DepthAttachment, FramebufferAttachment.DepthAttachment);

        /// <summary>
        /// Привязка текстура глубины и трафарета
        /// </summary>
        public static FrameBufferAttachmentSpecification DepthStencilAttachment => new FrameBufferAttachmentSpecification(
            FrameBufferTextureSpecification.DepthStencilAttachment, FramebufferAttachment.DepthStencilAttachment);
    }

    /// <summary>
    /// Спецификация привязываемой текстуры
    /// </summary>
    public struct FrameBufferTextureSpecification
    {
        public readonly PixelInternalFormat Format;
        public readonly PixelFormat PixelFormat;
        public readonly PixelType PixelType;

        public FrameBufferTextureSpecification(FrameBufferTextureSpecification textureSpecification)
        {
            Format = textureSpecification.Format;
            PixelFormat = textureSpecification.PixelFormat;
            PixelType = textureSpecification.PixelType;
        }

        public FrameBufferTextureSpecification(PixelInternalFormat format, PixelFormat pixelFormat,
            PixelType pixelType)
        {
            Format = format;
            PixelFormat = pixelFormat;
            PixelType = pixelType;
        }

        public static FrameBufferTextureSpecification ColorAttachment => new FrameBufferTextureSpecification(
            PixelInternalFormat.Rgba, PixelFormat.Rgba, PixelType.UnsignedInt);

        public static FrameBufferTextureSpecification DepthAttachment => new FrameBufferTextureSpecification(
            PixelInternalFormat.DepthComponent, PixelFormat.DepthComponent, PixelType.Float);

        public static FrameBufferTextureSpecification DepthStencilAttachment => new FrameBufferTextureSpecification(
            PixelInternalFormat.DepthStencil, PixelFormat.DepthStencil, PixelType.Float);
    }

    /// <summary>
    /// Спецификация привязываемого буфера рисования
    /// </summary>
    public struct FrameBufferRenderBufferSpecification 
    {
        public readonly RenderbufferTarget Target;
        public readonly RenderbufferStorage Storage;

        public FrameBufferRenderBufferSpecification(RenderbufferTarget target, RenderbufferStorage storage)
        {
            Target = target;
            Storage = storage;
        }

        public static FrameBufferRenderBufferSpecification Depth => new FrameBufferRenderBufferSpecification(
            RenderbufferTarget.Renderbuffer, RenderbufferStorage.DepthComponent);

        public static FrameBufferRenderBufferSpecification DepthStencil => new FrameBufferRenderBufferSpecification(
            RenderbufferTarget.Renderbuffer, RenderbufferStorage.DepthStencil);
    }

    /// <summary>
    /// Буфер кадра
    /// </summary>
    public class FrameBuffer
    {
        /// <summary>
        /// Спеификация буфера ( насстройки )
        /// </summary>
        private FrameBufferSpecification specification;

        /// <summary>
        /// Текстуры привязаные к буферу кадра
        /// </summary>
        private Dictionary<FramebufferAttachment, (FrameBufferTextureSpecification, int)> textures;

        /// <summary>
        /// Прогрмма буфера
        /// </summary>
        public int Handle { get; private set; }

        /// <summary>
        /// БУфер кадра
        /// </summary>
        /// <param name="spec"> Спецификаии буфера ( настройки ) <see cref="FrameBufferSpecification"/> </param>
        public FrameBuffer(FrameBufferSpecification spec)
        {
            specification = spec;

            textures = new Dictionary<FramebufferAttachment, (FrameBufferTextureSpecification, int)>();
        }

        /// <summary>
        /// Вложение текстуры
        /// </summary>
        /// <param name="spec"> Спецификаия текстуры <see cref="FrameBufferTextureSpecification"/> </param>
        /// <param name="attachment"> Что будет лежать в текстуре </param>
        private void TextureAttachment(FrameBufferTextureSpecification spec, FramebufferAttachment attachment)
        {
            int tex = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, tex);
            GL.TexImage2D(TextureTarget.Texture2D, 0, spec.Format, specification.Width, specification.Height, 0, spec.PixelFormat, spec.PixelType, IntPtr.Zero);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)All.Nearest);

            GL.FramebufferTexture2D(specification.Target, attachment, TextureTarget.Texture2D, tex, 0);

            textures.Add(attachment, (spec, tex));
        }

        /// <summary>
        /// Вложение буфера рисования
        /// </summary>
        /// <param name="spec"> Спецификаия бефера <see cref="FrameBufferRenderBufferSpecification"/> </param>
        /// <param name="attachment"> Что бедт лежать в буфере </param>
        private void RenderBufferAttachment(FrameBufferRenderBufferSpecification spec, FramebufferAttachment attachment)
        {
            int renderBuffer = GL.GenRenderbuffer();
            GL.BindRenderbuffer(spec.Target, renderBuffer);
            GL.RenderbufferStorage(spec.Target, spec.Storage, specification.Width, specification.Height);

            GL.FramebufferRenderbuffer(specification.Target, attachment, spec.Target, renderBuffer);

        }

        /// <summary>
        /// Инициализаия
        /// </summary>
        /// <exception cref="Exception"> Если буфер создан с ошибкой </exception>
        public void Initialize()
        {
            Handle = GL.GenFramebuffer();
            GL.BindFramebuffer(specification.Target, Handle);

            foreach(var attachSpecification in specification.AttachmentSpecifications)
            {
                switch(attachSpecification.AttachmentType)
                {
                    case FrameBufferAttachmentType.Texture:
                        TextureAttachment(attachSpecification.TextureSpecification, attachSpecification.Attachment);
                        break;
                    case FrameBufferAttachmentType.RenderBuffer:
                        RenderBufferAttachment(attachSpecification.RenderBufferSpecification, attachSpecification.Attachment);
                        break;
                }
            }

            if (GL.CheckFramebufferStatus(specification.Target) != FramebufferErrorCode.FramebufferComplete)
                throw new Exception("Framebuffer is not complete!");

            GL.BindFramebuffer(specification.Target, 0);
        }

        /// <summary>
        /// Связать буфер
        /// </summary>
        public void Bind()
        {
            GL.BindFramebuffer(specification.Target, Handle);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        /// <summary>
        /// Отвязать буфер
        /// </summary>
        public void Unbind()
        {
            GL.BindFramebuffer(specification.Target, 0);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        /// <summary>
        /// Прочитать пиксель
        /// </summary>
        /// <param name="x"> Позиция пикселя по вертекале </param>
        /// <param name="y"> Позиция пикселя по горизонтали </param>
        /// <param name="attachment"> Тип привязаной текстуры, для получения настроек пикселя </param>
        /// <param name="pixels"> Возвращает цвет пикселя в указаной позиции </param>
        public void ReadPixel(int x, int y, FramebufferAttachment attachment, ref Vector3 pixels)
        {
            var spec = textures[attachment].Item1;

            GL.BindFramebuffer(specification.Target, Handle);

            GL.ReadPixels(x, y, specification.Width, specification.Height, spec.PixelFormat, spec.PixelType, ref pixels);

            GL.BindFramebuffer(specification.Target, 0);
        }

        /// <summary>
        /// Уничтожить буфер
        /// </summary>
        ~FrameBuffer()
        {
            GL.DeleteFramebuffer(Handle);
        }
    }
}
