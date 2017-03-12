using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman.Game.Classes.State;
using static Pacman.Characters.Classes.Ghost;
using Pacman.Characters.Classes;
using Microsoft.Xna.Framework;

namespace PacmanUnitTest
{
    [TestClass]
    public class EnergizerTest
    {
        [TestMethod]
        public void TestValidConstructor()
        {
            /* Test points*/
            Energizer e = new Energizer();
            int points = e.Points;
            Assert.AreEqual(100, points);

            /* Test Ghosts*/

            GhostState gs = new GhostState();
            GameState gameState = new GameState();
            Color c = new Color();
            Vector2 v2
            Ghost g = new Ghost(gameState, 10, 10, new Vector2(10, 10), gs, c);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidPointsMutator()
        {
            Pellet p = new Pellet();
            p.Points = -1;
        }

        [TestMethod]
        public void TestPointsAccessor()
        {
            Pellet p = new Pellet();
            int points = p.Points;
            Assert.AreEqual(10, points);
        }

        [TestMethod]
        public void TestValidPointsMutator()
        {
            Pellet p = new Pellet();
            p.Points += 500;
            int points = p.Points;
            Assert.AreEqual(510, points);
        }

        [TestMethod]
        public void TestCollideEvent()
        {
            Boolean eventRaised = false;
            Pellet p = new Pellet();
            int points = p.Points;
            Assert.AreEqual(10, points);
            p.CollisionEvent += (x) =>
            {
                x.Points += 300;
            };
            p.Collide();
            points = p.Points;
            Assert.AreEqual(310, points);
        }
    }
}
