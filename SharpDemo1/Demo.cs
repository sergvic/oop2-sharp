using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDemo1
{
    interface temp
    {
        float a();
    }

    class Pointa
    {
        public int x;
    }
    class Demo
    {
        public static void testc(Pointa p)
        {
            p.x = 10;
        }

        public static void testOne()
        {
            Pointa p = new Pointa();
            p.x = 5;
            testc(p);
            Console.WriteLine(p.x);
        }

    }
}
