using _3DEngine.Renderer.Buffers;

namespace _3DEngine.Renderer
{
    public interface RenderTarget
    {
        public FrameBuffer FrameBuffer { get; }

        public void SetCamera(Camera camera);

        public Camera GetCamera();
    }
}
