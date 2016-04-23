using System;
using Citysim.Map.Tiles;

namespace Citysim.Map.Generators
{
    /// <summary>
    /// Generates a blank plane of grass.
    /// </summary>
    class GrassGenerator : IGenerator
    {
        public World generate(World world, int width, int height, Random random)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    world.tiles[x, y, 8] = Tile.tileGrass.id;
                }
            }

            return world;
        }
    }
}
