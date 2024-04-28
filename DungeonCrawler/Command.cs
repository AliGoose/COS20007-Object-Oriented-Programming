using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    public class Command
    {
        private bool _exit;
        private Game _game;
        private DisplayState _displayState;

        public bool Exit
        {
            get
            {
                return _exit;
            }
        }

        public Command(Game game)
        {
            _game = game;
            _exit = false;
            _displayState = DisplayState.MainMenu;
        }

        /// <summary>
        /// Return a string for current display
        /// </summary>
        /// <returns></returns>
        public string CurrentDisplay()
        {
            Console.Clear();
            switch(_displayState)
            {
                case DisplayState.MainMenu:
                    {
                        return _game.FriendlyParty.MenuDisplay + "\r\nWhat would you like to do:\r\n1. Combat\r\n2. Shop\r\n3. Save and Exit";
                    }
                case DisplayState.Shop:
                    {
                        return _game.ShopEncounter.ShopDisplay();
                    }
                case DisplayState.CombatSelectHero:
                    {
                        return _game.CombatEncounter.CombatDisplay() + _game.CombatEncounter.HeroSelectionDisplay();
                    }
                case DisplayState.CombatSelectAction:
                    {
                        return _game.CombatEncounter.CombatDisplay() + _game.CombatEncounter.ActionSelectionDisplay();
                    }
                case DisplayState.CombatSelectItem:
                    {
                        return _game.CombatEncounter.CombatDisplay() + _game.CombatEncounter.InventorySelectionDisplay();
                    }
                case DisplayState.CombatSelectAbility:
                    {
                        return _game.CombatEncounter.CombatDisplay() + _game.CombatEncounter.AbilitySelectionDisplay();
                    }
                case DisplayState.CombatSelectTargets:
                    {
                        return _game.CombatEncounter.CombatDisplay() + _game.CombatEncounter.TargetSelectionDisplay();
                    }
                case DisplayState.ComatEnemyTurn:
                    {
                        return _game.CombatEncounter.CombatDisplay() + "\r\n>>>ENEMY PARTY TURN<<<\r\n" + _game.CombatEncounter.EnemyTurn() + "\r\n\r\n...";
                    }
                default:
                    return "ERROR";
            }
        }

        /// <summary>
        /// Return a string representing the programs response to the users input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Execute(int input)
        {
            string output = "";
            switch (_displayState)
            {
                case DisplayState.MainMenu:
                    {
                        switch (input)
                        {
                            case 1:
                                {
                                    _displayState = DisplayState.CombatSelectHero;
                                    _game.TriggerNewCombat();
                                    output += "You have encountered a battle, prepare to fight!";
                                    break;
                                }
                            case 2:
                                {
                                    _displayState = DisplayState.Shop;
                                    output += "You have entered the shop";
                                    break;
                                }
                            case 3:
                                {
                                    _exit = true;
                                    output += "You have saved and exit the game";
                                    break;
                                }
                            default:
                                {
                                    output += "Please enter an integer corresponding to the following options";
                                    break;
                                }
                        }
                        break;
                    }
                case DisplayState.Shop:
                    {
                        if (input < 1 || input > _game.ShopEncounter.Exit)
                        {
                            output += "Please enter an integer corresponding to the following items";
                        }
                        else if (input == _game.ShopEncounter.Exit)
                        {
                            _displayState = DisplayState.MainMenu;
                            output += "You have left the shop";
                        }
                        else
                        {
                            output += _game.ShopEncounter.BuyItem(input);
                        }
                        break;
                    }
                case DisplayState.CombatSelectHero:
                    {
                        if (input < 1 || input > _game.FriendlyParty.Members.Count)
                        {
                            output += "Please enter an integer according to the corresponding available heroes";
                        }
                        else
                        {
                            output += _game.CombatEncounter.HeroSelection(input);
                            if (_game.CombatEncounter.CombatState == CombatState.ActionSelection)
                            {
                                _displayState = DisplayState.CombatSelectAction;
                            }
                        }
                        break;
                    }
                case DisplayState.CombatSelectAction:
                    {
                        if (input < 1 || input > _game.CombatEncounter.ExitActionSelection)
                        {
                            output += "Please enter an integer according to the corresponding available actions";
                        }
                        else if (input == _game.CombatEncounter.ExitActionSelection)
                        {
                            _displayState = DisplayState.CombatSelectHero;
                            output += "You have returned back to hero selection";
                        }
                        else
                        {
                            output = _game.CombatEncounter.ActionSelection(input);
                            switch (_game.CombatEncounter.CombatState)
                            {
                                case CombatState.AbilitySelection:
                                    {
                                        _displayState = DisplayState.CombatSelectAbility;
                                        break;
                                    }
                                case CombatState.InventorySelection:
                                    {
                                        _displayState = DisplayState.CombatSelectItem;
                                        break;
                                    }
                                case CombatState.RestSelection:
                                    {
                                        _displayState = DisplayState.CombatSelectHero;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case DisplayState.CombatSelectItem:
                    {
                        if (input < 1 || input > _game.CombatEncounter.ExitInventorySelection)
                        {
                            output += "Please enter an integer according to the corresponding available items";
                        }
                        else if (input == _game.CombatEncounter.ExitInventorySelection)
                        {
                            _displayState = DisplayState.CombatSelectHero;
                            output += "You have returned back to hero selection";
                        }
                        else
                        {
                            output = _game.CombatEncounter.InventorySelection(input);
                            if (_game.CombatEncounter.CombatState == CombatState.HeroSelection)
                            {
                                _displayState = DisplayState.CombatSelectHero;
                            }
                        }
                        break;
                    }
                case DisplayState.CombatSelectAbility:
                    {
                        if (input < 1 || input > _game.CombatEncounter.ExitAbilitySelection)
                        {
                            output += "Please enter an integer according to the corresponding available abiltiies";
                        }
                        else if (input == _game.CombatEncounter.ExitAbilitySelection)
                        {
                            _displayState = DisplayState.CombatSelectHero;
                            output += "You have returned back to hero selection";
                        }
                        else
                        {
                            output = _game.CombatEncounter.AbilitySelection(input);
                            if (_game.CombatEncounter.CombatState == CombatState.TargetSelection)
                            {
                                _displayState = DisplayState.CombatSelectTargets;
                            }
                            else if (_game.CombatEncounter.CombatState == CombatState.HeroSelection)
                            {
                                _displayState = DisplayState.CombatSelectHero;
                            }
                        }
                        break;
                    }
                case DisplayState.CombatSelectTargets:
                    {
                        if (input < 1 || input > _game.CombatEncounter.ExitTargetSelection)
                        {
                            output += "Please enter an integer according to the corresponding available targets";
                        }
                        else if (input == _game.CombatEncounter.ExitTargetSelection)
                        {
                            _displayState = DisplayState.CombatSelectHero;
                            output += "You have returned back to hero selection";
                        }
                        else
                        {
                            _displayState = DisplayState.CombatSelectHero;
                            output += _game.CombatEncounter.TargetSelection(input);
                        }
                        break;

                    }
                case DisplayState.ComatEnemyTurn:
                    {
                        _displayState = DisplayState.CombatSelectHero;
                        break;
                    }
            }
            if (_exit == false && _displayState != DisplayState.MainMenu && _displayState != DisplayState.Shop)
            {
                if (_game.FriendlyParty.PartyAlive == false)
                {
                    output += "\r\nYour party has been slain";
                    _exit = true;
                    return output;
                }
                if (_game.CombatEncounter.EnemyParty.PartyAlive == false)
                {
                    output += "\r\nYou have slain the enemy party";
                    _game.FriendlyParty.Gold += _game.CombatEncounter.EnemyParty.TotalGoldDrop;
                    _displayState = DisplayState.MainMenu;
                }
                if (_game.FriendlyParty.CheckPartyActions() == true)
                {
                    _displayState = DisplayState.ComatEnemyTurn;
                }
            }
            return output;

        }
    }
}
