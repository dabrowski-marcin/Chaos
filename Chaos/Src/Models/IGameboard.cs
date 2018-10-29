using Chaos.Src.Models;
using Microsoft.Xna.Framework;

namespace Chaos.Models
{
    public interface IGameboard
    {
        void GenerateEmptyGameboard();
        void GenerateVoidTile(Point point);
        Tile GetTile(Point pt);
        void Move(Point start, Point end);
        void PlaceWizard();
    }
}