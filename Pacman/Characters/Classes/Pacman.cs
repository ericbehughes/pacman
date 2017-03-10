using Microsoft.Xna.Framework;
using Pacman.Characters.Interfaces;
using Pacman.Game.Classes.Map;
using Pacman.Game.Classes.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Characters.Classes
{
    public class Pacman : ICollidable
    {
        private GameState controller;
        private Maze maze;
        private Vector2 position;

        public event CollisionEventHandler CollisionEvent;

        public Pacman(GameState gameState)
        {
            controller = gameState;

        }
        public Vector2 Position
        {
            get { return new Vector2(position.X, position.Y); }
            set { position = new Vector2(value.X, value.Y); }
        }

        public int Points
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

        public void Move(Direction dir)
        {
          switch (dir)
            {
                case Direction.Up:
                    if (this.Position.Y != 0)
                        this.Position = new Vector2(this.Position.X, this.Position.Y - 1);
                    break;

                case Direction.Down:
                    if (this.Position.Y != (maze.Size - 1))
                        this.Position = new Vector2(this.Position.X, this.Position.Y + 1);
                    break;

                case Direction.Left:
                    if (this.Position.X != 0)
                        this.Position = new Vector2(this.Position.X - 1, this.Position.Y);
                    break;

                case Direction.Right:
                    if (this.Position.X != (maze.Size - 1))
                        this.Position = new Vector2(this.Position.X + 1, this.Position.Y);
                    break;
            }
        }
        public void CheckCollisions(Vector2 v)
        {
            //check non empty tile collision
            if (this.maze[(int)this.position.X, (int)this.position.Y] != null)
            {
                this.maze[(int)this.position.X, (int)this.position.Y].Collide();
            }
            
       
        }

        public void Collide()
        {
            throw new NotImplementedException();
        }
    }
}
