using OpenTK.Graphics.OpenGL4;

namespace _3DEngine.Renderer.Windowing
{
    [Flags]
    public enum RenderStatesEnables
    { 
        None = 0,
        DepthTest = 1 << 0,
        CullFace = 1 << 1,
    }

    public struct RenderStates
    {
        private RenderStatesEnables enables { get; set; }
        private RenderStatesEnables disables { get; set; }
        public BlendMode BlendMode { get; set; }

        public void Enable(RenderStatesEnables enable)
        {
            enables |= enable;
            disables &= ~enable;
        }

        public void Disable(RenderStatesEnables enable)
        {
            enables &= ~enable;
            disables |= enable;
        }

        public bool IsEnabled(RenderStatesEnables enable)
            => (enables & enable) != 0 && (disables & enable) == 0;

        public void UseFlags()
        {
            foreach (RenderStatesEnables flag in Enum.GetValues(typeof(RenderStatesEnables)))
            {
                if (flag == RenderStatesEnables.None) continue;

                switch (flag)
                {
                    case RenderStatesEnables.DepthTest when IsEnabled(flag):
                        GL.Enable(EnableCap.DepthTest);
                        break;

                    case RenderStatesEnables.CullFace when IsEnabled(flag):
                        GL.Enable(EnableCap.CullFace);
                        break;
                }
            }

            foreach (RenderStatesEnables flag in Enum.GetValues(typeof(RenderStatesEnables)))
            {
                if (flag == RenderStatesEnables.None) continue;

                switch (flag)
                {
                    case RenderStatesEnables.DepthTest when IsEnabled(flag):
                        GL.Disable(EnableCap.DepthTest);
                        break;

                    case RenderStatesEnables.CullFace when IsEnabled(flag):
                        GL.Disable(EnableCap.CullFace);
                        break;
                }
            }
        }
    }
}
