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

            List<Tile> EmptyTiles = new List<Tile>();
            string positionx = "" + position.X;
            int x = Int32.Parse(positionx);
            string positiony = "" + position.Y;
            int y = Int32.Parse(positiony);

            switch (Direction)
            {
                case Direction.Down:
                    if (!(maze[x, y + 1] is Wall))
                    {
                        EmptyTiles.Add(maze[x, y + 1]);
                    }
                    break;

                case Direction.Up:
                    if (!(maze[x, y - 1] is Wall))
                    {
                        EmptyTiles.Add(maze[x, y - 1]);
                    }
                    break;
                    
                case Direction.Left:
                    Tile testTileLeft = maze[(int)(position.Y + 1), (int)position.X];

                    if (testTileLeft != maze[0, 0] && !(testTileLeft is Wall))
                    {
                        EmptyTiles.Add(testTileLeft);
                    }
                    break;

                case Direction.Right:
                    Tile testTileRight = maze[(int)((position.Y + 1)), (int)position.X];
                    if (!(testTileRight is Wall))
                    {
                        EmptyTiles.Add(maze[(int)((position.Y + 1)), (int)position.X]);
                    }
                    break;
            }



            /*
            switch (Direction)
            {
                case Direction.Down:
                    if (!(maze[x, y + 1] is Wall))
                    {
                        EmptyTiles.Add(maze[x, y + 1]);
                    }
                    break;
                case Direction.Up:
                    if (!(maze[x, y - 1] is Wall))
                    {
                        EmptyTiles.Add(maze[x, y - 1]);
                    }
                    break;
                case Direction.Left:
                    if (maze[(int)(position.Y + 1), (int)position.X] != maze[0, 0])
                    {
                        EmptyTiles.Add(maze[(int)(position.Y + 1), (int)position.X]);
                    }
                    break;
                case Direction.Right:
                    if (maze[(int)((position.Y + 1)), (int)position.X] != maze[0, 0])
                    {
                        EmptyTiles.Add(maze[(int)((position.Y + 1)), (int)position.X]);
                    }
                    break;
            }
            */
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
