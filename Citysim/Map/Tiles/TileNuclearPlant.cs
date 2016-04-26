using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Citysim.Map.Tiles
{
    class TileNuclearPlant : Tile, ITilePower
    {
        public TileNuclearPlant(int id) : base(id)
        {
            this.tileSize = new Point(2, 2);
            this.SetTextureName("tiles/nuclear");
        }

        public int EnergyUsage()
        {
            return 500; // produces 500 megawatts
        }
    }
}
