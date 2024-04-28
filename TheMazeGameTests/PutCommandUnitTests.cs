using NUnit.Framework;
using System;
using TheMazeGameDLL;

namespace TheMazeGameTests
{
    public class PutCommandTests
    {
        private Player steve;
        private Location cave;
        private Location dungeon;
        private Path caveNorth;
        private Path dungeonSouth;
        private CommandProcessor command;
        private Item sword;
        private Item bread;
        private Item potion;
        private Item torch;
        private Bag backpack;

        [SetUp]
        public void Setup()
        {
            steve = new Player("Steve", "The dude from minecraft!");
            sword = new Item(new string[] { "sword", "blade" }, "sword", "This is a sharp blade than can cut through most materials.");
            bread = new Item(new string[] { "bread" }, "bread", "A yummy warm bread made from 3 wheat");
            potion = new Item(new string[] { "potion", "elixer" }, "potion", "A small glass flask containg a purple liquid... who knows what it does?!?");
            torch = new Item(new string[] { "torch", "light" }, "torch", "A small handheld torch that can emit light if lit on fire");
            backpack = new Bag(new string[] { "backpack", "pack" }, "backpack", "A useful bag with straps allowing it to be carried on the users back.");
            cave = new Location(new string[] { "cave", "hole" }, "cave", "A dark gloomy cave that is bound to be dangerous, there appears to be an exit to the north.");
            dungeon = new Location(new string[] { "dungeon", "arena" }, "dungeon", "A darm room, it has loot but also dangerous enemies. There appears to be no other paths");
            caveNorth = new Path(new string[] { "north" }, "north", "You have moved north, into the dungeon", dungeon);
            dungeonSouth = new Path(new string[] { "south" }, "south", "You have moved south, into the cave", cave);
            command = new CommandProcessor();
            steve.Location = cave;
            cave.Inventory.Put(torch);
            steve.Inventory.Put(bread);
            steve.Inventory.Put(sword);
            steve.Inventory.Put(backpack);
            backpack.Inventory.Put(potion);
            cave.AddPath(caveNorth);
            dungeon.AddPath(dungeonSouth);
        }

        [Test]
        public void DropBread()
        {
            Assert.AreEqual(cave.Locate("bread"), null);
            Assert.AreEqual(command.Execute(steve, new string[] { "drop", "bread" }), "You have dropped your bread");
            Assert.AreEqual(cave.Locate("bread"), bread);
        }

        [Test]
        public void PutItemsInBackpack()
        {
            Assert.AreEqual(backpack.Locate("bread"), null);
            Assert.AreEqual(steve.Locate("bread"), bread);
            Assert.AreEqual(command.Execute(steve, new string[] { "put", "bread", "in", "backpack" }), "You have put your bread in your backpack");
            Assert.AreEqual(backpack.Locate("bread"), bread);
            Assert.AreEqual(steve.Locate("bread"), null);
            Assert.AreEqual(command.Execute(steve, new string[] { "put", "bread", "in", "backpack" }), "I could not find that item in the players inventory. \r\n>>NOTE: You must take an item out of its bag before you can drop it.<<");
        }

        [Test]
        public void InvalidDropCommands()
        {
            Assert.AreEqual(command.Execute(steve, new string[] { "put", "bread", "away" }), "I don't know how to put/drop like that");
            Assert.AreEqual(command.Execute(steve, new string[] { "throw", "bread" }), "Invalid Command Input");
            Assert.AreEqual(command.Execute(steve, new string[] { "put", "bread", "at", "bag" }), "Invalid 'in' input");
        }

        [Test]
        public void TestCantFindItemForDropCommand()
        {
            Assert.AreEqual(command.Execute(steve, new string[] { "drop", "gun" }), "I could not find that item in the players inventory. \r\n>>NOTE: You must take an item out of its bag before you can drop it.<<");
            Assert.AreEqual(command.Execute(steve, new string[] { "drop", "potion" }), "I could not find that item in the players inventory. \r\n>>NOTE: You must take an item out of its bag before you can drop it.<<");
            Assert.AreEqual(command.Execute(steve, new string[] { "put", "bread", "in", "pouch" }), "I could not find that bag in the players inventory. \r\n>>NOTE: You must take an item out of its bag before you can drop it.<<");
        }
    }
}