using System;
using System.Collections.Generic;
using System.Text;

namespace Semester_Test
{
    public class Book : LibraryResource
    {
        private string _isbn;

        public string ISBN
        {
            get
            {
                return _isbn;
            }
        }

        public Book(string name, string creator, string isbn) : base(name, creator)
        {
            _isbn = isbn;
        }
    }
}
