using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;

namespace DungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Game _game = new Game();
            Command _command = new Command(_game);
            HeroesFactory _heroesFactory = new HeroesFactory();
            bool _exit;
            do
            {
                _exit = true;
                Console.Clear();
                Console.WriteLine("Welcome to Dungeon Crawler\r\nWould you like to setup a new party ('new') or load an existing one ('load')?\r\n(NOTE: loading a new party will overwrite the existing one!)");
                StreamReader reader = new StreamReader("C:/Users/aligo/source/repos/COS20007/DungeonCrawler/Resources/SaveFile.txt");
                int partyCount = Convert.ToInt32(reader.ReadLine());
                string mode = Console.ReadLine().ToLower();
                if (mode.ToLower() == "load" && partyCount > 0) // load previous save
                {

                    for (int i = 0; i < partyCount; i++)
                    {
                        switch (reader.ReadLine())
                        {
                            case "Warrior":
                                {
                                    _game.FriendlyParty.AddCharacter(_heroesFactory.LoadWarrior(reader.ReadLine(), Convert.ToInt32(reader.ReadLine()), Convert.ToInt32(reader.ReadLine()), Convert.ToInt32(reader.ReadLine())));
                                    break;
                                }
                            case "Sorcerer":
                                {
                                    _game.FriendlyParty.AddCharacter(_heroesFactory.LoadSorcerer(reader.ReadLine(), Convert.ToInt32(reader.ReadLine()), Convert.ToInt32(reader.ReadLine()), Convert.ToInt32(reader.ReadLine())));
                                    break;
                                }
                            case "Bard":
                                {
                                    _game.FriendlyParty.AddCharacter(_heroesFactory.LoadBard(reader.ReadLine(), Convert.ToInt32(reader.ReadLine()), Convert.ToInt32(reader.ReadLine()), Convert.ToInt32(reader.ReadLine())));
                                    break;
                                }
                        }
                    }
                    int itemCount = Convert.ToInt32(reader.ReadLine());
                    for (int i = 0; i < itemCount; i++)
                    {
                        switch (reader.ReadLine())
                        {
                            case "Health Potion":
                                {
                                    _game.FriendlyParty.Inventory.AddItem(new HealthPotion(Convert.ToInt32(reader.ReadLine())));
                                    break;
                                }
                            case "Mana Potion":
                                {
                                    _game.FriendlyParty.Inventory.AddItem(new ManaPotion(Convert.ToInt32(reader.ReadLine())));
                                    break;
                                }
                            case "Power Stone":
                                {
                                    _game.FriendlyParty.Inventory.AddItem(new PowerStone(Convert.ToInt32(reader.ReadLine())));
                                    break;
                                }
                        }
                    }
                    _game.FriendlyParty.AddGold(Convert.ToInt32(reader.ReadLine()));
                    reader.Close();
                }
                else if (mode.ToLower() == "new") // Create a new save file
                {
                    reader.Close();
                    if (mode == "load" && partyCount == 0)
                    {
                        Console.WriteLine("Oh no, it appears your last party died. You will now have to setup a new one\r\n");
                    }
                    else
                    {
                        Console.WriteLine("Lets setup your party!\r\n");
                    }
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(false);
                    }
                    Console.WriteLine("Enter the name of your (male) warrior:");
                    string warriorName = Console.ReadLine();
                    Console.WriteLine("\r\nNow enter the name of your (male) sorcerer:");
                    string sorcererName = Console.ReadLine();
                    Console.WriteLine("\r\nAnd enter the name of your (male) bard:");
                    string bardName = Console.ReadLine();
                    _game.FriendlyParty.AddCharacter(_heroesFactory.NewWarrior(warriorName));
                    _game.FriendlyParty.AddCharacter(_heroesFactory.NewSorcerer(sorcererName));
                    _game.FriendlyParty.AddCharacter(_heroesFactory.NewBard(bardName));
                    _game.FriendlyParty.Inventory.AddItem(new HealthPotion(3));
                    _game.FriendlyParty.Inventory.AddItem(new ManaPotion(2));
                    _game.FriendlyParty.Inventory.AddItem(new PowerStone(1));
                    _game.FriendlyParty.AddGold(5);
                }
                else
                {
                    Console.WriteLine("Please enter either 'load' or 'new'!\r\n...");
                    Console.ReadLine();
                    _exit = false;
                }
            } while (_exit == false);
            
            Console.WriteLine("...");
            while (true)
            {
                Console.ReadLine();
                Console.WriteLine(_command.CurrentDisplay());
                try
                {
                    string input = Console.ReadLine();
                    if (input == "")
                    {
                        input = "0";
                    }
                    Console.WriteLine(_command.Execute(Convert.ToInt32(input)));
                }
                catch
                {
                    Console.WriteLine("Please enter an integer corresponding to the available options");
                }
                if (_command.Exit == true)
                {
                    _game.FriendlyParty.Save();
                    Environment.Exit(0);
                }
            }
        }
    }
}
