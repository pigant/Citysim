using System;
using Citysim.Map.Tiles;

namespace Citysim.Map
{
    public class TileRegistry
    {
        /// <summary>
        /// Array containing all the registered tiles.
        /// </summary>
        protected ITile[] tiles = new ITile[255];

        /// <summary>
        /// Register a new tile in the registry. Should be done during initialisation stage of game.
        /// </summary>
        /// <param name="tile">Instance of tile to register</param>
        public void Register(ITile tile)
        {
            if (tiles[tile.id] != null) {
                throw new TileIdConflictException();
            }

            tiles[tile.id] = tile;
        }

        /// <summary>
        /// Get a particular tiles instance.
        /// </summary>
        /// <param name="id">Tile ID</param>
        /// <returns>Tile instance</returns>
        public ITile GetTile(int id)
        {
            return tiles[id];
        }

        /// <summary>
        /// Load textures for all the registered tiles.
        /// </summary>
        public void LoadTextures()
        {
            foreach (ITile tile in tiles)
            {
                if (tile != null)
                    tile.LoadTexture();
            }
        }
    }

    /// <summary>
    /// Tile ID conflicted with another tile ID.
    /// </summary>
    class TileIdConflictException : Exception
    {
        
    }
}
