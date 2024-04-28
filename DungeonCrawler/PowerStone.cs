using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    public class PowerStone : Item
    {
        public PowerStone(int quantity) : base("Power Stone", "a stone when rubbed will permamently increase the heroes power by 1", 8, quantity, 3)
        {

        }

        public override string Use(Character user)
        {
            if (ChangeQuantity(-1) == true)
            {
                user.Power += 1;
                user.ActionTaken = true;
                return user.Name + " has permamently gained 1 power\r\n";
            }
            else
            {
                return "You do not have enough power stones\r\n";
            }
        }
    }
}
