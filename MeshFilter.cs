using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project230725
{
    class MeshFilter : Component
    {
        public MeshFilter()
        {
            //' ' == " "
            //" " = ' ' '\0'
            Shape = ' ';
            frontColor = ConsoleColor.Black;
            backColor = ConsoleColor.Black;
            isStatic = true;
        }
        public MeshFilter(char shape, ConsoleColor _frontColor, ConsoleColor _backColor, bool _isStatic)
        {
            //' ' == " "
            //" " = ' ' '\0'
            Shape = shape;
            frontColor = _frontColor;
            backColor = _backColor;
            isStatic = _isStatic;
        }

        ~MeshFilter()
        {
        }

        public char Shape;
        public ConsoleColor frontColor;
        public ConsoleColor backColor;
        public bool isStatic;
    }
}
