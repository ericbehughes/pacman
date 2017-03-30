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

        public bool RedrawGame { get;  set; }

        protected virtual void OnGameOver()
        {
            if (GameOverEvent != null)
                 GameOverEvent();
        }
     
        public void GameOver()
        {
            RedrawGame = true;
        }


        public void DeadPacman()
        {
            this.lives--;
            if (lives == 0 || gamestate.Maze.CheckMembersLeft() == 0)
            {
                OnGameOver();
            }
            gamestate.GhostPack.ResetGhosts();
            gamestate.Pacman.Position = new Microsoft.Xna.Framework.Vector2(11, 17); 
            
        }

        public void IncrementScore(ICollidable m)
        {
            this.score += m.Points; //increment score
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

     
   

    }
    }
