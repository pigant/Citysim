using System;

namespace Citysim.Map.Generators
{
    public interface IGenerator
    {
        /// <summary>
        /// Generate terrain elements to world
        /// </summary>
        /// <param name="world">World object</param>
        /// <param name="random">Random generator</param>
        World generate(World world, int width, int height, Random random);
    }
}
