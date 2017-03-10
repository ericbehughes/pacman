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

            List<Tile> emptyTiles = new List<Tile>();

            int x = (int)position.X,
                y = (int)position.Y;

            /* Check left */
            if (!(maze[x - 1, y] is Wall))
                if (Direction != Direction.Left)
                    emptyTiles.Add(maze[x - 1, y]);

            /* check right */
            if (!(maze[x - 1, y] is Wall))
                if (Direction != Direction.Right)
                    emptyTiles.Add(maze[x + 1, y]);

            /* Check up */
            if (!(maze[x, y - 1] is Wall))
                if (Direction != Direction.Up)
                    emptyTiles.Add(maze[x, y - 1]);

            /* Check down */
            if (!(maze[x, y] is Wall))
                if (Direction != Direction.Down)
                    emptyTiles.Add(maze[x, y + 1]);

            return emptyTiles;

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
                if (item.Member == null)
                {
                    count++;
                }
            }

            if (count == MemberCount())
            {
                PacmanWon();
            }
        }

        public int MemberCount()
        {
            int members = 0;
            foreach (Tile tile in maze){
                if (tile.Member == null || tile.Member is Pellet || tile.Member is Energizer)
                    members++;
            }
            return members;
        }
    }
}
