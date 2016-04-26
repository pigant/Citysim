using System;
using Microsoft.Xna.Framework;
using Citysim.Map.Tiles;

namespace Citysim.Map
{
    public class World
    {
        /// <summary>
        /// Amount of cash available. Measured in thousands (k).
        /// </summary>
        public int cash = 50; // $50k starting cash

        /// <summary>
        /// MW (mega watts) of electricity available to the city.
        /// </summary>
        public int power = 0;

        /// <summary>
        /// ML (mega litres) of water available to the city.
        /// </summary>
        public int water = 0;

        public int[,,] tiles; // array of tile IDs on map

        public Vector3?[,,] tileOrigins; // array which maps multiblock tiles to their origin tile

        public int width;
        public int height;
        public const int depth = 16;
        
        /// <summary>
        /// Is a particular set of coordinates within the bounds of the world?
        /// </summary>
        /// <param name="x">X coord</param>
        /// <param name="y">Y coord</param>
        /// <returns></returns>
        public bool InBounds(double x, double y)
        {
            return (((x >= 0) && (x < width)) && ((y >= 0) && (y < height)));
        }

        /// <summary>
        /// Is a particular set of coordinates within the bounds of the world?
        /// </summary>
        /// <param name="x">X coord</param>
        /// <param name="y">Y coord</param>
        /// <returns></returns>
        public bool InBounds(Vector2 vector)
        {
            return InBounds(vector.X, vector.Y);
        }

        /// <summary>
        /// Find the origin tile for a multiblock.
        /// If not a multiblock (or the origin block of one), it'll return the same position passed in.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Vector3 FindTileOrigin(Vector3 position)
        {
            Vector3? origin = tileOrigins[(int)position.X, (int)position.Y, (int)position.Z];
            if (origin.HasValue)
                return origin.Value;
            else
                return position; // Not a multitile, origin is self.
        }

        /// <summary>
        /// Remove a tile at this position.
        /// This is advised over manually modifiying the tiles array, as this handles multiblocks.
        /// </summary>
        /// <param name="position">Position of tile to remove. If part of a multitile, the entire multitile will be removed.</param>
        /// <returns></returns>
        public bool RemoveTile(Vector3 position)
        {
            Vector3 origin = FindTileOrigin(position);

            int tileID = tiles[(int)origin.X, (int)origin.Y, (int)origin.Z];
            ITile tile = Citysim.instance.tileRegistry.GetTile(tileID);
            Point size = new Point(1, 1);
            if (tile != null)
                size = tile.GetTileSize();
            
            for (int x = 0; x < size.X; x++)
            {
                for (int y = 0; y < size.Y; y++)
                {
                    Vector3 currentPos = new Vector3(origin.X + x, origin.Y + y, (int)position.Z);
                    tiles[(int)currentPos.X, (int)currentPos.Y, (int)currentPos.Z] = 0;
                    tileOrigins[(int)currentPos.X, (int)currentPos.Y, (int)currentPos.Z] = null;
                }
            }

            return true;
        }

        /// <summary>
        /// Places a tile.
        /// This is advised over manually modifiying the tiles array, as this handles multiblocks.
        /// </summary>
        /// <param name="tileID">ID of tile to place</param>
        /// <param name="position">Position to place tile. In the case of multiblocks, this is the top-left coordinate.</param>
        /// <returns></returns>
        public bool PlaceTile(int tileID, Vector3 position)
        {
            if (tileID == 0)
                return RemoveTile(position);

            ITile tile = Citysim.instance.tileRegistry.GetTile(tileID);
            Point size = tile.GetTileSize();

            int blockArea = size.X * size.Y;
            if (blockArea > 1)
            {
                // Bottom-right position of multiblock.
                Vector3 position2 = new Vector3(position.X + size.X - 1, position.Y + size.Y - 1, 1);

                // Check Multiblock will fit.
                for (int width = (int)position.X; width <= position2.X; width++)
                {
                    for (int height = (int)position.Y; height <= position2.Y; height++)
                    {
                        if (IsTilePresent(new Vector3(width, height, position.Z)))
                            return false; // Cannot fit!
                    }
                }

                // Place multiblock origin tile references.
                for (int width = (int)position.X; width <= position2.X; width++)
                {
                    for (int height = (int)position.Y; height <= position2.Y; height++)
                    {
                        tiles[width, height, (int)position.Z] = 0;
                        tileOrigins[width, height, (int)position.Z] = new Vector3(position.X, position.Y, position.Z);
                    }
                }
            }

            // Place origin block.
            tiles[(int)position.X, (int)position.Y, (int)position.Z] = tileID;

            return true;
        }

        /// <summary>
        /// Get a tile at the particular location.
        /// Takes into account multiblocks.
        /// </summary>
        /// <param name="position">Coordinates</param>
        /// <returns></returns>
        public ITile GetTile(Vector3 position)
        {
            if (!InBounds(new Vector2(position.X, position.Y)))
                throw new Exception("Attempt to get tile outside of world");

            Vector3 origin = (Vector3)FindTileOrigin(position);

            int tileID = tiles[(int)origin.X, (int)origin.Y, (int)origin.Z];

            ITile tile = Citysim.instance.tileRegistry.GetTile(tileID);

            return tile;
        }

        /// <summary>
        /// Checks if a tile is present at a particular location.
        /// </summary>
        /// <param name="position">Coordinates</param>
        /// <returns></returns>
        public bool IsTilePresent(Vector3 position)
        {
            if (!InBounds(new Vector2(position.X, position.Y)))
                return false; // Out of world

            Vector3 origin = FindTileOrigin(position);

            return (tiles[(int)origin.X, (int)origin.Y, (int)origin.Z] > 0);
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
            world.tileOrigins = new Vector3?[width, height, 16];

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
