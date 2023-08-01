using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project230725
{
    class Collider : Component
    {
        public Collider()
        {
            enabled = true;
        }
        ~Collider()
        {
        }

        public bool enabled;

        public bool CheckCollision(int x, int y) 
        { 
            return transform.x == x && transform.y == y; 
        }
    }
}
