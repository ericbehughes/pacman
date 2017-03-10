using Microsoft.Xna.Framework;
using Pacman.Game.Classes.Map;
using Pacman.Game.Classes.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Characters.Classes
{
    public class Pacman
    {
        private GameState controller;
        private Maze maze;
        private Vector2 position;

        public Pacman(GameState gameState)
        {
            controller = gameState;

        }
        public Vector2 Position
        {
            get { return new Vector2(position.X, position.Y); }
            set { position = new Vector2(value.X, value.Y); }
        }
        public void Move(Direction dir)
        {
          // jon will code this
        }
        public void CheckCollisions(Vector2 v)
        {
            //check non empty tile collision
            if (this.maze[(int)this.position.X, (int)this.position.Y] != null)
            {
                this.maze[(int)this.position.X, (int)this.position.Y].Collide();
            }
            
       
        }
    }
}
