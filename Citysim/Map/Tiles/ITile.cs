using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Citysim.Map.Tiles
{
    public interface ITile
    {
        int id { get; set; }

        /// <summary>
        /// Load the texture from the texture path variable.
        /// This is called automatically once the game is ready to load assets.
        /// </summary>
        void LoadTexture();

        /// <summary>
        /// Return the texture to be displayed on the map.
        /// </summary>
        /// <param name="gameTime">Game time provided for animation</param>
        /// <returns></returns>
        Texture2D GetTexture(GameTime gameTime);
    }
}
