using System;
using Citysim.Map.Tiles;

namespace Citysim.Map.Generators
{
    /// <summary>
    /// Random spread flowers across the map.
    /// </summary>
    class FlowersGenerator : IGenerator
    {
        public World generate(World world, int width, int height, Random random)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if ((random.NextDouble() < 0.075) && (world.tiles[x, y, 8] == Tile.tileGrass.id))
                        world.tiles[x, y, 9] = Tile.tileFlowers.id;
                }
            }

            return world;
        }
    }
}
