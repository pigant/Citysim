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

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Citysim " + Citysim.VERSION);
            sb.AppendLine("Map size " + game.city.world.height + "x" + game.city.world.width);
            sb.AppendLine("Camera: " + game.camera.position.X + "," + game.camera.position.Y + " [" + game.camera.speed + "]");
            sb.AppendLine("Absolute Mouse Position: " + game.camera.hoveringExact.X + "," + game.camera.hoveringExact.Y);
            sb.AppendLine("Selected Tile: " + game.camera.hovering.X + "," + game.camera.hovering.Y);

            spriteBatch.DrawString(game.font, sb, new Vector2(10, 10), Color.Black, 0F, new Vector2(0,0), 0.5F, SpriteEffects.None, 1.0F);
        }

        public void Update(Citysim game, GameTime gameTime)
        {
            // F3 toggles debug mode
            if (KeyboardHelper.IsKeyPressed(Keys.F3))
                game.debug = !game.debug;
        }
    }
}
