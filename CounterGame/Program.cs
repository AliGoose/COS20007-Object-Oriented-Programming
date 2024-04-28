using System;

namespace CounterGame
{
    class Program
    {
        public static void Main(string[] args)
        {
            Clock myClock = new Clock();
            for (int i = 1; i <= 90075; i++)
            {
                myClock.Tick();
            }
            myClock.Print();
        }
    }
}