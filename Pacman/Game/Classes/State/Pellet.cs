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
        private int points;

        public Pellet()
        {

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

        public event EventHandler Collisiion;

        public void Collide()
        {
            throw new NotImplementedException();
        }
    }
}
