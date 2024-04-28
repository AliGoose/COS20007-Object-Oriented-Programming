using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DungeonCrawler
{
    public class ShockWave : Ability
    {
        /// <summary>
        /// Return a string of the abilities description
        /// </summary>
        public override string Description
        {
            get
            {
                return "Deal " + (User.Power + 1) + " to all targets";
            }
        }

        public ShockWave(Character user) : base(5, user, false, false, "ShockWave", "Deal 4 damage to all targets")
        {

        }

        public override string Use(FriendlyParty friendlyParty, EnemyParty enemyParty, int input)
        {
            string output = User.Name + " emits a shockwave hitting all enemy targets\r\n";
            foreach (Character c in enemyParty.Members)
            {
                Power = User.Power + 1;
                c.AddHealth(-Power);
                output += "[#" + (enemyParty.Members.IndexOf(c) + 1) + "] " + c.Name + " takes " + Power + " damage\r\n";
            }
            output += PostUse(enemyParty);
            return output;
        }
    }
}
