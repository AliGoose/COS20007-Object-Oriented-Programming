using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DungeonCrawler
{
    public class Game
    {
        private FriendlyParty _friendlyParty;
        private Combat _combatEncounter;
        private Shop _shop;

        public Combat CombatEncounter
        {
            get
            {
                return _combatEncounter;
            }
        }
        public Shop ShopEncounter
        {
            get
            {
                return _shop;
            }
        }
        public FriendlyParty FriendlyParty
        {
            get
            {
                return _friendlyParty;
            }
        }

        public Game()
        {
            _friendlyParty = new FriendlyParty();
            _shop = new Shop(_friendlyParty);
            TriggerNewCombat();
        }

        /// <summary>
        /// Create a new combat scenario
        /// </summary>
        public void TriggerNewCombat()
        {
            foreach (Character c in _friendlyParty.Members)
            {
                c.ActionTaken = false;
            }
            _combatEncounter = new Combat(_friendlyParty); //create a new combat scenario
        }
    }
}