namespace Chaos.Src.Models
{
    public interface ISpellboard
    {
        SpellTile[,] SpellTileset { get; }
        void GenerateEmptySpellboard();
    }
}