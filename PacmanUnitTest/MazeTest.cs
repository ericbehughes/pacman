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
        public void TestMazeValidConstructor()
        {
            GameState gs = new GameState();
            gs.Parse("map.csv");
        }

        [TestMethod]
        public void TestMazeGetAvailableNeighbours()
        {
            String content = File.ReadAllText(@"map.csv");
            GameState gameState = new GameState();
            gameState.Parse(content);
            Maze maze = gameState.Maze;
            Vector2 v2 = new Vector2(1, 1);
            Pacman.Game.Classes.Map.Path testPath = new Pacman.Game.Classes.Map.Path(1, 2, new Energizer());
            List<Tile> testTiles = new List<Tile>();
            testTiles.Add(testPath);
            List<Tile> testNeighbors = maze.GetAvailableNeighbours(testPath, Direction.Left);
        }
    }
}
