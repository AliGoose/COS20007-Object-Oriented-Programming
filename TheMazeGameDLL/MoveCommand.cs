using System;
using System.Collections.Generic;
using System.Text;

namespace TheMazeGameDLL
{
    public class MoveCommand : Command
    {

        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 2)
            {
                return "I don't know how to move like that";
            }
            if (p.Location.LocatePath(text[1]) == null)
            {
                return "That path you have chosen does not exist";
            }
            string a = p.Location.LocatePath(text[1]).FullDescription;
            p.Location.LocatePath(text[1]).Move(p);
            a += p.Location.Name;
            return a;
        }
    }
}
