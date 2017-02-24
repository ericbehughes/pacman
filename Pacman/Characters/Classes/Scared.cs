using Pacman.Characters.Interfaces;
using Pacman.Game.Classes.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Characters.Classes
{
    public class Scared : IGhostState
    {
        private Ghost ghost;
        private Maze maze;

        public Scared(Ghost g, Maze m)
        {

        }

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}
