﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            for (int i = 0; i < ghosts.Count; i++)
                ghosts.ElementAt(i).ChangeState(
                    ghosts.ElementAt(i).CurrenState);
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
