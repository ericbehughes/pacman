using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Game.Classes.Map
{
    public class Maze
    {

        public delegate bool won();
        private Tile[,] maze;
        public event won PacmanWon;
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
        public Tile this[int index]
        {
            get
            {
                //needs to be coded
                Tile temp = null;
                return temp;
            }
            set
            {   //needs to be coded as it is 2d array
                if (index >= 0 && index <= maze.Length- 1)
                {
                    maze[index, index] = value;
                }
            }
        }


        public int Size
        {
            get
            {
                return maze.Length;
            }

            set
            {
                if (maze.Length >= 0)
                {
                    // also needs to be coded
                    maze = new Tile[value, value];
                }
            }
        }
        /*
        public List<Tile> GetAvailableNeighbours(Vector2 position, Vector2 Direction)
        {
            
            List<Tile> available_tiles = new List<Tile>();
            string positionx = "" + position.X;
            int x = Int32.Parse(positionx);
            string positiony = "" + position.Y;
            int y = Int32.Parse(positiony);
            switch (dir)
            {
                case Direction.Down:
                    if (!(maze[x, y + 1].Member() is Wall))
                    {
                        available_tiles.Add(maze[1, 1]);
                    }
                    break;
                case Direction.Up:
                    if (maze[x, y - 1].Member() is Wall)
                    {
                        available_tiles.Add(maze[1, 1]);
                    }
                    break;
                case Direction.Left:
                    /* if (maze[(int)(position.Y + 1), position.X] != maze[1, 1])
                     {
                         available_tiles.Add(maze[1, 1]);
                     } 
                    break;
                case Direction.Right:
                    /* if (maze[(int)(position.Y + 1), position.X] != maze[1, 1])
                     {
                         available_tiles.Add(maze[1, 1]);
                     } 
                    break;
            }
            return available_tiles;
          
            */
              
        public void CheckMembersLeft()
        {

        }

        public void drawMaze()
        {
            var lineCount = File.ReadLines(@"Maze\levels.txt").Count();
            Console.WriteLine("Line number: " + lineCount);
        }

    }
}
