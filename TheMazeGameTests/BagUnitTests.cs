using NUnit.Framework;
using System;
using TheMazeGameDLL;

namespace TheMazeGameTests
{
    public class BagTests
    {
        private Player steve;
        private Bag pouch;

        [SetUp]
        public void Setup()
        {
            steve = new Player("Steve", "The dude from minecraft!");
            pouch = new Bag(new string[] { "pouch", "bag" }, "pouch", "This is a small leather pouch usually used to hold gold coins.");
        }

        [Test]
        public void TestBagLocatesItems()
        {
            Item coin = new Item(new string[] { "coin", "gold coin" }, "coin", "A small gold coin used for trading");
            steve.Inventory.Put(pouch);
            pouch.Inventory.Put(coin);
            Assert.AreEqual(pouch.Locate("coin"), coin);
            Assert.AreEqual(pouch.Locate("gold coin"), coin);
            Assert.AreEqual(pouch.Inventory.HasItem("coin"), true);
        }

        [Test]
        public void TestBagLocatesIteself()
        {
            steve.Inventory.Put(pouch);
            Assert.AreEqual(pouch.Locate("pouch"), pouch);
            Assert.AreEqual(pouch.Locate("bag"), pouch);
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            steve.Inventory.Put(pouch);
            Assert.AreEqual(pouch.Locate("backpack"), null);
        }

        [Test]
        public void TestBagFullDescription()
        {
            Item coin = new Item(new string[] { "coin", "gold coin" }, "coin", "A small gold coin used for trading");
            steve.Inventory.Put(pouch);
            pouch.Inventory.Put(coin);
            Assert.AreEqual(pouch.FullDescription, "In the pouch, you have:\r\n   a coin (coin)\r\n");
        }

        [Test]
        public void TestBagInBag()
        {
            Bag backpack = new Bag(new string[] { "backpack", "pack" }, "backpack", "A useful bag with straps allowing it to be carried on the users back.");
            Item coin = new Item(new string[] { "coin", "gold coin" }, "coin", "A small gold coin used for trading");
            Item potion = new Item(new string[] { "potion", "elixer" }, "potion", "A small glass flask containg a purple liquid... who knows what it does?!?");
            steve.Inventory.Put(backpack);
            backpack.Inventory.Put(pouch);
            pouch.Inventory.Put(coin);
            backpack.Inventory.Put(potion);
            Assert.AreEqual(backpack.Locate("pouch"), pouch);
            Assert.AreEqual(backpack.Locate("bag"), pouch);
            Assert.AreEqual(pouch.Locate("coin"), coin);
            Assert.AreEqual(pouch.Locate("gold coin"), coin);
            Assert.AreEqual(pouch.Locate("potion"), null);
            Assert.AreEqual(pouch.Locate("elixer"), null);
        }
    }
}