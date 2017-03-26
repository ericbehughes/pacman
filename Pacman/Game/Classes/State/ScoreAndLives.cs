using Pacman.Characters.Interfaces;
using Pacman.Game.Classes.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Characters.Classes
{

    public delegate void GameOverHandler();
    public class ScoreAndLives
    {
        public event GameOverHandler GameOverEvent;
        private GameState gamestate;
        private int lives = 3;
        private int score;
        public ScoreAndLives(GameState gs)
        {
            this.gamestate = gs;
            //gamestate.Maze.PacmanWonEvent += GameOver;
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
               this.gamestate.GhostPack.ResetGhosts();
                
            }
        }

        public void incrementScore(ICollidable m)
        {
            this.score += m.Points; //increment score
            this.gamestate.Maze.CheckMembersLeft(); 
            // check if member is an energizer and scare ghosts
            if (m is Energizer)
            {
                this.gamestate.GhostPack.ScareGhosts();
                //m = new Energizer(gamestate.GhostPack);
            }
        }
    }
    }
