using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project230725
{
    internal class Goal : Component
    {
        public Goal()
        {
        }
        ~Goal()
        {
        }

        Transform playerTransform;

        public override void Start()
        {
            playerTransform = Engine.GetGameObjectByName("Player").transform;
        }

        public override void LateUpdate()
        {
            if (playerTransform.x == transform.x && playerTransform.y == transform.y)
            {
                //MapMaker.GameEnd("You Win!");
                Engine.Quit();
            }
        }

    }
}
