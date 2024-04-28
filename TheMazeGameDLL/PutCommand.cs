using System;
using System.Collections.Generic;
using System.Text;

namespace TheMazeGameDLL
{
    public class PutCommand : Command
    {
        public PutCommand() : base(new string[] {"put", "drop"})
        {

        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 2 && text.Length != 4)
            {
                return "I don't know how to put/drop like that";
            }
            if (text.Length == 4 && text[2] != "in")
            {
                return "Invalid 'in' input";
            }
            if (p.Locate(text[1]) == null)
            {
                return "I could not find that item in the players inventory. \r\n>>NOTE: You must take an item out of its bag before you can drop it.<<";
            }
            if (text.Length == 4 && p.Locate(text[3]) == null)
            {
                return "I could not find that bag in the players inventory. \r\n>>NOTE: You must take an item out of its bag before you can drop it.<<";
            }
            else if (text.Length == 2)
            {
                p.Location.Inventory.Put(p.Inventory.Take(text[1]));
                return "You have dropped your " + text[1];
            }
            else if (text.Length == 4)
            {
                I_Have_Inventory container = LookCommand.FetchContainer(p, text[3]);
                container.Inventory.Put(p.Inventory.Take(text[1]));
                return "You have put your " + text[1] + " in your " + text[3];
            }
            return null;
        }
    }
}
