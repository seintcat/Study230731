using SDL2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project230725
{
    class Engine
    {
        public Engine()
        {
            gameObjects = new List<GameObject>();
            instance = this;
            isRunning = false;
            needToRender = new List<Vector2>();
            Init();
        }
        public Engine(int x, int y)
        {
            xSize = x;
            ySize = y;
            gameObjects = new List<GameObject>();
            instance = this;
            isRunning = false;
            needToRender = new List<Vector2>();
            Init();
        }
        ~Engine()
        {
            gameObjects.Clear();
            needToRender.Clear();
            Term();
        }

        public static Engine instance;
        public static bool isRunning;
        public List<GameObject> gameObjects;
        public static List<Vector2> needToRender;
        public static int xSize;
        public static int ySize;
        public static int spriteSize = 40;

        public IntPtr myWindow;
        public IntPtr myRenderer;
        public SDL.SDL_Event myEvent;


        public void Init()
        {
            SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING);

            myWindow = SDL.SDL_CreateWindow("Game", 50, 50, xSize * spriteSize, ySize * spriteSize, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
            myRenderer = SDL.SDL_CreateRenderer
            (
                myWindow,
                -1,
                SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED |
                SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC |
                SDL.SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE
            );
        }

        public void Term()
        {
            SDL.SDL_DestroyRenderer(myRenderer);
            SDL.SDL_DestroyWindow(myWindow);
            SDL.SDL_Quit();
        }

        public void Instanciate(GameObject newGameObject)
        {
            gameObjects.Add(newGameObject);
        }

        public void Run()
        {
            //Console.CursorVisible = false;
            isRunning = true;
            GameLoop();
        }

        protected void GameLoop()
        {

            AllGameObjectinComponentsStart();
            AllGameObjectinMeshRendererRender();
            while (isRunning)
            {
                SDL.SDL_PollEvent(out myEvent);
                switch (myEvent.type)
                {
                    case SDL.SDL_EventType.SDL_QUIT:
                        isRunning = false;
                        break;

                    default:
                        break;
                }

                // Command Queue
                SDL.SDL_SetRenderDrawColor(myRenderer, 0, 0, 0, 0);
                //SDL.SDL_RenderClear(myRenderer);


                // Present
                SDL.SDL_RenderPresent(myRenderer);

                //Input();
                AllGameObjectinComponentsUpdate();
                AllGameObjectinMeshRendererRender();
                AllGameObjectinComponentsLateUpdate();
                needToRender.Clear();
            }

            //Console.ReadKey(true);
        }

        //protected void Input()
        //{
        //    foreach (GameObject gameObject in gameObjects)
        //    {
        //        foreach (Component component in gameObject.components)
        //        {
        //            bool result = component is Input;
        //            if (result)
        //            {
        //                Input input = component as Input;
        //                input.GetKeyDown();
        //            }
        //        }
        //    }
        //}

        protected void AllGameObjectinComponentsStart()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                foreach (Component component in gameObject.components)
                {
                    component.Start();
                }
            }
        }

        protected void AllGameObjectinComponentsUpdate()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                foreach (Component component in gameObject.components)
                {
                    component.Update();
                }
            }
        }
        protected void AllGameObjectinComponentsLateUpdate()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                foreach (Component component in gameObject.components)
                {
                    component.LateUpdate();
                }
            }
        }

        protected void AllGameObjectinMeshRendererRender()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                foreach (Component component in gameObject.components)
                {
                    if(component is MeshRenderer)
                    {
                        MeshRenderer renderer = component as MeshRenderer;
                        renderer.Render();
                    }
                }
            }
        }

        //public static List<Component> GetComponentsByType<T>()
        //{
        //    List<Component> list = new List<Component>();

        //    foreach (GameObject gameObject in nowEngine.gameObjects)
        //    {
        //        foreach (Component component in gameObject.components)
        //        {
        //            bool result = component is T;
        //            if (result)
        //            {
        //                list.Add(component);
        //            }
        //        }
        //    }
        //    return list;
        //}
        public static List<GameObject> GetGameObjectsByName(string name)
        {
            List<GameObject> list = new List<GameObject>();

            foreach (GameObject gameObject in instance.gameObjects)
            {
                if (gameObject.name == name)
                {
                    list.Add(gameObject);
                }
            }
            return list;
        }
        public static GameObject GetGameObjectByName(string name)
        {
            foreach (GameObject gameObject in instance.gameObjects)
            {
                if (gameObject.name == name)
                {
                    return gameObject;
                }
            }
            return null;
        }

        public static List<T> GetComponentsByType<T>() where T : Component
        {
            List<T> list = new List<T>();

            foreach (GameObject gameObject in instance.gameObjects)
            {
                foreach (Component component in gameObject.components)
                {
                    if(component is T)
                    {
                        list.Add(component as T);
                    }
                }
            }
            return list;
        }

        public static void Moved(int x, int y)
        {
            //Console.SetCursorPosition(x * 2, y);
            //Console.Write("  ");

            Vector2 vector = new Vector2();
            vector.x = x;
            vector.y = y;
            needToRender.Add(vector);
        }

        public static void Quit()
        {
            isRunning = false;
        }
    }

    public struct Vector2
    {
        public int x, y;
    }
}
