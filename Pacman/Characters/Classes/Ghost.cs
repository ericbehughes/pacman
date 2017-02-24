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

namespace Pacman.Characters.Classes
{
    public class Ghost : IGhostState, IMovable, ICollidable
    {
        public enum GhostState
        {
            Scared,
            Chase
        };
        private Pacman pacman;
        private Vector2 target;
        private Pen pen;
        private Maze maze;
        //private Direction direction;
        private Color colour;
        private IGhostState currentState;
        private Timer scared;

        public Vector2 Direction
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

        public Vector2 Position
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

        public Ghost() { }
        // need to figure out where gamestate is

        public Ghost(GameState gamestate, int x, int y, Vector2 t, GhostState ghostState)
        {

        }

        event EventHandler PacmanDied;
        event EventHandler Collision;
        public event EventHandler Collisiion;

        /*
public GhostState CurrentState
{
get
{
if (currentState is Scared)
return GhostState.Scared;
else if (currentState is Chase)
return GhostState.Chase;
else
return 0;  // have to check this
}
set
{
if (currentState != null)
if (value is Scared)
currentState(GhostState) = value;
}
}
*/

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Collide()
        {
            throw new NotImplementedException();
        }
    }

}
