using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DungeonCrawler
{
    public abstract class Party
    {
        private List<Character> _members;
        private List<Character> _deadMembers;
        private bool _partyAlive;

        public List<Character> Members
        {
            get
            {
                return _members;
            }
        }
        public List<Character> DeadMembers
        {
            get
            {
                return _deadMembers;
            }
            set
            {
                _deadMembers = value;
            }
        }
        /// <summary>
        /// Return true if atleast one party member is alive
        /// </summary>
        public bool PartyAlive
        {
            get
            {
                return _partyAlive;
            }
            set
            {
                _partyAlive = value;
            }
        }

        /// <summary>
        /// Return a list of all alive party members including their descriptions
        /// </summary>
        public abstract string FullDescription
        {
            get;
        }

        /// <summary>
        /// Return a list of all alive party memebrs
        /// </summary>
        public abstract string NameList
        {
            get;
        }

        public Party()
        {
            _members = new List<Character>();
            _deadMembers = new List<Character>();
            _partyAlive = true;
        }

        /// <summary>
        /// Return a string showing if a party member has been slain
        /// </summary>
        /// <returns></returns>
        public virtual string CheckPartyAlive()
        {
            string output = "";
            foreach (Character c in _members)
            {
                if (c.Health < 1)
                {
                    output += c.Name + " has been slain\r\n";
                    _deadMembers.Add(c);
                }
            }
            foreach (Character c in _deadMembers)
            {
                _members.Remove(c);
            }
            if (_members.Count < 1)
            {
                _partyAlive = false;
            }
            return output;
        }

        /// <summary>
        /// Return true if all members have executed an action this turn. Return false if atleast one member hasn't executed a method yet.
        /// </summary>
        /// <returns></returns>
        public bool CheckPartyActions()
        {
            foreach (Character c in _members)
            {
                if (c.ActionTaken == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Add a character to this party
        /// </summary>
        /// <param name="c"></param>
        public void AddCharacter(Character c)
        {
            _members.Add(c);
        }

        /// <summary>
        /// Return a character based on given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Character GetCharacter(int index)
        {
            return _members[index - 1];
        }
    }
}
