using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pacman.Characters.Classes;
using Pacman.Game.Classes.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanGame
{
    class GhostSprite : DrawableGameComponent
    {
        private Game1 maingame;
        private SpriteBatch spriteBatch;
       
        private int width,
                    height,
                    counter;

        private int _timeSinceLastFrame;
        private int mSecondsPerFrame = 290;
        private int changeSpeed = 10,
                    lastSpeed;
        // 1 array for colors 
        // 1 state / direction
        private readonly string[] _scaredOrChaseArray = { "Chase", "Scared"};
        private readonly string[] _ghostColorArray = { "Red", "Blue", "Pink", "Orange" };
        private Texture2D[,] ghostArray = new Texture2D[4,1]; 
                           
        public GhostSprite(Game1 maingame) : base(maingame)
        {
            this.maingame = maingame;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            _timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            lastSpeed += gameTime.ElapsedGameTime.Milliseconds;
            if (lastSpeed > changeSpeed)
            {
                lastSpeed -= changeSpeed;
                ChangeGhostPicture();
                if (counter >= 3)
                    counter = 0;
                lastSpeed = 0;
            }

            if (_timeSinceLastFrame > mSecondsPerFrame)
            {
                _timeSinceLastFrame -= mSecondsPerFrame;
                // increment current frame 
                foreach (var ghost in maingame.GameState.GhostPack)
                    ghost.Move();
                _timeSinceLastFrame = 0;
            }
        }

        private void ChangeGhostPicture()
        {
            foreach (var ghost in maingame.GameState.GhostPack)
            {
                if (ghost.ICurrentState is Scared)
                    ghostArray[counter, 0] = maingame.Content.Load<Texture2D>("scared");
                else
                {
                    ghostArray[counter, 0] = maingame.Content.Load<Texture2D>("ghost" +
                        _ghostColorArray[counter] + _scaredOrChaseArray[0]);
                }
                counter++;             
            }
        }
        // class that holds 6 things 
        // class ghsot directions it would hold all 6 things 
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            /* Set all ghosts graphics*/
            for (int i = 0; i < _ghostColorArray.Length; i++)
                for (int j = 0; j < 1; j++)
                    ghostArray[i, j] = maingame.Content.Load<Texture2D>
                        ("ghost"+ _ghostColorArray[i] + _scaredOrChaseArray[j]);

        }

        private void DrawSprite(int i, int j, Texture2D obj)
        {
            spriteBatch.Draw(obj, new Rectangle(i * 32, j * 32, 32, 32), Microsoft.Xna.Framework.Color.White);
        }

        public override void Draw(GameTime gameTime)
        {
            int counter = 0;
            spriteBatch.Begin();
            foreach (var item in maingame.GameState.GhostPack)
            {
                DrawSprite((int)item.Position.X, (int)item.Position.Y, ghostArray[counter,0]);
                counter++;
            }
            if (counter >= 3)
                counter = 0;
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
    


}