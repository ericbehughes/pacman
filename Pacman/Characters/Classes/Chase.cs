using Microsoft.Xna.Framework;
using Pacman.Characters.Interfaces;
using Pacman.Game.Classes.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Characters.Classes
{
    public class Chase : IGhostState
    {
        private Ghost ghost;
        private Maze maze;
        private Pacman pacman;
        private Vector2 target;
        public Chase(Ghost g, Maze m, Pacman p , Vector2 t )
        {
            this.ghost = g;
            this.maze = m;
            this.pacman = p;
            this.target = target;

        }

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}
