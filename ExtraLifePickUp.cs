using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class ExtraLifePickUp
    {
        Texture2D eLPUTexture;
        public Rectangle eLPURect;
        Vector2 eLPUSpawnPosition;
        float eLPUTextureOpacity = 1f;
        Random random2 = new Random();
        public int randX, randY;
        public bool isVisible = true;
        public bool player1ExtraLife = false;
        public bool player2ExtraLife = false;

        public ExtraLifePickUp(Texture2D texture, Vector2 eLPUPos)
        {
            eLPUTexture = texture;
            eLPUSpawnPosition = eLPUPos;
            randX = random2.Next(462, 562);
            randY = random2.Next(0, 5);
            eLPUTextureOpacity = 1f;
        }
        public void Update(GameTime gt, Game1 game1)
        {
            eLPURect = new Rectangle(
                (int)eLPUSpawnPosition.X + randX,
                (int)eLPUSpawnPosition.Y + randY,
                eLPUTexture.Width,
                eLPUTexture.Height);
            eLPUSpawnPosition.Y += 1.3f;
            if (eLPURect.Y >= 600)
            {
                isVisible = false;
                eLPURect.X = -eLPUTexture.Width;
                eLPURect.Y = -eLPUTexture.Height;
                eLPUTextureOpacity = 0f;
            }
            if (eLPURect.Intersects(game1.playerRect))
            {
                game1.player1CurrentHealth = 338;
                eLPUTextureOpacity = 0f;
                isVisible = false;
                player1ExtraLife = true;
            }
            if (eLPURect.Intersects(game1.player2Rect))
            {
                game1.player2CurrentHealth = 338;
                eLPUTextureOpacity = 0f;
                isVisible = false;
                player2ExtraLife = true;
            }
            if (eLPURect.Intersects(game1.player2VAIRect))
            {
                game1.player2CurrentHealth = 338;
                eLPUTextureOpacity = 0f;
                isVisible = false;
                player2ExtraLife = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(eLPUTexture, eLPURect, Color.White * eLPUTextureOpacity);
        }
    }
}
