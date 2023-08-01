using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project230725
{
    class Input : Component
    {
        public Input()
        {
            info = ConsoleKey.NoName;
        }
        ~Input()
        {
        }

        public ConsoleKey info;

        //public void GetKeyDown()
        //{
        //    if(Engine.isRunning)
        //    {
        //        info = Console.ReadKey(true).Key;
        //    }
        //}

        public bool GetKeyDown(SDL.SDL_Keycode keycode)
        {
            if(Engine.instance.myEvent.key.keysym.sym == keycode && Engine.instance.myEvent.key.state == SDL.SDL_PRESSED)
            {
                return true;
            }
            return false;
        }
    }
}