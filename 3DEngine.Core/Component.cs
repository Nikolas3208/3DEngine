using _3DEngine.Core.Components;

namespace _3DEngine.Core
{
    public abstract class Component
    {
        private GameObject gameObject = null!;

        protected Transform transform { get; private set; } = null!;

        public Guid Id { get; }


        public Component()
        {
            Id = Guid.NewGuid();
        }

        protected Component(Guid id)
        {
            Id = id;
        }

        internal void SetParent(GameObject gameObject)
        {
            this.gameObject = gameObject;

            if(this is not Transform)
            {
                transform = gameObject.GetComponent<Transform>();
            }
        }
    }
}
