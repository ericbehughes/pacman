using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pacman.Game.Classes.Map;
using Pacman.Game.Classes.State;

namespace PacmanGame
{
    public class MazeSprite : DrawableGameComponent
    {
        Game1 maingame;
        GameState gs;
        private List<Wall> Walls;


        private SpriteBatch spriteBatch;
        private Texture2D Wall;
        private Texture2D Pen;
        private Texture2D PenDoor;
        private Texture2D Energizer;
        private Texture2D Pellet;
        private Texture2D Path;
        

        public struct GameBoardDimensions
        {
            private int height;
            private int width;

            public GameBoardDimensions(int width = 32, int height = 32)
            {
                this.width = width;
                this.height = height;
            }
        }

        public MazeSprite(Game1 maingame) : base(maingame)
        {
            this.maingame = maingame;
            this.gs = maingame.GameState;
            Walls = new List<Wall>();
        }

        public override void Initialize()
        {
            GameBoardDimensions gbd = new GameBoardDimensions(32,32);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Wall = maingame.Content.Load<Texture2D>("wall");
            Pen = maingame.Content.Load<Texture2D>("pen");
            PenDoor = maingame.Content.Load<Texture2D>("penDoor");
            Energizer = maingame.Content.Load<Texture2D>("energizer");
            Pellet = maingame.Content.Load<Texture2D>("pellet");
            Path = maingame.Content.Load<Texture2D>("path");

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (gs.Score.Lives == 0)
            {
                LoadContent();
            }

            spriteBatch.Begin();


            base.Draw(gameTime);
        }


    }
}
