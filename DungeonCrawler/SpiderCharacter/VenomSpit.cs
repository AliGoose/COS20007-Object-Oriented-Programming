using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DungeonCrawler
{
    public class VenomSpit : Ability
    {
        public VenomSpit(Character user) : base(0, user, false, true, "Venom Spit", "Deal 2 damage one target")
        {

        }

        public override string Use(FriendlyParty friendlyParty, EnemyParty enemyParty, int input)
        {
            string output = "";
            Power = User.Power;
            Target = friendlyParty.GetCharacter(RNG.Next(1, friendlyParty.Members.Count + 1));
            Target.AddHealth(-Power);
            output += "[#" + (enemyParty.Members.IndexOf(User) + 1) + "] " + User.Name + " spits venom at " + Target.Name + " dealing " + Power + " damage\r\n";
            output += PostUse(friendlyParty);
            return output;
        }
    }
}
