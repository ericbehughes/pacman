using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman.Characters.Classes;
using Pacman.Game.Classes.State;
using Microsoft.Xna.Framework;
using Pacman.Game.Classes.Map;

namespace PacmanUnitTest
{
    [TestClass]
    public class PathTest
    {
        [TestMethod]
        public void TestValidConstructor()
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
        public void TestInValidConstructor()
        {
            GhostPack gPack = new GhostPack();
            Energizer e = new Energizer(gPack);
            int x = -1,
                y = -1;
            Path p = new Path(x, y, e);
        }

        [TestMethod]
        public void TestCanEnter()
        {
            GhostPack gPack = new GhostPack();
            Energizer e = new Energizer(gPack);
            int x = 10,
                y = 10;
            Path p = new Path(x, y, e);

            Assert.AreEqual(true, p.CanEnter());
        }

        [TestMethod]
        public void TestIsEmpty()
        {
            GhostPack gPack = new GhostPack();
            Energizer e = new Energizer(gPack);
            int x = 10,
                y = 10;
            Path p = new Path(x, y, e);
            p.IsEmpty();
            Assert.AreEqual(false, p.IsEmpty());
            p.Member = null;
            Assert.AreEqual(true, p.IsEmpty());
        }

        [TestMethod]
        public void TestMemberMutatorProperty()
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
        public void TestMemberAccessorProperty()
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
        public void TestCollide()
        {
            GhostPack gPack = new GhostPack();
            Energizer e = new Energizer(gPack);
            int x = 10,
                y = 10;
            Path p = new Path(x, y, e);
            p.Collide += (x) =>
            {

            }
        }
    }
}
