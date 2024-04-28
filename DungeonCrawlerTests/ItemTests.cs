using NUnit.Framework;
using DungeonCrawler;
using System;

namespace DungeonCrawlerTests
{
    public class ItemTests
    {
        private HealthPotion _healthPotion;
        private ManaPotion _manaPotion;
        private PowerStone _powerStone;
        private FriendlyParty _friendlyParty;
        private HeroesFactory _heroesFactory;

        [SetUp]
        public void Setup()
        {
            _healthPotion = new HealthPotion(3);
            _manaPotion = new ManaPotion(2);
            _powerStone = new PowerStone(1);
            _friendlyParty = new FriendlyParty();
            _heroesFactory = new HeroesFactory();
            _friendlyParty.AddCharacter(_heroesFactory.NewWarrior("Trevor"));
            _friendlyParty.AddCharacter(_heroesFactory.NewSorcerer("Dumble"));
            _friendlyParty.AddCharacter(_heroesFactory.NewBard("Stuart"));
        }

        [Test]
        public void TestHealthPotion()
        {
            _friendlyParty.GetCharacter(1).Health = 1;
            _healthPotion.Use(_friendlyParty.GetCharacter(1));
            Assert.AreEqual(_friendlyParty.GetCharacter(1).Health == 6, _healthPotion.Quantity == 2);
            _healthPotion.Use(_friendlyParty.GetCharacter(1));
            Assert.AreEqual(_friendlyParty.GetCharacter(1).Health == 11, _healthPotion.Quantity == 1);
            _healthPotion.Use(_friendlyParty.GetCharacter(1));
            Assert.AreEqual(_friendlyParty.GetCharacter(1).Health == 16, _healthPotion.Quantity == 0);
            _healthPotion.Use(_friendlyParty.GetCharacter(1));
            Assert.AreEqual(_friendlyParty.GetCharacter(1).Health == 16, _healthPotion.Quantity == 0);
        }

        [Test]
        public void TestManaPotion()
        {
            _friendlyParty.GetCharacter(2).Mana = 1;
            _manaPotion.Use(_friendlyParty.GetCharacter(2));
            Assert.AreEqual(_friendlyParty.GetCharacter(2).Mana == 6, _manaPotion.Quantity == 1);
            _manaPotion.Use(_friendlyParty.GetCharacter(2));
            Assert.AreEqual(_friendlyParty.GetCharacter(2).Mana == 11, _manaPotion.Quantity == 0);
            _manaPotion.Use(_friendlyParty.GetCharacter(2));
            Assert.AreEqual(_friendlyParty.GetCharacter(2).Mana == 11, _manaPotion.Quantity == 0);
        }

        [Test]
        public void TestPowerStone()
        {
            _friendlyParty.GetCharacter(2).Power = 1;
            _powerStone.Use(_friendlyParty.GetCharacter(2));
            Assert.AreEqual(_friendlyParty.GetCharacter(2).Power == 2, _powerStone.Quantity == 0);
            _powerStone.Use(_friendlyParty.GetCharacter(2));
            Assert.AreEqual(_friendlyParty.GetCharacter(2).Mana == 2, _manaPotion.Quantity == 0);
        }
    }
}