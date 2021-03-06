﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman.Game.Classes.Map;
using Microsoft.Xna.Framework;

namespace PacmanUnitTest
{
    [TestClass]
    public class WallTest
    {
        [TestMethod]
        public void TestWallValidConstructor()
        {
            int x = 10,
                y = 10;
            Vector2 v2 = new Vector2(x, y);
            Wall w = new Wall(x,y);
            Assert.AreEqual(v2, w.Position);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWallInValidConstructor()
        {
            int x = -1,
                y = -1;
            Wall w = new Wall(x, y);
        }

        [TestMethod]
        public void TestWallCanEnter()
        {
            Wall w = new Wall(10, 10);
            Assert.AreEqual(false, w.CanEnter());
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestWallCollide()
        {
            Wall w = new Wall(10, 10);
            w.Collide();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TestWallIsEmpty()
        {
            Wall w = new Wall(10, 10);
            w.IsEmpty();
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestWallMemberMutatorProperty()
        {
            Wall w = new Wall(10, 10);
            w.Member = null;
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestWallMemberAccessorProperty()
        {
            Wall w = new Wall(10, 10);
            var m = w.Member;
        }
    }


}
