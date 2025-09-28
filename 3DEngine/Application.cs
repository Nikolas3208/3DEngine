using _3DEngine.Renderer.Windowing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DEngine
{
    public class Application
    {
        private RenderWindow renderWindow;
        
        public Application()
        {
            renderWindow = new RenderWindow(VideoMode.Default, "3DEngine");
            renderWindow.Load += OnLoad;
            renderWindow.Update += OnUpdate;
            renderWindow.Render += OnRender;
            renderWindow.Resize += OnResize;
            renderWindow.Close += OnClose;
        }

        protected virtual void OnLoad()
        {
            //game.Start();
        }

        protected virtual void OnUpdate(float dt)
        {
            //game.Update(dt);
        }

        protected virtual void OnRender(RenderTarget target)
        {
            //game.Render(target);
        }

        protected virtual void OnResize(int width, int height)
        {
            //game.Resize(width, height);
        }

        protected virtual void OnClose()
        {
            //game.Close();
        }
    }
}
