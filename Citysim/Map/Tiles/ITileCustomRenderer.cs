using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Citysim.Map.Tiles
{
    interface ITileCustomRenderer
    {
        /// <summary>
        /// Where the tile can do the custom rendering.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="game"></param>
        /// <param name="position"></param>
        void Render(SpriteBatch spriteBatch, Citysim game, Vector2 position);
    }
}
