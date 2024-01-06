using System;
using System.Threading;

namespace Leetcode.Concurrency
{
    public class Foo
    {
        private static Semaphore s1;
        private static Semaphore s2;

        public Foo()
        {
            s1 = new Semaphore(initialCount: 0, maximumCount: 1);
            s2 = new Semaphore(initialCount: 0, maximumCount: 1);
        }

        public void First(Action printFirst)
        {
            printFirst();
            s1.Release();
        }

        public void Second(Action printSecond)
        {
            s1.WaitOne();
            printSecond();
            s2.Release(); // Если в цикле. System.Threading.SemaphoreFullException: "Adding the specified count to the semaphore would cause it to exceed its maximum count."
        }

        public void Third(Action printThird)
        {
            s2.WaitOne();
            printThird();
        }
    }
}
