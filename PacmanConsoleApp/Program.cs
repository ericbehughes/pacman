using Pacman.Game.Classes.Map;
using Pacman.Game.Classes.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pacman.Characters.Classes;

namespace PacmanConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GameState gameState = GameState.Parse("ghostMap.csv");

            // x and y are switched since business logic uses array logic instead of cartesian
            // row 3 col 1  vector is inverted
            Vector2 target = new Vector2(3, 1);
            GhostState state = GhostState.Chase;
            Pacman.Characters.Classes.Color c = Pacman.Characters.Classes.Color.Red;
            Pacman.Characters.Classes.Ghost ghost = new Pacman.Characters.Classes.Ghost(gameState, 1, 3, target, state, c);
            ghost.Direction = Pacman.Characters.Classes.Direction.Left;
            Console.WriteLine(gameState.Pacman.ToString());


        }
    }
}
