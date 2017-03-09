using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pacman.Game.Classes.Map;
using Pacman.Characters.Interfaces;
using System.Threading;
using Pacman.Game.Classes.State;
using PacManLib;

namespace Pacman.Characters.Classes
{
    public delegate void PacmanDiedEventHandler();
    public class Ghost : IGhostState, IMovable, ICollidable
    {
        public enum GhostState
        {
            Scared,
            Chase,
            Penned,
            Released
        };

        private Pacman pacman;
        private Vector2 target;
        private Pen pen;
        private Maze maze;
        private Direction direction;
        private Color colour;
        private IGhostState currentState;

        public static Timer scared;
        public static Vector2 ReleasePosition;
        public event CollisionEventHandler CollisionEvent; //event to encapsulate collision event
        public event PacmanDiedEventHandler PacmanDiedEvent; //event encapsulating pacman died event


        public delegate void Collision(ICollidable obj);

       

     
        public Ghost(GameState g, int x, int y, Vector2 target, IGhostState start, Color colour)
        {
            pacman = new Pacman(g);
            maze = new Maze();
            direction = new Direction();
            this.target = new Vector2(target.X, target.Y);
            currentState = start;
            this.colour = colour;
        }

  // need to check how this works its an enum in the class diagram
        public IGhostState CurrenState
        {
            get { return currentState; }
        }

        public Color Color
        {
            get { return colour; }
        }

        public Direction Direction
        {
            get { return direction; }

            set { direction = value; }
        }

        public Vector2 Position
        {
            get { return new Vector2(target.X, target.Y); }

            set { target = new Vector2(value.X, value.Y); }
        }

        public int Points
        {
            get { return 100; }

            set { }
        }

       // need direction here

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Collide()
        {
            if (this.CurrentState == GhostState.Scared)
            {
                CollisionEvent(this); //raise collision event to increment score of pacman
                this.pen.AddToPen(this); //add ghost back to pen 
            }
            if (this.CurrentState == GhostState.Chase)
            {
                PacmanDiedEvent(); //raise pacman died event
            }
        }

        public GhostState CurrentState
        {
            get
            {
                if (this.currentState is Scared)
                    return GhostState.Scared;

                return GhostState.Chase;
            }
        }


        public void Reset()
        {

        }

        public void ChangeState(IGhostState state)
        {
            if (state is Chase)
            {

            }
            else if (state is Scared)
            {
                //timer
            }
        }

        public void CheckCollisions(Vector2 target)
        {
            if (this.Position == target)
            {
                Collide();
            }
        }

    }

}
