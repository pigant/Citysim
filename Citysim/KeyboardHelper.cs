using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Citysim
{
    public static class KeyboardHelper
    {
        private static KeyboardState keyboardState;
        private static KeyboardState oldKeyboardState;

        public static void Update()
        {
            oldKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            if (oldKeyboardState == null)
                oldKeyboardState = keyboardState;
        }

        public static bool IsKeyDown(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }

        public static bool IsKeyUp(Keys key)
        {
            return keyboardState.IsKeyUp(key);
        }

        public static Keys[] GetPressedKeys()
        {
            return keyboardState.GetPressedKeys();
        }

        public static bool IsKeyPressed(Keys key)
        {
            return (keyboardState.IsKeyUp(key) && oldKeyboardState.IsKeyDown(key));
        }
    }
}
