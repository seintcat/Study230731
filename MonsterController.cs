using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project230725
{
    class MonsterController : Controller
    {
        public MonsterController()
        {
            random = new Random();
            dateTime = DateTime.Now;
        }
        ~MonsterController()
        {
        }

        static Random random;
        Transform playerTransform;
        DateTime dateTime;

        public override void Start()
        {
            playerTransform = Engine.GetGameObjectByName("Player").transform;
        }

        public override void Update()
        {
            if(dateTime.Second != DateTime.Now.Second)
            {
                dateTime = DateTime.Now;

                // monster turn
                switch (random.Next(4))
                {
                    // up
                    case 0:
                        if (transform.y > playerTransform.y && !CheckCollider(transform.x, transform.y))
                        {
                            transform.y--;
                        }
                        break;
                    //left
                    case 1:
                        if (transform.x > playerTransform.x && !CheckCollider(transform.x - 1, transform.y))
                        {
                            transform.x--;
                        }
                        break;
                    //down
                    case 2:
                        if (transform.y < playerTransform.y && !CheckCollider(transform.x, transform.y))
                        {
                            transform.y++;
                        }
                        break;
                    //left
                    case 3:
                        if (transform.x < playerTransform.x && !CheckCollider(transform.x + 1, transform.y))
                        {
                            transform.x++;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public override void LateUpdate()
        {
            if (playerTransform.x == transform.x && playerTransform.y == transform.y)
            {
                //MapMaker.GameEnd("Game Over");
                Engine.Quit();
            }
        }
    }
}
