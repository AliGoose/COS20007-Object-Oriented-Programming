using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    public class Message
    {
        private string _text;

        public Message(string txt)
        {
            _text = txt;
        }

        public void Print()
        {
            Console.WriteLine(_text);
        }
    }
}
