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
            this.member = member;
        }

        public override bool CanEnter(){  return true; }
        /*Invoked each time pacman moves to the tile*/
        public override void Collide()
        {
            if (this.member != null)
                Collide();
            this.member = null;
        }

        public override bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public override ICollidable Member { get;set; }
    }
}
