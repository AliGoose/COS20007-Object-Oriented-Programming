using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DungeonCrawler
{
    public class Enemy : Character
    {
        private int _goldDrop; //the amount of gold they'll drop when slain

        /// <summary>
        /// Return an int representing the amount of gold the enemy drops
        /// </summary>
        public int GoldDrop
        {
            get
            {
                return _goldDrop;
            }
        }

        public Enemy(int health, int maxHealth, int mana, int maxMana, int power, int gold, string classType, string name, string desc) : base(health, maxHealth, mana, maxMana, power, classType, name, desc)
        {
            _goldDrop = gold;
        }
    }
}
