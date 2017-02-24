using Pacman.Game.Classes.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pacman.Characters.Classes
{
    public class Pen
    {
        Queue<Ghost> ghosts;
        List<Timer> timers;
        List<Tile> pen;

        // might have to check this might need to be a property that returns list
        public Pen(Queue<Ghost> ghosts)
        {
            this.ghosts = ghosts;
        }
        /*
        public AddTime(Tile tile)
        {
          have to check this too it says tile and not time as paramater ask tomorrow  
        }
        */

        public void AddToPen(Ghost ghost)
        {
            
        }
    }
}
