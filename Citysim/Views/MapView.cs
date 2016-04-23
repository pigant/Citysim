using System;
using Citysim.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Citysim.Map.Tiles;
using Microsoft.Xna.Framework.Content;

namespace Citysim.Views
{
    public class MapView : IView
    {
        public void LoadContent(ContentManager content)
        {
        }

        public void Render(SpriteBatch spriteBatch, Citysim game, GameTime gameTime)
        {
            World world = game.city.world;

            int cameraX = (int)game.camera.position.X;
            int cameraY = (int)game.camera.position.Y;

            // Loop through tiles.
            for (int x = 0; x < world.width; x++)
            {
                for (int y = 0; y < world.height; y++)
                {
                    for (int z = 0; z < World.depth; z++)
                    {
                        ITile tile = game.tileRegistry.GetTile(world.tiles[x, y, z]);
                        if (tile == null)
                            continue; // unknown tile

                        Rectangle tileRect = new Rectangle(cameraX + x * 32, cameraY + y * 32, 32, 32);
                        spriteBatch.Draw(tile.GetTexture(gameTime), tileRect, Color.White);
                    }
                }
            }
        }

        public void Update(Citysim game, GameTime gameTime)
        {
            if (KeyboardHelper.IsKeyDown(Keys.LeftShift))
                game.camera.speed = 15;
            else
                game.camera.speed = 7;

            int speed = game.camera.speed;

            if (KeyboardHelper.IsKeyDown(Keys.W))
                game.camera.position.Y += speed;
            if (KeyboardHelper.IsKeyDown(Keys.A))
                game.camera.position.X += speed;
            if (KeyboardHelper.IsKeyDown(Keys.S))
                game.camera.position.Y -= speed;
            if (KeyboardHelper.IsKeyDown(Keys.D))
                game.camera.position.X -= speed;
        }
    }
}
