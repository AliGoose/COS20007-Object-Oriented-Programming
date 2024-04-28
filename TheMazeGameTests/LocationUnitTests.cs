using NUnit.Framework;
using System;
using TheMazeGameDLL;

namespace TheMazeGameTests
{
    public class LocationTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestLook() // be able to find players location with "look"
        {
            Player steve = new Player("Steve", "The dude from minecraft!");
            Location cave = new Location(new string[] { "cave", "hole" }, "cave", "A dark gloomy cave that is bound to be dangerous");
            LookCommand look = new LookCommand();
            steve.Location = cave;
            Assert.AreEqual(look.Execute(steve, new string[] {"look"}), "A dark gloomy cave that is bound to be dangerous");
        }

        [Test]
        public void TestLocationLocateItem() //location be able to look at an item that is within its inventory
        {
            Location cave = new Location(new string[] { "cave", "hole" }, "cave", "A dark gloomy cave that is bound to be dangerous");
            Item potion = new Item(new string[] { "potion", "elixer" }, "potion", "A small glass flask containg a purple liquid... who knows what it does?!?");
            cave.Inventory.Put(potion);
            Assert.AreEqual(cave.Locate("potion"), potion);
        }

        [Test]
        public void TestLocationCantLocateItem() //location be able to not find a non-existent item within its inventory
        {
            Location cave = new Location(new string[] { "cave", "hole" }, "cave", "A dark gloomy cave that is bound to be dangerous");
            Assert.AreEqual(cave.Locate("potion"), null);
        }

        [Test]
        public void TestPlayerLocateItemAtLocation() //player be able to look at an item that is within a locations inventory
        {
            Player steve = new Player("Steve", "The dude from minecraft!");
            Location cave = new Location(new string[] { "cave", "hole" }, "cave", "A dark gloomy cave that is bound to be dangerous");
            Item potion = new Item(new string[] { "potion", "elixer" }, "potion", "A small glass flask containg a purple liquid... who knows what it does?!?");
            LookCommand look = new LookCommand();
            cave.Inventory.Put(potion);
            steve.Location = cave;
            Assert.AreEqual(look.Execute(steve, new string[] { "look", "at", "potion" }), "A small glass flask containg a purple liquid... who knows what it does?!?");
        }

        [Test]
        public void TestPlayerCantLocateItemAtLocation() //player be able to not find an item that doesn't exist within the locations inventory
        {
            Player steve = new Player("Steve", "The dude from minecraft!");
            Location cave = new Location(new string[] { "cave", "hole" }, "cave", "A dark gloomy cave that is bound to be dangerous");
            LookCommand look = new LookCommand();
            steve.Location = cave;
            Assert.AreEqual(look.Execute(steve, new string[] { "look", "at", "potion" }), "I can't find the potion");
        }

    }
}