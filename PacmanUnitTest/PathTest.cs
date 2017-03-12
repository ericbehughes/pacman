using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman.Characters.Classes;
using Pacman.Game.Classes.State;
using Microsoft.Xna.Framework;
using Pacman.Game.Classes.Map;
using static Pacman.Characters.Classes.Ghost;

namespace PacmanUnitTest
{
    [TestClass]
    public class PathTest
    {
        [TestMethod]
        public void TestPathValidConstructor()
        {
            GhostPack gPack = new GhostPack();
            Energizer e = new Energizer(gPack);
            int x = 10,
                y = 10;
            Vector2 v2 = new Vector2(x, y);
            Path p = new Path(x, y, e);

            Assert.AreEqual(v2, p.Position);
            Assert.AreEqual(e, p.Member);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPathInValidConstructor()
        {
            int x = -1,
                y = -1;
            Path p = new Path(x, y, null);
        }

        [TestMethod]
        public void TestPathCanEnter()
        {
            int x = 10,
                y = 10;
            Path p = new Path(x, y, null);

            Assert.AreEqual(true, p.CanEnter());
        }

        [TestMethod]
        public void TestPathIsEmpty()
        {
            GhostPack gPack = new GhostPack();
            Energizer e = new Energizer(gPack);
            int x = 10,
                y = 10;
            Path p = new Path(x, y, e);
            Assert.AreEqual(false, p.IsEmpty());
            p.Member = null;
            Assert.AreEqual(true, p.IsEmpty());
        }

        [TestMethod]
        public void TestPathMemberMutatorProperty()
        {
            GhostPack gPack = new GhostPack();
            Energizer oldE = new Energizer(gPack);
            Energizer newE = new Energizer(gPack);
            oldE.Points = 100;
            newE.Points = 200;
            int x = 10,
                y = 10;
            Path p = new Path(x, y, oldE);
            Assert.AreEqual(oldE, p.Member);
            Assert.AreEqual(oldE.Points, p.Member.Points);
            p.Member = newE;
            Assert.AreEqual(newE, p.Member);
            Assert.AreEqual(newE.Points, p.Member.Points);
        }

        [TestMethod]
        public void TestPathMemberAccessorProperty()
        {
            GhostPack gPack = new GhostPack();
            Energizer e = new Energizer(gPack);
            int x = 10,
                y = 10;
            Path p = new Path(x, y, e);
            Assert.AreEqual(e, p.Member);
            Assert.AreEqual(e.Points, p.Member.Points);
        }

        [TestMethod]
        public void TestPathCollide()
        {
            int x = 10,
                y = 10;
            Path p = new Path(x, y, null);
            Pellet pel = new Pellet();
            bool actualVal = false;
            bool expectedVal = true;
            pel.CollisionEvent += (z) =>
            {
                actualVal = true;
            };
            pel.Collide();
            Assert.AreEqual(expectedVal, actualVal);
        }
    }
}
