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
    public class GhostTest
    {
        [TestMethod]
        public void TestGhostConstructor()
        {
            GameState gameState = GameState.Parse("ghostMap.csv");
            // x and y are switched since business logic uses array logic instead of cartesian
            // row 3 col 1  vector is inverted
            Vector2 position = new Vector2(1, 3);
            Vector2 expected = new Vector2()
        }
    }
}
