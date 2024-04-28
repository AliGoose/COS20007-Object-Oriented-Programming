using System;
using System.Collections.Generic;
using System.Text;

namespace TheMazeGameDLL
{
    public class TakeCommand : Command
    {
        public TakeCommand() : base(new string[] {"take", "pickup"})
        {

        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 2 && text.Length != 4)
            {
                return "I don't know how to pickup/take like that";
            }
            if (text.Length == 4 && text[2] != "from")
            {
                return "Invalid 'from' input";
            }
            if (text.Length == 4 && p.Locate(text[3]) == null)
            {
                return "I could not find that bag in the players inventory";
            }
            else if (text.Length == 2)
            {
                if (p.Location.Locate(text[1]) == null)
                {
                    return "Can't find that item in the " + p.Location.Name;
                }
                p.Inventory.Put(p.Location.Inventory.Take(text[1]));
                return "You have picked up the " + text[1];
            }
            else if (text.Length == 4)
            {
                I_Have_Inventory container = LookCommand.FetchContainer(p, text[3]);
                if (container.Locate(text[1]) == null)
                {
                    return "Can't find that item in " + text[3];
                }
                p.Inventory.Put(container.Inventory.Take(text[1]));
                return "You have taken the " + text[1] + " out of your " + text[3];
            }
            return null;
        }
    }
}
