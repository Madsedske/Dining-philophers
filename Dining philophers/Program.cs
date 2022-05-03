using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dining_philophers
{
    internal class Program
    {
        static object _lock = new object();
        static bool[] forks = { false, false, false, false, false };

        static void Main(string[] args)
        {
            Thread philophers1 = new Thread(Eat);
            philophers1.Start();
            Thread philophers2 = new Thread(Eat);
            philophers2.Start();
            Thread philophers3 = new Thread(Eat);
            philophers3.Start();
            Thread philophers4 = new Thread(Eat);
            philophers4.Start();
            Thread philophers5 = new Thread(Eat);
            philophers5.Start();

            philophers1.Name = "p1";
            philophers2.Name = "p2";
            philophers3.Name = "p3";
            philophers4.Name = "p4";
            philophers5.Name = "p5";

            philophers1.Join();
            philophers2.Join();
            philophers3.Join();
            philophers4.Join();
            philophers5.Join();
        }

        static void Eat()
        {
            while (true)
            {


            }
        }
    }
}