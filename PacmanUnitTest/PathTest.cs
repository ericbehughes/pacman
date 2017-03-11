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
        }
    }
}
