using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Game.Classes.Map
{
    public class Maze
    {
        private Tile[,] maze;

        public void SetTiles(Tile[,] maze) // is this method void?
        {
            
        }

        public delegate string MyDel(string str);
        event MyDel PacmanWon;
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

        public List<Tile> GetAvailableNeighbours(Vector2 position, Vector2 Direction)
        {
            return null;
        }

        public void CheckMembersLeft()
        {

        }

    }
}
