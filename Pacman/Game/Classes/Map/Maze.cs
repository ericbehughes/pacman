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
    public class Maze
    {

        public delegate bool won();
        private Tile[,] maze;
        public event won PacmanWon;
        private int size;

        public Maze()
        {
            drawMaze();
        }
        public void SetTiles(Tile[,] tiles)
        {
            this.maze = tiles;
        }


        /* notes on events 
         * 
         * Events are user actions such as key press, clicks, mouse movements, etc., or some occurrence such as system
         *  generated notifications. Applications need to respond to events when they occur. For example, interrupts. 
         *  Events are used for inter-process communication.

            Using Delegates with Events
            The events are declared and raised in a class and associated with the event handlers using delegates within the same
            class or some other class. The class containing the event is used to publish the event. This is called the publisher class.
            Some other class that accepts this event is called the subscriber class. Events use the publisher-subscriber model.

            A publisher is an object that contains the definition of the event and the delegate. The event-delegate association is 
            also defined in this object. A publisher class object invokes the event and it is notified to other objects.

            A subscriber is an object that accepts the event and provides an event handler. The delegate in the publisher class 
            invokes the method (event handler) of the subscriber class.
         * 
         * 
         * 
         * events
         * */

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
                        EmptyTiles.Add(maze[1, 1]);
                    }
                    break;
                case Direction.Up:
                    if (maze[x, y - 1] is Wall)
                    {
                        EmptyTiles.Add(maze[1, 1]);
                    }
                    break;
                case Direction.Left:
                    if (maze[(int)(position.Y + 1), (int)position.X] != maze[1, 1])
                    {
                        EmptyTiles.Add(maze[1, 1]);
                    }
                    break;
                case Direction.Right:
                    if (maze[(int)((position.Y + 1)), (int)position.X] != maze[1, 1])
                    {
                        EmptyTiles.Add(maze[1, 1]);
                    }
                    break;
            }
            return EmptyTiles;

        }
            
              
        public void CheckMembersLeft()
        {

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
