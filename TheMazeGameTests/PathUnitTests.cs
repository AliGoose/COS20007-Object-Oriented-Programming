using NUnit.Framework;
using System;
using TheMazeGameDLL;

namespace TheMazeGameTests
{
    public class PathTests
    {
        private Player steve;
        private Location cave;
        private Location dungeon;
        private Path caveNorth;
        private Path dungeonSouth;
        private MoveCommand move;
        private CommandProcessor command;


        [SetUp]
        public void Setup()
        {
            steve = new Player("Steve", "The dude from minecraft!");
            cave = new Location(new string[] { "cave", "hole" }, "cave", "A dark gloomy cave that is bound to be dangerous, there appears to be an exit to the north.");
            dungeon = new Location(new string[] { "dungeon", "arena" }, "dungeon", "A darm room, it has loot but also dangerous enemies. There appears to be no other paths");
            caveNorth = new Path(new string[] { "north" }, "north", "You move through a tiny crack in the wall", dungeon);
            dungeonSouth = new Path(new string[] { "south" }, "south", "You move through a tiny crack in the wall", cave);
            move = new MoveCommand();
            command = new CommandProcessor();
        }

        [Test]
        public void TestMove() // Test to move one location
        {
            steve.Location = cave;
            cave.AddPath(caveNorth);
            dungeon.AddPath(dungeonSouth);
            Assert.AreEqual(move.Execute(steve, new string[] { "move", "north" }), "You head north\r\nYou move through a tiny crack in the wall\r\nYou arrive at a dungeon");
            Assert.AreEqual(steve.Location, dungeon);
        }

        [Test]
        public void TestMoveBackAndForth() // Test to move back and forth between two locations
        {
            steve.Location = cave;
            cave.AddPath(caveNorth);
            dungeon.AddPath(dungeonSouth);
            move.Execute(steve, new string[] { "move", "north" });
            Assert.AreEqual(move.Execute(steve, new string[] { "move", "south" }), "You head south\r\nYou move through a tiny crack in the wall\r\nYou arrive at a cave");
            Assert.AreEqual(steve.Location, cave);
        }

        [Test]
        public void TestInvalidPath() // Test to try and move through a non-existent path
        {
            steve.Location = cave;
            cave.AddPath(caveNorth);
            dungeon.AddPath(dungeonSouth);
            Assert.AreEqual(move.Execute(steve, new string[] { "move", "west" }), "That path you have chosen does not exist");
            Assert.AreEqual(steve.Location, cave);
        }

        [Test]
        public void TestInvalidInput() // Test to try invalid command input
        {
            steve.Location = cave;
            cave.AddPath(caveNorth);
            dungeon.AddPath(dungeonSouth);
            Assert.AreEqual(command.Execute(steve, new string[] { "slide", "west" }), "Invalid Command Input");
            Assert.AreEqual(steve.Location, cave);
        }

        [Test]
        public void TestInvalidInputLength() // Test to try invalid command input length
        {
            steve.Location = cave;
            cave.AddPath(caveNorth);
            dungeon.AddPath(dungeonSouth);
            Assert.AreEqual(move.Execute(steve, new string[] { "slide", "west", "side" }), "I don't know how to move like that");
            Assert.AreEqual(steve.Location, cave);
        }
    }
}