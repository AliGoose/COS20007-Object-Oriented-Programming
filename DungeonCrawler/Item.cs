using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    public abstract class Item : IdentifiableEntity
    {
        private int _value;
        private int _quantity;
        private int _maxQuantity;
        private Item _instance;

        /// <summary>
        /// Return an int representing this items value
        /// </summary>
        public int Value
        {
            get
            {
                return _value;
            }
        }
        /// <summary>
        /// Return an int represetning the quantity of this item
        /// </summary>
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }
        /// <summary>
        /// Return an int representing the max quantity of this item
        /// </summary>
        public int MaxQuantity
        {
            get
            {
                return _maxQuantity;
            }
        }

        public Item(string name, string desc, int value, int quantity, int carryAmount) : base(name, desc)
        {
            _value = value;
            _quantity = quantity;
            _maxQuantity = carryAmount;
            _instance = this;
        }

        public Item GetInstance()
        {
            return _instance;
        }

        /// <summary>
        /// Return true if this item was used successfully
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public abstract string Use(Character user);

        /// <summary>
        /// Return true if the quantity of this item was changed successfully
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool ChangeQuantity(int amount)
        {
            if (_quantity == 0 && amount < 0)
            {
                return false;
            }
            else if (_quantity == _maxQuantity && amount > 0)
            {
                return false;
            }
            else
            {
                _quantity += amount;
                return true;
            }
        }
    }
}
