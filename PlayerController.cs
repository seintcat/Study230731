using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project230725
{
    class PlayerController : Controller
    {
        public PlayerController()
        {
        }
        ~PlayerController()
        {

        }

        Input input;
        MeshRenderer renderer;

        public override void Start()
        {
            foreach (Component component in gameObject.components)
            {
                if (component is Input)
                {
                    input = component as Input;
                }
                if (component is MeshRenderer)
                {
                    renderer = component as MeshRenderer;
                }
            }
        }

        public override void Update()
        {
            //ConsoleKey info = input.info;

            //switch (info)
            //{
            //    case ConsoleKey.W:
            //        if (transform.y > 0 && !CheckCollider(transform.x, transform.y - 1))
            //        {
            //            transform.y--;
            //        }
            //        break;
            //    case ConsoleKey.A:
            //        if (transform.x > 0 && !CheckCollider(transform.x - 1, transform.y))
            //        {
            //            transform.x--;
            //        }
            //        break;
            //    case ConsoleKey.S:
            //        if (transform.y < (MapMaker.ySize - 1) && !CheckCollider(transform.x, transform.y + 1))
            //        {
            //            transform.y++;
            //        }
            //        break;
            //    case ConsoleKey.D:
            //        if (transform.x < (MapMaker.xSize - 1) && !CheckCollider(transform.x + 1, transform.y))
            //        {
            //            transform.x++;
            //        }
            //        break;
            //    default:
            //        break;
            //}

            // W
            if (input.GetKeyDown(SDL.SDL_Keycode.SDLK_w) && transform.y > 0 && !CheckCollider(transform.x, transform.y - 1))
            {
                renderer.indexY = 2;
                renderer.moved = true;
                transform.y--;
            }
            // A
            if (input.GetKeyDown(SDL.SDL_Keycode.SDLK_a) && transform.x > 0 && !CheckCollider(transform.x - 1, transform.y))
            {
                renderer.indexY = 0;
                renderer.moved = true;
                transform.x--;
            }
            // S
            if (input.GetKeyDown(SDL.SDL_Keycode.SDLK_s) && transform.y < (Engine.ySize - 1) && !CheckCollider(transform.x, transform.y + 1))
            {
                renderer.indexY = 3;
                renderer.moved = true;
                transform.y++;
            }
            // D
            if (input.GetKeyDown(SDL.SDL_Keycode.SDLK_d) && transform.x < (Engine.xSize - 1) && !CheckCollider(transform.x + 1, transform.y))
            {
                renderer.indexY = 1;
                renderer.moved = true;
                transform.x++;
            }

        }
    }
}
