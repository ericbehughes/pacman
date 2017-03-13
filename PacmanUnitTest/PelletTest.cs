using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman;
using Pacman.Game.Classes.State;
using Pacman.Game.Classes.Map;

namespace PacmanUnitTest
{
    [TestClass]
    public class PelletTest
    {
        [TestMethod]
        public void TestPelletValidConstructor()
        {
            Pellet p = new Pellet();
            int points = p.Points;
            Assert.AreEqual(10, points);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPelletInvalidPointsMutator()
        {
            Pellet p = new Pellet();
            p.Points = -1;
        }
        
        [TestMethod]
        public void TestPelletPointsAccessor()
        {
            Pellet p = new Pellet();
            int points = p.Points;
            Assert.AreEqual(10, points);
        }

        [TestMethod]
        public void TestPelletValidPointsMutator()
        {
            Pellet p = new Pellet();
            p.Points += 500;
            int points = p.Points;
            Assert.AreEqual(510, points);
        }

        [TestMethod]
        public void TestPelletCollideEvent()
        {
            GameState gameState = GameState.Parse("map.csv");
            Pellet p = new Pellet();
            int points = p.Points;
            Assert.AreEqual(10, points);
            p.CollisionEvent += (x) =>
            {
                x.Points += 300;
            };
            Maze maze = gameState.Maze;
            maze[2, 1].Member = p;
            maze[2, 1].Member.Collide();
            maze[2, 1].Member = null;
            points = p.Points;
            Assert.AreEqual(310, points);

        }
    }
}
