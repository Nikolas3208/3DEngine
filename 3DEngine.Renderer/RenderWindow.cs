using _3DEngine.Core.Mathematics;
using _3DEngine.Renderer.Buffers;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

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

        private GameWindow window { get; }
        private Camera camera { get; set; }

        public FrameBuffer FrameBuffer { get; }

        public RenderWindow(GameWindowSettings windowSettings, NativeWindowSettings nativeWindowSettings)
        {
            window = new GameWindow(windowSettings, nativeWindowSettings);

            window.Load += OnLoad;
            window.UpdateFrame += OnUpdate;
            window.RenderFrame += OnRender;

            screen = new VertexArray(new VertexBuffer(screenVertices), new IndexBuffer(indices));
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


        }

        public void Run() => window.Run();

        public void SetCamera(Camera camera) => this.camera = camera;

        public Camera GetCamera() => camera;
    }
}
