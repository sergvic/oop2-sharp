using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpDemo1
{
    enum weekDay { mon, tue, wed, fri};

    interface IDrawable
    {
        void Draw();
    }

    class Animal
    {
        protected string name;
    }

    class Cat : Animal, IDrawable
    {
        public void Draw()
        {
            Console.WriteLine("Cat Drawn");
        }
    }

    enum FigureTypes { SingleDim, Flat, Volume };

    class Figure {
        public Figure(FigureTypes newType)
        {
            Console.WriteLine("Figure ctr");
            Type = newType;
        }

        public FigureTypes Type;

        public virtual float getSquare()
        {
            return -1;
        }
    }

    class LineSegment: Figure, IDrawable
    {
        public LineSegment():base(FigureTypes.SingleDim)
        {
            
        }
        public void Draw() {
            Console.WriteLine("LineSegment Drawn");
        }
        public override float getSquare()
        {
            return 1;
        }
    }

    class Point : Figure, IDrawable, IComparable<Point>, IComparable
    {
        private double _x;
        private double _y;

        public Point() : base(FigureTypes.SingleDim)
        {
            Console.WriteLine("Point ctr");
            x = y = 0;
        }

        public override float getSquare()
        {            
            return 0;
        }

        public double x {
            get { return _x; }
            set { _x = value * value; }
        }

        public double y
        {
            get { return _y; }
            set { _y = value; }
        }

        public void Draw()
        {
            Console.WriteLine("Point Drawn");
        }



        public int CompareTo(Point other)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }

    struct PointStruct
    {
        public double x;
        public double y;
    }

    class SceneObjects<T> where T: IDrawable, new()
    {
        T[] objects;

        void drawScene()
        {
            var a = new T();
            foreach (var item in objects)
            {
                item.Draw();
            }
        }
    }

    class Program
    {
        int mult(int a, int b)
        {
            return a * b;
        }

        static void changePoint(Point p)
        {
            p.y = -10;
        }

        static void changePointStruct(PointStruct p)
        {
            p.y = -10;
        }

        static void RenderScene(IDrawable[] items)
        {
            foreach (var item in items)
            {
                item.Draw();
            }
        }

        static void testInterfaces()
        {
            Point p1 = new Point() { x = 1, y = 2 };
            Point p2 = new Point() { x = 12, y = 3 };
            LineSegment line = new LineSegment();
            Cat pussy = new Cat();
            Cat murzik = new Cat();

            IDrawable[] objects = { p1, p2, pussy };

            RenderScene(objects);

            Figure[] figures = { p1, p2, line };
            Console.Write("p1: {0}; p2: {1}; line: {2}",
                figures[0].getSquare(), figures[1].getSquare(), figures[2].getSquare()
                );
        }

        static void ProcessList(List<IDrawable> list)
        {
            foreach (var item in list)
            {
                item.Draw();
            }
        }

        static void ProcessDictionary(Dictionary<string, IDrawable> items)
        {
            foreach (KeyValuePair<string, IDrawable> item in items)
            {
                item.Value.Draw();
            }
        }

        static void TestList()
        {
            Point p1 = new Point() { x = 1, y = 2 };
            Point p2 = new Point() { x = 12, y = 3 };
            LineSegment line = new LineSegment();
            Cat pussy = new Cat();
            Cat murzik = new Cat();
            string oops = "oops";

            List<IDrawable> figures = new List<IDrawable>();
            figures.Add(p1);
            figures.Add(p2);
            figures.Add(pussy);
            figures.Remove(p1);

            ProcessList(figures);

            return;
        }

        class PointComparer : IEqualityComparer<IDrawable>
        {
            public bool Equals(IDrawable x, IDrawable y)
            {
                return true;
            }

            public int GetHashCode(IDrawable obj)
            {
                return obj.GetHashCode();
            }
        }

        static void Main(string[] args)
        {
            Point p1 = new Point() { x = 1, y = 2 };
            Point p2 = new Point() { x = 12, y = 3 };
            LineSegment line = new LineSegment();
            Cat pussy = new Cat();
            Cat murzik = new Cat();
            string oops = "oops";

            Dictionary<string, IDrawable> figures = new Dictionary<string, IDrawable>()
            {
                { "FirstPoint", p1},
                { "SecondPoint", p2},
                { "Pussy", pussy},
                { "Murzik", new Cat()}
            };

            if(figures.Any(x => x.Value is Cat))
                Console.WriteLine("There is Lambda - CAT in the Dictionary!");

            foreach (var item in figures)
            {
                if(item.Value is Cat)
                {
                    Console.WriteLine("There is CAT in the Dictionary!");
                    break;
                }
            }

            if (figures.ContainsKey("Pussy"))
            {
                Console.WriteLine("Cat OK!");
            }

            ProcessDictionary(figures);

            HashSet<IDrawable> drawableSet = new HashSet<IDrawable>(new PointComparer());
            drawableSet.Add(p1);
            drawableSet.Add(p2);
            drawableSet.Add(p1);
            drawableSet.Add(p1);
            drawableSet.Add(pussy);
            drawableSet.Contains(pussy);

            Console.WriteLine(string.Format("Elements: {0}", drawableSet.Count));

            return;
        }
    }
}
