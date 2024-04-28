using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DungeonCrawler
{
    public abstract class Ability : IdentifiableEntity
    {
        private int _manaCost; // mana cost of a bility
        private Character _user; // the character that uses this ability
        private int _power; // power of ability
        private Random _rng; // rng modifier used to add a slight randomiser to the power of abilities
        private Character _target; // target of this ability
        private bool _manualTargeting;
        private bool _targetingFriendly;

        public int ManaCost
        {
            get
            {
                return _manaCost;
            }
        }
        public Character User
        {
            get
            {
                return _user;
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
        public Random RNG
        {
            get
            {
                return _rng;
            }
        }
        public Character Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
            }
        }
        /// <summary>
        /// Return true if ability requries user to select targets
        /// </summary>
        public bool ManualTargeting
        {
            get
            {
                return _manualTargeting;
            }
        }
        /// <summary>
        /// Return true if ability targets friendly party
        /// </summary>
        public bool TargetingFriendly
        {
            get
            {
                return _targetingFriendly;
            }
        }

        public Ability(int manaCost, Character user, bool manualTargeting, bool targetingFriendly, string name, string desc) : base(name, desc)
        {
            _manaCost = manaCost;
            _user = user;
            _rng = new Random();
            _manualTargeting = manualTargeting;
            _targetingFriendly = targetingFriendly;
        }

        /// <summary>
        /// Execute the main function of the ability
        /// </summary>
        /// <param name="party"></param>
        /// <param name="enemyParty"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public abstract string Use(FriendlyParty friendlyParty, EnemyParty enemyParty, int input);

        /// <summary>
        /// Apply mana cost from ability and check if party is alive
        /// </summary>
        /// <param name="party"></param>
        /// <returns></returns>
        public string PostUse(Party party)
        {
            _user.AddMana(-_manaCost);
            _user.ActionTaken = true;
            return "\r\n\r\n" + party.CheckPartyAlive();
        }
    }
}
