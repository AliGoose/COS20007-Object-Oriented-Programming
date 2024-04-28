using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DungeonCrawler
{
    public abstract class Character : IdentifiableEntity
    {
        private int _health;
        private int _maxHealth; //highest health the character can reach
        private bool _actionTaken; //indicates whether character has taken an action this turn
        private int _mana;
        private int _maxMana; //highest mana the character can reach
        private int _power; // power level of character
        private List<Ability> _abilities; // list of abilities the character can use
        private string _classType;

        public string ClassType
        {
            get
            {
                return _classType;
            }
        }
        public int Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
            }
        }
        public int MaxHealth
        {
            get
            {
                return _maxHealth;
            }
        }
        /// <summary>
        /// Return true if character has taken an action this turn
        /// </summary>
        public bool ActionTaken
        {
            get
            {
                return _actionTaken;
            }
            set
            {
                _actionTaken = value;
            }
        }
        public int Mana
        {
            get
            {
                return _mana;
            }
            set
            {
                _mana = value;
            }
        }
        public int MaxMana
        {
            get
            {
                return _maxMana;
            }
        }
        public int Power
        {
            get
            {
                return _power;
            }
            set
            {
                _power = value;
            }
        }
        /// <summary>
        /// Return a string which is a list of all the abilities a character has
        /// </summary>
        public string AbilitiesFullDescription
        {
            get
            {
                string abilitiesList = "";
                foreach (Ability a in _abilities)
                {
                    abilitiesList += (_abilities.IndexOf(a) + 1) + ". " + a.Name + " (" + a.Description + ") (" + a.ManaCost + " MANA)\r\n";
                }
                return abilitiesList;
            }
        }
        public List<Ability> Abilities
        {
            get
            {
                return _abilities;
            }
        }

        public Character(int health, int maxHealth, int mana, int maxMana, int power, string classType, string name, string desc) : base(name, desc)
        {
            _health = health;
            _maxHealth = maxHealth;
            _actionTaken = false;
            _mana = mana;
            _maxMana = maxMana;
            _power = power;
            _abilities = new List<Ability>();
            _classType = classType;
        }
        /// <summary>
        /// Add an amount of health to this character
        /// </summary>
        /// <param name="amount"></param>
        public void AddHealth(int amount)
        {
            _health += amount;
            if (_health > _maxHealth) // if health exceeds the characters max health, change it back to the characters max health
            {
                _health = _maxHealth;
            }
        }

        /// <summary>
        /// Add an amount of mana to this character
        /// </summary>
        /// <param name="amount"></param>
        public void AddMana(int amount)
        {
            _mana += amount;
            if (_mana < 0) // if mana goes below zero, return it back to zero
            {
                _mana = 0;
            }
            if (_mana > _maxMana) // if mana exceeds the maximum amount of mana, change it back to the characters maximum mana
            {
                _mana = _maxMana;
            }
        }

        /// <summary>
        /// Add an ability to this character
        /// </summary>
        /// <param name="ability"></param>
        public void AddAbility(Ability ability)
        {
            _abilities.Add(ability);
        }

        /// <summary>
        /// Return an ability the characters hosts using an index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Ability GetAbility(int index)
        {
            return _abilities[index - 1];
        }
    }
}
