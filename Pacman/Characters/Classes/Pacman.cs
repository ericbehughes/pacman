using Microsoft.Xna.Framework;
using Pacman.Characters.Interfaces;
using Pacman.Game.Classes.Map;
using Pacman.Game.Classes.State;
using System;

namespace Pacman.Characters.Classes
{
    public class Pacman
    {
        private GameState gamestate;
        private Maze maze;

        /*Told where to move and gets a direction for the objects move method*/
        public Pacman(GameState gs)
        {
            this.gamestate = gs;
            this.maze = gamestate.Maze;
        }

        public Vector2 Position { get; set; }
       
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
            int x = (int)this.Position.X,
                y = (int)this.Position.Y;
            switch (dir)
            {
                /* The maze is drawn sideways because vector2(x,y) = array[y,x] (instead of array[x,y])
                 * Either change the way the maze is stored or use this for positions
                 */
                // case Direction.Up:
                case Direction.Up:
                    if (CanEnter(new Vector2(x - 1, y), Direction.Left))
                        this.Position = new Vector2(x - 1, y);
                    break;

                //   case Direction.Down:
                case Direction.Down:
                    if (CanEnter(new Vector2(x + 1, y), Direction.Down))
                        this.Position = new Vector2(x + 1, y);
                    break;

                //  case Direction.Left:
                case Direction.Left:
                    if (CanEnter(new Vector2(x, y - 1), Direction.Left))
                        this.Position = new Vector2(x, y - 1);
                    break;

                //   case Direction.Right:
                case Direction.Right:
                    if (CanEnter(new Vector2(x, y + 1), Direction.Right))
                        this.Position = new Vector2(x, y + 1);
                    break;
            }

            CheckCollisions();
            gamestate.Maze.CheckMembersLeft();
        }

        public Boolean CanEnter(Vector2 position, Direction dir)
        {
            var freeTiles = gamestate.Maze.GetAvailableNeighbours(Position, dir);
            foreach (Tile tile in freeTiles)
            {
                if ((tile.Position.X == position.X) && (tile.Position.Y == position.Y))
                    return true;
            }
            return false;

        }

        public void CheckCollisions()
        {
            gamestate.GhostPack.CheckCollideGhosts(Position);
            gamestate.Maze[(int)this.Position.X, (int)this.Position.Y].Collide();

        }
    }
}
