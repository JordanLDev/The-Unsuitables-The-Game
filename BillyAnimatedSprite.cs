using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class BillyAnimatedSprite
    {
        public Texture2D billySpriteTexture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int totalFrames;
        int billyCurrentFrame;
        int billyTimeSinceLastFrame = 0;
        int billyMillisecondsPerFrame = 150;

        public BillyAnimatedSprite(Texture2D texture, Rectangle playerRect, int rows, int columns)
        {
            billySpriteTexture = texture;
            Rows = rows;
            Columns = columns;
            billyCurrentFrame = 0;
            totalFrames = Rows * Columns;
        }
        public void Update(GameTime gameTime)
        {
            billyTimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (billyTimeSinceLastFrame > billyMillisecondsPerFrame)
            {
                billyTimeSinceLastFrame -= billyMillisecondsPerFrame;
                billyCurrentFrame++;
                billyTimeSinceLastFrame = 0;
                if (billyCurrentFrame == totalFrames)
                {
                    billyCurrentFrame = 0;
                    
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = billySpriteTexture.Width / Columns;
            int height = billySpriteTexture.Height / Rows;
            int row = (int)((float)billyCurrentFrame / Columns);
            int column = billyCurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            
            KeyboardState ks = Keyboard.GetState();
            //player1 movement
            if (ks.IsKeyDown(Keys.Left) && ks.IsKeyUp(Keys.Right))
            {
                spriteBatch.Draw(billySpriteTexture, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                //animatedSprite.Draw(spriteBatch, new Vector2 (playerRect.X, playerRect.Y));
                //spriteBatch.Draw(player1TextureSpriteSheet, new Vector2 (playerRect.X, playerRect.Y), new Rectangle(billyCurrentFrame.X * billyFrameSize.X, billyCurrentFrame.Y * billyFrameSize.Y, billyFrameSize.X, billyFrameSize.Y), Color.White, 0, Vector2.Zero,1, SpriteEffects.FlipHorizontally, 0);
                //.Draw(player1Texture, playerRect, null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            }
            else
            if (ks.IsKeyDown(Keys.Right) && ks.IsKeyUp(Keys.Left))
            {
                spriteBatch.Draw(billySpriteTexture, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
            }
            else
            if (ks.IsKeyDown(Keys.Right) && ks.IsKeyDown(Keys.Left))
            {
                spriteBatch.Draw(billySpriteTexture, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
            }
            else
            if (ks.IsKeyDown(Keys.Right) && location.X < 512 || location.X < 512 || (ks.IsKeyUp(Keys.Right) && ks.IsKeyUp(Keys.Left) && location.X < 512))
            {
                spriteBatch.Draw(billySpriteTexture, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
            }
            else
            if (ks.IsKeyDown(Keys.Left) && location.X > 512 || location.X > 512 || (ks.IsKeyUp(Keys.Right) && ks.IsKeyUp(Keys.Left) && location.X > 512))
            {
                spriteBatch.Draw(billySpriteTexture, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            }
        }
    }
}