using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    public class HealthPotion : Item
    {
        public HealthPotion(int quantity) : base("Health Potion", "a potion that restores 5 health", 3, quantity, 5)
        {

        }

        public override string Use(Character user)
        {
            if (ChangeQuantity(-1) == true)
            {
                user.AddHealth(5);
                user.ActionTaken = true;
                return user.Name + " has restored 5 health\r\n";
            }
            else
            {
                return "You do not have enough health potions\r\n";
            }
        }
    }
}
