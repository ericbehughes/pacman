 using Microsoft.Xna.Framework;
using Pacman.Characters.Classes;
using Pacman.Game.Classes.State;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
            drawMaze();
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
                    if (maze[x, y - 1] is Wall)
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

        public void drawMaze()
        {
            size = File.ReadLines(@"level.txt").Count();
            this.maze = new Tile[size, size];
            String[,] strMaze = new String[size, size];
            string line = Regex.Replace(File.ReadAllText(@"level.txt"), @"[\r\n\t]+", ",");
               
                String[] str = line.Split(',');
            int counter = 0;
                for (int i = 0; i < size ; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    // build wall object
                    if (str[counter].ToLower().Equals("w"))
                    {
                        Wall tile = new Wall(i, j);

                        maze[i, j] = tile;

                    }
                    // build pellet or empty object for path
                    else if (str[counter].ToLower().Equals("p"))
                    {
                        Path tile = new Path(i, j, new Pellet());
                        maze[i, j] = tile;
                    }
                    else if (str[counter].ToLower().Equals("e"))
                    {
                        Path tile = new Path(i, j, new Energizer());
                        maze[i, j] = tile;
                    }
                    // empty path 
                    else if (str[counter].ToLower().Equals("m"))
                    {
                        Path tile = new Path(i, j, null);
                        maze[i, j] = tile;
                    }
                    counter++;
                }
                    
                
            }

      

        }

      

    }
}
