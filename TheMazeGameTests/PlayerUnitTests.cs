using NUnit.Framework;
using System;
using TheMazeGameDLL;

namespace TheMazeGameTests
{
    public class PlayerTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestPlayerIsIdentifiable()
        {
            Player steve = new Player("Steve", "The dude from minecraft!");
            Assert.AreEqual(steve.AreYou("me"), true);
            Assert.AreEqual(steve.AreYou("inventory"), true);
        }

        [Test]
        public void TestPlayerLocatesItems()
        {
            Player steve = new Player("Steve", "The dude from minecraft!");
            Item sword = new Item(new string[] { "sword", "blade" }, "sword", "This is a sharp blade than can cut through most materials.");
            steve.Inventory.Put(sword);
            Assert.AreEqual(steve.Locate("sword"), sword);
            Assert.AreEqual(steve.Locate("blade"), sword);
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            Player steve = new Player("Steve", "The dude from minecraft!");
            Assert.AreEqual(steve.Locate("me"), steve);
            Assert.AreEqual(steve.Locate("inventory"), steve);
        }

        [Test]
        public void TestPlayerLocatesNothing()
        {
            Player steve = new Player("Steve", "The dude from minecraft!");
            Location cave = new Location(new string[] { "cave", "hole" }, "cave", "A dark gloomy cave that is bound to be dangerous");
            steve.Location = cave;
            Assert.AreEqual(steve.Locate("shield"), null);
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            Player steve = new Player("Steve", "The dude from minecraft!");
            Item sword = new Item(new string[] { "sword", "blade" }, "sword", "This is a sharp blade than can cut through most materials.");
            steve.Inventory.Put(sword);
            string a = "You are Steve, The dude from minecraft! \r\nYou are carrying:\r\n   a sword (sword)\r\n";
            Assert.AreEqual(steve.FullDescription, a);
        }
    }
}