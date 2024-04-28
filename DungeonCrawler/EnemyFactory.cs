using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawler
{
    public class EnemyFactory
    {
        public EnemyFactory()
        {

        }

        /// <summary>
        /// Return a new Spider Enemy
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Enemy NewSpider()
        {
            Enemy _newSpider = new Enemy(5, 5, 0, 0, 1, 2, "Arachnids", "Spider", "a dark hairy spider as big as a dog");
            _newSpider.AddAbility(new VenomSpit(_newSpider));
            return _newSpider;
        }

        /// <summary>
        /// Return a new Vampire Enemy
        /// </summary>
        /// <returns></returns>
        public Enemy newVampire()
        {
            Enemy _newVampire = new Enemy(8, 8, 0, 0, 2, 3, "Monster", "Vampire", "A slender pale figure wearing a dark robe.");
            _newVampire.AddAbility(new Bite(_newVampire));
            return _newVampire;
        }
    }
}
