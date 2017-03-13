using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman.Game.Classes.State;
using Pacman.Characters.Classes;
using Microsoft.Xna.Framework;

namespace PacmanUnitTest
{
    [TestClass]
    public class PacmanTest
    {
        [TestMethod]
        public void TestPacmanStartPosition()
        {
            GameState gameState = GameState.Parse("map.csv");
            int x = (int)gameState.Pacman.Position.X,
               y = (int)gameState.Pacman.Position.Y;
            Assert.AreEqual(3, x);
            Assert.AreEqual(1, y);
        }

        [TestMethod]
        public void TestPacmanMoveUp()
        {
            GameState gameState = GameState.Parse("map.csv");
            Pacman.Characters.Classes.Pacman pacman = gameState.Pacman;
            int x = (int)gameState.Pacman.Position.X,
               y = (int)gameState.Pacman.Position.Y;
            /* Make sure start position is correct */
            Assert.AreEqual(3, x);
            Assert.AreEqual(1, y);
            gameState.Pacman.Position = new Vector2(3, 1);
            gameState.Pacman.Move(Pacman.Characters.Classes.Direction.Up);
            x = (int)gameState.Pacman.Position.X;
            y = (int)gameState.Pacman.Position.Y;
            /* New position should be x - 1*/
            Assert.AreEqual(2, x);
            Assert.AreEqual(1, y);
        }

        [TestMethod]
        public void TestPacmanMoveLeft()
        {
            GameState gameState = GameState.Parse("map.csv");
            int x = (int)gameState.Pacman.Position.X,
               y = (int)gameState.Pacman.Position.Y;
            /* Make sure start position is correct */
            Assert.AreEqual(3, x);
            Assert.AreEqual(1, y);
            Pacman.Characters.Classes.Pacman p = new Pacman.Characters.Classes.Pacman(gameState);
            p.Position = new Vector2(3, 1);
            p.Move(Pacman.Characters.Classes.Direction.Left);
            x = (int)p.Position.X;
            y = (int)p.Position.Y;
            /* New position should be the same because left is a wall*/
            Assert.AreEqual(3, x);
            Assert.AreEqual(1, y);
        }

        [TestMethod]
        public void TestPacmanMoveDown()
        {
            GameState gameState = GameState.Parse("map.csv");
            int x = (int)gameState.Pacman.Position.X,
               y = (int)gameState.Pacman.Position.Y;
            /* Make sure start position is correct */
            Assert.AreEqual(3, x);
            Assert.AreEqual(1, y);
            Pacman.Characters.Classes.Pacman p = new Pacman.Characters.Classes.Pacman(gameState);
            p.Position = new Vector2(3, 1);
            p.Move(Pacman.Characters.Classes.Direction.Down);
            x = (int)p.Position.X;
            y = (int)p.Position.Y;
            /* New position should be x - 1*/
            Assert.AreEqual(4, x);
            Assert.AreEqual(1, y);
        }

        [TestMethod]
        public void TestPacmanMoveRight()
        {
            GameState gameState = GameState.Parse("map.csv");
            int x = (int)gameState.Pacman.Position.X,
               y = (int)gameState.Pacman.Position.Y;
            /* Make sure start position is correct */
            Assert.AreEqual(3, x);
            Assert.AreEqual(1, y);
            Pacman.Characters.Classes.Pacman p = new Pacman.Characters.Classes.Pacman(gameState);
            p.Position = new Vector2(3, 1);
            p.Move(Pacman.Characters.Classes.Direction.Right);
            x = (int)p.Position.X;
            y = (int)p.Position.Y;
            /* New position should be x - 1*/
            Assert.AreEqual(3, x);
            Assert.AreEqual(2, y);
        }
    }
}
