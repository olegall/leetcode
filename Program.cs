using Leetcode.Concurrency;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++) // for асинхронный?
            {
                Threads();
                Thread.Sleep(500);
                Console.WriteLine();
            }
            //Console.WriteLine("Hello World!");
        }

        private static void Threads()
        {
            Action a1 = delegate() { Console.WriteLine("first"); };
            Action a2 = delegate() { Console.WriteLine("second"); };
            Action a3 = delegate() { Console.WriteLine("third"); };

            var foo = new Foo();

            new Thread(() => { foo.First(a1); }).Start();
            new Thread(() => { foo.Second(a2); }).Start();
            new Thread(() => { foo.Third(a3); }).Start();

            //Task.Run(() => foo.First(a1));
            //Task.Run(() => foo.Second(a2));
            //Task.Run(() => foo.Third(a3));
        }
    }
}
