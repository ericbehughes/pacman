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

        private Texture2D[][] ghostarray;
        // 1 array for colors 
        // 1 state / direction
        private string[] csv_array = { "normal", "scared"};
        private string[] colorArray = { "red", "blue", "pink", "green" };
        private Texture2D[,] ghostArray = new Texture2D[4,2]; 
        public GhostSprite(Game1 maingame) : base(maingame)
        {
            this.maingame = maingame;
        }

        public override void Initialize()
        {
            base.Initialize();
        }
        // class that holds 6 things 
        // class ghsot directions it would hold all 6 things 
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            /* Set red ghost */
            for (int i = 0; i < colorArray.Length; i++)
                for (int j = 0; j < csv_array.Length; j++)
                    // ghostArray[i,j] = maingame.Content.Load<Texture2D>("ghost"+ colorArray[i] + csv_array[j]);
                    ghostArray[i, j] = maingame.Content.Load<Texture2D>("ghost");
            /*
            GhostRedNormal = maingame.Content.Load<Texture2D>("ghost/red/ghostRedNormal");
            GhostRedScared = maingame.Content.Load<Texture2D>("ghost/red/ghostRedScared");
            GhostRedLeft = maingame.Content.Load<Texture2D>("ghost/red/ghostRedLeft");
            GhostRedRight = maingame.Content.Load<Texture2D>("ghost/red/ghostRedRight");
            GhostRedUp = maingame.Content.Load<Texture2D>("ghost/red/ghostRedUp");
            GhostRedDown = maingame.Content.Load<Texture2D>("ghost/red/ghostRedDown");

            GhostBlueNormal = maingame.Content.Load<Texture2D>("ghost/blue/ghostBlueNormal");
            GhostBlueScared = maingame.Content.Load<Texture2D>("ghost/blue/ghostBlueScared");
            GhostBlueLeft = maingame.Content.Load<Texture2D>("ghost/blue/ghostBlueLeft");
            GhostBlueRight = maingame.Content.Load<Texture2D>("ghost/blue/ghostBlueRight");
            GhostBlueUp = maingame.Content.Load<Texture2D>("ghost/blue/ghostBlueUp");
            GhostBlueDown = maingame.Content.Load<Texture2D>("ghost/blue/ghostBlueDown");

            GhostOrangeNormal = maingame.Content.Load<Texture2D>("ghost/orange/ghostOrangeNormal");
            GhostOrangeScared = maingame.Content.Load<Texture2D>("ghost/orange/ghostOrangeScared");
            GhostOrangeLeft = maingame.Content.Load<Texture2D>("ghost/orange/ghostOrangeLeft");
            GhostOrangeRight = maingame.Content.Load<Texture2D>("ghost/orange/ghostOrangeRight");
            GhostOrangeUp = maingame.Content.Load<Texture2D>("ghost/orange/ghostOrangeUp");
            GhostOrangeDown = maingame.Content.Load<Texture2D>("ghost/orange/ghostOrangeDown");

            GhostPinkNormal = maingame.Content.Load<Texture2D>("ghost/pink/ghostPinkNormal");
            GhostPinkScared = maingame.Content.Load<Texture2D>("ghost/pink/ghostPinkScared");
            GhostPinkLeft = maingame.Content.Load<Texture2D>("ghost/pink/ghostPinkLeft");
            GhostPinkRight = maingame.Content.Load<Texture2D>("ghost/pink/ghostPinkRight");
            GhostPinkUp = maingame.Content.Load<Texture2D>("ghost/pink/ghostPinkUp");
            GhostPinkDown = maingame.Content.Load<Texture2D>("ghost/pink/ghostPinkDown");
            */

        }

        private void DrawSprite(int i, int j, Texture2D obj)
        {
            //spriteBatch.Draw(obj, new Rectangle(i * 32, j * 32, 32, 32), color);
            spriteBatch.Draw(obj, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
        }

        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin();

            foreach (var item in maingame.GameState.GhostPack)
            {
                DrawSprite((int)item.Position.X, (int)item.Position.Y, ghostArray[0,0]);
            }
            /*
            spriteBatch.Draw(GhostRedNormal, GhostBlue, Color.Blue);

            spriteBatch.Draw(GhostRedNormal, GhostOrange, Color.Orange);

            spriteBatch.Draw(GhostRedNormal, GhostPink, Color.Pink);
            */
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
    


}