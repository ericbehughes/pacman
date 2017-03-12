﻿using System;
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
            Vector2 target = new Vector2(3, 1);
            GhostState state = GhostState.Chase;
            Pacman.Characters.Classes.Color c = Pacman.Characters.Classes.Color.Red;
            Ghost ghost = new Ghost(gameState, 1, 3, target, state, c);
            ghost.Direction = Direction.Left;

            Assert.AreEqual(1, ghost.Position.X);
            Assert.AreEqual(3, ghost.Position.Y);
            Assert.AreEqual(Direction.Left, ghost.Direction);
            Assert.AreEqual(Pacman.Characters.Classes.Color.Red, ghost.Color);

        }

        [TestMethod]
        public void TestGhostChaseMovement()
        {
            //parse map
            GameState gameState = GameState.Parse("ghostMap.csv");

            //NOTE
            // x and y are switched since business logic uses array logic instead of cartesian
            //  vector X and Y are inverted in constructor for Ghost Class

            //target is pacmans location on ghostMap.csv in bin/debug row 3 col 1
            Vector2 target = new Vector2(3, 1);
            //build ghost
            GhostState state = GhostState.Chase;
            Pacman.Characters.Classes.Color c = Pacman.Characters.Classes.Color.Red;
            Ghost ghost = new Ghost(gameState, 1, 3, target, state, c);
            ghost.Direction = Direction.Left;
            // make ghost move towards target
            ghost.Move();

            Assert.AreEqual(1, ghost.Position.X);
            Assert.AreEqual(2, ghost.Position.Y);

        }


        [TestMethod]
        public void TestGhostCollision()
        {
            //parse map
            GameState gameState = GameState.Parse("collisionTest.csv");

            //target is pacmans location on ghostMap.csv in bin/debug row 3 col 1
            Vector2 target = gameState.Pacman.Position;
            //build ghost
            GhostState state = GhostState.Chase;
            Pacman.Characters.Classes.Color c = Pacman.Characters.Classes.Color.Red;
            Ghost ghost = new Ghost(gameState, 1, 3, target, state, c);
            ghost.Direction = Direction.Left;
            // make ghost move towards target
            ghost.Move();

            Assert.AreEqual(1, ghost.Position.X);
            Assert.AreEqual(2, ghost.Position.Y);

        }
    }
}
