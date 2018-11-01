using Microsoft.Xna.Framework;

namespace Chaos.Src.Models
{
    public class Spellboard : ISpellboard
    {
        public const int SPELLBOARD_WIDTH = 2;
        public const int SPELLBOARD_HEIGHT = 10;
        public const int GAMEBOARD_OFFSET_WIDTH = 577;
        public const int GAMEBOARD_OFFSET_HEIGHT = 48;

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
    }
}