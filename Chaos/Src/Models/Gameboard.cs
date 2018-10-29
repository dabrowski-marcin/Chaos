using System;
using System.Threading;
using Chaos.Src.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Chaos.Models
{
    public class Gameboard : IGameboard
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
                    Tileset[width, height].Texture = content.Load<Texture2D>("void");
                }
            }

            PlaceWizard();
            Thread.Sleep(100);
            PlaceWizard();
        }

        public void PlaceWizard()
        {
            var randX = new Random().Next(0, 10);
            var randY = new Random().Next(0, 10);

            var pos = new Point(randX, randY);
            Tileset[pos.X, pos.Y].Texture = content.Load<Texture2D>("Wizard1");
            Tileset[pos.X, pos.Y].Occupant = new Creature
            {
                Name = $"TestWizard {randX} / {randY}"
            };

        }

        public void GenerateVoidTile(Point point)
        {
            Tileset[point.X / 48, point.Y / 48] = new Tile();
            Tileset[point.X / 48, point.Y / 48].Texture = content.Load<Texture2D>("void");
        }

        public void Move(Point start, Point end)
        {
            var startX = start.X / 48;
            var startY = start.Y / 48;

            var endX = end.X / 48;
            var endY = end.Y / 48;

            Tileset[endX, endY].Occupant = Tileset[startX, startY].Occupant;
            Tileset[endX, endY].Texture = Tileset[startX, startY].Texture;
            Tileset[startX, startY].Occupant = null;
            Tileset[startX, startY].Texture = content.Load<Texture2D>("void");
        }

        public Tile GetTile(Point pt)
        {
            return Tileset[pt.X / 48, pt.Y / 48];
        }
    }
}