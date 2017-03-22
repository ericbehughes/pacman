﻿using System;
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
using Pacman.Characters.Classes;
using Color = Microsoft.Xna.Framework.Color;

namespace PacmanGame
{
    public class MazeSprite : DrawableGameComponent
    {
        Game1 maingame;
        private List<Wall> Walls;
        private List<Texture2D> pictureList;

        private SpriteBatch spriteBatch;
        private Texture2D Wall;
        private Texture2D Pen;
        private Texture2D PenDoor;
        private Texture2D Energizer;
        private Texture2D Pellet;
        private Texture2D Path;
        private string[] csv_array = { "w", "e", "x", "pw", "1", "2", "3", "4", "P", "p" };
        //private delegate void drawSpriteDelegate(Texture2D v);

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
            
            Walls = new List<Wall>();
        }

        public override void Initialize()
        {
            GameBoardDimensions gbd = new GameBoardDimensions(32, 32);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Wall = maingame.Content.Load<Texture2D>("wall");
            Pen = maingame.Content.Load<Texture2D>("pen");
            //PenDoor = maingame.Content.Load<Texture2D>("penDoor");
            Energizer = maingame.Content.Load<Texture2D>("energizer");
            Pellet = maingame.Content.Load<Texture2D>("pellet");
            Path = maingame.Content.Load<Texture2D>("path");

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        private void DrawSprite(Texture2D obj)
        {
            spriteBatch.Draw(obj, new Rectangle(30, 30, 32, 32), Color.White);
        }
       
        public override void Draw(GameTime gameTime)
        {
            if (maingame.GameState.Score.Lives == 0)
            {
                LoadContent();
            }
            for (int i = 0; i < maingame.GameState.Maze.Size; i++)
            {
                for (int j = 0; j < maingame.GameState.Maze.Size; j++)
                {
                    if (maingame.GameState.Maze[i, j] is Wall)
                    {
                        DrawSprite(Wall);
                    }
                    else if (maingame.GameState.Maze[i, j] is Pacman.Game.Classes.Map.Path)
                    {
                        DrawSprite(Path);
                    }
                    else
                    {
                      
                        if (maingame.GameState.Maze[i, j].Member is Energizer)
                        {

                            DrawSprite(Energizer);
                        }
                        else if (maingame.GameState.Maze[i, j].Member is Pellet)
                        {

                            DrawSprite(Pellet);
                        }
                     
                       
                    }
                
                }
            }

            spriteBatch.Begin();

            // need to search which pictureList to choose from i put pictureList[0] for testing
            

            base.Draw(gameTime);
        }


    }
}
