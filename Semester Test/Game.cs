using System;
using System.Collections.Generic;
using System.Text;

namespace Semester_Test
{
    public class Game : LibraryResource
    {
        private string _contentRating;

        public string ContentRating
        {
            get
            {
                return _contentRating;
            }
        }

        public Game(string name, string creator, string contentRating) : base(name, creator)
        {
            _contentRating = contentRating;
        }
    }
}
