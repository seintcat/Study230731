using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project230725
{
    class GameObject
    {
        public GameObject()
        {
            components = new List<Component>();
            name = string.Empty;
            transform = new Transform();
        }
        ~GameObject()
        {
            components.Clear();
        }

        public List<Component> components;
        public string name;
        public Transform transform;

        public void AddComponent(Component newComponent)
        {
            newComponent.transform = transform;
            newComponent.gameObject = this;
            components.Add(newComponent);
        }
        public void RemoveComponent(Component removeComponent)
        {
            components.Remove(removeComponent);
        }
    }
}
