using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacman.Characters.Classes;
using Pacman.Game.Classes.Map;
using PacManLib;

namespace Pacman.Game.Classes.State
{
    public class GameState
    {


        public GameState Parse(string filecontent)
        {
            //string 2d array to hold the elements from the file text.
            string[,] map = null;
            Tile[,] tileArray = null;

            //Setting GameState Object to hold the state of the game and its properties
            GameState g = new GameState();
            Pen pen = new Pen();
            Maze maze = new Maze();
            GhostPack gpack = new GhostPack();
            Pacman.Characters.Classes.Pacman pacman = new Pacman.Characters.Classes.Pacman(g);

          try
            {
                maze.drawMaze();
            }
            catch (Exception)
            {

               
            }

            return g;
        }
        
        /// <summary>
        /// The GhostPack property gets and sets a GhostPack Object.
        /// The GhostPack object will encapsulates a list of Ghost Objects.
        /// </summary>
        public GhostPack GhostPack
        {
            get;
            private set;
        }
        /// <summary>
        /// The Maze property gets and sets a Maze Object.
        /// </summary>
        public Maze Maze
        {
            get;
            private set;
        }
        /// <summary>
        /// The Pen property gets and sets a Pen Object.
        /// </summary>
        public Pen Pen
        {
            get;
            private set;
        }
        /// <summary>
        /// The Score property gets and sets a ScoreAndLives Object.
        /// </summary>
        public ScoreAndLives Score
        {
            get;
            private set;
        }


    }
}
