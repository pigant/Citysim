using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Citysim.Views
{
    public interface IView
    {
        /// <summary>
        /// Allow view to load any resources.
        /// </summary>
        /// <param name="content"></param>
        void LoadContent(ContentManager content);

        /// <summary>
        /// Render whatever neccesary to the spritebatch.
        /// Do not call spriteBatch.Begin() or spriteBatch.End().
        /// </summary>
        /// <param name="spriteBatch">Sprite batch to draw to</param>
        /// <param name="game">Game instance for access to current state</param>
        /// <param name="gameTime">Game time</param>
        void Render(SpriteBatch spriteBatch, Citysim game, GameTime gameTime);

        /// <summary>
        /// Runs during the update loop.
        /// Perform any update related code here.
        /// </summary>
        /// <param name="game">Game instance</param>
        /// <param name="gameTime">Game time</param>
        void Update(Citysim game, GameTime gameTime);
    }
}
