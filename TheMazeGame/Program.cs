using System;
using TheMazeGameDLL;

namespace TheMazeGame
{
    public class Program
    {
        static void Main()
        {
            Player steve = new Player("Steve", "The dude from minecraft!");
            Item sword = new Item(new string[] { "sword", "blade" }, "sword", "This is a sharp blade than can cut through most materials.");
            Item bread = new Item(new string[] { "bread" }, "bread", "A yummy warm bread made from 3 wheat");
            Item potion = new Item(new string[] { "potion", "elixer" }, "potion", "A small glass flask containg a purple liquid... who knows what it does?!?");
            Item torch = new Item(new string[] { "torch", "light" }, "torch", "A small handheld torch that can emit light if lit on fire");
            Bag backpack = new Bag(new string[] { "backpack", "bag" }, "backpack", "A useful bag that can be worn on your back");
            Location cave = new Location(new string[] { "cave", "hole" }, "cave", "A dark gloomy cave that is bound to be dangerous, there appears to be an exit to the north.");
            Location dungeon = new Location(new string[] { "dungeon", "arena" }, "dungeon", "A dark room, it has loot but also dangerous enemies. There appears to be no more advancing paths");
            Path caveNorth = new Path(new string[] { "north" }, "north", "You move through a tiny crack in the wall", dungeon);
            Path dungeonSouth = new Path(new string[] { "south" }, "south", "You move through a tiny crack in the wall", cave);
            CommandProcessor command = new CommandProcessor();
            steve.Location = cave;
            cave.AddPath(caveNorth);
            dungeon.AddPath(dungeonSouth);
            steve.Inventory.Put(sword);
            steve.Inventory.Put(bread);
            steve.Inventory.Put(backpack);
            backpack.Inventory.Put(potion);
            cave.Inventory.Put(torch);
            while (true)
            {
                string input;
                input = Console.ReadLine();
                if (input.ToLower() == "quit")
                {
                    break;
                }
                Console.WriteLine(command.Execute(steve, input.Split(" ")));
                Console.WriteLine("");
            }
        }
    }
}
