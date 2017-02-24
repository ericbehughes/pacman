using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pacman.Characters.Interfaces;
using Pacman.Game.Classes.State;

namespace Pacman.Game.Classes.Map
{
    public class Path : Tile
    {

        private ICollidable member;
        public Path(int x, int y, ICollidable member) : base(x, y)
        {
        }

        public override bool CanEnter()
        {
            throw new NotImplementedException();
        }

        public override void Collide()
        {
            throw new NotImplementedException();
        }

        public override float GetDistance(Vector2 goal)
        {
            throw new NotImplementedException();
        }

        public string toString()
        {
            if (this.member is Energizer)
                return "o";
            else if (this.member is Pellet)
                return "*";
            else
                return "neither";
        }
    }
}
