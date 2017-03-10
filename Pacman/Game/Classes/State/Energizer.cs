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

        public event CollisionEventHandler CollisionEvent;

        public Energizer(GhostPack ghosts)
        {
            this.ghosts = ghosts;
        }

        public Energizer(){ }

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

        // check how these events work
        protected virtual void OnCollisionEvent()
        {
            if (CollisionEvent != null)
            {
                CollisionEvent(this);
            }
        }
        public void Collide()
        {
            // runs increment score
            OnCollisionEvent();
        }

        public string toString()
        {
            return "o";
        }


    }
}
