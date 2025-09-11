using _3DEngine.Core.Mathematics;
using _3DEngine.Renderer.Buffers;

namespace _3DEngine.Renderer
{
    public interface RenderTarget
    {
        Vector2i Size { get; }
        FrameBuffer FrameBuffer { get; }

        void ClearColor(Color4 color);

        void Clear();

        void SetCamera(Camera camera);

        Camera GetCamera();

        void Draw(IDrawable drawable);

        void Draw(VertexArray vertexArray, RenderStates states);
    }
}
