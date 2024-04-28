using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DungeonCrawler
{
    public class Drain : Ability
    {
        /// <summary>
        /// Return a string of the abilities description
        /// </summary>
        public override string Description
        {
            get
            {
                return "Deal " + (User.Power - 2) + "-" + User.Power + " to one random target and heal for the amount of damage you deal";
            }
        }

        public Drain(Character user) : base(2, user, false, false, "Drain", "Deal 1-3 damage to one random target and heal for the amount of damage you deal")
        {

        }

        public override string Use(FriendlyParty friendlyParty, EnemyParty enemyParty, int input)
        {
            string output = "";
            Power = User.Power + RNG.Next(-2, 1);
            Target = enemyParty.GetCharacter(RNG.Next(1, enemyParty.Members.Count + 1));
            Target.AddHealth(-Power);
            User.AddHealth(Power);
            output += User.Name + " shoots a fireball at [#" + (enemyParty.Members.IndexOf(Target) + 1) + "] " + Target.Name + " dealing " + Power + " damage and healing for " + Power + " health";
            output += PostUse(enemyParty);
            return output;
        }
    }
}
