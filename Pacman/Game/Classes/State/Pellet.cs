using Pacman.Characters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Game.Classes.State
{
    public class Pellet : ICollidable
    {
        public event CollisionEventHandler CollisionEvent;
        private int points;

        public Pellet()
        {

        }
        public int Points
        {
            get{ return points;}
            set{ if (value >= 0) points = value;}
        }
        // check how these events work
        protected virtual void OnCollisionEvent()
        {
            // same invoke as energizer
           if (CollisionEvent != null)
            {
                CollisionEvent(this);
            }
        }
        public void Collide()
        {
            // runs increment score for pellet
            // assigned in gamestate
            OnCollisionEvent();
        }
    }
}
