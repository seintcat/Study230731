using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project230725
{
    class Component
    {
        public Component()
        {
        }
        ~Component()
        {
        }

        public virtual void Start()
        {
        }
        public virtual void Update()
        {
        }
        public virtual void LateUpdate()
        {
        }

        public Transform transform;
        public GameObject gameObject;
    }
}
