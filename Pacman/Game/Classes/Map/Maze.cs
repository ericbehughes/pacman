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

        public void drawMaze()
        {
            size = File.ReadLines(@"level.txt").Count();
            this.maze = new Tile[size, size];
            String[,] strMaze = new String[size, size];
            string line = Regex.Replace(File.ReadAllText(@"level.txt"), @"[\r\n\t]+", ",");
            String[] str = line.Split(',');
            String mazeChar = "";
            Pacman.Characters.Classes.Pacman pacman = new Pacman.Characters.Classes.Pacman(new GameState());
            int counter = 0;
                for (int i = 0; i < size ; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    mazeChar = str[counter].ToLower();
                    // build wall object
                    if (mazeChar.Equals("w"))
                    {
                        Wall tile = new Wall(i, j);

                        maze[i, j] = tile;

                    }
                    // build pellet or empty object for path
                    else if (mazeChar.Equals("p"))
                    {
                        Path tile = new Path(i, j, new Pellet());
                        maze[i, j] = tile;
                    }
                    else if (mazeChar.Equals("e"))
                    {
                        Path tile = new Path(i, j, new Energizer());
                        maze[i, j] = tile;
                    }
                    // empty path 
                    else if (mazeChar.Equals("m"))
                    {
                        Path tile = new Path(i, j, null);
                        maze[i, j] = tile;
                    }
                    else if (mazeChar.Equals("1"))
                    {
                        Ghost ghost = new Ghost(new GameState(),10, 11, new Vector2(8,11), Ghost.GhostState.Released ,new Characters.Classes.Color());
                        Path tile = new Path(10, 11, ghost);
                        maze[i, j] = tile;
                    }

                    else if (mazeChar.Equals("2"))
                    {
                        Ghost ghost = new Ghost(new GameState(), 10, 10, new Vector2(10, 10), Ghost.GhostState.Penned, new Characters.Classes.Color());
                        Path tile = new Path(10, 11, ghost);
                        maze[i, j] = tile;
                    }

                    else if (mazeChar.Equals("3"))
                    {
                        Ghost ghost = new Ghost(new GameState(), 10, 11, new Vector2(10, 11), Ghost.GhostState.Penned, new Characters.Classes.Color());
                        Path tile = new Path(10, 11, ghost);
                        maze[i, j] = tile;
                    }

                    else if (mazeChar.Equals("4"))
                    {
                        Ghost ghost = new Ghost(new GameState(), 10, 12, new Vector2(10, 12), Ghost.GhostState.Penned, new Characters.Classes.Color());
                        Path tile = new Path(10, 11, ghost);
                        maze[i, j] = tile;
                    }

                    else if (mazeChar.Equals("P"))
                    {
                        Pacman.Characters.Classes.Pacman pacman = new Pacman.Characters.Classes.Pacman(new GameState());
                        Path tile = new Path(10, 11, ghost);
                        maze[i, j] = tile;
                    }
                    counter++;
                }
                    
                
            }

      

        }

      

    }
}
