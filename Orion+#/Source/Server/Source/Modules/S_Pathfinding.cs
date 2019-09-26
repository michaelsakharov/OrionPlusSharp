using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{

    public class Vector2i
    {
        public int x;
        public int y;
        public Vector2i(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    // TODO - Make a pathfinding system to replace the existing one, Mainly to improve pets, and to also allow pets to move diagonally
    // Needs to support both Non diagonal movement AND diagonal movement

}