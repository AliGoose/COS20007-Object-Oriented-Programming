using System;
using System.Collections.Generic;
using System.Text;

namespace TheMazeGameDLL
{
    public abstract class IdentifiableObject
    {
        private List<string> _identifiers;

        public string FirstId
        {
            get
            {
                if (_identifiers.Count == 0)
                {
                    return "";
                }
                else
                {
                    return _identifiers[0];
                }
                
            }
        }

        public IdentifiableObject(string[] idents) 
        {
            for (int i = 0; i <= idents.Length - 1; i++)
            {
                idents[i] = idents[i].ToLower();
            }
            _identifiers = new List<string>(idents);
        }

        public bool AreYou(string id)
        {
            bool i = false;
            foreach (string s in _identifiers)
            {
                if (id.ToLower() == s)
                {
                    i = true;
                    break;
                }
            }

            return i;
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }
    }
}
