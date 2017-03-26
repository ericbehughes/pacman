using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pacman.Characters.Classes;
using Microsoft.Xna.Framework.Graphics;

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
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin();
            spriteBatch.DrawString(score, "Score: " + maingame.GameState.ScoreAndLives.Score, 
                new Vector2(50, 750),Microsoft.Xna.Framework.Color.White);

            spriteBatch.DrawString(lives, "Lives :" +maingame.GameState.ScoreAndLives.Lives, 
                new Vector2(500, 750), Microsoft.Xna.Framework.Color.White);
            
            spriteBatch.End();
            base.Draw(gameTime);

        }

    }
}
