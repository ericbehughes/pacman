using Pacman.Characters.Interfaces;
using Pacman.Game.Classes.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace Pacman.Characters.Classes
{
    public class Scared : IGhostState
    {
        private Ghost ghost;
        private Maze maze;
        /*The scared object chooses randomly among the neighbors return by the mazes getAvailableNeighbors() method*/
        public Scared(Ghost ghost, Maze maze)
        {
            //change direction - make a 180 degree turn
            switch (ghost.Direction)
            {
                case Direction.Up:
                    ghost.Direction = Direction.Down;
                    break;
                case Direction.Down:
                    ghost.Direction = Direction.Up;
                    break;
                case Direction.Right:
                    ghost.Direction = Direction.Left;
                    break;
                case Direction.Left:
                    ghost.Direction = Direction.Right;
                    break;
            }
            this.ghost = ghost;
            this.maze = maze;
        }
        public void Move()
        {
            ghost.ChangeState(GhostState.Scared);
            Tile current = maze[(int)ghost.Position.Y, (int)ghost.Position.X];
            List<Tile> places = maze.GetAvailableNeighbours(ghost.Position, ghost.Direction);
            int num = places.Count;
            if (num == 0)
                throw new Exception("Nowhere to go");

            Random rand = new Random();
            int choice = rand.Next(num);
            //determine direction
            if (places[choice].Position.X == ghost.Position.X + 1)
                ghost.Direction = Direction.Right;
            else if (places[choice].Position.X == ghost.Position.X - 1)
                ghost.Direction = Direction.Left;
            else if (places[choice].Position.Y == ghost.Position.Y - 1)
                ghost.Direction = Direction.Up;
            else
                ghost.Direction = Direction.Down;
            ghost.Position = places[choice].Position;
        }
    }
}
