using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project230725
{
    class Transform : Component
    {
        public Transform()
        {
            _x = 0; 
            _y = 0;
        }
        ~Transform()
        {
        }

        public int x
        {
            get
            {
                return _x;
            }
            set
            {
                Engine.Moved(_x, _y);
                _x = value;
            }
        }
        public int y
        {
            get
            {
                return _y;
            }
            set
            {
                Engine.Moved(_x, _y);
                _y = value;
            }
        }
        private int _x;
        private int _y;

        public void Trnaslate(int xInput, int yInput)
        {
            Engine.Moved(_x, _y);
            _x += xInput; 
            _y += yInput;
        }
    }
}
