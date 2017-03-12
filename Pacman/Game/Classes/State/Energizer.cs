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
            this.points = 100;
        }

        public Energizer(){ }

        public int Points {
            get { return points; }
            set { if (value < 0) throw new ArgumentException("points must be > 0"); } }

        // check how these events work
        protected virtual void OnCollisionEvent()
        {
            // i want the longer invoke of delegate, easier to read
            if (CollisionEvent != null)
            {
                CollisionEvent(this);
            }
        }
        public void Collide()
        {
            // runs increment score for energizer
            // assigned in gamestate
            OnCollisionEvent();
        }

    }
}
