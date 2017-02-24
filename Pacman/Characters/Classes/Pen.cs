using Microsoft.Xna.Framework;
using Pacman.Game.Classes.Map;
using Pacman.Game.Classes.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pacman.Characters.Classes
{
    // this class needs alot of work
    public class Pen //: Ghost
    {
        Queue<Ghost> ghosts;
        List<Timer> timers;
        List<Tile> pen;

        // might have to check this might need to be a property that returns list
        public Pen() 
        {
            this.ghosts = new Queue<Ghost>();
            this.timers = new List<Timer>();
            pen = new List<Tile>();
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
