using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Citysim.Map.Tiles
{
    public class TileWater : TileAnimated
    {
        public TileWater(int id) : base(id)
        {
            frames = new Texture2D[3];
            fps = 5;
        }
        
        public override void LoadTexture()
        {
            frames[0] = Citysim.instance.Content.Load<Texture2D>("tiles/water.1");
            frames[1] = Citysim.instance.Content.Load<Texture2D>("tiles/water.2");
            frames[2] = Citysim.instance.Content.Load<Texture2D>("tiles/water.3");
        }
    }
}
