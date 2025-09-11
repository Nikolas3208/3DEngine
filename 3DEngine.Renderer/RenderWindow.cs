using _3DEngine.Core;
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
        public event Action<float> Update;
        public event Action<RenderTarget> Render;
        public event Action<int, int> Resize;

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

        private string vertShader = "#version 460\r\n\r\nlayout (location = 0) in vec3 aPos;\r\nlayout (location = 2) in vec2 TexCoord;\r\n\r\nout vec2 TexCoords;\r\n\r\nvoid main()\r\n{\r\n    TexCoords = TexCoord;\r\n    gl_Position = vec4(aPos, 1);\r\n}";
        private string fragShader = "#version 460\r\n\r\nin vec2 TexCoords;\r\n\r\nuniform sampler2D screenTexture;\r\n\r\nout vec4 FragColor;\r\n\r\nvoid main()\r\n{\r\n    FragColor = texture(screenTexture, TexCoords);\r\n}";

        private VideoMode videoMode;

        private UniformBuffer cameraUbo;
        private VertexArray screen;
        private Shader screenShader;

        private GameWindow window { get; }
        private Camera camera { get; set; }

        public Vector2i Size { get => new Vector2i(videoMode.Width, videoMode.Height); }

        public FrameBuffer FrameBuffer { get; }

        public RenderWindow(VideoMode videoMode, string title)
        {
            this.videoMode = videoMode;

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

            Input.KeyboardState = window.KeyboardState;
            Input.MouseState = window.MouseState;

            FrameBuffer = new FrameBuffer(new FrameBufferSpecification(videoMode.Width, videoMode.Height, 0, FramebufferTarget.Framebuffer,
                new() { FrameBufferAttachmentSpecification.ColorAttachment }));

            FrameBuffer.Initialize();

            cameraUbo = new UniformBuffer(Matrix4.SizeInBytes * 2);

            screen = new VertexArray(screenVertices, indices);
            screenShader = new Shader(vertShader, fragShader);
            screenShader.Use();

            camera = new Camera((float)videoMode.Width / videoMode.Height);
        }

        private void OnLoad()
        {
            Load?.Invoke();
        }

        private void OnUpdate(FrameEventArgs e)
        {
            cameraUbo.SubData(camera.GetProjectionMatrix(), 0);
            cameraUbo.SubData(camera.GetViewMatrix(), Matrix4.SizeInBytes);

            Update?.Invoke((float)e.Time);
        }
        private void OnRender(FrameEventArgs obj)
        {

            FrameBuffer.Bind();

            Render?.Invoke(this);

            FrameBuffer.Unbind();

            FrameBuffer.BindTexture(FramebufferAttachment.ColorAttachment0, TextureUnit.Texture0);

            screenShader.SetInt("screenTexture", 0);
            screenShader.Use();

            screen.Bind();

            GL.DrawElements(PrimitiveType.Triangles, screen.ElementCount, DrawElementsType.UnsignedInt, 0);

            screen.Unbind();

            window.SwapBuffers();
        }

        private void OnResize(ResizeEventArgs e)
        {
            FrameBuffer.Resize(e.Width, e.Height);
            
            camera.Resize(e.Width, e.Height);

            GL.Viewport(0, 0, e.Width, e.Height);

            Resize?.Invoke(e.Width, e.Height);
        }

        private void OnClose(CancelEventArgs e)
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

        public void Draw(IDrawable drawable)
        {

        }

        public void Draw(VertexArray vertexArray, RenderStates states)
        {

        }
    }
}
