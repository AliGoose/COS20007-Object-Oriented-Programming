using NUnit.Framework;
using System;
using DungeonCrawler;
using System.Collections.Generic;
using System.Text;

namespace DungeonCrawlerTests
{
    public class InventoryTests
    {
        private Inventory _inventory;

        [SetUp]
        public void Setup()
        {
            _inventory = new Inventory();
            _inventory.AddItem(new HealthPotion(3));
            _inventory.AddItem(new ManaPotion(2));
            _inventory.AddItem(new PowerStone(1));
        }

        [Test]
        public void TestItemCount()
        {
            Assert.AreEqual(_inventory.GetItem("Health Potion").Quantity, 3);
            Assert.AreEqual(_inventory.GetItem("Mana Potion").Quantity, 2);
            Assert.AreEqual(_inventory.GetItem("Power Stone").Quantity, 1);
            _inventory.GetItem("Health Potion").ChangeQuantity(-1);
            Assert.AreEqual(_inventory.GetItem("Health Potion").Quantity, 2);
            _inventory.GetItem("Health Potion").ChangeQuantity(-2);
            Assert.AreEqual(_inventory.GetItem("Health Potion").Quantity, 0);
        }

        [Test]
        public void TestInventoryList()
        {
            Assert.AreEqual(_inventory.List, "1. [3/5]\tHealth Potion, a potion that restores 5 health\r\n2. [2/5]\tMana Potion, a potion that restores 5 mana\r\n3. [1/3]\tPower Stone, a stone when rubbed will permamently increase the heroes power by 1\r\n");
            _inventory.GetItem("Health Potion").ChangeQuantity(-1);
            Assert.AreEqual(_inventory.List, "1. [2/5]\tHealth Potion, a potion that restores 5 health\r\n2. [2/5]\tMana Potion, a potion that restores 5 mana\r\n3. [1/3]\tPower Stone, a stone when rubbed will permamently increase the heroes power by 1\r\n");
            _inventory.GetItem("Health Potion").ChangeQuantity(-2);
            Assert.AreEqual(_inventory.List, "1. [0/5]\tHealth Potion, a potion that restores 5 health\r\n2. [2/5]\tMana Potion, a potion that restores 5 mana\r\n3. [1/3]\tPower Stone, a stone when rubbed will permamently increase the heroes power by 1\r\n");
        }
    }
}
