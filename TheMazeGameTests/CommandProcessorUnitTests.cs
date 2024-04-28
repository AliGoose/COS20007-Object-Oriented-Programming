using NUnit.Framework;
using System;
using TheMazeGameDLL;

namespace TheMazeGameTests
{
    public class CommandProcessorTests
    {
        private Player steve;
        private Location cave;
        private Location dungeon;
        private Path caveNorth;
        private Path dungeonSouth;
        private CommandProcessor command;

        [SetUp]
        public void Setup()
        {
            steve = new Player("Steve", "The dude from minecraft!");
            cave = new Location(new string[] { "cave", "hole" }, "cave", "A dark gloomy cave that is bound to be dangerous, there appears to be an exit to the north");
            dungeon = new Location(new string[] { "dungeon", "arena" }, "dungeon", "A darm room, it has loot but also dangerous enemies. There appears to be no other paths");
            caveNorth = new Path(new string[] { "north" }, "north", "You move through a tiny crack in the wall", dungeon);
            dungeonSouth = new Path(new string[] { "south" }, "south", "You move through a tiny crack in the wall", cave);
            command = new CommandProcessor();
            steve.Location = cave;
            cave.AddPath(caveNorth);
            dungeon.AddPath(dungeonSouth);
        }

        [Test]
        public void TestLookCommand() // Testing look command through command processor
        {
            Assert.AreEqual(command.Execute(steve, new string[] {"look"}), "A dark gloomy cave that is bound to be dangerous, there appears to be an exit to the north");
        }

        [Test]
        public void TestMoveCommand() // Testing move command through command processor
        {
            Assert.AreEqual(command.Execute(steve, new string[] { "move", "north" }), "You head north\r\nYou move through a tiny crack in the wall\r\nYou arrive at a dungeon");
            Assert.AreEqual(steve.Location, dungeon);
        }

        [Test]
        public void TestNonExistentCommand() // Testing if the inputted string is empty
        {
            Assert.AreEqual(command.Execute(steve, new string[] { "" }), "Invalid Command Input");
        }

        [Test]
        public void TestInvalidCommand() // Testing if the inputted string is invalid
        {
            Assert.AreEqual(command.Execute(steve, new string[] { "slide" }), "Invalid Command Input");
        }
    }
}