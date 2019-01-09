using System.Linq;
using Chaos.Src.Helpers;
using Microsoft.Xna.Framework;
using NLog;

namespace Chaos.Src.Models
{
    public class Spellboard : ISpellboard
    {
        public const int SPELLBOARD_WIDTH = 2;
        public const int SPELLBOARD_HEIGHT = 10;
        public const int GAMEBOARD_OFFSET_WIDTH = 577;
        public const int GAMEBOARD_OFFSET_HEIGHT = 48;

        private static readonly Logger Log = LoggerController.Spellboard;

        private SpellTile[,] _spellTileset = new SpellTile[SPELLBOARD_WIDTH, SPELLBOARD_HEIGHT];

        public SpellTile[,] SpellTileset
        {
            get { return _spellTileset; }
        }

        public void GenerateEmptySpellboard()
        {
            for (int width = 0; width < SPELLBOARD_WIDTH; width++)
            {
                for (int height = 0; height < SPELLBOARD_HEIGHT; height++)
                {

                    _spellTileset[width, height] = new SpellTile();
                    _spellTileset[width, height].Position = new Point((width * 48) + GAMEBOARD_OFFSET_WIDTH, (height * 48) + GAMEBOARD_OFFSET_HEIGHT);
                }
            }

        }

        public void DrawPlayerSpells(Player player)
        {
            var spells = player.Spells.Take(20);
            var spellIndex = 0;
            for (int width = 0; width < SPELLBOARD_WIDTH; width++)
            {
                for (int height = 0; height < SPELLBOARD_HEIGHT; height++)
                {
                    _spellTileset[width, height].Spell = spells.ElementAt(spellIndex++);
                    _spellTileset[width, height].Position = new Point((width * 48) + GAMEBOARD_OFFSET_WIDTH, (height * 48) + GAMEBOARD_OFFSET_HEIGHT);
                }
            }
        }

        public SpellTile GetSpellTile(Point pt)
        {
            return _spellTileset[(pt.X - GAMEBOARD_OFFSET_WIDTH) / 48, (pt.Y - GAMEBOARD_OFFSET_HEIGHT) / 48];
        }
    }
}