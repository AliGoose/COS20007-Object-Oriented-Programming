using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DungeonCrawler
{
    public class Swing : Ability
    {
        /// <summary>
        /// Return a string of the abilities description
        /// </summary>
        public override string Description
        {
            get
            {
                return "Deal " + (User.Power - 1) + "-" + (User.Power + 1) + " to a single target";
            }
        }

        public Swing(Character user) : base(1, user, true, false, "Swing", "Deal " + (user.Power - 1) + "-" + (user.Power + 1) + " to a single target")
        {

        }

        public override string Use(FriendlyParty friendlyParty, EnemyParty enemyParty, int input)
        {
            Target = enemyParty.GetCharacter(input);
            Power = User.Power + RNG.Next(-1, 2);
            Target.AddHealth(-Power);
            string output = User.Name + " swings their sword and deals " + Power + " damage to [#" + (enemyParty.Members.IndexOf(Target) + 1) + "] " + Target.Name + "\r\n\r\n";
            output += PostUse(enemyParty);
            return output;
        }
    }
}
