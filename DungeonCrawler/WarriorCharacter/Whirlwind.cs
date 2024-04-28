using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DungeonCrawler
{
    public class Whirlwind : Ability
    {
        /// <summary>
        /// Return a string of the abilities description
        /// </summary>
        public override string Description
        {
            get
            {
                return "Deal " + User.Power + " damage to all targets";
            }
        }

        public Whirlwind(Character user) : base(3, user, false, false, "WhirlWind", "Deal " + user.Power + " damage to all targets")
        {

        }

        public override string Use(FriendlyParty friendlyParty, EnemyParty enemyParty, int input)
        {
            string output = User.Name + " spins his sword in a circle\r\n";
            foreach (Character c in enemyParty.Members)
            {
                Power = User.Power;
                c.AddHealth(-Power);
                output += "[#" + (enemyParty.Members.IndexOf(c) + 1) + "] " + c.Name + " takes " + Power + " damage\r\n";
            }
            output += PostUse(enemyParty);
            return output;
        }
    }
}
