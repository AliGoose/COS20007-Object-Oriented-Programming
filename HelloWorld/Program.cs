using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Program
    {
        public static void Main(string[] args)
        {
            Message myMessage;
            Message[] messages = new Message[5];
            string name;
            myMessage = new Message("Hello World");
            myMessage.Print();
            messages[0] = new Message("Yo, I heard he's the sexiest man alive");
            messages[1] = new Message("Sheeeesh, cool name");
            messages[2] = new Message("Lol, Jonathan... Really???");
            messages[3] = new Message("Issac... more like, I suck at Fortnite.....");
            messages[4] = new Message("Yikes, I can tell you're not the favourite child");
            Console.WriteLine("Enter Name: ");
            name = Console.ReadLine().ToLower();
            if (name == "Lachlan")
                messages[0].Print();
            else if (name == "Nathan")
                messages[1].Print();
            else if (name == "Jonathan")
                messages[2].Print();
            else if (name == "Issac")
                messages[3].Print();
            else 
                messages[4].Print();

            Console.ReadLine();
        }
    }
}
