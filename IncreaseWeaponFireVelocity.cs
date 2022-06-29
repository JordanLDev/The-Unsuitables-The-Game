using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class IncreaseWeaponFireVelocity
    {
        Texture2D iWFVTexture;
        public Rectangle iWFVRect;
        Vector2 spawnPosition;
        float iWFVTextureOpacity = 1f;
        Random random = new Random();
        public int randX, randY;
        public bool isVisible = true;

        public IncreaseWeaponFireVelocity(Texture2D tex, Vector2 pos)
        {
            iWFVTexture = tex;
            spawnPosition = pos;
            randX = random.Next(550, 650);
            randY = random.Next(0, 10);
            iWFVTextureOpacity = 1f;
        }
        public void Update(GameTime gt, Game1 game1)
        {
            iWFVRect = new Rectangle(
                (int)spawnPosition.X + randX,
                (int)spawnPosition.Y + randY,
                iWFVTexture.Width,
                iWFVTexture.Height);
            spawnPosition.Y += 2.3f;
            if (iWFVRect.Y >= 600)
            {
                isVisible = false;
                iWFVRect.X = -iWFVTexture.Width;
                iWFVRect.Y = -iWFVTexture.Height;
                iWFVTextureOpacity = 0f;
                game1.laserVelocity = 6;
                game1.missileVelocity = 4;
            }
            if (iWFVRect.Intersects(game1.playerRect))
            {
                game1.missileVelocity = 10;
                iWFVTextureOpacity = 0f;
                isVisible = false;
            }
            else
            if (iWFVRect.Intersects(game1.playerRect) && isVisible == false)
            {
                game1.missileVelocity = 4;
                iWFVTextureOpacity = 0f;
                isVisible = false;
            }
            if (iWFVRect.Intersects(game1.player2Rect))
            {
                game1.laserVelocity = 10;
                iWFVTextureOpacity = 0f;
                isVisible = false;
            }
            else
            if (iWFVRect.Intersects(game1.player2Rect) && isVisible == false)
            {
                game1.laserVelocity = 6;
                iWFVTextureOpacity = 0f;
                isVisible = false;
            }
            if (iWFVRect.Intersects(game1.player2VAIRect))
            {
                game1.laserVelocity = 10;
                iWFVTextureOpacity = 0f;
                isVisible = false;
            }
            else
            if (iWFVRect.Intersects(game1.player2VAIRect) && isVisible == false)
            {
                game1.laserVelocity = 6;
                iWFVTextureOpacity = 0f;
                isVisible = false;
            }
            if (iWFVTextureOpacity == 0f && iWFVRect.Intersects(new Rectangle(0, 600, (int)1024, (int)10)))
            {
                game1.laserVelocity = 6;
                game1.missileVelocity = 4;
            }
        }    
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(iWFVTexture, iWFVRect, Color.White * iWFVTextureOpacity);
        }
    }
}
