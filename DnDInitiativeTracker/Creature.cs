using System;
using System.Collections.Generic;
using System.Text;

namespace DnDInitiativeTracker
{
    public class Creature
    {
        private string _name;
        private int _initiative;

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
        public int Initiative
        {
            get
            {
                return _initiative;
            }
            set
            {
                _initiative = value;
            }
        }

        public Creature(string name)
        {
            _name = name;
        }
    }
}
