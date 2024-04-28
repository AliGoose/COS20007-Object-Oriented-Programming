using NUnit.Framework;
using System;
using TheMazeGameDLL;

namespace TheMazeGameTests
{
    public class InventoryTests
    {
        private Player steve;

        [SetUp]
        public void Setup()
        {
            steve = new Player("Steve", "The dude from minecraft!");
        }

        [Test]
        public void TestFindItem()
        {
            Item sword = new Item(new string[] { "sword", "blade" }, "sword", "This is a sharp blade than can cut through most materials.");
            steve.Inventory.Put(sword);
            Assert.AreEqual(steve.Inventory.HasItem("sword"), true);
            Assert.AreEqual(steve.Inventory.HasItem("blade"), true);
        }

        [Test]
        public void TestNoItemFind()
        {
            Assert.AreEqual(steve.Inventory.HasItem("sword"), false);
            Assert.AreEqual(steve.Inventory.HasItem("blade"), false);
        }

        [Test]
        public void TestFetchItem()
        {
            Item sword = new Item(new string[] { "sword", "blade" }, "sword", "This is a sharp blade than can cut through most materials.");
            steve.Inventory.Put(sword);
            Assert.AreEqual(steve.Inventory.Fetch("sword"), sword);
            Assert.AreEqual(steve.Inventory.HasItem("sword"), true);
            Assert.AreEqual(steve.Inventory.Fetch("blade"), sword);
            Assert.AreEqual(steve.Inventory.HasItem("blade"), true);
        }

        [Test]
        public void TestTakeItem()
        {
            Item sword = new Item(new string[] { "sword", "blade" }, "sword", "This is a sharp blade than can cut through most materials.");
            steve.Inventory.Put(sword);
            Assert.AreEqual(steve.Inventory.Take("sword"), sword);
            Assert.AreEqual(steve.Inventory.HasItem("sword"), false);
            Assert.AreEqual(steve.Inventory.HasItem("blade"), false);
        }

        [Test]
        public void TestItemList()
        {
            Item sword = new Item(new string[] { "sword", "blade" }, "sword", "This is a sharp blade than can cut through most materials.");
            steve.Inventory.Put(sword);
            string a = "   a sword (sword)\r\n";
            Assert.AreEqual(steve.Inventory.ItemList, a);
        }
    }
}