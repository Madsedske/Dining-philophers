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
                if (forks[4] == false && forks[0] == false)
                {
                    Monitor.Enter(_lock);
                    try
                    {
                        Console.WriteLine("Philsopher 1 is eating..");
                        forks[4] = true;
                        forks[0] = true;
                        Thread.Sleep(1000);
                    }                  
                    finally
                    {
                        Console.WriteLine("Philsopher 1 stops eat..");
                        forks[4] = false;
                        forks[0] = false;
                        Monitor.Exit(_lock);
                    }
                }
                else
                    Console.WriteLine("Philsopher 1 is waiting...");

                if (forks[0] == false && forks[1] == false)
                {
                    Monitor.Enter(_lock);

                    try
                    {
                        Console.WriteLine("Philsopher 2 is eating..");

                        forks[0] = true;
                        forks[1] = true;
                        Thread.Sleep(1000);
                    }                  
                    finally
                    {
                        Console.WriteLine("Philsopher 2 stops eat..");
                        forks[0] = false;
                        forks[1] = false;
                        Monitor.Exit(_lock);

                    }
                }
                else
                    Console.WriteLine("Philsopher 2 is waiting...");

                if (forks[1] == false && forks[2] == false)
                {
                    Monitor.Enter(_lock);

                    try
                    {
                        Console.WriteLine("Philsopher 3 is eating..");

                        forks[1] = true;
                        forks[2] = true;
                        Thread.Sleep(1000);
                    }
                    
                    finally
                    {
                        Console.WriteLine("Philsopher 3 stops eat..");
                        forks[1] = false;
                        forks[2] = false;
                        Monitor.Exit(_lock);

                    }
                }
                else
                    Console.WriteLine("Philsopher 3 is waiting...");

                if (forks[2] == false && forks[3] == false)
                {
                    Monitor.Enter(_lock);

                    try
                    {
                        Console.WriteLine("Philsopher 4 is eating..");

                        forks[2] = true;
                        forks[3] = true;
                        Thread.Sleep(1000);
                    }                   
                    finally
                    {
                        Console.WriteLine("Philsopher 4 stops eat..");
                        forks[2] = false;
                        forks[3] = false;
                        Monitor.Exit(_lock);

                    }
                }
                else
                    Console.WriteLine("Philsopher 4 is waiting...");

                if (forks[3] == false && forks[4] == false)
                {
                    Monitor.Enter(_lock);

                    try
                    {
                        Console.WriteLine("Philsopher 5 is eating..");

                        forks[3] = true;
                        forks[4] = true; 
                        Thread.Sleep(1000);
                    }                   
                    finally
                    {
                        Console.WriteLine("Philsopher 5 stops eat..");
                        forks[3] = false;
                        forks[4] = false;
                        Monitor.Exit(_lock);
                    }
                }
                else
                    Console.WriteLine("Philsopher 5 is waiting...");
            }
        }
    }
}