﻿using System.IO;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pacman.Characters.Classes;
using Pacman.Game.Classes.State;
using Color = Microsoft.Xna.Framework.Color;

namespace PacmanGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private MazeSprite map;
        private GhostSprite ghostSprite;
        private PacmanSprite pacmanSprite;
        private ScoreSprite scorelivesSprite;
        int timeSinceLastFrame = 0;
        int millisecondsPerFrame = 300;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 736;
            graphics.PreferredBackBufferHeight = 800;
            Content.RootDirectory = "Content";
            GameState = GameState.Parse("map.csv");
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            map = new MazeSprite(this);
            ghostSprite = new GhostSprite(this);
            pacmanSprite = new PacmanSprite(this);
            scorelivesSprite = new ScoreSprite(this);
            Components.Add(map);
            Components.Add(ghostSprite);
            Components.Add(pacmanSprite);
            Components.Add(scorelivesSprite);
            base.Initialize();
        }

        public GameState GameState { get; set; }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
    
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

          
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            

            base.Draw(gameTime);
        }
    }
}
