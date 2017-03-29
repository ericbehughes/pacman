using Pacman.Characters.Interfaces;
using Pacman.Game.Classes.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Pacman.Characters.Classes
{

    public delegate void GameOverHandler();
    public class ScoreAndLives
    {
        public event GameOverHandler GameOverEvent;
        private GameState gamestate;
        private int lives = 1;
        private int score;
        private Timer timer = new Timer(1000);
        public ScoreAndLives(GameState gs)
        {
            this.gamestate = gs;
        }

        public int Lives
        {
            get { return this.lives; }
            set { this.lives = value; }  // might need validation here
        }

       
        public int Score
        {
            get { return this.score; }
            set { this.score = value; }
        }

        protected virtual void OnGameOver()
        {
            GameOverEvent();
        }

        public void DeadPacman()
        {
            this.lives--;
            if (lives <= 0)
            {
                // if this GameOver event is not null then call OnGameOver() 
                // helper method which invokes GameOver event pointing to incrementscore method
                if (GameOverEvent != null)
                    OnGameOver();
            }
            else
            {
                var ghosts = gamestate.GhostPack;
                for (int i = 0; i < ghosts.Count(); i++)
                    if (ghosts.ElementAt(i).Position == ghosts.ElementAt(i).Pacman.Position)
                    {
                        ghosts.ElementAt(i).Reset();
                        gamestate.Pacman.Position = new Microsoft.Xna.Framework.Vector2(11, 17);
                    }
            }
        }

        public void incrementScore(ICollidable m)
        {
            this.score += m.Points; //increment score
            //this.gamestate.Maze.CheckMembersLeft(); 
            // check if member is an energizer and scare ghosts
            if (m is Energizer)
            {
                this.gamestate.GhostPack.ScareGhosts();
                //m = new Energizer(gamestate.GhostPack);
            }
            else if (m is Ghost)
            {
                ((Ghost)m).Reset();
            }
        }

        public void EndGame()
        {
            timer.Enabled = true;
            timer.Elapsed += (o, e) => gamestate = GameState.Parse("map.csv");
        }
   

    }
    }
