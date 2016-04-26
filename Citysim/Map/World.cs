using System;
using Microsoft.Xna.Framework;
using Citysim.Map.Tiles;

namespace Citysim.Map
{
    public class World
    {
        public int[,,] tiles; // array of tile IDs on map

        public int width;
        public int height;
        public const int depth = 16;
        
        public bool InBounds(double x, double y)
        {
            return (((x >= 0) && (x < width)) && ((y >= 0) && (y < height)));
        }

        public bool InBounds(Vector2 vector)
        {
            return InBounds(vector.X, vector.Y);
        }

        public bool RemoveTile(Vector3 position)
        {
            tiles[(int)position.X, (int)position.Y, (int)position.Z] = 0;

            return true;
        }

        public bool PlaceTile(int tileID, Vector3 position)
        {
            ITile tile = Citysim.instance.tileRegistry.GetTile(tileID);
            Point size = tile.GetTileSize();
            Vector3 position2 = new Vector3(position.X + size.X - 1, position.Y + size.Y - 1, 1);
            
            for (int width = (int)position.X; width <= position2.X; width++)
            {
                for (int height = (int)position.Y; height <= position2.Y; height++)
                {
                    tiles[width, height, (int)position.Z] = tileID;
                }
            }

            return true;
        }

        /// <summary>
        /// Generate a blank map. Has no special generation features.
        /// </summary>
        /// <param name="width">Width of map</param>
        /// <param name="height">Height of map</param>
        /// <param name="tileID">Tile ID to for making ground</param>
        public static World GenerateBlankMap(int width, int height, int tileID)
        {
            World world = new World();
            world.tiles = new int[width, height, 16];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    world.tiles[x, y, 8] = tileID;
                }
            }
            
            world.width = width;
            world.height = height;

            return world;
        }
    }
}
