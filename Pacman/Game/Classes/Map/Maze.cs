using Microsoft.Xna.Framework;
using Pacman.Characters.Classes;
using Pacman.Characters.Interfaces;
using Pacman.Game.Classes.State;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Pacman.Characters.Classes.Ghost;

namespace Pacman.Game.Classes.Map
{
    public delegate void PacmanWonEventHandler();
    public class Maze
    {

        public delegate bool won();
        private Tile[,] maze;
        private int size;

        public Maze()
        {
          // check what should go in here
        }
        public void SetTiles(Tile[,] tiles)
        {
            this.maze = tiles;
        }


        public event PacmanWonEventHandler PacmanWonEvent;

        // indexers
        public Tile this[int x, int y]
        {
            get
            {
                //needs to be coded
                Tile temp = null;
                return temp;
            }
            set
            {   //needs to be coded as it is 2d array
                
                    maze[x, y] = value;
                
            }
        }


        public int Size
        {
            get
            {
                return this.maze.GetLength(0);
            }

            set
            {
                if (size >= 0)
                {
                    // also needs to be coded
                    size = value;
                }
            }
        }

        public List<Tile> GetAvailableNeighbours(Vector2 position, Direction Direction)
        {

            List<Tile> EmptyTiles = new List<Tile>(),
                       tilesLeft = new List<Tile>(),
                       tilesDown = new List<Tile>(),
                       tilesRight = new List<Tile>(),
                       tilesUp = new List<Tile>();

            int x = (int)position.X,
                y = (int)position.Y;

            for (int i = 1; i <= 10; i++)
            {
                if (i <= 5)
                {
                    if (!(maze[x - i, y] is Wall))
                        tilesLeft.Add(maze[x - i, y]);

                    if (!(maze[x, y - i] is Wall))
                        tilesUp.Add(maze[x, y - i]);
                }

                if (i >= 6)
                {
                    if (!(maze[x + (i - 5), y] is Wall))
                        tilesRight.Add(maze[x + (i - 5), y]);

                    if (!(maze[x, y + (i - 5)] is Wall))
                        tilesDown.Add(maze[x, y + (i - 5)]);
                }
            }

            switch (Direction)
            {
                case Direction.Left:
                    EmptyTiles = tilesLeft;
                    break;
                case Direction.Down:
                    EmptyTiles = tilesDown;
                    break;

                case Direction.Right:
                    EmptyTiles = tilesRight;
                    break;

                case Direction.Up:
                    EmptyTiles = tilesUp;
                    break;

            }

            return EmptyTiles;

        }

        protected virtual void PacmanWon()
        {
            if (PacmanWonEvent != null)
                PacmanWonEvent();
        }


        public void CheckMembersLeft()
        {
            int count = 0;
            foreach (Tile item in this.maze)
            {
                if (item is Path /*item.IsEmpty() == false*/)
                {
                    count++;
                }
            }

            if (count == 0)
            {
                PacmanWon();
            }
        }

        

      

    }
}
