using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Citysim
{
    public static class Util
    {
        /// <summary>
        /// Moves the vector position uniformly in one direction.
        /// Does not do diagonals.
        /// </summary>
        /// <param name="origin">Orgin vector position</param>
        /// <param name="random">Random object to decide which direction to move</param>
        /// <returns></returns>
        public static Vector2 MoveInRandomDirection(Vector2 origin, Random random)
        {
            switch (random.Next(0, 4))
            {
                case 0:
                    origin.X += 1;
                    break;
                case 1:
                    origin.X -= 1;
                    break;
                case 2:
                    origin.Y += 1;
                    break;
                case 3:
                    origin.Y -= 1;
                    break;
            }

            return origin;
        }
    }
}
