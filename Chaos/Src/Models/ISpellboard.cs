using Microsoft.Xna.Framework;

namespace Chaos.Src.Models
{
    public interface ISpellboard
    {
        SpellTile[,] SpellTileset { get; }
        void GenerateEmptySpellboard();
        void DrawPlayerSpells(Player player);
        SpellTile GetSpellTile(Point pt);
    }
}