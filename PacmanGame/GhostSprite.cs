using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private GameState gs;
        private Game1 maingame;
        private Rectangle GhostRed = new Rectangle(20, 20, 20, 20),
                          GhostBlue = new Rectangle(20, 20, 20, 20),
                          GhostOrange = new Rectangle(20, 20, 20, 20),
                          GhostPink = new Rectangle(20, 20, 20, 20);
        private SpriteBatch spriteBatch;
        private Texture2D GhostRedNormal,
                          GhostRedScared,
                          GhostRedUp,
                          GhostRedDown,
                          GhostRedLeft,
                          GhostRedRight,
                          GhostBlueNormal,
                          GhostBlueScared,
                          GhostBlueUp,
                          GhostBlueDown,
                          GhostBlueLeft,
                          GhostBlueRight,
                          GhostOrangeNormal,
                          GhostOrangeScared,
                          GhostOrangeUp,
                          GhostOrangeDown,
                          GhostOrangeLeft,
                          GhostOrangeRight,
                          GhostPinkScared,
                          GhostPinkNormal,
                          GhostPinkUp,
                          GhostPinkDown,
                          GhostPinkLeft,
                          GhostPinkRight;

        private int width,
                    height;

        public GhostSprite(Game1 maingame) : base(maingame)
        {
            this.maingame = maingame;
        }

        protected void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            /* Set red ghost */
            GhostRedNormal = maingame.Content.Load<Texture2D>("ghost/red/ghostRedNormal");
            GhostRedScared = maingame.Content.Load<Texture2D>("ghost/red/ghostRedScared");
            GhostRedLeft = maingame.Content.Load<Texture2D>("ghost/red/ghostRedLeft");
            GhostRedRight = maingame.Content.Load<Texture2D>("ghost/red/ghostRedRight");
            GhostRedUp = maingame.Content.Load<Texture2D>("ghost/red/ghostRedUp");
            GhostRedDown = maingame.Content.Load<Texture2D>("ghost/red/ghostRedDown");

            /* Set Blue ghost */
            GhostBlueNormal = maingame.Content.Load<Texture2D>("ghost/blue/ghostBlueNormal");
            GhostBlueScared = maingame.Content.Load<Texture2D>("ghost/blue/ghostBlueScared");
            GhostBlueLeft = maingame.Content.Load<Texture2D>("ghost/blue/ghostBlueLeft");
            GhostBlueRight = maingame.Content.Load<Texture2D>("ghost/blue/ghostBlueRight");
            GhostBlueUp = maingame.Content.Load<Texture2D>("ghost/blue/ghostBlueUp");
            GhostBlueDown = maingame.Content.Load<Texture2D>("ghost/blue/ghostBlueDown");

            /* Set Orange ghost */
            GhostOrangeNormal = maingame.Content.Load<Texture2D>("ghost/orange/ghostOrangeNormal");
            GhostOrangeScared = maingame.Content.Load<Texture2D>("ghost/orange/ghostOrangeScared");
            GhostOrangeLeft = maingame.Content.Load<Texture2D>("ghost/orange/ghostOrangeLeft");
            GhostOrangeRight = maingame.Content.Load<Texture2D>("ghost/orange/ghostOrangeRight");
            GhostOrangeUp = maingame.Content.Load<Texture2D>("ghost/orange/ghostOrangeUp");
            GhostOrangeDown = maingame.Content.Load<Texture2D>("ghost/orange/ghostOrangeDown");

            /* Set Pink ghost */
            GhostPinkNormal = maingame.Content.Load<Texture2D>("ghost/pink/ghostPinkNormal");
            GhostPinkScared = maingame.Content.Load<Texture2D>("ghost/pink/ghostPinkScared");
            GhostPinkLeft = maingame.Content.Load<Texture2D>("ghost/pink/ghostPinkLeft");
            GhostPinkRight = maingame.Content.Load<Texture2D>("ghost/pink/ghostPinkRight");
            GhostPinkUp = maingame.Content.Load<Texture2D>("ghost/pink/ghostPinkUp");
            GhostPinkDown = maingame.Content.Load<Texture2D>("ghost/pink/ghostPinkDown");

        }

        private void Draw(Texture2D tObj)
        {
            /* Draw red ghost */
            spriteBatch.Draw(tObj, GhostRed, Color.Red);

            /* Draw blue ghost */
            spriteBatch.Draw(tObj, GhostBlue, Color.Blue);

            /* Draw orange ghost */
            spriteBatch.Draw(tObj, GhostOrange, Color.Orange);

            /* Draw pink ghost */
            spriteBatch.Draw(tObj, GhostPink, Color.Pink);

        }
    }


}