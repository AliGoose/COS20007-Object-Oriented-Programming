using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DungeonCrawler
{
    public class Bite : Ability
    {
        public Bite(Character user) : base(0, user, false, true, "Bite", "Deal 2-3 damage to one target")
        {

        }

        public override string Use(FriendlyParty friendlyParty, EnemyParty enemyParty, int input)
        {
            string output = "";
            Power = User.Power + RNG.Next(0, 2);
            Target = friendlyParty.GetCharacter(RNG.Next(1, friendlyParty.Members.Count + 1));
            Target.AddHealth(-Power);
            output += "[#" + (enemyParty.Members.IndexOf(User) + 1) + "] " + User.Name + " bites " + Target.Name + " dealing " + Power + " damage";
            output += PostUse(friendlyParty);
            return output;
        }
    }
}
