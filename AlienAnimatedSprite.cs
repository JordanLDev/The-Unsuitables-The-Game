using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1
    {
        public class AlienAnimatedSprite
        { 
            public Texture2D alienSpriteTexture { get; set; }
            public int Rows { get; set; }
            public int Columns { get; set; }
            private int totalFrames;
            int alienCurrentFrame;
            int alienTimeSinceLastFrame = 0;
            int alienMillisecondsPerFrame = 150;

            public AlienAnimatedSprite(Texture2D texture, Rectangle alienRect, int rows, int columns)
            {
                alienSpriteTexture = texture;
                Rows = rows;
                Columns = columns;
                alienCurrentFrame = 0;
                totalFrames = Rows * Columns;
            }
            public void Update(GameTime gameTime)
            {
                alienTimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                if (alienTimeSinceLastFrame > alienMillisecondsPerFrame)
                {
                    alienTimeSinceLastFrame -= alienMillisecondsPerFrame;
                    alienCurrentFrame++;
                    alienTimeSinceLastFrame = 0;
                    if (alienCurrentFrame == totalFrames)
                    {
                        alienCurrentFrame = 0;
                    }
                }
            }
            public void Draw(SpriteBatch spriteBatch, Vector2 location4 )
            {
                int width = alienSpriteTexture.Width / Columns;
                int height = alienSpriteTexture.Height / Rows;
                int row = (int)((float)alienCurrentFrame / Columns);
                int column = alienCurrentFrame % Columns;

                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
                Rectangle destinationRectangle = new Rectangle((int)location4.X, (int)location4.Y, width, height);

            if (location4.X > 512)
            {
                spriteBatch.Draw(alienSpriteTexture, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
            }
            if (location4.X < 512)
            {
                spriteBatch.Draw(alienSpriteTexture, destinationRectangle, sourceRectangle, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            }

        }
    }
}