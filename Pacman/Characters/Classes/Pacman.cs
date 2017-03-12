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
        private GameState gamestate;
        private Maze maze;
        private Vector2 position;

        public event CollisionEventHandler CollisionEvent;

        /*Told where to move and gets a direction for the objects move method*/
        public Pacman(GameState gs)
        {
            this.gamestate = gs;
            this.maze = this.gamestate.Maze;

        }
        public Vector2 Position
        {
            /* Old
            get { return new Vector2(position.X, position.Y); }
            set { position = new Vector2(value.X, value.Y); }
            */
            get { return new Vector2(position.Y, position.X); }
            set { position = new Vector2(value.Y, value.X); }

        }

        public int Points
        {
            get
            {
                //throw new NotImplementedException();
                return Points;
            }

            set
            {
                if (value == 10 || value == 100 || value == 200)
                    Points = value;
            }
        }

        public void Move(Direction dir)
        {
            int x = (int)this.Position.Y,
                y = (int)this.Position.X;

            switch (dir)
            {
                /* The maze is drawn sideways because vector2(x,y) = array[y,x] (instead of array[x,y])
                 * Either change the way the maze is stored or use this for positions
                 */
                // case Direction.Up:
                case Direction.Left:
                    if (this.Position.Y != 0)
                        //this.Position = new Vector2(this.Position.X, this.Position.Y - 1);
                        //this.Position = new Vector2(x - 1, y);
                        this.Position = new Vector2(y, x - 1);
                    break;

                //   case Direction.Down:
                case Direction.Right:
                    if (this.Position.Y != (maze.Size - 1))
                        //this.Position = new Vector2(this.Position.X, this.Position.Y + 1);
                        //this.Position = new Vector2(x + 1, y);
                        this.Position = new Vector2(y, x + 1);
                    break;

                //  case Direction.Left:
                case Direction.Up:
                    if (this.Position.X != 0)
                        //this.Position = new Vector2(this.Position.X - 1, this.Position.Y);
                        // this.Position = new Vector2(x, y - 1);
                        this.Position = new Vector2(y - 1, x);
                    break;

                //   case Direction.Right:
                case Direction.Down:
                    if (this.Position.X != (maze.Size - 1))
                        //this.Position = new Vector2(this.Position.X + 1, this.Position.Y);
                        //  this.Position = new Vector2(x, y + 1);
                        this.Position = new Vector2(y + 1, x);
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
            CollisionEvent(this);
        }
    }
}
