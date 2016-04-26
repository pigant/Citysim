using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Citysim.Map.Tiles
{
    class TileLargeTest : Tile
    {
        public TileLargeTest(int id) : base(id)
        {
            this.SetTextureName("tiles/64x64test");
            this.tileSize = new Point(2, 2);
        }
    }
}
