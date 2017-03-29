using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pacman.Characters.Classes;
using Microsoft.Xna.Framework.Graphics;
using System.Timers;
using Pacman.Game.Classes.State;

namespace PacmanGame
{
    public class ScoreSprite : DrawableGameComponent
    {
        public ScoreSprite(Game game) : base(game){}

        private ScoreAndLives scoreAndLives;
        private Game1 maingame;
        private SpriteBatch spriteBatch;
        private SpriteFont score;
        private SpriteFont lives;
        private Texture2D wasted;

        //private TimeSpan resetCheck = TimeSpan.FromMilliseconds(3000);
       // private TimeSpan reset;

        public ScoreSprite(Game1 game) : base(game)
        {
            this.maingame = game;

        }


        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            score = maingame.Content.Load<SpriteFont>("ScoreTxt");
            lives = maingame.Content.Load<SpriteFont>("LivesTxt");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            var timer = new Timer(1000);
            timer.Enabled = false;
            timer.Elapsed += EndGame;
            if (maingame.GameState.ScoreAndLives.Lives == 0)
            {
                timer.Enabled = true;
                //spriteBatch.DrawString(score, "Game Over", new Vector2(125, 750), Microsoft.Xna.Framework.Color.White);
            }

            else if (maingame.GameState.Maze.MemberCount() == 0)
            {
                timer.Enabled = true;
                //spriteBatch.DrawString(score, "You win", new Vector2(125, 750), Microsoft.Xna.Framework.Color.White);
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin();
            var Lives = maingame.GameState.ScoreAndLives.Lives;
            if (Lives < 4 && Lives > 0)
            {
                spriteBatch.DrawString(score, "Score: " + maingame.GameState.ScoreAndLives.Score,
                    new Vector2(50, 750), Microsoft.Xna.Framework.Color.White);

                spriteBatch.DrawString(lives, "Lives: " + maingame.GameState.ScoreAndLives.Lives,
                    new Vector2(500, 750), Microsoft.Xna.Framework.Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);

        }

        
        private void EndGame(object sender, ElapsedEventArgs e)
        {
            var t = sender as Timer;
            t.Enabled = false;
            maingame.GameState.ScoreAndLives.EndGame();
        }
        
    }
}
