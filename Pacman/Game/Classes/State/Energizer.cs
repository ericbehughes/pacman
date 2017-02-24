using Pacman.Characters.Classes;
using Pacman.Characters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Game.Classes.State
{
    public class Energizer : ICollidable
    {
        private int points;
        private GhostPack ghosts;

        public Energizer(GhostPack ghosts)
        {
            this.ghosts = ghosts; // i think
        }

        event EventHandler ICollidable.Collisiion
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public int Points
        {
            get
            {
                return points;
            }

            set
            {
                if (value >= 0) // whatever goes here
                    points = value;
            }
        }

        int ICollidable.Points
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void Collide()
        {

        }

        void ICollidable.Collide()
        {
            throw new NotImplementedException();
        }
    }
}
