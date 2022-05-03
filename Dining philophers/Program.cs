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
        static int number;
        static int leftfork;
        static int rightfork;

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
            


            leftfork = this.number;
            rightfork = (this.number + 1) % 5;

            while (true)
            {

                Thread.Sleep(rand.Next(1000, 5000));

                Monitor.Enter(forks);
                {
                    while (forks[rightfork] == true || forks[leftfork] == true)
                    {
                        Monitor.Wait(forks);
                    }

                    forks[rightfork] = true;
                    forks[leftfork] = true;

                    Monitor.PulseAll(forks);
                }

                //spise sleep
                Thread.Sleep(rand.Next(1000, 5000));

                //færdig med at spise - gaflerne lægges!				
                lock (forks)
                {

                    if (forks[rightfork] == false || forks[leftfork] == false)
                    {
                        throw new InvalidOperationException("What the fuck!");
                    }

                    forks[rightfork] = false;
                    forks[leftfork] = false;
                    Monitor.PulseAll(forks);
                }
            }
        }
    }