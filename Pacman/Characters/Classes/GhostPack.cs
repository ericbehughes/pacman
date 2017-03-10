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

        public GhostPack()
        {
            ghosts = new List<Ghost>();

        }

        public void CheckCollideGhosts(Vector2 target)
        {
            foreach (var monster in ghosts)
            {
                monster.CheckCollisions(target);
            }
        }

        public void ResetGhosts()
        {
            for (int i = 0; i < ghosts.Count; i++)
                ghosts.ElementAt(i).Reset();
        }

        public void ScareGhosts()
        {
            foreach (Ghost g in ghosts)
            {
                
                if (g.CurrentState == GhostState.Scared)
                    return;

                g.ChangeState(GhostState.Scared);
            }

         
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
    }
}
