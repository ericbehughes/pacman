﻿using Microsoft.Xna.Framework;
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
 
    
    public class Maze
    {
        public delegate void PacmanWonEventHandler();
        public event PacmanWonEventHandler PacmanWonEvent;
        private Tile[,] maze;
        private int size;

        public Maze()
        {
            
        }
        public void SetTiles(Tile[,] tiles)
        {
            this.maze = tiles;
            size = maze.GetLength(0);
        }
        // indexers
        public Tile this[int x, int y]
        {
            get { return this.maze[x, y]; }
            set
            {
                if (x < 0 || y < 0)
                    throw new ArgumentException("Cannot access maze element with negative x and y positions");
                if (x >= this.Size || y >= this.Size)
                    throw new ArgumentException("Cannot access maze element with the input x and y positions");

                this.maze[x, y] = value;
            }
        }


        public int Size
        {
            get
            {
                return size;
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


        /* The function will check the tiles to the left, right, down and up from the parameter's position and save them to a list
         * if and only if the tiles are not a wall
         */
        public List<Tile> GetAvailableNeighbours(Vector2 position, Direction direction)
        {

            List<Tile> emptyTiles = new List<Tile>();

            int x = (int)position.X,
                y = (int)position.Y;


            /* check Left  */// // 
            if (!(maze[x, y - 1] is Wall))
                if (direction != Direction.Right)
                    emptyTiles.Add(maze[x, y - 1]);

            /* check Right */ // left
            if (!(maze[x, y + 1] is Wall))
                if (direction != Direction.Left)
                    emptyTiles.Add(maze[x, y + 1]);

            /* Check Up */ // down
            if (!(maze[x - 1, y] is Wall))
                if (direction != Direction.Down)
                    emptyTiles.Add(maze[x - 1, y]);

            /* Check Down */ //up
            if (!(maze[x + 1, y] is Wall))
                if (direction != Direction.Up)
                    emptyTiles.Add(maze[x + 1, y]);

            return emptyTiles;
        }


        protected virtual void OnPacmanWon()
        {
            if (PacmanWonEvent != null)
                PacmanWonEvent();
        }

        public void PacmanWon()
        {
            OnPacmanWon();
        }

        /* The funciton throws an event (PacmanWon()) when all the Path tiles (excluding ghosts)
         * Are empty (have no members)
         */
        public int CheckMembersLeft()
        {
            int members = 0;
            foreach (Tile tile in maze)
            {
                if (tile.Member == null)
                    continue;
                else if (tile.Member is Pellet || tile.Member is Energizer)
                    members++;

            }
            if (members == 0)
                OnPacmanWon();
            return members;
        }

 
    }
}
