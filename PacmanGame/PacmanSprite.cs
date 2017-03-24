using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanGame
{
    class PacmanSprite : DrawableGameComponent
    {
        private Game1 maingame;
        private SpriteBatch spriteBatch;
        private Texture2D Pacman;
        public PacmanSprite(Game1 maingame) : base(maingame)
        {
            this.maingame = maingame;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Pacman = maingame.Content.Load<Texture2D>("pacman");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        private void DrawSprite(Texture2D obj, int i, int j)
        {
            spriteBatch.Draw(obj, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
        }
        
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            DrawSprite(Pacman, (int)maingame.GameState.Pacman.Position.X, (int)maingame.GameState.Pacman.Position.Y);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
