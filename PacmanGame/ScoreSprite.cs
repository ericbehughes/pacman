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
        public ScoreSprite(Game game) : base(game)
        {
        }

        private ScoreAndLives scoreAndLives;
        private Game1 maingame;
        private SpriteBatch spriteBatch;
        private SpriteFont font;

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
            font = maingame.Content.Load<SpriteFont>("score");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin();
            spriteBatch.DrawString(font, "" + maingame.GameState.Score, new Vector2(700, 100),
                Microsoft.Xna.Framework.Color.White);

            spriteBatch.End();
            base.Draw(gameTime);

        }

    }
}
