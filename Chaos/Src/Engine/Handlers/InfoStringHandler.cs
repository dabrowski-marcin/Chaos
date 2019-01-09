using System;
using Autofac;
using Chaos.Engine;
using Chaos.Models;
using Chaos.Src.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chaos.Src.Engine.Handlers
{
    public class InfoStringHandler : IInfoStringHandler
    {
        private IGameboardHandler gameboardHandler;
        private IGameboard gameboard = ServiceContainer.Container.Resolve<IGameboard>();

        private SpriteBatch spriteBatch;

        public InfoStringHandler(IGameboardHandler gameboardHandler)
        {
            this.gameboardHandler = gameboardHandler;
        }


        public void UpdateFieldUnderCursorInformation(SpriteBatch spriteBatch)
        {
            var point = InputHandler.Position;
            var indX = Math.Floor(point.X / 48);
            var indY = Math.Floor(point.Y / 48);

            if (indX > 11 || indX < 0 || indY > 11 || indY < 0)
            {
            }
            else
            {
                var tile = this.gameboard.Tileset[(int)indX, (int)indY];
                string ownerName = "nobody";
                if (tile.Occupant != null)
                {
                    ownerName = tile.Occupant.Owner.Name;
                }
                var entityname = tile.Name;
                spriteBatch.Begin();
                spriteBatch.DrawString(StaticManager.ContentManager.Load<SpriteFont>("Fonts/Font"), $"{entityname} ({ownerName})", new Vector2(1, 595), Color.LightGreen);
                spriteBatch.End();
            }
        }

        public void UpdateMovesLeftInformation(SpriteBatch spriteBatch)
        {
            if (gameboardHandler.SelectedTile != null)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(StaticManager.ContentManager.Load<SpriteFont>("Fonts/Font"), $"Moves: {gameboardHandler.SelectedTile.Occupant.CurrentMovement}/{gameboardHandler.SelectedTile.Occupant.MaxMovement}", new Vector2(1, 580), Color.LightGreen);
                spriteBatch.End();
            }
        }
    }

    public interface IInfoStringHandler
    {
        void UpdateFieldUnderCursorInformation(SpriteBatch spriteBatch);
        void UpdateMovesLeftInformation(SpriteBatch spriteBatch);
    }
}