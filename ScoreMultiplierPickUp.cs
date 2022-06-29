using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class ScoreMultiplierPickUp
    {
        Texture2D sMPUTexture;
        public Rectangle sMPURect;
        Vector2 sMPUSpawnPosition;
        float sMPUTextureOpacity = 1f;
        Random random3 = new Random();
        public int randX, randY;
        public bool isVisible = true;
        public bool player1ScoreMultiplier = false;
        public bool player2ScoreMultiplier = false;

        public ScoreMultiplierPickUp(Texture2D texture, Vector2 sMPUPos)
        {
            sMPUTexture = texture;
            sMPUSpawnPosition = sMPUPos;
            randX = random3.Next(462, 562);
            randY = random3.Next(0, 5);
            sMPUTextureOpacity = 1f;
        }
        public void Update(GameTime gt, Game1 game1)
        {
            sMPURect = new Rectangle(
                (int)sMPUSpawnPosition.X + randX,
                (int)sMPUSpawnPosition.Y + randY,
                sMPUTexture.Width,
                sMPUTexture.Height);
            sMPUSpawnPosition.Y += 1.7f;
            
            if (sMPURect.Y >= 600)
            {
                isVisible = false;
                sMPURect.X = -sMPUTexture.Width;
                sMPURect.Y = -sMPUTexture.Height;
                sMPUTextureOpacity = 0f;
            }
            if (sMPURect.Intersects(game1.playerRect))
            {
                game1.p1hitScoreValue = 600;
                sMPUTextureOpacity = 0f;
                isVisible = false;
                player1ScoreMultiplier = true;
            }
            if (sMPURect.Intersects(game1.player2Rect))
            {
                game1.p2hitScoreValue = 600;
                sMPUTextureOpacity = 0f;
                isVisible = false;
                player2ScoreMultiplier = true;
            }
            if (sMPURect.Intersects(game1.player2VAIRect))
            {
                game1.p2hitScoreValue = 600;
                sMPUTextureOpacity = 0f;
                isVisible = false;
                player2ScoreMultiplier = true;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sMPUTexture, sMPURect, Color.White * sMPUTextureOpacity);
        }
    }
}
