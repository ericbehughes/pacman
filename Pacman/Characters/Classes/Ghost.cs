using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pacman.Game.Classes.Map;
using Pacman.Characters.Interfaces;
using System.Timers;
using Pacman.Game.Classes.State;

namespace Pacman.Characters.Classes
{
    public delegate void PacmanDiedEventHandler();
    public class Ghost : IGhostState, IMovable, ICollidable
    {

        private Pacman pacman;
        private Vector2 target;
        private Vector2 position;
        private Pen pen;
        private Maze maze;
        public static Timer scared;
        public static Vector2 ReleasePosition;
        public event CollisionEventHandler CollisionEvent;
        public event PacmanDiedEventHandler PacmanDiedEvent;


        public delegate void Collision(ICollidable obj);

        public Ghost(GameState g, int x, int y, Vector2 target, GhostState start, Color colour)
        {
            this.Position = new Vector2(x, y);
            this.maze = g.Maze;
            Console.WriteLine(g.Pacman);
            this.pacman = g.Pacman;
            this.pen = g.Pen;
            Random r = new Random();
            var enums = Enum.GetValues(typeof(Direction));
            var enumchosen = enums.GetValue(r.Next(0, 3));
            Direction = (Direction)enumchosen;
            this.target = target;
            ChangeState(start);
            
            this.Color = colour;
        }

        // need to check how this works its an enum in the class diagram
        public IGhostState CurrenState { get; private set; }

        public Color Color { get; }

        public Direction Direction { get; set; }

        public Vector2 Position
        {
            get { return this.position; }

            set
            {
                var pos = value;
                if (pos.X < 0 || pos.Y < 0)
                    throw new ArgumentException("The X and Y position of a ghost must not be negative");
                this.position = pos;
            }

        }


        public int Points { get { return 200; }  set { } }

        public void Move()
        {
            if (this.CurrenState != null)
             this.CurrenState.Move();
            CheckCollisions(this.pacman.Position);
        }

        public void CheckCollisions(Vector2 target)
        {
            if (this.Position == target)
            {
                Collide();
            }
        }

        public void Collide()
        {
            if (this.CurrentState == GhostState.Scared)
            {
                OnCollisionEvent(this);
                pen.AddToPen(this);
            }
            else if (this.CurrentState == GhostState.Chase)
            {
                PacmanDiedEvent?.Invoke();
            }
        }

        public virtual void OnCollisionEvent(ICollidable m)
        {
            if (CollisionEvent != null)
                CollisionEvent(m);
        }

        public GhostState CurrentState
        {
            get
            {
                if (this.CurrenState is Scared)
                    return GhostState.Scared;

                return GhostState.Chase;
            }
            set { }
        }

        public Pacman Pacman
        {
            get; set;
        }


        public void Reset()
        {
           
            this.pen.AddToPen(this);
        }

        public void ChangeState(GhostState g)
        {
            switch (g)
            {
                case GhostState.Scared:
                    this.CurrenState = new Scared(this, this.maze);
                    break;
                case GhostState.Chase:
                    this.CurrenState = new Chase(this, this.maze, this.pacman, this.pacman.Position);
                    break;
                case GhostState.Released:
                    this.Position = new Vector2(11, 9); // default release position in front of pen
                    this.CurrenState = new Chase(this, this.maze, this.pacman, this.target);
                    break;
                default:
                    this.CurrenState = null;
                    break;
            }
        }




    }

}
