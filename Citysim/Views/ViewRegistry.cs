using System;
using Citysim;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Citysim.Views
{
    public class ViewRegistry
    {
        protected IView[] views = new IView[32];

        /// <summary>
        /// Register a new view.
        /// </summary>
        /// <param name="view"></param>
        public void Register(IView view)
        {
            for (int i = 0; i < views.Length; i++)
            {
                if (views[i] == null)
                {
                    views[i] = view;
                    return;
                }
            }
        }

        /// <summary>
        /// Render views.
        /// This should be run every draw loop.
        /// </summary>
        /// <param name="game">Game instance</param>
        /// <param name="spriteBatch">Spritebatch to draw to</param>
        /// <param name="gameTime">Game time</param>
        public void Render(Citysim game, SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (IView view in views)
            {
                if (view != null)
                    view.Render(spriteBatch, game, gameTime);
            }
        }

        /// <summary>
        /// Update views.
        /// Should be run every update loop.
        /// </summary>
        /// <param name="game">Game instance</param>
        /// <param name="gameTime">Game time</param>
        public void Update(Citysim game, GameTime gameTime)
        {
            foreach (IView view in views)
            {
                if (view != null)
                    view.Update(game, gameTime);
            }
        }


        public static void RegisterViews(ViewRegistry registry)
        {
            registry.Register(new MapView());
            registry.Register(new DebugView());
        }
    }
}
