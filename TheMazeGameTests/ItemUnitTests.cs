using NUnit.Framework;
using System;
using TheMazeGameDLL;

namespace TheMazeGameTests
{
    public class ItemTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestItemIsIdentifiable()
        {
            Player steve = new Player("Steve", "The dude from minecraft!");
            Item sword = new Item(new string[] { "sword", "blade" }, "sword", "This is a sharp blade than can cut through most materials.");
            steve.Inventory.Put(sword);
            Assert.AreEqual(steve.Locate("sword"), sword);
            Assert.AreEqual(steve.Locate("blade"), sword);
        }

        [Test]
        public void TestShortDescription()
        {
            Item sword = new Item(new string[] { "sword", "blade" }, "sword", "This is a sharp blade than can cut through most materials.");
            Assert.AreEqual(sword.ShortDescription, "a sword (sword)");
        }

        [Test]
        public void TestFullDescription()
        {
            Item sword = new Item(new string[] { "sword", "blade" }, "sword", "This is a sharp blade than can cut through most materials.");
            Assert.AreEqual(sword.FullDescription, "This is a sharp blade than can cut through most materials.");
        }
    }
}