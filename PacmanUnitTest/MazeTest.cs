using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman.Game.Classes.State;

namespace PacmanUnitTest
{
    [TestClass]
    public class MazeTest
    {
        [TestMethod]
        public void TestMazeValidConstructor()
        {
            GameState gs = new GameState();
            gs.Parse("map.csv");
        }
    }
}
