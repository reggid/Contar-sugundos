using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Real_Time
{
    class Floor
    {
        public Rectangle Box;
        public bool Done;

        public Floor(Rectangle b)
        {
            Box = b;
            Done = false;
        }

    }
}
