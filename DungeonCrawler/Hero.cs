using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DungeonCrawler
{
    public class Hero : Character
    {
        public Hero(int health,  int maxHealth, int mana, int maxMana, int power, string classType, string name, string desc) : base(health, maxHealth, mana, maxMana, power, classType, name, desc)
        {
            //Hero class is empty and useless, but I think it should stay for clarity and potentialiality of it been useful in further development
        }
    }
}
