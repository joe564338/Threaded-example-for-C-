using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace ConsoleApp2
{
    class Threaded
    {
        static double X { get; set; }
        static double Y { get; set; }
        static double Z { get; set; }
        static double XV { get; set; }
        static double YV { get; set; }
        static double ZV { get; set; }
        static double XA { get; set; }
        static double YA { get; set; }
        static double ZA { get; set; }
        public void Initialize()
        {
            X = 0;
            Y = 0;
            Z = 0;
            XV = 0;
            YV = 0;
            ZV = 0;
            XA = 0;
            YA = 0;
            ZA = 0;
        }
        public Threaded() { }
        private void ChangeAccel()
        {
            Random random = new Random();
            XA = (-.5 + random.NextDouble()) * 20;
            YA = (-.5 + random.NextDouble()) * 20;
            ZA = (-.5 + random.NextDouble()) * 20;
            Console.WriteLine("CHANGING ACCELLERATION");
            
        }
        public void TryChangeAccel()
        {
            int i = 0;
            while (i < 9)
            {
                i++;
                Console.WriteLine("TRYING TO CHANGE ACCELLERATION");
                Random random = new Random();
                if (random.NextDouble() > .4)
                {
                    ChangeAccel();
                }
                Thread.Sleep(6000);
            }
        }
        public void Update()
        {
            
            int i = 0;
            while (i < 60)
            {
                i++;
                X += XV;
                Y += YV;
                Z += ZV;
                XV += XA;
                YV += YA;
                ZV += ZA;
                Console.WriteLine("UPDATE: Coords: <{0}, {1}, {2}> Velocity: <{3}, {4}, {5}> Accelleration: <{6}, {7}, {8}>", X, Y, Z, XV, YV, ZV, XA, YA, ZA);
                Thread.Sleep(1000);
            }
            
        }
    }
}
