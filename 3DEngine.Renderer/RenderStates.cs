namespace _3DEngine.Renderer
{
    public enum RenderStatesEnables
    { 
        None = 0,
        DepthTest = 1 << 0,
    }

    public struct RenderStates
    {
        public RenderStatesEnables Enables { get; set; }
        public BlendMode BlendMode { get; set; }
    }
}
