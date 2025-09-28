using _3DEngine.Core.Mathematics;
using _3DEngine.Renderer.Buffers;

namespace _3DEngine.Renderer.Windowing
{
    public interface RenderTarget
    {
        Vector2i Size { get; }
        FrameBuffer FrameBuffer { get; }

        string Title { get; set; }

        void ClearColor(Color4 color);

        void Clear();

        void SetCamera(Camera camera);

        Camera GetCamera();
    }
}
