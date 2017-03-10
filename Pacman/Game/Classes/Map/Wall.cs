using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pacman.Game.Classes.Map
{
    public class Wall : Tile
    {
        public Wall(int x, int y) : base(x, y)
        {
        }

        public override bool CanEnter()
        {
            return false;
        }

        public override void Collide()
        {
           
        }

        public override float GetDistance(Vector2 goal)
        {
            return 0.0f;
        }

        public string toString()
        {
            return "|_|";
        }
    }
}
