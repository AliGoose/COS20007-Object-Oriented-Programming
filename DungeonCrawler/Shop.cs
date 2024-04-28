using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    public class Shop
    {
        private FriendlyParty _friendlyParty;

        public int Exit
        {
            get
            {
                return _friendlyParty.Inventory.UniqueItemsCount + 1;
            }
        }

        public Shop(FriendlyParty friendlyParty)
        {
            _friendlyParty = friendlyParty;
        }

        /// <summary>
        /// Return a string of all the potiential items the player can buy
        /// </summary>
        /// <param name="friendlyParty"></param>
        /// <returns></returns>
        public string ShopDisplay()
        {
            string output = _friendlyParty.MenuDisplay + "What would you like to buy?\r\n";
            foreach (Item t in _friendlyParty.Inventory.Items)
            {
                output += (_friendlyParty.Inventory.Items.IndexOf(t) + 1) + ". ($" + t.Value + ") [" + t.Quantity + "/" + t.MaxQuantity + "]\t" + t.Name + ", " + t.Description + "\r\n";
            }
            output += (_friendlyParty.Inventory.UniqueItemsCount + 1) + ". Back";
            return output;
        }

        /// <summary>
        /// Return item if given a valid input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Item SelectItem(int input)
        {
            return _friendlyParty.Inventory.GetItem(input);
        }

        /// <summary>
        /// Return a string confirming the outcome of buying an item
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string BuyItem(int input)
        {
            if (SelectItem(input).Value > _friendlyParty.Gold)
            {
                return "You cannot afford that item";
            }
            else if (SelectItem(input).ChangeQuantity(1) == false)
            {
                return "You can't carry any more of that item"; 
            }
            else
            {
                _friendlyParty.Gold -= SelectItem(input).Value;
                return "You have bought one " + SelectItem(input).Name;
            }
        }
    }
}
