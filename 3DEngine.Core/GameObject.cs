using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DEngine.Core
{
    public class GameObject
    {
        private List<Component> components;

        public Guid Id { get; }

        public GameObject()
        {
            components = new List<Component>();

            Id = Guid.NewGuid();
        }

        public GameObject(Guid id)
        {
            Id = id;

            components = new List<Component>();
        }

        public void Start()
        {

        }

        public void Update(float dt)
        {

        }

        public void Draw()
        {

        }

        public void AddComponent(Component component)
        {
            component.SetParent(this);
            components.Add(component);
        }

        public T GetComponent<T>() where T : Component
        {
            return (T)components.Find(component => component is T)!;
        }
    }
}
