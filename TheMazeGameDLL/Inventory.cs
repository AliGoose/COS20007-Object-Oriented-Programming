using System;
using System.Collections.Generic;
using System.Text;

namespace TheMazeGameDLL
{
    public class Inventory
    {
        private List<Item> _items;

        public string ItemList
        {
            get
            {
                string a = "";
                foreach (Item itm in _items)
                {
                    a += "   " + itm.ShortDescription + "\r\n";
                }
                return a;
            }
        }

        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool HasItem(string id)
        {
            if (_items.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (Item i in _items)
                {
                    if (i.AreYou(id))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id) == true)
                {
                    _items.Remove(itm);
                    return itm;
                }
            }
            return null;
        }

        public Item Fetch(string id)
        {

            foreach (Item itm in _items)
            {
                if (itm.AreYou(id) == true)
                {
                    return itm;
                }
            }
            return null;
            
        }

    }
}
