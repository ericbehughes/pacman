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

        /*The chase object chooses the neighbor whos distance to the target is the smallest*/
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

            Direction ghostDir = ghost.Direction;
            Vector2 temp;
            float shortestDistance = Vector2.Distance(target, ghost.Position);
            List<Tile> freeTiles = maze.GetAvailableNeighbours(ghost.Position, ghostDir);
            int index = 0, counter = 0;
            foreach (Tile tile in freeTiles){
                if (Vector2.Distance(target, tile.Position) < shortestDistance)
                {
                    index = counter;
                    shortestDistance = Vector2.Distance(target, tile.Position);
                }
                counter++;
            }

            temp = freeTiles.ElementAt((int)index).Position;
            if ((int)temp.X != (int)ghost.Position.X) {
                if ((int)temp.X < (int)ghost.Position.X)
                {
                    ghost.Position = temp;
                    ghost.Direction = Direction.Up;
                }

                else if ((int)temp.X > (int)ghost.Position.X)
                {
                    ghost.Position = temp;
                    ghost.Direction = Direction.Down;
                }
            }

            else if ((int)temp.Y != (int)ghost.Position.Y)
            {
                if (temp.Y < ghost.Position.Y)
                {
                    ghost.Position = temp;
                    ghost.Direction = Direction.Left;
                }

                else if (temp.Y > ghost.Position.Y)
                {
                    ghost.Position = temp;
                    ghost.Direction = Direction.Right;
                }
            }
        }
    }
}
