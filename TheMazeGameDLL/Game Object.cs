using System;
using System.Collections.Generic;
using System.Text;

namespace TheMazeGameDLL
{
    public abstract class Game_Object : IdentifiableObject
    {
        private string _description;
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
        }
        public string ShortDescription
        {
            get
            {
                string a = "a " + _name + " (" + FirstId + ")";
                return a;
            }
        }
        public virtual string FullDescription
        {
            get
            {
                return _description;
            }
        }

        public Game_Object(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }

    }
}
