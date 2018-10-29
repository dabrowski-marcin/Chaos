using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Chaos.Src.Models
{
    public class Gameboard
    {
        private GraphicsDevice device;
        private SpriteBatch spriteBatch;
        private ContentManager content;
        public Gameboard(GraphicsDevice device, SpriteBatch spriteBatch, ContentManager contentManager)
        {
            this.device = device;
            this.spriteBatch = spriteBatch;
            this.content = contentManager;
        }
        public const int GAMEBOARD_WIDTH = 12;
        public const int GAMEBOARD_HEIGHT = 12;
        public Tile[,] Tileset = new Tile[GAMEBOARD_WIDTH, GAMEBOARD_HEIGHT];

        public void GenerateEmptyGameboard()
        {
            for (int width = 0; width < GAMEBOARD_WIDTH; width++)
            {
                for (int height = 0; height < GAMEBOARD_HEIGHT; height++)
                {

                    Tileset[width, height] = new Tile();
                    Tileset[width, height].Position = new Point(width * 48, height * 48);
                    Tileset[width, height].IsEmpty = true;
                    Tileset[width, height].Texture = content.Load<Texture2D>("void");
                }
            }

            PlaceWizard();
            PlaceWizard();
        }

        public void PlaceWizard()
        {
            var randX = new Random().Next(0, 10);
            var randY = new Random().Next(0, 10);

            var pos = new Point(randY, randX);
            Tileset[pos.Y, pos.X].Texture = content.Load<Texture2D>("Wizard1");
            Tileset[pos.Y, pos.X].Occupant = new Creature
            {
                Name = $"TestWizard {randX} / {randY}"
            };

        }

        public Tile GetTile(Point pt)
        {
            return Tileset[pt.X / 48, pt.Y / 48];
        }
    }
}