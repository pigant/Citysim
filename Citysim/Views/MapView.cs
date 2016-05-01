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
        private Texture2D hitbox;

        private int tileSize = Setting.Tiles.tileSize;

        public void LoadContent(ContentManager content)
        {
            hitbox = content.Load<Texture2D>("hitbox");
        }

        public void Render(SpriteBatch spriteBatch, Citysim game, GameTime gameTime)
        {
            World world = game.city.world;

            int cameraX = (int)game.camera.position.X;
            int cameraY = (int)game.camera.position.Y;

            // Loop through tiles.
            for (int z = 0; z < World.depth; z++)
            {
                for (int y = 0; y < world.height; y++)
                {
                    for (int x = 0; x < world.width; x++)
                    {
                        ITile tile = game.tileRegistry.GetTile(world.tiles[x, y, z]);
                        if (tile == null)
                            continue; // unknown tile

                        Rectangle tileRect = new Rectangle(cameraX + x * tileSize, cameraY + y * tileSize, tileSize * tile.GetTileSize().X, tileSize * tile.GetTileSize().Y);

                        spriteBatch.Draw(tile.GetTexture(gameTime), tileRect, Color.White);
                    }
                }
            }

            if (world.InBounds(game.camera.hovering))
            {
                // Draw hitbox
                int hitX = (int)(game.camera.hovering.X * tileSize + game.camera.position.X);
                int hitY = (int)(game.camera.hovering.Y * tileSize + game.camera.position.Y);
                spriteBatch.Draw(hitbox, new Rectangle(hitX, hitY, tileSize, tileSize), Color.White);
            }
        }

        public void Update(Citysim game, GameTime gameTime)
        {
            if (game.city.world.InBounds(game.camera.hovering.X, game.camera.hovering.Y) && game.debug)
            {
                MouseState mouseState = Mouse.GetState();
                if (mouseState.LeftButton == ButtonState.Pressed)
                    //game.city.world.tiles[(int)game.camera.hovering.X, (int)game.camera.hovering.Y, 9] = Tile.tileLargeTest.id;
                    game.city.world.PlaceTile(Tile.tileNuclearReactor.id, new Vector3(game.camera.hovering.X, game.camera.hovering.Y, 9));
                else if (mouseState.RightButton == ButtonState.Pressed)
                    //game.city.world.tiles[(int)game.camera.hovering.X, (int)game.camera.hovering.Y, 9] = 0;
                    game.city.world.RemoveTile(new Vector3(game.camera.hovering.X, game.camera.hovering.Y, 9));
            }
        }
    }
}
