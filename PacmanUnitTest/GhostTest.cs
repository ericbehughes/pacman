using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman.Game.Classes.State;
using Pacman.Game.Classes.Map;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Pacman.Characters.Classes;
using static Pacman.Characters.Classes.Ghost;

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
            Vector2 target = new Vector2(3, 1);
            GhostState state = GhostState.Chase;
            Pacman.Characters.Classes.Color c = Pacman.Characters.Classes.Color.Red;
            Ghost ghost = new Ghost(gameState, 3, 1, target, state, c);
            ghost.Move();

        }
    }
}
