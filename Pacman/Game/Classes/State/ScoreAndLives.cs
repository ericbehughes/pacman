using Pacman.Characters.Interfaces;
using Pacman.Game.Classes.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Characters.Classes
{
    // game over delegate over these 2
    
    public delegate void GameOverHandler();
    public class ScoreAndLives
    {
        private GameState gamestate;
        public event GameOverHandler GameOver;
        private int lives;
        private int score;
        public ScoreAndLives(GameState gs)
        {
            this.gamestate = gs;
        }

        public int Lives
        {
            get { return this.lives; }
            set { this.lives = value; }
        }
        public int Score
        {
            get { return this.score; }
            set { this.score = value; }
        }

        protected virtual void OnGameOver()
        {
            OnGameOver();
        }

        public void deadPacman()
        {
            if (lives <= 0)
            {
                GameOver();
            }


        }

        public void incrementScore(ICollidable m)
        {
            this.score += m.Points; //increment score

            // check if member is an energizer and scare ghosts
            if (m is Energizer)
            {
                this.gamestate.GhostPack.ScareGhosts();
            }
        }
    }
    }
