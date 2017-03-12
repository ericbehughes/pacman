using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman.Game.Classes.Map;
using Microsoft.Xna.Framework;

namespace PacmanUnitTest
{
    [TestClass]
    public class WallTest
    {
        [TestMethod]
        public void TestValidConstructor()
        {
            int x = 10,
                y = 10;
            Vector2 v2 = new Vector2(x, y);
            Wall w = new Wall(x,y);
            Assert.AreEqual(v2, w.Position);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInValidConstructor()
        {
            int x = -1,
                y = -1;
            Wall w = new Wall(x, y);
        }

        [TestMethod]
        public void TestCanEnter()
        {
            Wall w = new Wall(10, 10);
            Assert.AreEqual(false, w.CanEnter());
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestCollide()
        {
            Wall w = new Wall(10, 10);
            w.Collide();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TestIsEmpty()
        {
            Wall w = new Wall(10, 10);
            w.IsEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestMemberMutatorProperty()
        {
            Wall w = new Wall(10, 10);
            w.Member = null;
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestMemberAccessorProperty()
        {
            Wall w = new Wall(10, 10);
            var m = w.Member;
        }
    }


}
