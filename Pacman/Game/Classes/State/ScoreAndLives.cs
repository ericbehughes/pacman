using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Game.Classes.State
{
    public class ScoreAndLives
    {
        event EventHandler GameOver;
        private event EventHandler deadPacman;
        // go over syntax for events and event handlers
        //private event EventHandler incrementScore(ICollidable ic);
        public ScoreAndLives(GameState gt)
        {

        }

        public int Lives
        {
            get
            {
                return 1;
            }

            set
            {

            }


        }

        


    }
}
