using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacman.Characters.Classes;
using Pacman.Game.Classes.Map;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;

namespace Pacman.Game.Classes.State
{
    public class GameState
    {
        public static GameState Parse(string filecontent)
        {
            //Setting GameState Obiect to hold the state of the game and its properties
            GameState g = new GameState();
            Pen pen = new Pen();
            Maze maze = new Maze();
            GhostPack gpack = new GhostPack();
            ScoreAndLives score_lives = new ScoreAndLives(g);
            Characters.Classes.Pacman pacman = new Characters.Classes.Pacman(g);
            g.Pacman = pacman;
            // initializing properties with obiects from above
            g.Maze = maze;
            g.Pen = pen;
            g.GhostPack = gpack;
            g.Score = score_lives;
            g.GhostPack = gpack;

        //    try
       //     {
                drawMaze(g, filecontent);
          
         //   }
      //      catch (Exception e)
        //    {
         //   }

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

        public Characters.Classes.Pacman Pacman
        {
            get;
            private set;
        }

        // understand how pacman is initialized pr ghost or before all ghosts and ignored during ghost build
        private static void drawMaze(GameState g, string fileContent)
        {
            var size = File.ReadLines(@fileContent).Count();
            g.Maze.SetTiles(new Tile[size, size]);
            
            String[,] strMaze = new String[size, size];
            string line = Regex.Replace(File.ReadAllText(@fileContent), @"[\r\n\t]+", ",");
            String[] str = line.Split(',');
            String mazeChar = "";

            int counter = 0;
            for (int j = 0; j < size; j++)
            {
                for (int i = 0; i < size; i++)
                {
                    // mazeChar = str[counter].ToLower(); This gave me a headache 
                    mazeChar = str[counter];
                    // build wall obiect
                    if (mazeChar.Equals("w"))
                    {
                        g.Maze[i, j] = new Wall(i, j);
                    }
                    // build pellet or empty obiect for path
                    else if (mazeChar.Equals("p"))
                    {
                        var pel = new Pellet();
                        pel.CollisionEvent += g.Score.incrementScore;
                        g.Maze[i, j] = new Map.Path(i, j, pel);
                    }
                    else if (mazeChar.Equals("e"))
                    {
                        var e = new Energizer();
                        e.CollisionEvent += g.Score.incrementScore;
                        g.Maze[i, j] = new Map.Path(i, j, e);
                    }
                    // empty path 
                    else if (mazeChar.Equals("m"))
                    {
                        g.Maze[i, j] = new Map.Path(i, j, null);
                    }
                    else if (mazeChar.Equals("1"))
                    {
                        Ghost ghost = new Ghost(g, i, j, new Vector2(i, j), GhostState.Chase, new Characters.Classes.Color());
                        ghost.Pacman = g.Pacman;
                        g.GhostPack.Add(ghost);
                        ghost.CollisionEvent += g.Score.incrementScore;
                        ghost.PacmanDiedEvent += g.Score.deadPacman;
                        g.Maze[i, j] = new Map.Path(i, j, ghost);

                    }

                    else if (mazeChar.Equals("2"))
                    {
                        Ghost ghost = new Ghost(g, i, j, new Vector2(i, j), GhostState.Penned, new Characters.Classes.Color());
                        ghost.Pacman = g.Pacman;
                        g.GhostPack.Add(ghost);
                        g.Pen.AddToPen(ghost);
                        ghost.CollisionEvent += g.Score.incrementScore;
                        ghost.PacmanDiedEvent += g.Score.deadPacman;
                        g.Maze[i, j] = new Map.Path(i, j, ghost);
                        g.Pen.AddTile(g.Maze[i, j]);

                    }

                    else if (mazeChar.Equals("3"))
                    {
                        Ghost ghost = new Ghost(g, i, j, new Vector2(i, j), GhostState.Penned, new Characters.Classes.Color());
                        ghost.Pacman = g.Pacman;
                        g.GhostPack.Add(ghost);
                        g.Pen.AddToPen(ghost);
                        ghost.CollisionEvent += g.Score.incrementScore;
                        ghost.PacmanDiedEvent += g.Score.deadPacman;
                        g.Maze[i, j] = new Map.Path(i, j, ghost);
                        g.Pen.AddTile(g.Maze[i, j]);
                    }

                    else if (mazeChar.Equals("4"))
                    {
                        Ghost ghost = new Ghost(g, i, j, new Vector2(i, j), GhostState.Penned, new Characters.Classes.Color());
                        ghost.Pacman = g.Pacman;
                        g.GhostPack.Add(ghost);
                       g.Pen.AddToPen(ghost);
                        ghost.CollisionEvent += g.Score.incrementScore;
                        ghost.PacmanDiedEvent += g.Score.deadPacman;
                        g.Maze[i, j] = new Map.Path(i, j, ghost);
                        g.Pen.AddTile(g.Maze[i, j]);
                    }
                    // pacman
                    else if (mazeChar.Equals("P"))
                    {
                        g.Maze[i, j] = new Map.Path(i, j, g.Pacman);
                        g.Pacman.Position = new Vector2(i, j);
                 

                    }

                    else if (mazeChar.Equals("x"))
                    {
                        g.Maze[i, j] = new Map.Path(i, j, null);
                        g.Pen.AddTile(g.Maze[i, j]);
                    }

                 
                    counter++;
                }


            }
        } // end of method
    }
}
