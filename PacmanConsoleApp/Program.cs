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
            for (int i = 0; i < maze.Size; i++)
            {
                for (int j = 0; j < maze.Size; j++)
                {
                    
                }
            }
        }
    }
}
