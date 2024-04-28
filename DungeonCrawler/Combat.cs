using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DungeonCrawler
{
    public class Combat
    {
        private EnemyParty _enemyParty;
        private FriendlyParty _friendlyParty;
        private Character _selectedCharacter;
        private Ability _selectedAbility;
        private CombatState _combatState;
        
        public EnemyParty EnemyParty
        {
            get
            {
                return _enemyParty;
            }
        }
        /// <summary>
        /// Return an enum of Combat State
        /// </summary>
        public CombatState CombatState
        {
            get
            {
                return _combatState;
            }
        }
        public int ExitActionSelection
        {
            get
            {
                return 4;
            }
        }
        public int ExitInventorySelection
        {
            get
            {
                return _friendlyParty.Inventory.UniqueItemsCount + 1;
            }
        }
        public int ExitAbilitySelection
        {
            get
            {
                return _selectedCharacter.Abilities.Count + 1;
            }
        }
        public int ExitTargetSelection
        {
            get
            {
                if (_selectedAbility.TargetingFriendly == false)
                {
                    return _enemyParty.Members.Count + 1;
                }
                else
                {
                    return _friendlyParty.Members.Count + 1;
                }
                
            }
        }

        public Combat(FriendlyParty friendlyParty)
        {
            _enemyParty = new EnemyParty();
            _enemyParty.AddCharacter(CreateEnemy());
            _enemyParty.AddCharacter(CreateEnemy());
            _enemyParty.AddCharacter(CreateEnemy());
            _friendlyParty = friendlyParty;
        }

        /// <summary>
        /// Returns a randomly selected enemy
        /// </summary>
        /// <returns></returns>
        private Enemy CreateEnemy()
        {
            Random RNG = new Random();
            EnemyFactory _enemyFactory = new EnemyFactory();
            EnemyType enemy = (EnemyType)RNG.Next(0,2);
            switch (enemy)
            {
                case EnemyType.Spider :
                    {
                        return _enemyFactory.NewSpider();
                    }
                case EnemyType.Vampire :
                    {
                        return _enemyFactory.newVampire();
                    }
                default :
                    {
                        return null;
                    }
            }
        }

        /// <summary>
        /// Return a string for Combat Display
        /// </summary>
        /// <returns></returns>
        public string CombatDisplay()
        {
            return "GOLD: " + (_friendlyParty.Gold + _enemyParty.TotalGoldDrop) + "\r\n\r\n--------------------------------------------------------------\r\n\r\n" + _friendlyParty.FullDescription + "\r\n<><><><><><><><><><><><><><><><><<><><><><><><><<><><><><><><>\r\n\r\n" + _enemyParty.FullDescription + "\r\n--------------------------------------------------------------\r\n\r\n";
        }

        /// <summary>
        /// Return a string for Hero Selection
        /// </summary>
        /// <returns></returns>
        public string HeroSelectionDisplay()
        {
            return "Select a hero:\r\n" + _friendlyParty.NameList;
        }

        /// <summary>
        /// Return a string for Action Selection
        /// </summary>
        /// <returns></returns>
        public string ActionSelectionDisplay()
        {
            return "Select the type of action for " + _selectedCharacter.Name + ":\r\n1. Abilites\r\n2. Inventory\r\n3. Rest (Restore 2 Mana)\r\n4. Back";
        }

        /// <summary>
        /// Return a string for Inventory Selection
        /// </summary>
        /// <returns></returns>
        public string InventorySelectionDisplay()
        {
            return "Select an item you would like " + _selectedCharacter.Name + " to use:\r\n" + _friendlyParty.Inventory.List + (_friendlyParty.Inventory.UniqueItemsCount + 1) + ". Back";
        }

        /// <summary>
        /// Return a string for Ability Selection
        /// </summary>
        /// <returns></returns>
        public string AbilitySelectionDisplay()
        {
            return "Select the ability you would like " + _selectedCharacter.Name + " to use:\r\n" + (_selectedCharacter.AbilitiesFullDescription) + (_selectedCharacter.Abilities.Count + 1) + ". Back";
        }
        
        /// <summary>
        /// Return a string for Target Selection
        /// </summary>
        /// <returns></returns>
        public string TargetSelectionDisplay()
        {
            string output = "Select a target for " + _selectedCharacter.Name + ":\r\n";
            if (_selectedAbility.TargetingFriendly == false)
            {
                output += _enemyParty.NameList;
            }
            else
            {
                output += _friendlyParty.NameList;
            }
            return output;
            
        }

        /// <summary>
        /// Return a string for hero selection
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string HeroSelection(int input)
        {
            _selectedCharacter = _friendlyParty.GetCharacter(input);
            if (_selectedCharacter.ActionTaken == true)
            {
                return "Please select a character that hasn't taken an action yet";
            }
            else
            {
                _combatState = CombatState.ActionSelection;
                return "You have selected " + _selectedCharacter.Name;
            }        
        }

        /// <summary>
        /// Return a string for action selection
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string ActionSelection(int input)
        {
            switch (input)
            {
                case 1:
                    {
                        _combatState = CombatState.AbilitySelection;
                        return "You have chosen to use one of your abilties";
                    }
                case 2:
                    {
                        _combatState = CombatState.InventorySelection;
                        return "You have chosen to use an item in your inventory";
                    }
                case 3:
                    {
                        _selectedCharacter.AddMana(2);
                        _selectedCharacter.ActionTaken = true;
                        _combatState = CombatState.RestSelection;
                        return _selectedCharacter.Name + " has chosen to rest";
                    }
                default:
                    {
                        return "ERROR";
                    }
            }
        }

        /// <summary>
        /// Return a string for inventory selection
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string InventorySelection(int input)
        {
            string output = _friendlyParty.Inventory.GetItem(input).Use(_selectedCharacter);
            if (_selectedCharacter.ActionTaken == true)
            {
                _combatState = CombatState.HeroSelection;
            }
            return output;
        }

        /// <summary>
        /// Return a string for ability selection
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string AbilitySelection(int input)
        {
            if (_selectedCharacter.Mana < _selectedCharacter.GetAbility(input).ManaCost)
            {
                return _selectedCharacter.Name + " does not have enough mana to cast that ability";
            }
            else
            {
                _selectedAbility = _selectedCharacter.GetAbility(input);
                if (_selectedAbility.ManualTargeting == true)
                {
                    _combatState = CombatState.TargetSelection;
                    return _selectedAbility.Name + " needs a target";
                }
                else
                {
                    _combatState = CombatState.HeroSelection;
                    return _selectedAbility.Use(_friendlyParty, _enemyParty, 0);
                }
                
            }
        }

        /// <summary>
        /// Return a string for target selection
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string TargetSelection(int input)
        {
            return _selectedAbility.Use(_friendlyParty, _enemyParty, input);
        }

        /// <summary>
        /// Return a string for enemy turn
        /// </summary>
        /// <returns></returns>
        public string EnemyTurn()
        {
            string output = "";
            foreach (Character c in _enemyParty.Members)
            {
                output += _friendlyParty.CheckPartyAlive() + "\r\n";
                if (_friendlyParty.PartyAlive == false)
                {
                    break;
                }
                output += c.GetAbility(1).Use(_friendlyParty, _enemyParty, 0);
            }
            foreach (Character c in _friendlyParty.Members)
            {
                c.ActionTaken = false;
            }
            return output;
        }
    }
}
