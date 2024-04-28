using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DungeonCrawler
{
    public class Sing : Ability
    {
        /// <summary>
        /// Return a string of the abilities description
        /// </summary>
        public override string Description
        {
            get
            {
                return "Heal " + (User.Power + 3) + " for a single target";
            }
        }

        public Sing(Character user) : base(3, user, true, true, "Sing", "Heal 4 HP for a single target")
        {

        }

        public override string Use(FriendlyParty friendlyParty, EnemyParty enemyParty, int input)
        {
            string output = "";
            Target = friendlyParty.GetCharacter(input);
            Power = User.Power + 3;
            Target.AddHealth(Power);
            output += User.Name + " heals " + Target.Name + ", restoring " + Power + " HP";
            output += PostUse(friendlyParty);
            return output;
        }
    }
}
