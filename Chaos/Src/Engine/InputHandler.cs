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

        static public bool Released { get; private set; }
        static public bool Pressed { get; private set; }
        static private Vector2 position;
        static private MouseState PreviousMouseState;
        static private KeyboardState PreviousKeyboardState;

        /// <summary>
        /// Updates the inputs.
        /// </summary>
        static public void Update(Game game, GraphicsDeviceManager graphics)
        {
            // Reset old states
            Pressed = false;
            Released = false;

            // Get new states
            KeyboardState currentKeyboardState = Keyboard.GetState();
            MouseState currentMouseState = Mouse.GetState();

            // Position
            position = new Vector2(currentMouseState.X, currentMouseState.Y);
            // Pressed
            if (currentMouseState.LeftButton == ButtonState.Pressed)
                Pressed = true;
            // Released
            else if (PreviousMouseState.LeftButton == ButtonState.Pressed)
                Released = true;
            // Esc - exit game
            if (currentKeyboardState.IsKeyDown(Keys.Escape))
                game.Exit();

            PreviousMouseState = currentMouseState;
            PreviousKeyboardState = currentKeyboardState;
        }
    }
}