using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    public class HeroesFactory
    {
        public HeroesFactory()
        {

        }

        /// <summary>
        /// Return a new Warrior Hero
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Hero NewWarrior(string name)
        {
            Hero _newWarrior = new Hero(20, 20, 5, 5, 2, "Warrior", name, "a warrior who loves slaying monsters");
            _newWarrior.AddAbility(new Swing(_newWarrior));
            _newWarrior.AddAbility(new Whirlwind(_newWarrior));
            return _newWarrior;
        }

        /// <summary>
        /// Return a previously created Warrior Hero
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="mana"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        public Hero LoadWarrior(string name, int health, int mana, int power)
        {
            Hero _loadWarrior = new Hero(health, 20, mana, 5, power, "Warrior", name, "a warrior who loves slaying monsters");
            _loadWarrior.AddAbility(new Swing(_loadWarrior));
            _loadWarrior.AddAbility(new Whirlwind(_loadWarrior));
            return _loadWarrior;
        }

        /// <summary>
        /// Return a new Sorcerer Hero
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Hero NewSorcerer(string name)
        {
            Hero _newSorcerer = new Hero(10, 10, 15, 15, 3, "Sorcerer", name, "a wise wizard");
            _newSorcerer.AddAbility(new Drain(_newSorcerer));
            _newSorcerer.AddAbility(new ShockWave(_newSorcerer));
            return _newSorcerer;
        }

        /// <summary>
        /// Return a previously created Sorcerer Hero
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="mana"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        public Hero LoadSorcerer(string name, int health, int mana, int power)
        {
            Hero _loadSorcerer = new Hero(health, 10, mana, 15, power, "Sorcerer", name, "a wise wizard");
            _loadSorcerer.AddAbility(new Drain(_loadSorcerer));
            _loadSorcerer.AddAbility(new ShockWave(_loadSorcerer));
            return _loadSorcerer;
        }

        /// <summary>
        /// Return a new Bard Hero
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Hero NewBard(string name)
        {
            Hero _newBard = new Hero(10, 10, 10, 10, 1, "Bard", name, "a charasmatic bard");
            _newBard.AddAbility(new Punch(_newBard));
            _newBard.AddAbility(new Sing(_newBard));
            return _newBard;
        }

        /// <summary>
        /// Return a previously created Bard Hero
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="mana"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        public Hero LoadBard(string name, int health, int mana, int power)
        {
            Hero _loadBard = new Hero(health, 10, mana, 10, power, "Bard", name, "a charasmatic bard");
            _loadBard.AddAbility(new Punch(_loadBard));
            _loadBard.AddAbility(new Sing(_loadBard));
            return _loadBard;
        }
    }
}
