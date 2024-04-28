using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    public class ManaPotion : Item
    {

        public ManaPotion(int quantity) : base("Mana Potion", "a potion that restores 5 mana", 5, quantity, 5)
        {

        }

        public override string Use(Character user)
        {
            if (ChangeQuantity(-1) == true)
            {
                user.AddMana(5);
                user.ActionTaken = true;
                return user.Name + " has restored 5 mana\r\n";
            }
            else
            {
                return "You do not have enough mana potions\r\n";
            }
        }
    }
}
