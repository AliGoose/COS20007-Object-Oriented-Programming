using System;
using System.Collections.Generic;
using System.Text;

namespace TheMazeGameDLL
{
    public class Path : Game_Object
    {
        private Location _location;

        public override string FullDescription
        {
            get
            {
                return "You head " + Name + Environment.NewLine + base.FullDescription + Environment.NewLine + "You arrive at a ";
            }
        }

        public Path(string[] idents, string name, string desc, Location loc) : base(idents, name, desc)
        {
            _location = loc;
        }

        public void Move(Player p)
        {
            p.Location = _location;
        }
    }
}
