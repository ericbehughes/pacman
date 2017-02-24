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
        //private Target target //???


        public Chase(Ghost g, Maze m, Pacman p /*,Target t */)
        {
            this.ghost = g;
            this.maze = m;
            this.pacman = p;
        }

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}
