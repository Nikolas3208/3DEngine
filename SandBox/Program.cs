using _3DEngine.Core.Mathematics;
using _3DEngine.Renderer;

RenderWindow window = new RenderWindow(VideoMode.Default, "SandBox");

window.Render += OnRender;

void OnRender(RenderTarget target)
{
    target.ClearColor(Color4.Cyan);
}

window.Run();