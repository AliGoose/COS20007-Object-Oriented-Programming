using System;
using System.Collections.Generic;
using System.Text;

namespace TheMazeGameDLL
{
    public class Player : Game_Object, I_Have_Inventory
    {
        private Inventory _inventory;
        private Location _location;

        public override string FullDescription
        {
            get
            {
                string a = "You are " + Name + ", " + base.FullDescription + " \r\nYou are carrying:\r\n" + Inventory.ItemList;
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

        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public Game_Object Locate(string id)
        {
            if (AreYou(id) == true)
            {
                return this;
            }
            else if (_inventory.Fetch(id) != null)
            {
                return _inventory.Fetch(id);
            }
            else
            {
                return _location.Locate(id);
            }
        }
    }
}
