using System;
using System.Collections.Generic;
using System.Text;

namespace TheMazeGameDLL
{
    public class Bag : Item, I_Have_Inventory
    {
        private Inventory _inventory;

        public override string FullDescription
        {
            get
            {
                string a = "Your " + Name + " is empty";
                if (Inventory.ItemList != "")
                {
                    a = "In the " + Name + ", you have:\r\n" + Inventory.ItemList;
                }
                return a;
            }
        }
        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public Game_Object Locate(string id)
        {
            if (AreYou(id) == true)
            {
                return this;
            }
            else
            {
                return _inventory.Fetch(id);

            }
        }
    }
}
