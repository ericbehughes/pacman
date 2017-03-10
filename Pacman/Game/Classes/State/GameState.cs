using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacman.Characters.Classes;
using Pacman.Game.Classes.Map;
using PacManLib;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using static Pacman.Characters.Classes.Ghost;

namespace Pacman.Game.Classes.State
{
    public class GameState
    {
        public GameState Parse(string filecontent)
        {
            //Setting GameState Object to hold the state of the game and its properties
            GameState g = new GameState();
            Pen pen = new Pen();
            Maze maze = new Maze();
            GhostPack gpack = new GhostPack();
            ScoreAndLives score_lives = new ScoreAndLives(g);
            Pacman.Characters.Classes.Pacman pacman = new Pacman.Characters.Classes.Pacman(g);

            // initializing properties with objects from above
            g.Maze = maze;
            g.Pen = pen;
            g.GhostPack = gpack;
            g.Score = score_lives;
            g.GhostPack = gpack;

          try
            {
             drawMaze(g);
            }
            catch (Exception)
            {
            }

            return g;
        }
        
        public GhostPack GhostPack
        {
            get;
            private set;
        }
 
        public Maze Maze
        {
            get;
            private set;
        }
   
        public Pen Pen
        {
            get;
            private set;
        }

        public ScoreAndLives Score
        {
            get;
            private set;
        }

        // understand how pacman is initialized pr ghost or before all ghosts and ignored during ghost build
        private static void drawMaze(GameState g)
        {
            var size = File.ReadLines(@"level.txt").Count();
            g.Maze.SetTiles(new Tile[size, size]);
            String[,] strMaze = new String[size, size];
            string line = Regex.Replace(File.ReadAllText(@"level.txt"), @"[\r\n\t]+", ",");
            String[] str = line.Split(',');
            String mazeChar = "";
            Pacman.Characters.Classes.Pacman pacman = new Pacman.Characters.Classes.Pacman(new GameState());
            int counter = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    mazeChar = str[counter].ToLower();
                    // build wall object
                    if (mazeChar.Equals("w"))
                    {
                        Wall tile = new Wall(i, j);
                        g.Maze[i, j] = tile;

                    }
                    // build pellet or empty object for path
                    else if (mazeChar.Equals("p"))
                    {
                        Map.Path tile = new Map.Path(i, j, new Pellet());
                        g.Maze[i, j] = tile;
                    }
                    else if (mazeChar.Equals("e"))
                    {
                        Map.Path tile = new Map.Path(i, j, new Energizer());
                        g.Maze[i, j] = tile;
                    }
                    // empty path 
                    else if (mazeChar.Equals("m"))
                    {
                        Map.Path tile = new Map.Path(i, j, null);
                        g.Maze[i, j] = tile;
                    }
                    else if (mazeChar.Equals("1"))
                    {
                        Ghost ghost = new Ghost(new GameState(), 10, 11, new Vector2(8, 11), GhostState.Penned, new Characters.Classes.Color());
                        ghost.Pacman = pacman;
                        g.GhostPack.Add(ghost);
                        ghost.CollisionEvent += g.Score.incrementScore;
                        ghost.PacmanDiedEvent += g.Score.deadPacman;
                        // all the events 
                        //  ghost.CollisionEvent += 
                        Map.Path tile = new Map.Path(10, 11, ghost);
                        g.Maze[i, j] = tile;
                    }

                    else if (mazeChar.Equals("2"))
                    {
                        Ghost ghost = new Ghost(new GameState(), 10, 10, new Vector2(10, 10), GhostState.Penned, new Characters.Classes.Color());
                        ghost.Pacman = pacman;
                        g.GhostPack.Add(ghost);
                        g.Pen.AddToPen(ghost);
                        ghost.CollisionEvent += g.Score.incrementScore;
                        ghost.PacmanDiedEvent += g.Score.deadPacman;
                        Map.Path tile = new Map.Path(10, 11, ghost);
                        g.Maze[i, j] = tile;
                    }

                    else if (mazeChar.Equals("3"))
                    {
                        Ghost ghost = new Ghost(new GameState(), 10, 11, new Vector2(10, 11), GhostState.Penned, new Characters.Classes.Color());
                        ghost.Pacman = pacman;
                        g.GhostPack.Add(ghost);
                        g.Pen.AddToPen(ghost);
                        ghost.CollisionEvent += g.Score.incrementScore;
                        ghost.PacmanDiedEvent += g.Score.deadPacman;
                        Map.Path tile = new Map.Path(10, 11, ghost);
                        g.Maze[i, j] = tile;
                    }

                    else if (mazeChar.Equals("4"))
                    {
                        Ghost ghost = new Ghost(new GameState(), 10, 12, new Vector2(10, 12), Ghost.GhostState.Penned, new Characters.Classes.Color());
                        ghost.Pacman = pacman;
                        g.GhostPack.Add(ghost);
                        g.Pen.AddToPen(ghost);
                        ghost.CollisionEvent += g.Score.incrementScore;
                        ghost.PacmanDiedEvent += g.Score.deadPacman;
                        Map.Path tile = new Map.Path(10, 11, ghost);
                        g.Maze[i, j] = tile;
                    }

                    else if (mazeChar.Equals("P"))
                    {

                        Map.Path tile = new Map.Path(10, 11, null);
                        g.Maze[i, j] = tile;
                    }
                    counter++;
                }


            }



        }


    }
}
