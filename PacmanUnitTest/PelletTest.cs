using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman;
using Pacman.Game.Classes.State;

namespace PacmanUnitTest
{
    [TestClass]
    public class PelletTest
    {
        [TestMethod]
        public void TestValidConstructor()
        {
            /* Test Pellet */
            Pellet p = new Pellet();
            int points = p.Points;
            Assert.AreEqual(10, points);
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
