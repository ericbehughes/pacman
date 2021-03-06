﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using static Pacman.Characters.Classes.Ghost;
using System.Collections;

namespace Pacman.Characters.Classes
{
    public class GhostPack : IEnumerable<Ghost>
    {
        private List<Ghost> ghosts;

        /*Centralizes where they're asked to move, collision checks, 
         * reset to starting point and change to scared mode*/
        public GhostPack()
        {
            ghosts = new List<Ghost>();

        }
        // changed ghostpack comment
        
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
                if (g.GhostStateEnum != GhostState.Penned)
                    g.ChangeState(GhostState.Scared);
            }
            // update ghost public scared timer field
            scared.Interval = 9000;
            scared.Enabled = true;
            scared.Elapsed += OnPauseScaredTimer;
        }

        private void OnPauseScaredTimer(object sender, ElapsedEventArgs e)
        {
            Timer t = (Timer)sender;
            t.Enabled = false;
            foreach (var item in ghosts)
            {
                item.ChangeState(GhostState.Chase);
            }
      
        }


        public IEnumerator<Ghost> GetEnumerator()
        {
            return ghosts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ghosts.GetEnumerator();
        }
    }
}
