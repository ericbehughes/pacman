using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static Pacman.Characters.Classes.Ghost;

namespace Pacman.Characters.Classes
{
    public class GhostPack
    {
        private List<Ghost> ghosts;

        /*Centralizes where they're asked to move, collision checks, 
         * reset to starting point and change to scared mode*/
        public GhostPack()
        {
            ghosts = new List<Ghost>();

        }

        public void CheckCollideGhosts(Vector2 target)
        {
            foreach (var g in ghosts)
            {
                g.CheckCollisions(target);
            }
        }

        public void ResetGhosts()
        {
            for (int i = 0; i < ghosts.Count; i++)
                ghosts.ElementAt(i).Reset();
        }

        public void Move()
        {
            for (int i = 0; i < ghosts.Count; i++)
                ghosts.ElementAt(i).Move();
        }

        public void Add(Ghost g)
        {
            ghosts.Add(g);
        }

        public void ScareGhosts()
        {
            foreach (Ghost g in ghosts)
            {
                if (g.CurrentState != GhostState.Scared)
                    g.ChangeState(GhostState.Scared);
            }
            /* go over this timer for scared ghsot
            Ghost.scared = new Timer(6000);
            Ghost.scared.Enabled = true;
            Ghost.scared.Elapsed += OnScareGhostDisable;
            */
        }
    }
}
