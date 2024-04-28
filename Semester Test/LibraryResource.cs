using System;
using System.Collections.Generic;
using System.Text;

namespace Semester_Test
{
    public abstract class LibraryResource
    {
        private string _name;
        private string _creator;
        private bool _onLoan;

        public string Name
        {
            get
            {
                return _name;
            }
        }
        public string Creator
        {
            get
            {
                return _creator;
            }
        }
        public bool OnLoan
        {
            get
            {
                return _onLoan;
            }
            set
            {
                _onLoan = value;
            }
        }

        public LibraryResource(string name, string creator)
        {
            _name = name.ToLower();
            _creator = creator;
            _onLoan = false;
        }
    }
}
