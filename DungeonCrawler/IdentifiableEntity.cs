using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DungeonCrawler
{
    public class IdentifiableEntity
    {
        private string _name;
        private string _description;

        public string Name
        {
            get
            {
                return _name;
            }
        }
        public virtual string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        /// <summary>
        /// This class will be inherited whenever a class representing an entity is created
        /// </summary>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        public IdentifiableEntity(string name, string desc)
        {
            _name = name;
            _description = desc;
        }
    }
}
