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
        public void TestValidParameterConstructor()
        {
            /* Test Points Ghosts*/
            /*
            GhostState gs = new GhostState();
            GameState gameState = new GameState();
            Pacman.Characters.Classes.Color c = new Pacman.Characters.Classes.Color();
            Vector2 v2 = new Vector2(10, 10);
            Ghost g = new Ghost(gameState, 10, 10, v2, gs, c);
            */
            GhostPack gPack = new GhostPack();
            Energizer e = new Energizer(gPack);
            int points = e.Points;
            Assert.AreEqual(100, points); 

        }

        [TestMethod]
        public void TestValidNoParameterConstructor()
        {
            Energizer e = new Energizer();
            int points = e.Points;
            Assert.AreEqual(100, points);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidPointsMutator()
        {
            Energizer e = new Energizer();
            e.Points = -1;
        }

        [TestMethod]
        public void TestPointsAccessor()
        {
            Energizer e = new Energizer();
            int points = e.Points;
            Assert.AreEqual(100, points);
        }
        
        [TestMethod]
        public void TestValidPointsMutator()
        {
            Energizer e = new Energizer();
            e.Points += 500;
            int points = e.Points;
            Assert.AreEqual(600, points);
        }
        
        [TestMethod]
        public void TestCollideEvent()
        {
            Energizer e = new Energizer();
            int points = e.Points;
            Assert.AreEqual(100, points);
            e.CollisionEvent += (x) =>
            {
                x.Points += 300;
            };
            e.Collide();
            points = e.Points;
            Assert.AreEqual(400, points);
        }
        
    }
}
