using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Citysim.Map.Tiles;

namespace Citysim.Map.Generators
{
    class WaterGenerator : IGenerator
    {
        private World generatePond(World world, int originX, int originY, int width, int height, int sizeLimit, int densityLimit, Random random)
        {
            Vector2 origin = new Vector2(originX, originY);

            // Place inital water tile
            world.tiles[(int)origin.X, (int)origin.Y, 8] = Tile.tileWater.id;
            
            for (int density = 0; density < densityLimit; density++)
            {
                // Generate a "branch"
                Vector2 position = new Vector2(origin.X, origin.Y);
                for (int size = 0; size < sizeLimit; size++)
                {
                    position = Util.MoveInRandomDirection(position, random);
                    if (world.InBounds(position))
                        world.tiles[(int)position.X, (int)position.Y, 8] = Tile.tileWater.id;
                }
            }

            return world;
        }

        public World generate(World world, int width, int height, Random random)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (random.NextDouble() < 0.001)
                        generatePond(world, x, y, width, height, 10, 24, random);
                }
            }

            return world;
        }
    }
}
