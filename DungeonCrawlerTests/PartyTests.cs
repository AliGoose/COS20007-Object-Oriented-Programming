using NUnit.Framework;
using DungeonCrawler;
using System;

namespace DungeonCrawlerTests
{
    public class PartyTests
    {
        private FriendlyParty _friendlyParty;
        private HeroesFactory _heroesFactory;
        private EnemyParty _enemyParty;
        private EnemyFactory _enemyFactory;

        [SetUp]
        public void Setup()
        {
            _friendlyParty = new FriendlyParty();
            _heroesFactory = new HeroesFactory();
            _enemyParty = new EnemyParty();
            _enemyFactory = new EnemyFactory();
        }

        [Test]
        public void EmptyParty() //Check party list when party is empty
        {
            Assert.AreEqual(_friendlyParty.FullDescription, "");
            Assert.AreEqual(_enemyParty.FullDescription, "");
        }

        [Test]
        public void Party1Character() //Check party list with 1 character
        {
            _friendlyParty.AddCharacter(_heroesFactory.NewWarrior("Trevor"));
            _enemyParty.AddCharacter(_enemyFactory.NewSpider());
            Assert.AreEqual(_friendlyParty.FullDescription, "(HP 20/20)\t(MANA 5/5)\tTrevor, a warrior who loves slaying monsters\r\n");
            Assert.AreEqual(_enemyParty.FullDescription, "(HP 5/5)\t\t\t[#1] Spider, a dark hairy spider as big as a dog\r\n");
        }

        [Test]
        public void Party2Character() //Check party list with 2 characters
        {
            _friendlyParty.AddCharacter(_heroesFactory.NewWarrior("Trevor"));
            _friendlyParty.AddCharacter(_heroesFactory.NewSorcerer("Dumble"));
            _enemyParty.AddCharacter(_enemyFactory.NewSpider());
            _enemyParty.AddCharacter(_enemyFactory.NewSpider());
            Assert.AreEqual(_friendlyParty.FullDescription, "(HP 20/20)\t(MANA 5/5)\tTrevor, a warrior who loves slaying monsters\r\n(HP 10/10)\t(MANA 15/15)\tDumble, a wise wizard\r\n");
            Assert.AreEqual(_enemyParty.FullDescription, "(HP 5/5)\t\t\t[#1] Spider, a dark hairy spider as big as a dog\r\n(HP 5/5)\t\t\t[#2] Spider, a dark hairy spider as big as a dog\r\n");
        }

        [Test]
        public void Party3Character() //Check party list with 3 characters
        {
            _friendlyParty.AddCharacter(_heroesFactory.NewWarrior("Trevor"));
            _friendlyParty.AddCharacter(_heroesFactory.NewSorcerer("Dumble"));
            _friendlyParty.AddCharacter(_heroesFactory.NewBard("Stuart"));
            _enemyParty.AddCharacter(_enemyFactory.NewSpider());
            _enemyParty.AddCharacter(_enemyFactory.NewSpider());
            _enemyParty.AddCharacter(_enemyFactory.NewSpider());
            Assert.AreEqual(_friendlyParty.FullDescription, "(HP 20/20)\t(MANA 5/5)\tTrevor, a warrior who loves slaying monsters\r\n(HP 10/10)\t(MANA 15/15)\tDumble, a wise wizard\r\n(HP 10/10)\t(MANA 10/10)\tStuart, a charasmatic bard\r\n");
            Assert.AreEqual(_enemyParty.FullDescription, "(HP 5/5)\t\t\t[#1] Spider, a dark hairy spider as big as a dog\r\n(HP 5/5)\t\t\t[#2] Spider, a dark hairy spider as big as a dog\r\n(HP 5/5)\t\t\t[#3] Spider, a dark hairy spider as big as a dog\r\n");
        }

        [Test]
        public void CheckPartyNameList() //Check party name list
        {
            _friendlyParty.AddCharacter(_heroesFactory.NewWarrior("Trevor"));
            _friendlyParty.AddCharacter(_heroesFactory.NewSorcerer("Dumble"));
            _friendlyParty.AddCharacter(_heroesFactory.NewBard("Stuart"));
            _enemyParty.AddCharacter(_enemyFactory.NewSpider());
            _enemyParty.AddCharacter(_enemyFactory.NewSpider());
            _enemyParty.AddCharacter(_enemyFactory.NewSpider());
            Assert.AreEqual(_friendlyParty.NameList, "1. [X]\tTrevor\r\n2. [X]\tDumble\r\n3. [X]\tStuart\r\n");
            Assert.AreEqual(_enemyParty.NameList, "1. [#1] Spider\r\n2. [#2] Spider\r\n3. [#3] Spider\r\n");
        }

    }
}