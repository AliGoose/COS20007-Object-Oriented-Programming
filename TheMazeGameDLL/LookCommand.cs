using System;
using System.Collections.Generic;
using System.Text;

namespace TheMazeGameDLL
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 1 && text.Length != 3 && text.Length != 5)
            {
                return "I don't know how to look like that";
            }
            if (text.Length > 1 && text[1] != "at")
            {
                return "What do you want to look at?";
            }
            if (text.Length == 5 && text[3] != "in")
            {
                return "What do you want to look in?";
            }
            if (text.Length == 1)
            {
                return p.Location.FullDescription;
            }
            else if (text.Length == 3)
            {
                if (LookAtIn(text[2], p) == null)
                {
                    string exception = "I can't find the " + text[2];
                    return exception;
                }
                else
                {
                    return LookAtIn(text[2], p);
                }
            }
            else if (text.Length == 5)
            {
                I_Have_Inventory container = FetchContainer(p, text[4]);
                if (container == null)
                {
                    string exception = "I can't find the " + text[4];
                    return exception;
                }
                else if (LookAtIn(text[2], container) == null)
                {
                    string exception = "I can't find the " + text[2];
                    return exception;
                }
                else
                {
                    return LookAtIn(text[2], container);
                }
            }
            return null;
        }

        public static I_Have_Inventory FetchContainer(Player p, string containerId)
        {
            I_Have_Inventory obj = p.Locate(containerId) as I_Have_Inventory;
            return obj;
        }

        private string LookAtIn(string thingId, I_Have_Inventory container)
        {
            if (container.Locate(thingId) == null)
            {
                string exception = null;
                return exception;
            }
            else
            {
                return container.Locate(thingId).FullDescription;
            }   
        }
    }
}
