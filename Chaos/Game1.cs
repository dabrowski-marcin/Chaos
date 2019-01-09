using System;
using Autofac;
using Chaos.Engine;
using Chaos.Models;
using Chaos.Src.Engine;
using Chaos.Src.Helpers;
using Chaos.Src.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Chaos.Src.Engine.Handlers;

namespace Chaos
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private IGameboard gameboard;
        private ISpellboard spellboard;

        private IGameEventHandler gameEventHandler;
        private IInfoStringHandler infoStringHandler;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            StaticManager.ContentManager = Content;
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
            List<Player> tempPlayers = new List<Player>();
            tempPlayers.Add(new Player { Index = 0, IsDead = false, IsHuman = true, Name = "player1", Points = 0 });
            tempPlayers.Add(new Player { Index = 1, IsDead = true, IsHuman = true, Name = "player2", Points = 0 });
            tempPlayers.Add(new Player { Index = 2, IsDead = false, IsHuman = true, Name = "player3", Points = 0 });

            StateGlobals.Players = tempPlayers;
            PhaseHandler.CurrentPlayer = StateGlobals.Players[0];

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gameboard = ServiceContainer.Container.Resolve<IGameboard>();
            spellboard = ServiceContainer.Container.Resolve<ISpellboard>();
            gameboard.GenerateEmptyGameboard();
            spellboard.GenerateEmptySpellboard();

            gameEventHandler = ServiceContainer.Container.Resolve<IGameEventHandler>();
            infoStringHandler = ServiceContainer.Container.Resolve<IInfoStringHandler>();

            SpellsGenerator sg = new SpellsGenerator();
            sg.GenerateSpells();
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
            StateGlobals.GameTime = gameTime;
            InputHandler.Update(this, graphics);
            gameEventHandler.Update();
            base.Update(gameTime);
        }

        private void DrawScreenElements(GameTime gameTime)
        {
            DrawGameboard(gameTime);
            DrawSpellBoard();
            DrawEndTurnButton();
        }

        private void DrawGameboard(GameTime gameTime)
        {
            foreach (var tile in gameboard.Tileset)
            {
                tile.Animation?.Draw(spriteBatch);
                tile.Animation?.Update(gameTime);
                tile.Animate(gameTime);
            }
        }

        private void DrawSpellBoard()
        {
            if (PhaseHandler.GamePhase == Phase.SpellPicking)
            {
                spellboard.DrawPlayerSpells(PhaseHandler.CurrentPlayer);
                foreach (var tile in spellboard.SpellTileset)
                {
                    spriteBatch.Begin();
                    var position = new Vector2(tile.Rectangle.Left, tile.Rectangle.Top);
                    spriteBatch.Draw(tile.Texture, position);
                    spriteBatch.End();
                }
            }
        }

        private void DrawEndTurnButton()
        {
            spriteBatch.Begin();
            var rectangle = new Rectangle(new Point(577, 528), new Point(47, 96));
            var position = new Vector2(rectangle.Left, rectangle.Top);
            spriteBatch.Draw(StaticManager.ContentManager.Load<Texture2D>("GUI/turn"), position);
            spriteBatch.End();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>\
        protected override void Draw(GameTime gameTime)
        {
            graphics.PreferredBackBufferWidth = 800;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 615;   // set this value to the desired height of your window
            graphics.ApplyChanges();
            
            GraphicsDevice.Clear(Color.DarkOrchid);

            DrawScreenElements(gameTime);
            DrawEndTurnButton();
            infoStringHandler.UpdateFieldUnderCursorInformation(spriteBatch);
            infoStringHandler.UpdateMovesLeftInformation(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
