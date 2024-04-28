using NUnit.Framework;
using CounterGame;

namespace CounterTest
{
    public class Tests1
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Counter myCounter = new Counter("Seconds");
            Assert.AreEqual(myCounter.Ticks, 0);
        }
        [Test]
        public void Test2()
        {
            Counter myCounter = new Counter("Seconds");
            myCounter.Increment();
            Assert.AreEqual(myCounter.Ticks, 1);
        }
        [Test]
        public void Test3()
        {
            Counter myCounter = new Counter("Seconds");
            myCounter.Increment();
            myCounter.Increment();
            myCounter.Increment();
            myCounter.Increment();
            Assert.AreEqual(myCounter.Ticks, 4);
        }
        [Test]
        public void Test4()
        {
            Counter myCounter = new Counter("Seconds");
            myCounter.Increment();
            myCounter.Increment();
            myCounter.Increment();
            myCounter.Increment();
            myCounter.Reset();
            Assert.AreEqual(myCounter.Ticks, 0);
        }

    }
}