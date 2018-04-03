using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDemo1
{
    class Vertex
    {
        public float x;
        public float y;

        public override string ToString()
        {
            return string.Format("({0},{1})", x, y);
        }
    }
}
