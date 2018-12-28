using Chaos.Engine;
using Chaos.Src.Models;
using Microsoft.Xna.Framework;
using System;

namespace Chaos.Models
{
    public class Gameboard : IGameboard
    {
        public Gameboard()
        {
        }
        public const int GAMEBOARD_WIDTH = 12;
        public const int GAMEBOARD_HEIGHT = 12;
        private Tile[,] _tileset = new Tile[GAMEBOARD_WIDTH, GAMEBOARD_HEIGHT];

        public Tile[,] Tileset
        {
            get { return _tileset; }
        }

        public void GenerateEmptyGameboard()
        {
            for (int width = 0; width < GAMEBOARD_WIDTH; width++)
            {
                for (int height = 0; height < GAMEBOARD_HEIGHT; height++)
                {

                    _tileset[width, height] = new Tile();
                    _tileset[width, height].Position = new Point(width * 48, height * 48);
                }
            }

            PlaceWizard(0);
            PlaceWizard(2);
        }

        // TODO: Remove
        public void PlaceWizard(int id)
        {
            var randX = new Random().Next(0, 10);
            var randY = new Random().Next(0, 10);

            var pos = new Point(randX, randY);
            _tileset[pos.X, pos.Y].Occupant = new Creature
            {
                Name = $"Pegasus",
                CurrentMovement = 2,
                Owner = PhaseHandler.ActivePlayers[id]
            };

        }

        public void GenerateVoidTile(Point point)
        {
            _tileset[point.X / 48, point.Y / 48] = new Tile();
        }

        public void Move(Point start, Point end)
        {
            var startX = start.X / 48;
            var startY = start.Y / 48;

            var endX = end.X / 48;
            var endY = end.Y / 48;

            _tileset[endX, endY].Occupant = _tileset[startX, startY].Occupant;
            _tileset[startX, startY].Occupant = null;
        }

        public Tile GetTile(Point pt)
        {
            return _tileset[pt.X / 48, pt.Y / 48];
        }
    }
}