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
            GameState gs = GameState.Parse("map.csv");
            Maze maze = gs.Maze;
            Vector2 v2 = new Vector2(1, 2);
            Pacman.Game.Classes.Map.Path testPath = new Pacman.Game.Classes.Map.Path(1, 2, new Energizer());
            List<Tile> testTiles = new List<Tile>();
            testTiles.Add(testPath);
            List<Tile> testNeighbors = maze.GetAvailableNeighbours(v2, Direction.Left);
            Assert.AreEqual(new Vector2(1, 1), testNeighbors[0]);
            Assert.AreEqual(1, testNeighbors.Count);
        }

        public void TestMazeGetAvailableNeighboursRight()
        {
            GameState gs = GameState.Parse("map.csv");
            Maze maze = gs.Maze;
            Vector2 v2 = new Vector2(1, 2);
            Pacman.Game.Classes.Map.Path testPath = new Pacman.Game.Classes.Map.Path(1, 2, new Energizer());
            List<Tile> testTiles = new List<Tile>();
            testTiles.Add(testPath);
            List<Tile> testNeighbors = maze.GetAvailableNeighbours(v2, Direction.Right);
            Assert.AreEqual(new Vector2(1, 1), testNeighbors[0]);
            Assert.AreEqual(new Vector2(2, 2), testNeighbors[1]);
            Assert.AreEqual(2, testNeighbors.Count);
        }

        public void TestMazeGetAvailableNeighboursUp()
        {
            GameState gs = GameState.Parse("map.csv");
            Maze maze = gs.Maze;
            Vector2 v2 = new Vector2(1, 2);
            Pacman.Game.Classes.Map.Path testPath = new Pacman.Game.Classes.Map.Path(1, 2, new Energizer());
            List<Tile> testTiles = new List<Tile>();
            testTiles.Add(testPath);
            List<Tile> testNeighbors = maze.GetAvailableNeighbours(v2, Direction.Up);
            Assert.AreEqual(new Vector2(1, 1), testNeighbors[0]);
            Assert.AreEqual(new Vector2(2, 2), testNeighbors[1]);
            Assert.AreEqual(2, testNeighbors.Count);
        }

        public void TestMazeGetAvailableNeighboursDown()
        {
            GameState gs = GameState.Parse("map.csv");
            Maze maze = gs.Maze;
            Vector2 v2 = new Vector2(1, 2);
            Pacman.Game.Classes.Map.Path testPath = new Pacman.Game.Classes.Map.Path(1, 2, new Energizer());
            List<Tile> testTiles = new List<Tile>();
            testTiles.Add(testPath);
            List<Tile> testNeighbors = maze.GetAvailableNeighbours(v2, Direction.Down);
            Assert.AreEqual(new Vector2(2, 2), testNeighbors[0]);
            Assert.AreEqual(1, testNeighbors.Count);
        }

    }
}
