using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pacman.Characters.Classes;
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
        private int timeSinceLastFrame = 0;
        private int mSecondsPerFrame = 50;
        public PacmanSprite(Game1 maingame) : base(maingame)
        {
            this.maingame = maingame;
        }

        public override void Initialize()
        {
            PacmanKeyPress();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Pacman = maingame.Content.Load<Texture2D>("pacman");
        }

        public override void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > mSecondsPerFrame)
            {
                timeSinceLastFrame -= mSecondsPerFrame;
                PacmanKeyPress();
                timeSinceLastFrame = 0;
            }
            base.Update(gameTime);
        }
        
        private void PacmanKeyPress()
        {
            KeyboardState CurrentKeyState = Keyboard.GetState();
            
            /* Check for right key press */
            if (CurrentKeyState.IsKeyDown(Keys.Right))
                maingame.GameState.Pacman.Move(Direction.Down);

            /* Check for left key press */
            else if (CurrentKeyState.IsKeyDown(Keys.Left))
                maingame.GameState.Pacman.Move(Direction.Up);

            /* Check for up key press */
            else if (CurrentKeyState.IsKeyDown(Keys.Up))
                maingame.GameState.Pacman.Move(Direction.Left);

            /* Check for down key press */
            else if (CurrentKeyState.IsKeyDown(Keys.Down))
                maingame.GameState.Pacman.Move(Direction.Right);

        }
        
        private void DrawSprite(Texture2D obj, int i, int j)
        {
            spriteBatch.Draw(obj, new Rectangle(i * 32, j * 32, 32, 32), Microsoft.Xna.Framework.Color.White);
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
