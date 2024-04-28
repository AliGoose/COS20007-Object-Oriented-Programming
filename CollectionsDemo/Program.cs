using System;
using System.Collections.Generic;

namespace CollectionsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> myList = new List<string>();

            //myList.Add("Lachlan");
            //myList.Add("John");
            //myList.Add("Ned");
            //myList.Add("Gertrude");

            //for (int i = 0; i < myList.Count; i++)
            //{
            //    Console.WriteLine("List at {0} = {1}", i, myList[i]);
            //}

            //myList.RemoveAt(0);
            //myList.Remove("Lachlan");

            //foreach (string s in myList)
            //{
            //    Console.WriteLine("List has data {0}", s);
            //}

            Dictionary<string, int> myDictionary = new Dictionary<string, int>();
            myDictionary.Add("one", 1);
            myDictionary.Add("two", 2);
            myDictionary.Add("three", 3);
            myDictionary.Add("fourteen", 98765);
            //myDictionary.Add("fourteen", 4);

            myDictionary["Potato"] = 44;
            myDictionary["Potato"] = 56;

            foreach (string aKey in myDictionary.Keys)
            {
                Console.WriteLine("Dictionary contains key: {0}; value: {1}", aKey, myDictionary[aKey]);
            }
        }
    }
}
