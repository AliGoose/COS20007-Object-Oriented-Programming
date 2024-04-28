using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DungeonCrawler
{
    public class FriendlyParty : Party
    {
        public Inventory _inventory;
        public int _gold;

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
        /// <summary>
        /// Return an int representing the partys total gold
        /// </summary>
        public int Gold
        {
            get
            {
                return _gold;
            }
            set
            {
                _gold = value;
            }
        }
        public override string NameList
        {
            get
            {
                string nameList = "";
                foreach (Character c in Members)
                {
                    nameList += (Members.IndexOf(c) + 1) + ". ";
                    if (c.ActionTaken == false)
                    {
                        nameList += "[X]\t";
                    }
                    else
                    {
                        nameList += "[O]\t";
                    }
                    nameList += c.Name + "\r\n";
                }
                return nameList;
            }
        }
        public override string FullDescription
        {
            get
            {
                string partyList = "";
                foreach (Character c in Members)
                {
                    partyList += "(HP " + c.Health + "/" + c.MaxHealth + ")\t(MANA " + c.Mana + "/" + c.MaxMana + ")\t" + c.Name + ", " + c.Description + "\r\n";
                }
                return partyList;
            }
        }

        public string MenuDisplay
        {
            get
            {
                return "GOLD: " + _gold + "\r\n\r\n--------------------------------------------------------------\r\n\r\n" + FullDescription + "\r\n" + _inventory.MenuList + "\r\n<><><><><><><><><><><><><><><><><<><><><><><><><<><><><><><><>\r\n\r\n";
            }
        }

        public FriendlyParty()
        {
            _inventory = new Inventory();
        }

        /// <summary>
        /// Return true if total gold amount was changed successfully
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool AddGold(int amount)
        {
            if (_gold == 0 && amount < 0)
            {
                return false;
            }
            else
            {
                _gold += amount;
                return true;
            }
        }

        public override string CheckPartyAlive()
        {
            string output = base.CheckPartyAlive();
            if (PartyAlive == false)
            {
                Save();
            }
            return output;
        }

        /// <summary>
        /// Save this friendly party to a local .txt file
        /// </summary>
        public void Save()
        {
            
            StreamWriter writer = new StreamWriter("C:/Users/aligo/source/repos/COS20007/DungeonCrawler/Resources/SaveFile.txt");
            writer.WriteLine(Members.Count);
            for (int i = 1; i < Members.Count + 1; i++)
            {
                writer.WriteLine(GetCharacter(i).ClassType);
                writer.WriteLine(GetCharacter(i).Name);
                writer.WriteLine(GetCharacter(i).Health);
                writer.WriteLine(GetCharacter(i).Mana);
                writer.WriteLine(GetCharacter(i).Power);
            }
            writer.WriteLine(_inventory.UniqueItemsCount);
            for (int i = 1; i < _inventory.UniqueItemsCount + 1; i++)
            {
                writer.WriteLine(_inventory.GetItem(i).Name);
                writer.WriteLine(_inventory.GetItem(i).Quantity);
            }
            writer.WriteLine(_gold);
            writer.Close();
        }
    }
}
