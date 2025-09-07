using _3DEngine.Core.Mathematics;
using _3DEngine.Renderer.Buffers;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System.ComponentModel;

namespace _3DEngine.Renderer
{
    public class RenderWindow : RenderTarget
    {
        public event Action Load;
        public event Action<FrameEventArgs> Update;
        public event Action<RenderTarget> Render;

        private Vertex[] screenVertices =
        {
            new Vertex(new Vector3(1.0f, 1.0f, 0.0f), new Vector2(1, 1)),
            new Vertex(new Vector3(1.0f, -1.0f, 0.0f) , new Vector2(1, 0)),
            new Vertex(new Vector3(-1.0f, -1.0f, 0.0f), new Vector2(0, 0)),
            new Vertex(new Vector3(-1.0f, 1.0f, 0.0f), new Vector2(0, 1))
        };

        private uint[] indices = {
            0, 1, 3,
            1, 2, 3
        };

        private VertexArray screen;
        private Shader screenShader;

        private GameWindow window { get; }
        private Camera camera { get; set; }

        public FrameBuffer FrameBuffer { get; }

        public RenderWindow(VideoMode videoMode, string title)
        {
            NativeWindowSettings nativeWindowSettings = new NativeWindowSettings()
            {
                Title = title,
                ClientSize = new OpenTK.Mathematics.Vector2i(videoMode.Width, videoMode.Height)
            };

            window = new GameWindow(GameWindowSettings.Default, nativeWindowSettings);

            window.Load += OnLoad;
            window.UpdateFrame += OnUpdate;
            window.RenderFrame += OnRender;
            window.Closing += OnClose;
            window.Resize += OnResize;

            FrameBuffer = new FrameBuffer(new FrameBufferSpecification(videoMode.Width, videoMode.Height, 0, FramebufferTarget.Framebuffer, new() { FrameBufferAttachmentSpecification.ColorAttachment }));
            FrameBuffer.Initialize();

            screen = new VertexArray(new VertexBuffer(screenVertices), new IndexBuffer(indices));
            screenShader = new Shader("Shaders\\screen.vert", "Shaders\\screen.frag");
            screenShader.Use();

        }

        private void OnLoad()
        {
            Load?.Invoke();
        }

        private void OnUpdate(FrameEventArgs obj)
        {
            Update?.Invoke(obj);
        }
        private void OnRender(FrameEventArgs obj)
        {

            FrameBuffer.Bind();

            Render?.Invoke(this);

            FrameBuffer.Unbind();

            FrameBuffer.BindTexture(FramebufferAttachment.ColorAttachment0, TextureUnit.Texture0);

            screenShader.SetInt("screenTexture", 0);

            screen.Bind();

            GL.DrawElements(PrimitiveType.Triangles, screen.ElementCount, DrawElementsType.UnsignedInt, 0);

            screen.Unbind();

            window.SwapBuffers();
        }

        private void OnResize(ResizeEventArgs obj)
        {
            
        }

        private void OnClose(CancelEventArgs obj)
        {

        }

        public void Run() => window.Run();

        public void SetCamera(Camera camera) => this.camera = camera;

        public Camera GetCamera() => camera;

        public void ClearColor(Color4 color)
        {
            GL.ClearColor(color.R, color.G, color.B, color.A);
        }

        public void Clear()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }
    }
}
