using SDL2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project230725
{
    class MeshRenderer : Component
    {
        public MeshRenderer()
        {
            renderFirst = true;
            R = 0;
            G = 0;
            B = 0;
            A = 0;
        }
        public MeshRenderer(byte _r, byte _g, byte _b, byte _a)
        {
            renderFirst = true;
            R = _r;
            G = _g;
            B = _b;
            A = _a;
        }
        public MeshRenderer(byte _r, byte _g, byte _b, byte _a, string inTextureName, bool inSlice, bool isPink)
        {
            renderFirst = true;
            R = _r;
            G = _g;
            B = _b;
            A = _a;
            textureName = inTextureName;

            unsafe
            {
                mySurface = SDL.SDL_LoadBMP("Data/" + textureName);
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)mySurface;
                if (isPink)
                {
                    SDL.SDL_SetColorKey
                    (
                        mySurface,
                        1,
                        SDL.SDL_MapRGB(surface->format, 255, 0, 255)
                    );
                }
                else
                {
                    SDL.SDL_SetColorKey
                    (
                        mySurface,
                        1,
                        SDL.SDL_MapRGB(surface->format, 255, 255, 255)
                    );
                }
                myTexture = SDL.SDL_CreateTextureFromSurface(Engine.instance.myRenderer, mySurface);
            }
            slice = inSlice;

            indexX = 0;
            indexY = 0;
            moved = false;
        }
        ~MeshRenderer()
        {

        }

        byte R;
        byte G;
        byte B;
        byte A;
        string textureName;
        IntPtr mySurface;
        IntPtr myTexture;
        bool slice;
        int indexX;
        public int indexY;
        public bool moved;

        public override void Start()
        {
            foreach (Component component in gameObject.components)
            {
                if (component is MeshFilter)
                {
                    meshFilter = component as MeshFilter;
                }
            }
        }

        protected MeshFilter meshFilter;
        bool renderFirst;

        public virtual void Render()
        {
            //if (!meshFilter.isStatic || renderFirst || RenderCheck())
            //{
            //Console.SetCursorPosition(transform.x * 2, transform.y);
            //Console.ForegroundColor = (meshFilter as MeshFilter).frontColor;
            //Console.BackgroundColor = (meshFilter as MeshFilter).backColor;
            //Console.Write((meshFilter as MeshFilter).Shape + " ");
            //Console.ForegroundColor = ConsoleColor.Black;
            //Console.BackgroundColor = ConsoleColor.Black;
            //    renderFirst = false;
            //}

            // Fill Rect
            //SDL.SDL_Rect myRect = new SDL.SDL_Rect();
            //myRect.x = transform.x * 30;
            //myRect.y = transform.y * 30;
            //myRect.w = 30;
            //myRect.h = 30;
            //SDL.SDL_SetRenderDrawColor(Engine.instance.myRenderer, R, G, B, A);
            //SDL.SDL_RenderFillRect(Engine.instance.myRenderer, ref myRect);

            unsafe
            {
                SDL.SDL_Rect source = new SDL.SDL_Rect();
                SDL.SDL_Surface* surface = (SDL.SDL_Surface*)mySurface;
                if (slice)
                {
                    source.x = indexX * 51;
                    source.y = indexY * 51;
                    source.w = surface->w/5;
                    source.h = surface->h/5;
                }
                else
                {
                    source.x = 0;
                    source.y = 0;
                    source.w = surface->w;
                    source.h = surface->h;
                }

                if (moved && indexX < 5)
                {
                    indexX++;
                }
                else
                {
                    moved = false;
                    indexX = 0;
                }

                SDL.SDL_Rect destination = new SDL.SDL_Rect();
                destination.x = transform.x * Engine.spriteSize;
                destination.y = transform.y * Engine.spriteSize;
                destination.w = Engine.spriteSize;
                destination.h = Engine.spriteSize;

                SDL.SDL_RenderCopy(Engine.instance.myRenderer, myTexture, ref source, ref destination);
            }
        }

        public bool RenderCheck()
        {
            foreach(Vector2 vector in Engine.needToRender) 
            {
                if(vector.x == transform.x && vector.y == transform.y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
