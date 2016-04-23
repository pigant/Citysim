using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.BitmapFonts;

namespace Citysim.Views
{
    class CityInfoView : IView
    {
        public void LoadContent(ContentManager content)
        {
        }

        private List<string[]> stats = new List<string[]>();

        private void AddStat(string label, string value)
        {
            string[] stat = new string[2];
            stat[0] = label;
            stat[1] = value;
            stats.Add(stat);
        }

        public void Render(SpriteBatch spriteBatch, Citysim game, GameTime gameTime)
        {
            int width = game.GraphicsDevice.Viewport.Width;
            int height = game.GraphicsDevice.Viewport.Height;
            float scale = 1.0F;

            int fontHeight = (int)(game.gameFont.MeasureString("Aap123#").Y);

            AddStat("Cash", "$" + game.city.cash.ToString() + "k");

            // Draw stats
            foreach (string[] stat in stats)
            {
                string label = stat[0];
                string value = stat[1];

                int stringFullSize = (int)(game.gameFont.MeasureString(label + ": " + value).X * scale);
                int labelSize = (int)(game.gameFont.MeasureString(label + ": ").X * scale);
                Vector2 labelDrawPos = new Vector2(width - stringFullSize - 10, 10);
                Vector2 valueDrawPos = new Vector2(width - (stringFullSize - labelSize) - 10, 10);

                spriteBatch.DrawString(game.gameFont, label + ": ", labelDrawPos, Color.Black);
                spriteBatch.DrawString(game.gameFont, value, valueDrawPos, Color.Yellow);
            }
        }

        public void Update(Citysim game, GameTime gameTime)
        {
            
        }
    }
}
