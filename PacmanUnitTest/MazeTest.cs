using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman.Game.Classes.State;
using Pacman.Game.Classes.Map;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Pacman.Characters.Classes;

namespace PacmanUnitTest
{
    [TestClass]
    public class MazeTest
    {
        [TestMethod]
        public void TestMazeGetAvailableNeighboursLeft()
        {
            GameState gameState = GameState.Parse("map.csv");
            List<Tile> testNeighbors = gameState.Maze.GetAvailableNeighbours(new Vector2(1, 2), Direction.Left);
            Assert.AreEqual(1, testNeighbors[0].Position.X);
            Assert.AreEqual(1, testNeighbors[0].Position.Y);
            Assert.AreEqual(2, testNeighbors[1].Position.X);
            Assert.AreEqual(2, testNeighbors[1].Position.Y);
            Assert.AreEqual(2, testNeighbors.Count);
        }

        [TestMethod]
        public void TestMazeGetAvailableNeighboursRight()
        {
            GameState gameState = GameState.Parse("map.csv");
            List<Tile> testNeighbors = gameState.Maze.GetAvailableNeighbours(new Vector2(1,2), Direction.Right);
            Assert.AreEqual(1, testNeighbors[0].Position.X);
            Assert.AreEqual(3, testNeighbors[0].Position.Y);
            Assert.AreEqual(2, testNeighbors[1].Position.X);
            Assert.AreEqual(2, testNeighbors[1].Position.Y);
            Assert.AreEqual(2, testNeighbors.Count);
        }

        [TestMethod]
        public void TestMazeGetAvailableNeighboursUp()
        {
            GameState gameState = GameState.Parse("map.csv");
            List<Tile> testNeighbors = gameState.Maze.GetAvailableNeighbours(new Vector2(1,2), Direction.Up);
            Assert.AreEqual(1, testNeighbors[0].Position.X);
            Assert.AreEqual(1, testNeighbors[0].Position.Y);
            Assert.AreEqual(1, testNeighbors[1].Position.X);
            Assert.AreEqual(3, testNeighbors[1].Position.Y);
            Assert.AreEqual(2, testNeighbors.Count);
        }

        [TestMethod]
        public void TestMazeGetAvailableNeighboursDown()
        {
            GameState gameState = GameState.Parse("map.csv");
            List<Tile> testNeighbors = gameState.Maze.GetAvailableNeighbours(new Vector2(1, 2), Direction.Down);
            Assert.AreEqual(1, testNeighbors[0].Position.X);
            Assert.AreEqual(1, testNeighbors[0].Position.Y);
            Assert.AreEqual(1, testNeighbors[1].Position.X);
            Assert.AreEqual(3, testNeighbors[1].Position.Y);
            Assert.AreEqual(2, testNeighbors[2].Position.X);
            Assert.AreEqual(2, testNeighbors[2].Position.Y);
            Assert.AreEqual(3, testNeighbors.Count);
        }

        [TestMethod]
        public void TestMazeCheckMembersLeftWin()
        {
            GameState gs = GameState.Parse("map.csv");
            Maze maze = gs.Maze;
            Boolean val = false;
            maze.PacmanWonEvent += () =>
            {
                val = true;
            };
            maze.CheckMembersLeft();
            Assert.AreEqual(true, val);
        }

        [TestMethod]
        public void TestMazeCheckMembersLeftTestLose()
        {
            GameState gs = GameState.Parse("map.csv");
            Maze maze = gs.Maze;
            maze[1, 1].Member = null;
            maze[2, 1].Member = new Pellet();
            Boolean val = false;
            maze.PacmanWonEvent += () =>
            {
                val = true;
            };
            maze.CheckMembersLeft();
            Assert.AreEqual(false, val);
        }
    }
}
