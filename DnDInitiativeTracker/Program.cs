using System;
using System.IO;
using System.Collections.Generic;

namespace DnDInitiativeTracker
{
    public class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader($"C:/Users/aligo/source/repos/DnDInitiativeTracker/Library/Party.txt");
            List<Creature> party = new List<Creature>();
            int partyQty = Convert.ToInt32(reader.ReadLine());
            List<Creature> NPCs = new List<Creature>();
            List<Creature> collective = new List<Creature>();
            List<Creature> output = new List<Creature>();
            for (int i = 0; i < partyQty; i++)
            {
                party.Add(new Creature(reader.ReadLine()));
            }
            reader.Close();
            Console.WriteLine("Please enter the number of unique NPC:");
            int NPCQty = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            for (int i = 0; i < NPCQty; i++)
            {
                Console.WriteLine("Please enter the name of NPC number " + (i + 1) + ":");
                NPCs.Add(new Creature(Console.ReadLine()));
                Console.Clear();
            }
            for (int i = 0; i < partyQty; i++)
            {
                Console.WriteLine("Please enter the iniative of " + party[i] + ":");
                party[i].Initiative = Convert.ToInt32(Console.ReadLine());
                collective.Add(party[i]);
                Console.Clear();
            }
            for (int i = 0; i < NPCQty; i++)
            {
                Console.WriteLine("Please enter the iniative of " + NPCs[i] + ":");
                NPCs[i].Initiative = Convert.ToInt32(Console.ReadLine());
                collective.Add(NPCs[i]);
                Console.Clear();
            }
            for (int u = 0; i < collective.Count; int++)
            {
                for (int i = 0; i < collective.Count; i++)
                {
                    int a = -100;
                    if (a < collective[i].Initiative)
                    {
                        a = collective[i].Initiative;
                    }
                }

            }
            
            //for (int i = 0; i < 6; i++)
            //{
            //    Console.WriteLine(party[i]);
            //}
        }
    }
}
