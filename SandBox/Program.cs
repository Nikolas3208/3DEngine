using _3DEngine.Core;
using _3DEngine.Core.Mathematics;
using _3DEngine.Core.Resources;
using _3DEngine.Core.Serialize;
using _3DEngine.Renderer.Components;
using _3DEngine.Renderer.Resources;
using _3DEngine.Renderer.Resources.Loaders;
using _3DEngine.Renderer.Windowing;


RenderWindow window = new RenderWindow(VideoMode.Default, "SandBox");

window.Load += OnLoad;

Shader shader;

GameObject gameObject = null;


void OnLoad()
{
    //shader = Shader.LoadFromFile("shader.vert", "shader.frag");

    gameObject = new GameObject();

    var meshRender = new MeshRender();

    gameObject.AddComponent(meshRender);

    AssetsLoader.LoadAssets();
}

window.Render += OnRender;


void OnRender(RenderTarget target)
{
    target.ClearColor(Color4.Cyan);

    gameObject?.Draw();
}

window.Run();