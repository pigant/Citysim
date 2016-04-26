using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Citysim.Map.Generators
{
    public class Generator
    {
        protected IGenerator[] generators = new IGenerator[127];

        /// <summary>
        /// Register a new terrain generator.
        /// </summary>
        /// <param name="generator"></param>
        public void Register(IGenerator generator)
        {
            for (int i = 0; i < generators.Length; i++)
            {
                if (generators[i] == null)
                {
                    generators[i] = generator;
                    return;
                }
            }

            throw new Exception("Not enough generator IDs to register new generator");
        }

        /// <summary>
        /// Apply generators to a world.
        /// </summary>
        /// <param name="world">World to generate map for</param>
        /// <param name="width">Width of world</param>
        /// <param name="height">Height of world. Not depth.</param>
        /// <param name="random">Random object. Allows for a world seed.</param>
        public World Generate(World world, int width, int height, Random random)
        {
            // Create new world
            world.tiles = new int[width, height, 16];
            world.tileOrigins = new Vector3?[width, height, 16];
            world.width = width;
            world.height = height;

            // Run all generators.
            foreach (IGenerator generator in generators)
            {
                if (generator != null)
                    world = generator.generate(world, world.width, world.height, random);
            }

            return world;
        }


        public static void RegisterGenerators(Generator generator)
        {
            generator.Register(new GrassGenerator());
            generator.Register(new DirtGenerator());
            generator.Register(new WaterGenerator());
            generator.Register(new FlowersGenerator());
        }
    }
}
