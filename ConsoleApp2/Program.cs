using System;
using System.Threading;
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Threaded threaded = new Threaded();
            threaded.Initialize();
            Thread thread2 = new Thread(new ThreadStart(threaded.Update));
            Thread thread = new Thread(new ThreadStart(threaded.TryChangeAccel));
            thread2.Start();
            thread.Start();
            bool alertChangeStop = false;
            bool alertUpdateStop = false;
            while (thread.IsAlive || thread2.IsAlive)
            {
                if (!thread.IsAlive && !alertChangeStop)
                {
                    alertChangeStop = true;
                    Console.WriteLine("Changing accel is stopped");
                }
                if (!thread2.IsAlive && !alertUpdateStop)
                {
                    alertUpdateStop = true;
                    Console.WriteLine("Update has stopped");
                }
            }
            Console.WriteLine("Threads are finished");
        }
    }
}