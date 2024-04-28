using NUnit.Framework;
using CounterGame;

namespace CounterTest
{
    public class ClockTests
    {
        private Clock myClock;

        [SetUp]
        public void Setup()
        {
            myClock = new Clock();
        }

        [Test]
        public void ClockObjectTest()
        {
            Assert.AreEqual("00:00:00", myClock.Print());
        }

        [Test]
        public void SecondsTest()
        {
            for (int i = 1; i <= 59; i++)
            {
                myClock.Tick();
            }
            Assert.AreEqual("00:00:59", myClock.Print());
        }

        [Test]
        public void MinutesTest()
        {
            for (int i = 1; i <= 60; i++)
            {
                myClock.Tick();
            }
            Assert.AreEqual("00:01:00", myClock.Print());
        }

        [Test]
        public void HoursTest()
        {
            for (int i = 1; i <= 3600; i++)
            {
                myClock.Tick();
            }
            Assert.AreEqual("01:00:00", myClock.Print());
        }

        [Test]
        public void PMTest()
        {
            for (int i = 1; i <= 50061; i++)
            {
                myClock.Tick();
            }
            Assert.AreEqual("13:54:21", myClock.Print());
        }

        [Test]
        public void ResetTest()
        {
            for (int i = 1; i <= 50061; i++)
            {
                myClock.Tick();
            }
            myClock.Reset();
            Assert.AreEqual("00:00:00", myClock.Print());
        }

        [Test]
        public void Over24HoursTest()
        {
            for (int i = 1; i <= 136465; i++)
            {
                myClock.Tick();
            }
            Assert.AreEqual("13:54:25", myClock.Print());
        }
    }
}