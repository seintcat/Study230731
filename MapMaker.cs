using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project230725
{
    class MapMaker : Component
    {
        public MapMaker()
        {
            //Engine.xSize = 10;
            //Engine.ySize = 10;
            Mapmake(Engine.xSize, Engine.ySize);
        }
        //public MapMaker(int _xSize, int _ySize)
        //{
        //    Engine.xSize = _xSize;
        //    Engine.ySize = _ySize;
        //    Mapmake(Engine.xSize, Engine.ySize);
        //}
        ~MapMaker()
        {
        }

        public void Mapmake(int xSize, int ySize)
        {
            // floor
            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    GameObject floor = new GameObject();
                    floor.name = "floor";
                    floor.transform.x = x;
                    floor.transform.y = y;
                    floor.AddComponent(new MeshFilter(' ', ConsoleColor.DarkGray, ConsoleColor.DarkGray, true));
                    floor.AddComponent(new MeshRenderer(255, 255, 255, 0, "floor.bmp", false, false));
                    Engine.instance.Instanciate(floor);
                }
            }

            // wall
            for (int i = 0; i < xSize; i++)
            {
                GameObject wall = new GameObject();
                wall.name = "wall";
                wall.transform.x = i;
                wall.transform.y = 0;
                wall.AddComponent(new MeshFilter('*', ConsoleColor.DarkRed, ConsoleColor.DarkRed, true));
                wall.AddComponent(new MeshRenderer(0, 0, 255, 0, "wall.bmp", false, false));
                wall.AddComponent(new Collider());
                Engine.instance.Instanciate(wall);

                GameObject wall3 = new GameObject();
                wall3.name = "wall";
                wall3.transform.x = i;
                wall3.transform.y = ySize - 1;
                wall3.AddComponent(new MeshFilter('*', ConsoleColor.DarkRed, ConsoleColor.DarkRed, true));
                wall3.AddComponent(new MeshRenderer(0, 0, 255, 0, "wall.bmp", false, false));
                wall3.AddComponent(new Collider());
                Engine.instance.Instanciate(wall3);
            }
            for (int i = 0; i < ySize; i++)
            {
                GameObject wall2 = new GameObject();
                wall2.name = "wall";
                wall2.transform.x = 0;
                wall2.transform.y = i;
                wall2.AddComponent(new MeshFilter('*', ConsoleColor.DarkRed, ConsoleColor.DarkRed, true));
                wall2.AddComponent(new MeshRenderer(0, 0, 255, 0, "wall.bmp", false, false));
                wall2.AddComponent(new Collider());
                Engine.instance.Instanciate(wall2);

                GameObject wall4 = new GameObject();
                wall4.name = "wall";
                wall4.transform.x = xSize - 1;
                wall4.transform.y = i;
                wall4.AddComponent(new MeshFilter('*', ConsoleColor.DarkRed, ConsoleColor.DarkRed, true));
                wall4.AddComponent(new MeshRenderer(0, 0, 255, 0, "wall.bmp", false, false));
                wall4.AddComponent(new Collider());
                Engine.instance.Instanciate(wall4);

                // wall middle
                if(i != (ySize / 2))
                {
                    GameObject wall3 = new GameObject();
                    wall3.name = "wall";
                    wall3.transform.x = xSize / 2;
                    wall3.transform.y = i;
                    wall3.AddComponent(new MeshFilter('*', ConsoleColor.DarkRed, ConsoleColor.DarkRed, true));
                    wall3.AddComponent(new MeshRenderer(0, 0, 255, 0, "wall.bmp", false, false));
                    wall3.AddComponent(new Collider());
                    Engine.instance.Instanciate(wall3);
                }
            }

            // props
            GameObject goal = new GameObject();
            goal.name = "Goal";
            goal.transform.x = xSize - 2;
            goal.transform.y = ySize - 2;
            goal.AddComponent(new MeshFilter('G', ConsoleColor.Green, ConsoleColor.Green, true));
            goal.AddComponent(new MeshRenderer(0, 255, 255, 0, "coin.bmp", false, false));
            goal.AddComponent(new Goal());
            Engine.instance.Instanciate(goal);

            GameObject monster = new GameObject();
            monster.name = "Monster";
            monster.transform.x = xSize - 2;
            monster.transform.y = ySize - 2;
            monster.AddComponent(new MeshFilter('M', ConsoleColor.Yellow, ConsoleColor.Yellow, false));
            monster.AddComponent(new MeshRenderer(0, 255, 0, 255, "Slime.bmp", false, false));
            monster.AddComponent(new MonsterController());
            Engine.instance.Instanciate(monster);

            GameObject player = new GameObject();
            player.name = "Player";
            player.transform.x = 1;
            player.transform.y = 1;
            player.AddComponent(new MeshFilter('P', ConsoleColor.DarkGreen, ConsoleColor.DarkGreen, false));
            player.AddComponent(new MeshRenderer(255, 0, 0, 0, "test.bmp", true, true));
            player.AddComponent(new PlayerController());
            player.AddComponent(new Input());
            Engine.instance.Instanciate(player);
        }

        //public static void GameEnd(string input)
        //{
        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.SetCursorPosition(0, ySize);
        //    Console.WriteLine(input);
        //    Console.ForegroundColor = ConsoleColor.Black;
        //}
    }
}
