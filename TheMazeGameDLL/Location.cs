using System;
using System.Collections.Generic;
using System.Text;

namespace TheMazeGameDLL
{
    public class Location : Game_Object, I_Have_Inventory
    {
        private Inventory _inventory;
        private List<Path> _paths;

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public override string FullDescription
        {
            get
            {
                string a = base.FullDescription;
                if (Inventory.ItemList != "")
                {
                    a += "\r\nThe surrounding loot includes:\r\n" + Inventory.ItemList;
                }
                return a;
            }
        }

        public Location(string[] idents, string name, string desc) : base(idents, name, desc)
        {
            _inventory = new Inventory();
            _paths = new List<Path>();
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

        public Path LocatePath(string id)
        {
            foreach (Path pth in _paths)
            {
                if (pth.AreYou(id) == true)
                {
                    return pth;
                }
            }
            return null;
        }

        public void AddPath(Path x)
        {
            _paths.Add(x);
        }
    }
}