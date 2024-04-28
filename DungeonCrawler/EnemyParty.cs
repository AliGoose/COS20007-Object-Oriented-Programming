using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    public class EnemyParty : Party
    {
        private int _totalGoldDrop; //cumalative amount of gold the enemy team has dropped

        public int TotalGoldDrop
        {
            get
            {
                return _totalGoldDrop;
            }
        }
        public override string NameList
        {
            get
            {
                string nameList = "";
                foreach (Character c in Members)
                {
                    nameList += (Members.IndexOf(c) + 1) + ". [#" + (Members.IndexOf(c) + 1) + "] " + c.Name + "\r\n";
                }
                return nameList;
            }
        }

        /// <summary>
        /// Return a representing all the enemies health, name and descriptions
        /// </summary>
        public override string FullDescription
        {
            get
            {
                string partyList = "";
                foreach (Character c in Members)
                {
                    partyList += "(HP " + c.Health + "/" + c.MaxHealth + ")\t\t\t[#" + (Members.IndexOf(c) + 1) + "] " + c.Name + ", " + c.Description + "\r\n";
                }
                return partyList;
            }
        }

        public EnemyParty() : base()
        {
            _totalGoldDrop = 0;
        }

        public override string CheckPartyAlive()
        {
            string output = "";
            foreach (Character c in Members)
            {
                if (c.Health < 1)
                {
                    output += "[#" + (Members.IndexOf(c) + 1) + "] " + c.Name + " has been slain\r\n";
                    DeadMembers.Add(c);
                    output += DropGold(c as Enemy) + "\r\n\r\n";
                }
            }
            foreach (Character c in DeadMembers)
            {
                Members.Remove(c);
            }
            if (Members.Count < 1)
            {
                PartyAlive = false;
            }
            return output;
        }

        /// <summary>
        /// Add the amount of gold the enemy dropped to the cumalitve gold drop of this enemy party
        /// </summary>
        /// <param name="enemy"></param>
        private string DropGold(Enemy enemy)
        {
            _totalGoldDrop += enemy.GoldDrop;
            return "You have looted " + enemy.GoldDrop + " gold from [#" + (Members.IndexOf(enemy) + 1) + "] " + enemy.Name;
        }
    }
}
