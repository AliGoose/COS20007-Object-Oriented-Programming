using System;

namespace InterfaceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTransaction m = new MyTransaction("2346", "May 1 2019", 25.6);

            m.ShowTransaction();
        }
    }
}
