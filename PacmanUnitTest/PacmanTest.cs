using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman.Game.Classes.State;

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
            //Assert.AreEqual(null, gameState.Pacman);
            Assert.AreEqual(2, x);
            Assert.AreEqual(3, y);
        }

        [TestMethod]
        public void TestPacmanMoveUp()
        {
            GameState gameState = GameState.Parse("map.csv");
            int x = (int)gameState.Pacman.Position.X,
               y = (int)gameState.Pacman.Position.Y;
            /* Make sure start position is correct */
            Assert.AreEqual(2, x);
            Assert.AreEqual(3, y);

            gameState.Pacman.Move(Pacman.Characters.Classes.Direction.Up);
            x = (int)gameState.Pacman.Position.X;
            y = (int)gameState.Pacman.Position.Y;
            /* New position should be x, y - 1 */
            Assert.AreEqual(2, x);
            Assert.AreEqual(2, y);
        }

        [TestMethod]
        public void TestPacmanMoveLeft()
        {
            GameState gameState = GameState.Parse("map.csv");
            int x = (int)gameState.Pacman.Position.X,
               y = (int)gameState.Pacman.Position.Y;
            /* Make sure start position is correct */
            Assert.AreEqual(2, x);
            Assert.AreEqual(3, y);

            gameState.Pacman.Move(Pacman.Characters.Classes.Direction.Up);
            x = (int)gameState.Pacman.Position.X;
            y = (int)gameState.Pacman.Position.Y;
            /* New position should be x - 1, y  */
            Assert.AreEqual(1, x);
            Assert.AreEqual(3, y);
        }

        [TestMethod]
        public void TestPacmanMoveDown()
        {
            GameState gameState = GameState.Parse("map.csv");
            int x = (int)gameState.Pacman.Position.X,
               y = (int)gameState.Pacman.Position.Y;
            /* Make sure start position is correct */
            Assert.AreEqual(2, x);
            Assert.AreEqual(3, y);

            gameState.Pacman.Move(Pacman.Characters.Classes.Direction.Up);
            x = (int)gameState.Pacman.Position.X;
            y = (int)gameState.Pacman.Position.Y;
            /* New position should be x, y + 1  */
            Assert.AreEqual(2, x);
            Assert.AreEqual(4, y);
        }

        [TestMethod]
        public void TestPacmanMoveRight()
        {
            GameState gameState = GameState.Parse("map.csv");
            int x = (int)gameState.Pacman.Position.X,
               y = (int)gameState.Pacman.Position.Y;
            /* Make sure start position is correct */
            Assert.AreEqual(2, x);
            Assert.AreEqual(3, y);

            gameState.Pacman.Move(Pacman.Characters.Classes.Direction.Up);
            x = (int)gameState.Pacman.Position.X;
            y = (int)gameState.Pacman.Position.Y;
            /* New position should be x + 1, y  */
            Assert.AreEqual(3, x);
            Assert.AreEqual(3, y);
        }
    }
}
