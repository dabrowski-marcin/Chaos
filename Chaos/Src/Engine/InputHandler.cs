using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Chaos.Src.Engine
{
    public class InputHandler
    {
        static public Vector2 Position
        {
            get { return position; }
        }

        static public bool LeftButtonReleased { get; private set; }
        static public bool LeftButtonPressed { get; private set; }
        static public bool RightButtonPressed { get; private set; }
        static public bool RightButtonReleased { get; private set; }
        static private Vector2 position;
        static private MouseState PreviousMouseState;
        static private KeyboardState PreviousKeyboardState;

        /// <summary>
        /// Updates the inputs.
        /// </summary>
        static public void Update(Game game, GraphicsDeviceManager graphics)
        {
            // Reset old states
            LeftButtonPressed = false;
            LeftButtonReleased = false;
            RightButtonPressed = false;
            RightButtonReleased = false;

            // Get new states
            KeyboardState currentKeyboardState = Keyboard.GetState();
            MouseState currentMouseState = Mouse.GetState();

            // Position
            position = new Vector2(currentMouseState.X, currentMouseState.Y);
            // Pressed
            if (currentMouseState.LeftButton == ButtonState.Pressed)
                LeftButtonPressed = true;
            // Released
            else if (PreviousMouseState.LeftButton == ButtonState.Pressed)
                LeftButtonReleased = true;

            if (currentMouseState.RightButton == ButtonState.Pressed)
                RightButtonPressed = true;
            // Released
            else if (PreviousMouseState.RightButton == ButtonState.Pressed)
                RightButtonReleased = true;
            // Esc - exit game
            if (currentKeyboardState.IsKeyDown(Keys.Escape))
                game.Exit();

            PreviousMouseState = currentMouseState;
            PreviousKeyboardState = currentKeyboardState;
        }
    }
}