using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1
    {
        public class NeddyVAIAnimatedSprite
        {
            public Texture2D neddySpriteTexture { get; set; }
            public int Rows { get; set; }
            public int Columns { get; set; }
            private int totalFrames;
            int neddyCurrentFrame;
            int neddyTimeSinceLastFrame = 0;
            int neddyMillisecondsPerFrame = 150;

            public NeddyVAIAnimatedSprite(Texture2D texture, Rectangle player2Rect, int rows, int columns)
            {
                neddySpriteTexture = texture;
                Rows = rows;
                Columns = columns;
                neddyCurrentFrame = 0;
                totalFrames = Rows * Columns;
            }
            public void Update(GameTime gameTime)
            {
                neddyTimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                if (neddyTimeSinceLastFrame > neddyMillisecondsPerFrame)
                {
                    neddyTimeSinceLastFrame -= neddyMillisecondsPerFrame;
                    neddyCurrentFrame++;
                    neddyTimeSinceLastFrame = 0;
                    if (neddyCurrentFrame == totalFrames)
                    {
                        neddyCurrentFrame = 0;
                    }
                }
            }
            public void Draw(SpriteBatch spriteBatch, Vector2 location3)
            {
                int width = neddySpriteTexture.Width / Columns;
                int height = neddySpriteTexture.Height / Rows;
                int row = (int)((float)neddyCurrentFrame / Columns);
                int column = neddyCurrentFrame % Columns;

                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
                Rectangle destinationRectangle = new Rectangle((int)location3.X, (int)location3.Y, width, height);

                KeyboardState ks = Keyboard.GetState();
                //player2 movement
                if (ks.IsKeyDown(Keys.A) && ks.IsKeyUp(Keys.D))
                {
                    spriteBatch.Draw(neddySpriteTexture, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                }
                else
                if (ks.IsKeyDown(Keys.D) && ks.IsKeyUp(Keys.A))
                {
                    spriteBatch.Draw(neddySpriteTexture, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                }
                else
                if (ks.IsKeyDown(Keys.D) && ks.IsKeyDown(Keys.A))
                {
                    spriteBatch.Draw(neddySpriteTexture, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                }
                else
                if (ks.IsKeyDown(Keys.D) && location3.X < 512 || location3.X < 512 || (ks.IsKeyUp(Keys.D) && ks.IsKeyUp(Keys.A) && location3.X < 512))
                {
                    spriteBatch.Draw(neddySpriteTexture, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
                }
                else
                if (ks.IsKeyDown(Keys.A) && location3.X > 512 || location3.X > 512 || (ks.IsKeyUp(Keys.D) && ks.IsKeyUp(Keys.A) && location3.X > 512))
                {
                    spriteBatch.Draw(neddySpriteTexture, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                }
          }
     }
}