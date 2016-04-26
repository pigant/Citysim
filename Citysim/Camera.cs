using System;
using Citysim.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Citysim
{
    public class Camera
    {
        public Vector2 position = new Vector2(0, 0);

        public int speed = 5;

        public int tileSize = 64;

        // Current X/Y coords where the mouse is hovering.
        public Vector2 hovering = new Vector2(0, 0);

        // Current X/Y coords where the mouse is hovering (exact to the decimal).
        public Vector2 hoveringExact = new Vector2(0, 0);

        public void Update(Citysim game, GameTime gameTime)
        {
            // Handle movement.
            if (KeyboardHelper.IsKeyDown(Keys.LeftShift))
                game.camera.speed = 15;
            else
                game.camera.speed = 7;

            int speed = game.camera.speed;

            if (KeyboardHelper.IsKeyDown(Keys.W))
                game.camera.position.Y += speed;
            if (KeyboardHelper.IsKeyDown(Keys.A))
                game.camera.position.X += speed;
            if (KeyboardHelper.IsKeyDown(Keys.S))
                game.camera.position.Y -= speed;
            if (KeyboardHelper.IsKeyDown(Keys.D))
                game.camera.position.X -= speed;

            // Handle mouse.
            MouseState mouseState = Mouse.GetState();
            hoveringExact.X = mouseState.Position.X - game.camera.position.X;
            hoveringExact.Y = mouseState.Position.Y - game.camera.position.Y;

            hovering.X = (int)Math.Floor(hoveringExact.X / tileSize);
            hovering.Y = (int)Math.Floor(hoveringExact.Y / tileSize);
        }
    }
}
