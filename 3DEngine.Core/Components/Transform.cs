using _3DEngine.Core.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DEngine.Core.Components
{
    public class Transform : Component
    {
        private bool isUpdate = false;

        private Vector3 position;
        private Vector3 rotation;
        private Vector3 scale;

        private Matrix4 model = Matrix4.Identity;

        public Vector3 Position { get => position; set { position = value; isUpdate = true; } }
        public Vector3 Rotation { get => rotation; set { rotation = value; isUpdate = true; } }
        public Vector3 Scale { get => scale; set { scale = value; isUpdate = true; } }

        public Matrix4 Model
        {
            get
            {
                if(isUpdate)
                {
                    model = Matrix4.Identity;
                    model *= Matrix4.CreateScale(scale);
                    model *= Matrix4.CreateRotationX(MathHelper.DegreesToRadians(rotation.X));
                    model *= Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rotation.Y));
                    model *= Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(rotation.Z));
                    model *= Matrix4.CreateTranslation(position);

                    return model;
                }

                return model;
            }
        }
    }
}
