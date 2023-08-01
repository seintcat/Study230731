using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project230725
{
    class Controller : Component
    {
        public Controller()
        {
        }
        ~Controller()
        {
        }

        public bool CheckCollider(int x, int y)
        {
            List<Collider> colliders = Engine.GetComponentsByType<Collider>();
            foreach (Collider collider in colliders)
            {
                if (collider.CheckCollision(x, y))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
