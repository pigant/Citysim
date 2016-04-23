using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Citysim.Map.Tiles;

namespace Citysim.Map.Generators
{
    class DirtGenerator : IGenerator
    {
        private World generateDirtPatch(World world, int originX, int originY, int width, int height, int sizeLimit, int densityLimit, Random random)
        {
            Vector2 origin = new Vector2(originX, originY);

            // Place inital dirt tile
            world.tiles[(int)origin.X, (int)origin.Y, 8] = Tile.tileDirt.id;

            for (int density = 0; density < densityLimit; density++)
            {
                // Generate a "branch"
                Vector2 position = new Vector2(origin.X, origin.Y);
                for (int size = 0; size < sizeLimit; size++)
                {
                    position = Util.MoveInRandomDirection(position, random);
                    if (world.InBounds(position))
                        world.tiles[(int)position.X, (int)position.Y, 8] = Tile.tileDirt.id;
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
                    if (random.NextDouble() < 0.0035)
                        generateDirtPatch(world, x, y, width, height, 3, 8, random);
                }
            }

            return world;
        }
    }
}
