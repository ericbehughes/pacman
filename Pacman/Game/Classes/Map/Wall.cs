using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pacman.Characters.Interfaces;

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
            return Vector2.Distance(this.Position, goal);
        }


        public string toString()
        {
            return "|_|";
        }
    }
}
