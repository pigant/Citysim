using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Citysim.Map.Tiles
{
    public class TileAnimated : Tile
    {
        /// <summary>
        /// Array of frames to animate. Make sure the size of the array is equal to how many frames there are.
        /// </summary>
        protected Texture2D[] frames;

        /// <summary>
        /// FPS to run animation at. Water runs animates at 5FPS.
        /// </summary>
        protected int fps = 5;

        public TileAnimated(int id) : base(id)
        {
        }

        public override Texture2D GetTexture(GameTime gameTime)
        {
            int frame = (int)Math.Floor(gameTime.TotalGameTime.TotalSeconds * fps) % frames.Length;
            return frames[frame];
        }
    }
}
