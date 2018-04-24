using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestTask
{
    delegate void onReallyHungry(Duck creature);

    class Duck
    {
        public static bool killDucks = false;

        public onReallyHungry IAmHungry;

        private int hunger;
        public int Hunger {
            get { return hunger; }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        private string name;

        private int eatingAbility;

        private void lifeIsPassing()
        {
            while (!killDucks)
            {
                hunger += eatingAbility;
                if (hunger > 5 && IAmHungry != null)
                {
                    IAmHungry(this);
                }

                Console.WriteLine($"{this.name} is alive!");
                Thread.Sleep(1000);
            }
        }

        public Duck(string name, int eatingAbility)
        {
            this.name = name;
            this.eatingAbility = eatingAbility;

            Thread th = new Thread(this.lifeIsPassing);
            th.Start();
        }
                
        bool isHungry()
        {
            return hunger>0;
        }

        public void Feed()
        {
            hunger -= 5;
        }

        public void Krya()
        {
            Console.WriteLine($"{this.name} krya");
        }
    }

    class Program
    {
        static void doStarBehavior(Duck x)
        {
            x.Krya(); x.Krya(); x.Krya();
        }

        static void onDuckWantEat(Duck creature)
        {
            Console.WriteLine("{0} is hungry! Level: {1}", creature.Name, creature.Hunger);
            creature.Feed();
        }

        static void Main(string[] args)
        {
            Duck myFavoriteDuck = new Duck("Star", 2);

            myFavoriteDuck.IAmHungry = doStarBehavior;

            List<Duck> kachki = new List<Duck> {
                new Duck("Zoryka", 1),
                new Duck("Lebid", 4),
                myFavoriteDuck
            };

            //Func<Duck, Duck, int> duckSorter =
            //    (x, y) => x.Hunger.CompareTo(y.Hunger);

            // Action<Duck, Duck> test = (x,y) => { x.Feed(); };
            //kachki.OrderBy()

            foreach (var creature in kachki)
                creature.IAmHungry += onDuckWantEat;

            Thread.Sleep(10000);
            myFavoriteDuck.IAmHungry -= doStarBehavior;

            kachki[0].IAmHungry -= onDuckWantEat;
            kachki.RemoveAt(0);

            Duck.killDucks = true;

            while (true)
            {
                Thread.Sleep(500);
            }

            //while (true)
            //{
            //    foreach (var creature in kachki)
            //    {
            //        //Console.WriteLine(string.Format("Hunger: {0}", creature.Hunger));

                //        string temp = $"Duck's hunger level: {creature.Hunger}";

                //        Console.WriteLine(temp);
                //        creature.Krya();
                //        if(creature.Hunger>10)
                //            creature.Feed();

                //        Thread.Sleep(500);
                //    }
                //}
        }
    }
}
