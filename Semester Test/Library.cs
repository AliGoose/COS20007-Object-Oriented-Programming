using System;
using System.Collections.Generic;
using System.Text;

namespace Semester_Test
{
    public class Library
    {
        private List<LibraryResource> _resources;
        private string _name;

        public Library(string name)
        {
            _resources = new List<LibraryResource>();
            _name = name;
        }

        public void AddResource(LibraryResource resource)
        {
            _resources.Add(resource);
        }

        public bool HasResource(string name)
        {
            foreach (LibraryResource resource in _resources)
            {
                if (resource.Name == name.ToLower() && resource.OnLoan == false)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
