using Pacman.Game.Classes.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Maze maze = new Maze();
            maze.drawMaze();
            Console.WriteLine(maze.Size);
        }
    }
}
