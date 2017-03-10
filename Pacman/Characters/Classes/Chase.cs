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
            this.target = t;

        }


        /* During Chase mode, each ghost has a different target location, which can be expressed as a Vector2. 
         * For example, a target of (0, 2), means the ghost will try to get to the tile that has the same x-coordinate 
         * but is two tiles below. The ghost chooses from all the available tiles from his location (except the tile where he 
         * just was) – the choice is based on the tile which is closest to the target coordinates. The Vector2 struct has a static 
         * method: Vector2.Distance(vectorA, vectorB) that returns a float. Use this to find the closest Tile.
         */
        public void Move()
        {
            Pacman pacman = ghost.Pacman;
            float currentDistance = 0;
            Vector2 currentPos = ghost.Position;
            Direction currentDir = ghost.Direction;

        }
    }
}
