using _3DEngine.Renderer.Buffers;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace _3DEngine.Renderer
{
    public class RenderWindow : RenderTarget
    {
        public event Action Load;
        public event Action<FrameEventArgs> Update;
        public event Action<FrameEventArgs> Render;

        private GameWindow window { get; }
        private Camera camera { get; set; }

        public FrameBuffer FrameBuffer { get; }

        public RenderWindow(GameWindowSettings windowSettings, NativeWindowSettings nativeWindowSettings)
        {
            window = new GameWindow(windowSettings, nativeWindowSettings);

            window.Load += OnLoad;
            window.UpdateFrame += OnUpdate;
            window.RenderFrame += OnRender;
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

            Render?.Invoke(obj);

            FrameBuffer.Unbind();
        }

        public void Run() => window.Run();

        public void SetCamera(Camera camera) => this.camera = camera;

        public Camera GetCamera() => camera;
    }
}
