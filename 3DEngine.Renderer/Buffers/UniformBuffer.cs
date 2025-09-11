using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _3DEngine.Renderer.Buffers
{
    public class UniformBuffer
    {
        public int Handle { get; }

        public UniformBuffer(int size)
        {
            Handle = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.UniformBuffer, Handle);
            GL.BufferData(BufferTarget.UniformBuffer, size, IntPtr.Zero, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.UniformBuffer, 0);

            GL.BindBufferRange(BufferRangeTarget.UniformBuffer, 0, Handle, 0, size);
        }

        public void SubData<T>(T data, int offset) where T : struct
        {
            GL.BindBuffer(BufferTarget.UniformBuffer, Handle);
            GL.BufferSubData(BufferTarget.UniformBuffer, offset, Marshal.SizeOf(typeof(T)), ref data);
            GL.BindBuffer(BufferTarget.UniformBuffer, 0);
        }
    }
}
