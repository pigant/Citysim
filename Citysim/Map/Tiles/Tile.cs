using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Citysim.Map.Tiles
{
    /// <summary>
    /// Tile class.
    /// </summary>
    public class Tile : ITile
    {
        /// <summary>
        /// Tile ID
        /// </summary>
        public int id;

        int ITile.id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public Point tileSize = new Point(1, 1);

        protected Texture2D texture;

        /// <summary>
        /// Texture path within game content.
        /// </summary>
        protected string texturePath = "tiles/error";

        /// <summary>
        /// Tile size (measured in tiles) for this tile.
        /// A standard tile is 1,1 (a single tile).
        /// </summary>
        public virtual Point GetTileSize()
        {
            return this.tileSize;
        }

        /// <summary>
        /// Load the texture from the texture path variable.
        /// This is called automatically once the game is ready to load assets.
        /// </summary>
        public virtual void LoadTexture()
        {
            this.texture = Citysim.instance.Content.Load<Texture2D>(this.texturePath);
        }

        /// <summary>
        /// Return the texture to be displayed on the map.
        /// </summary>
        /// <param name="gameTime">Game time provided for animation</param>
        /// <returns></returns>
        public virtual Texture2D GetTexture(GameTime gameTime)
        {
            return this.texture;
        }

        /// <summary>
        /// Set texture name (texture path).
        /// </summary>
        /// <param name="textureName">Texture path</param>
        /// <returns></returns>
        public virtual Tile SetTextureName(string textureName)
        {
            this.texturePath = textureName;
            return this;
        }

        public Tile(int id)
        {
            this.id = id;
        }

        #region TileDefinitions
        public static Tile tileGrass;
        public static Tile tileDirt;
        public static Tile tileFlowers;
        public static Tile tileWater;
        public static Tile tileLargeTest;
        public static Tile tileNuclearReactor;

        public static void Register(TileRegistry tileRegistry)
        {
            tileGrass = new Tile(1).SetTextureName("tiles/grass");
            tileDirt = new Tile(2).SetTextureName("tiles/dirt");
            tileFlowers = new Tile(3).SetTextureName("tiles/flowers");
            tileWater = new TileWater(4);
            tileLargeTest = new TileLargeTest(5);
            tileNuclearReactor = new TileNuclearPlant(6);

            tileRegistry.Register(tileGrass);
            tileRegistry.Register(tileDirt);
            tileRegistry.Register(tileFlowers);
            tileRegistry.Register(tileWater);
            tileRegistry.Register(tileLargeTest);
            tileRegistry.Register(tileNuclearReactor);
        }
        #endregion
    }
}
