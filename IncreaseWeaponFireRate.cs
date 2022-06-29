using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class IncreaseWeaponFireRate
    {
        Texture2D iWFRTexture;
        public Rectangle iWFRRect;
        Vector2 spawnPosition;
        float iWFRTextureOpacity = 1f;
        Random random4 = new Random();
        public int randX, randY;
        public bool isVisible = true;

        public IncreaseWeaponFireRate(Texture2D tex, Vector2 pos)
        {
            iWFRTexture = tex;
            spawnPosition = pos;
            randX = random4.Next(400, 800);
            randY = random4.Next(0, 10);
            iWFRTextureOpacity = 1f;
        }
        public void Update(GameTime gt, Game1 game1)
        {
            iWFRRect = new Rectangle(
                (int)spawnPosition.X + randX,
                (int)spawnPosition.Y + randY,
                iWFRTexture.Width,
                iWFRTexture.Height);
            spawnPosition.Y += 3f;
            if (iWFRRect.Y >= 600)
            {
                isVisible = false;
                iWFRRect.X = -iWFRTexture.Width;
                iWFRRect.Y = -iWFRTexture.Height;
                iWFRTextureOpacity = 0f;
                game1.laserDelay = 70;
                game1.missileDelay = 75;
            }
            if (iWFRRect.Intersects(game1.playerRect))
            {
                game1.missileDelay = 65;
                iWFRTextureOpacity = 0f;
                isVisible = false;
            }
            else
            if (iWFRRect.Intersects(game1.playerRect) && isVisible == false)
            {
                game1.missileDelay = 75;
                iWFRTextureOpacity = 0f;
                isVisible = false;
            }
            if (iWFRRect.Intersects(game1.player2Rect))
            {
                game1.laserDelay = 60;
                iWFRTextureOpacity = 0f;
                isVisible = false;
            }
            else
            if (iWFRRect.Intersects(game1.player2Rect) && isVisible == false)
            {
                game1.laserDelay = 70;
                iWFRTextureOpacity = 0f;
                isVisible = false;
            }
            if (iWFRRect.Intersects(game1.player2VAIRect))
            {
                game1.laserDelay = 60;
                iWFRTextureOpacity = 0f;
                isVisible = false;
            }
            else
            if (iWFRRect.Intersects(game1.player2VAIRect) && isVisible == false)
            {
                game1.laserDelay = 70;
                iWFRTextureOpacity = 0f;
                isVisible = false;
            }
            if (iWFRTextureOpacity == 0f && iWFRRect.Intersects(new Rectangle(0, 600, (int)1024, (int)10)))
            {
                game1.laserDelay = 70;
                game1.missileDelay = 75;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(iWFRTexture, iWFRRect, Color.White * iWFRTextureOpacity);
        }
    }
}

