using NUnit.Framework;
using System;
using TheMazeGameDLL;

namespace TheMazeGameTests
{
    public class TakeCommandTests
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
        public void PickupTorch()
        {
            Assert.AreEqual(cave.Locate("torch"), torch);
            Assert.AreEqual(command.Execute(steve, new string[] { "pickup", "torch" }), "You have picked up the torch");
            Assert.AreEqual(cave.Locate("torch"), null);
        }

        [Test]
        public void TakePotionFromBackpack()
        {
            Assert.AreEqual(backpack.Locate("potion"), potion);
            Assert.AreEqual(steve.Locate("potion"), null);
            Assert.AreEqual(command.Execute(steve, new string[] { "take", "potion", "from", "backpack" }), "You have taken the potion out of your backpack");
            Assert.AreEqual(backpack.Locate("potion"), null);
            Assert.AreEqual(steve.Locate("potion"), potion);
        }

        [Test]
        public void InvalidPickupCommands()
        {
            Assert.AreEqual(command.Execute(steve, new string[] { "pickup", "potion", "thanks" }), "I don't know how to pickup/take like that");
            Assert.AreEqual(command.Execute(steve, new string[] { "pick", "potion" }), "Invalid Command Input");
            Assert.AreEqual(command.Execute(steve, new string[] { "pickup", "potion", "out", "backpack" }), "Invalid 'from' input");
        }

        [Test]
        public void TestCantFindItemForTakeCommand()
        {
            Assert.AreEqual(command.Execute(steve, new string[] { "pickup", "gun" }), "Can't find that item in the cave");
            Assert.AreEqual(command.Execute(steve, new string[] { "pickup", "potion", "from", "pouch" }), "I could not find that bag in the players inventory");
        }
    }
}