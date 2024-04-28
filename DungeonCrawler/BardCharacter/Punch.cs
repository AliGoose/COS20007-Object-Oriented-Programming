using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DungeonCrawler
{
    public class Punch : Ability
    {
        /// <summary>
        /// Return a string of the abilities description
        /// </summary>
        public override string Description
        {
            get
            {
                return "Deal " + (User.Power - 1) + "-" + User.Power + " to a single target";
            }
        }

        public Punch(Character user) : base(1, user, true, false, "Punch", "Deal 0-1 damage to a single target")
        {

        }

        public override string Use(FriendlyParty friendlyParty, EnemyParty enemyParty, int input)
        {
            string output = "";
            Target = enemyParty.GetCharacter(input);
            Power = User.Power + RNG.Next(-1, 1);
            Target.AddHealth(-Power);
            output += User.Name + " punches [#" + (enemyParty.Members.IndexOf(Target) + 1) + "] " + Target.Name + " dealing " + Power + " damage";
            output += PostUse(enemyParty);
            return output;
        }
    }
}