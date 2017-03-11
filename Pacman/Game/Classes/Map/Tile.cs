using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pacman.Characters.Interfaces;

namespace Pacman.Game.Classes.Map
{
    public abstract class Tile 
    {
        private Vector2 position;//position of the tile
        public Tile(int x, int y)
        {
            if (x < 0 || y < 0)
                throw new ArgumentException("The x and y position have a value of 0 or above.");

            this.position.X = x;
            this.position.Y = y;
        }
        //position is not abstract and must have validation
        public Vector2 Position
        {
            get { return position; }
            set
            {
                Vector2 pos = value;
                if (pos.X < 0 || pos.Y < 0)
                    throw new ArgumentException("The Tile object's position x and y must " +
                       "be positive");
                position = pos;
            }
        }
        public abstract ICollidable Member { get; set; }
        public abstract Boolean CanEnter();
        public abstract void Collide();
        public abstract bool IsEmpty();
        public float GetDistance(Vector2 goal)
        {
            return Vector2.Distance(position, goal);
        } 

    }
}
