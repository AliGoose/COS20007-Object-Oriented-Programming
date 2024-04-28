using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DungeonCrawler
{
    public class Inventory
    {
        private List<Item> _items;

        /// <summary>
        /// Return a list of all items as a string for Combat
        /// </summary>
        public string List
        {
            get
            {
                string output = "";
                foreach (Item item in _items)
                {
                    output += (_items.IndexOf(item) + 1) + ". [" + item.Quantity + "/" + item.MaxQuantity + "]\t" + item.Name + ", " + item.Description + "\r\n";
                }
                return output;
            }
        }
        /// <summary>
        /// Return a list of all items as a string for the Main Menu and Shop
        /// </summary>
        public string MenuList
        {
            get
            {
                string output = "";
                foreach (Item item in _items)
                {
                    output += "[" + item.Quantity + "/" + item.MaxQuantity + "]\t" + item.Name + ", " + item.Description + "\r\n";
                }
                return output;
            }
        }
        /// <summary>
        /// Return an integer representing the amount of unique items this inventory contains
        /// </summary>
        public int UniqueItemsCount
        {
            get
            {
                return _items.Count;
            }
        }
        public List<Item> Items
        {
            get
            {
                return _items;
            }
        }

        public Inventory()
        {
            _items = new List<Item>();
        }

        /// <summary>
        /// Add item to this inventory
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        /// <summary>
        /// Return an item from this inventory based on given string representing the items name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Item GetItem(string name)
        {
            foreach (Item t in _items)
            {
                if (t.Name.ToLower() == name.ToLower())
                {
                    return t;
                }
            }
            return null;
        }

        /// <summary>
        /// Return an item from this inventory based on the given index of the item
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Item GetItem(int index)
        {
            foreach (Item t in _items)
            {
                if (t.Name.ToLower() == _items[index-1].Name.ToLower())
                {
                    return t;
                }
            }
            return null;
        }
    }
}
