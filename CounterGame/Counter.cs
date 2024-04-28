using System;
using System.Collections.Generic;
using System.Text;

namespace CounterGame
{
    public class Counter
    {
        private int _count;
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public int Ticks
        {
            get
            {
                return _count;
            }
        }

        public Counter (string name)
        {
            _count = 0;
            _name = name;
        }

        public void Increment()
        {
            _count++;
        }

        public void Reset()
        {
            _count = 0;
        }
    }
}
