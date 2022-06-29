using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class HealthPickUp
    {
        Texture2D hPUTexture;
        public Rectangle hPURect;
        Vector2 hPUSpawnPosition;
        float hPUTextureOpacity = 1f;
        Random random2 = new Random();
        public int randX, randY;
        public bool isVisible = true;

        public HealthPickUp(Texture2D texture, Vector2 hPUPos)
        {
            hPUTexture = texture;
            hPUSpawnPosition = hPUPos;
            randX = random2.Next(50, 974);
            randY = random2.Next(0, 5);
            hPUTextureOpacity = 1f;
        }
        public void Update(GameTime gt, Game1 game1)
        {
            hPURect = new Rectangle(
                (int)hPUSpawnPosition.X + randX,
                (int)hPUSpawnPosition.Y + randY,
                hPUTexture.Width,
                hPUTexture.Height);
            hPUSpawnPosition.Y += 1.5f;
            if (hPURect.Y >= 600)
            {
                isVisible = false;
                hPURect.X = -hPUTexture.Width;
                hPURect.Y = -hPUTexture.Height;
                hPUTextureOpacity = 0f;
            }
            if (hPURect.Intersects(game1.playerRect))
            {
                game1.player1CurrentHealth = 338;
                hPUTextureOpacity = 0f;
                isVisible = false;
            }
            if (hPURect.Intersects(game1.player2Rect))
            {
                game1.player2CurrentHealth = 338;
                hPUTextureOpacity = 0f;
                isVisible = false;
            }
            if (hPURect.Intersects(game1.player2VAIRect))
            {
                game1.player2CurrentHealth = 338;
                hPUTextureOpacity = 0f;
                isVisible = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(hPUTexture, hPURect, Color.White * hPUTextureOpacity);
        }
    }
}
