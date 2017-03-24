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

        private void Initialize()
        {
            base.Initialize();
        }

        private void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Pacman = maingame.Content.Load<Texture2D>("pacman");
        }

        private void DrawSprite(Texture2D obj, int i, int j, Color color)
        {
            spriteBatch.Draw(obj, new Rectangle(i * 32, j * 32, 32, 32) Color.White);
        }
        
        private void Draw()
        {

        }
    }
}
