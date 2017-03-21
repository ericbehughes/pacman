using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pacman.Game.Classes.Map;
using Pacman.Game.Classes.State;
using System.IO;
using System.Text.RegularExpressions;

namespace PacmanGame
{
    public class MazeSprite : DrawableGameComponent
    {
        Game1 maingame;
        GameState gs;
        private List<Wall> Walls;
        private List<Texture2D> pictureList; 

        private SpriteBatch spriteBatch;
        private Texture2D Wall;
        private Texture2D Pen;
        private Texture2D PenDoor;
        private Texture2D Energizer;
        private Texture2D Pellet;
        private Texture2D Path;
        private string[] csv_array = {"w", "e","x","pw", "1", "2", "3", "4", "P", "p"};
        private delegate void drawSpriteDelegate(Texture2D v);
    


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
            pictureList.Add(Wall);
            Pen = maingame.Content.Load<Texture2D>("pen");
            pictureList.Add(Pen);
            PenDoor = maingame.Content.Load<Texture2D>("penDoor");
            pictureList.Add(PenDoor);
            Energizer = maingame.Content.Load<Texture2D>("energizer");
            pictureList.Add(Energizer);
            Pellet = maingame.Content.Load<Texture2D>("pellet");
            pictureList.Add(Pellet);
            Path = maingame.Content.Load<Texture2D>("path");
            pictureList.Add(Path);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        private void drawSprite(Texture2D obj)
        {
            spriteBatch.Draw(obj, new Rectangle(30,30, 32, 32), Color.White);
        }

        public override void Draw(GameTime gameTime)
        {
            if (gs.Score.Lives == 0)
            {
                LoadContent();
            }
            //private string[] csv_array = {"w", "e","x","pw", "1", "2", "3", "4", "P", "p"};

            var dictionary = new Dictionary<string,drawSpriteDelegate>();
            dictionary.Add(csv_array[0], drawSprite);

            string line = Regex.Replace(File.ReadAllText("map.csv"), @"[\r\n\t]+", ",");
            string[] str = line.Split(',');
            String mazeChar = "";

            spriteBatch.Begin();
            for (int i = 0; i < gs.Maze.Size; i++)
            {
                // need to test this dictionary 
                for (int j = 0; j < gs.Maze.Size; j++)
                {
                    dictionary[mazeChar](pictureList[0]);
                }
            }

            base.Draw(gameTime);
        }


    }
}
