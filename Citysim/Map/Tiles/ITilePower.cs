using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citysim.Map.Tiles
{
    interface ITilePower
    {
        /// <summary>
        /// Produce or consume power here.
        /// Negative number for consuption, positive number for production.
        /// Measured in MW.
        /// </summary>
        /// <returns>Power production/consuption</returns>
        int EnergyUsage();
    }
}
