using NUnit.Framework;
using System;
using TheMazeGameDLL;

namespace TheMazeGameTests
{
    public class LookCommandTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestLookAtMe()
        {
            Player steve = new Player("Steve", "The dude from minecraft!");
            Item potion = new Item(new string[] { "potion", "elixer" }, "potion", "A small glass flask containg a purple liquid... who knows what it does?!?");
            steve.Inventory.Put(potion);
            LookCommand look = new LookCommand();
            Assert.AreEqual(look.Execute(steve, new string[] { "look", "at", "me" }), "You are Steve, The dude from minecraft! \r\nYou are carrying:\r\n   a potion (potion)\r\n");
        }

        [Test]
        public void TestLookAtGem()
        {
            Player steve = new Player("Steve", "The dude from minecraft!");
            Item gem = new Item(new string[] { "gem", "jewel" }, "gem", "A small gem shining in a brigh red colour");
            steve.Inventory.Put(gem);
            LookCommand look = new LookCommand();
            Assert.AreEqual(look.Execute(steve, new string[] { "look", "at", "gem" }), "A small gem shining in a brigh red colour");
        }

        [Test]
        public void TestLookAtUnk()
        {
            Player steve = new Player("Steve", "The dude from minecraft!");
            Location cave = new Location(new string[] { "cave", "hole" }, "cave", "A dark gloomy cave that is bound to be dangerous");
            steve.Location = cave;
            LookCommand look = new LookCommand();
            Assert.AreEqual(look.Execute(steve, new string[] { "look", "at", "gem" }), "I can't find the gem");
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            Player steve = new Player("Steve", "The dude from minecraft!");
            LookCommand look = new LookCommand();
            Item gem = new Item(new string[] { "gem", "jewel" }, "gem", "A small gem shining in a bright red colour");
            steve.Inventory.Put(gem);
            Assert.AreEqual(look.Execute(steve, new string[] { "look", "at", "gem" }), "A small gem shining in a bright red colour");
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            Player steve = new Player("Steve", "The dude from minecraft!");
            LookCommand look = new LookCommand();
            Bag bag = new Bag(new string[] { "bag", "sack" }, "bag", "A medium sized bag used for carrying everyday items");
            Item gem = new Item(new string[] { "gem", "jewel" }, "gem", "A small gem shining in a bright red colour");
            steve.Inventory.Put(bag);
            bag.Inventory.Put(gem);
            Assert.AreEqual(look.Execute(steve, new string[] { "look", "at", "gem", "in", "bag" }), "A small gem shining in a bright red colour");
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            Player steve = new Player("Steve", "The dude from minecraft!");
            Location cave = new Location(new string[] { "cave", "hole" }, "cave", "A dark gloomy cave that is bound to be dangerous");
            steve.Location = cave;
            LookCommand look = new LookCommand();
            Item gem = new Item(new string[] { "gem", "jewel" }, "gem", "A small gem shining in a bright red colour");
            steve.Inventory.Put(gem);
            Assert.AreEqual(look.Execute(steve, new string[] { "look", "at", "gem", "in", "bag" }), "I can't find the bag");
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            Player steve = new Player("Steve", "The dude from minecraft!");
            LookCommand look = new LookCommand();
            Bag bag = new Bag(new string[] { "bag", "sack" }, "bag", "A medium sized bag used for carrying everyday items");
            steve.Inventory.Put(bag);
            Assert.AreEqual(look.Execute(steve, new string[] { "look", "at", "gem", "in", "bag" }), "I can't find the gem");
        }

        [Test]
        public void TestInvalidLook()
        {
            Player steve = new Player("Steve", "The dude from minecraft!");
            CommandProcessor command = new CommandProcessor();
            Assert.AreEqual(command.Execute(steve, new string[] { "look", "at", "gem", "in", "the", "bag" }), "I don't know how to look like that");
            Assert.AreEqual(command.Execute(steve, new string[] { "find", "a", "gem", "in", "bag" }), "Invalid Command Input");
            Assert.AreEqual(command.Execute(steve, new string[] { "look", "for", "gem", "in", "bag" }), "What do you want to look at?");
            Assert.AreEqual(command.Execute(steve, new string[] { "look", "at", "gem", "from", "bag" }), "What do you want to look in?");
        }
    }
}