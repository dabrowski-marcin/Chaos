using Chaos.Src.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Chaos.Engine;
using Chaos.Models;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace Chaos
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Gameboard gb;
        private GameboardActionHandler handler;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gb = new Gameboard(GraphicsDevice, spriteBatch, Content);
            gb.GenerateEmptyGameboard();
            handler = new GameboardActionHandler(gb);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                GetContent(Mouse.GetState().Position);
            }

//            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))

         //       base.Update(gameTime);
        }

        private void GetContent(Point point)
        {
            // 576x576
            if (PointBetweenValues(point, 0, 576))
            {
                var tile = gb.GetTile(point);
                handler.Action(tile);
//                if (tile.Occupant == null)
//                {
//                    MessageBox.Show($"Tile: {tile.Position.X} / {tile.Position.Y} Empty: {tile.IsEmpty}");
//                }

//                else
//                {
//                    MessageBox.Show($"Tile: {tile.Position.X} / {tile.Position.Y} Occupant: {tile.Occupant.Name}");
//                }

                return;
            }
        }

        private bool PointBetweenValues(Point point, int minVal, int maxVal)
        {
            return point.X >= minVal && point.Y >= minVal && point.X <= maxVal && point.Y <= maxVal;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>\
        protected override void Draw(GameTime gameTime)
        {
            graphics.PreferredBackBufferWidth = 1024;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 768;   // set this value to the desired height of your window
            graphics.ApplyChanges();
            
            GraphicsDevice.Clear(Color.CornflowerBlue);


            // TODO: Add your drawing code here
            foreach (var tile in gb.Tileset)
            {
                spriteBatch.Begin();
                var position = new Vector2(tile.Rectangle.Left, tile.Rectangle.Top);
                spriteBatch.Draw(tile.Texture, position);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
}
