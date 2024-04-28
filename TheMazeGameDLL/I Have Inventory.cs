using System;
using System.Collections.Generic;
using System.Text;

namespace TheMazeGameDLL
{
    public interface I_Have_Inventory
    {
        string Name
        {
            get;
        }
        Inventory Inventory
        {
            get;
        }

        Game_Object Locate(string id);
    }
}
