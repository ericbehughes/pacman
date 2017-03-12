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
            throw new NotSupportedException("Wall.cs - Wall collide exception");
        }

        public override bool IsEmpty()
        {
            throw new NotImplementedException("Wall.cs - Walls cant be empty exception");
        }

        public override ICollidable Member
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }
    }
}
