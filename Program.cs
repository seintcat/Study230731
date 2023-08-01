using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace Project230725
{
    //interface IFruit
    //{
    //    void Incense();
    //}
    //interface INetwork
    //{
    //    void Connect();
    //}
    //class Plant
    //{

    //}

    //class Apple : Plant, IFruit, INetwork
    //{
    //    public void Connect()
    //    {

    //    }

    //    public void Incense()
    //    {

    //    }
    //}

    internal class Program
    {
        static void Main(string[] args)
        {
            //IFruit apple = new Apple();


            Engine engine = new Engine(30, 20);

            GameObject mapMaker = new GameObject();
            mapMaker.name = "MapMaker";
            mapMaker.transform.x = 0;
            mapMaker.transform.y = 0;
            mapMaker.AddComponent(new MapMaker());
            Engine.instance.Instanciate(mapMaker);

            engine.Run();
        }
    }
}
