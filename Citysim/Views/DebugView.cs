using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.BitmapFonts;

namespace Citysim.Views
{
    public class DebugView : IView
    {
        public void LoadContent(ContentManager content)
        {
        }

        public void Render(SpriteBatch spriteBatch, Citysim game, GameTime gameTime)
        {
            if (!game.debug)
                return; // Debug mode disabled

            spriteBatch.DrawString(game.font, "Citysim " + Citysim.VERSION, new Vector2(10, 10), Color.Black);
        }

        public void Update(Citysim game, GameTime gameTime)
        {
            // F3 toggles debug mode
            if (KeyboardHelper.IsKeyPressed(Keys.F3))
                game.debug = !game.debug;
        }
    }
}
